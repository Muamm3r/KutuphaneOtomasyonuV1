using KutuphaneOtomasyonu.Models;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using ZXing;
using ZXing.Common;
using ZXing.Rendering;
using ZXing.Windows.Compatibility;

namespace KutuphaneOtomasyonu
{
    public partial class BarkodOlusturForm : Form
    {
        private List<(string KitapAdi, string RafNo, Image Barkod, string BarkodText)> barkodListesi
            = new List<(string, string, Image, string)>();

        public BarkodOlusturForm()
        {
            InitializeComponent();

            // Hata almamak için border style'ı sabitliyoruz.
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        // Eksik Load metodu eklendi
        private void BarkodOlusturForm_Load(object sender, EventArgs e)
        {
            
            
            
            
            // Gerekirse form yüklendiğinde işlemler buraya
        }

        private void btnBarkodOlustur_Click(object sender, EventArgs e)
        {
            barkodListesi.Clear();
            flpBarkodlar.Controls.Clear();

            using (var db = new KutuphaneContext())
            {
                var kitaplar = db.Kitaplars
                                 .Where(k => string.IsNullOrEmpty(k.Barkod))
                                 .ToList();

                if (kitaplar.Count == 0)
                {
                    MessageBox.Show("Barkodsuz kitap bulunamadı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                foreach (var kitap in kitaplar)
                {
                    string barkodVerisi = kitap.KitapId.ToString("D8");

                    var writer = new BarcodeWriter<Bitmap>
                    {
                        Format = BarcodeFormat.CODE_128,
                        Options = new EncodingOptions
                        {
                            Width = 300,
                            Height = 100,
                            Margin = 2
                        },
                        Renderer = new BitmapRenderer()
                    };

                    Image barkodImage = writer.Write(barkodVerisi);
                    kitap.Barkod = barkodVerisi;
                    db.SaveChanges();

                    barkodListesi.Add((kitap.KitapAdi, kitap.RafNo, barkodImage, barkodVerisi));

                    Panel kitapPanel = new Panel
                    {
                        Width = 320,
                        Height = 140,
                        Margin = new Padding(10),
                        BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
                    };

                    Label lbl = new Label
                    {
                        Text = $"{kitap.KitapAdi} (Raf No: {kitap.RafNo})",
                        Font = new Font("Arial", 9, FontStyle.Bold),
                        TextAlign = ContentAlignment.MiddleCenter,
                        Dock = DockStyle.Top,
                        Height = 20
                    };

                    PictureBox pb = new PictureBox
                    {
                        Image = barkodImage,
                        Dock = DockStyle.Fill,
                        SizeMode = PictureBoxSizeMode.Zoom
                    };

                    kitapPanel.Controls.Add(pb);
                    kitapPanel.Controls.Add(lbl);
                    flpBarkodlar.Controls.Add(kitapPanel);
                }
            }

            MessageBox.Show("Tüm barkodlar başarıyla oluşturuldu.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnPdfKaydet_Click(object sender, EventArgs e)
        {
            if (barkodListesi.Count == 0)
            {
                MessageBox.Show("Önce barkodları oluşturmalısınız.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            PdfDocument pdf = new PdfDocument();
            pdf.Info.Title = "Barkodlar";

            PdfPage page = pdf.AddPage();
            XGraphics gfx = XGraphics.FromPdfPage(page);
            int pageWidth = (int)page.Width;
            int pageHeight = (int)page.Height;

            int xLeft = 40;
            int xRight = pageWidth / 2 + 10;
            int y = 40;
            int labelHeight = 160;

            XFont fontTitle = new XFont("Arial", 10, XFontStyleEx.Bold);
            XFont fontCode = new XFont("Arial", 9, XFontStyleEx.Regular);

            for (int i = 0; i < barkodListesi.Count; i++)
            {
                var item = barkodListesi[i];
                int currentX = (i % 2 == 0) ? xLeft : xRight;

                string title = $"{item.KitapAdi} (Raf No: {item.RafNo})";
                gfx.DrawString(title, fontTitle, XBrushes.Black,
                    new XRect(currentX, y, 300, 20), XStringFormats.TopCenter);

                // DÜZELTME: MemoryStream'i using bloğu dışında tutuyoruz
                MemoryStream ms = new MemoryStream();
                item.Barkod.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                ms.Position = 0;

                XImage barcodeImage = XImage.FromStream(ms);
                gfx.DrawImage(barcodeImage, currentX, y + 20, 300, 80);

                // XImage kullanıldıktan sonra MemoryStream'i temizleyebiliriz
                barcodeImage.Dispose();
                ms.Dispose();

                if (i % 2 == 1)
                    y += labelHeight;

                if ((i % 2 == 1 && y + labelHeight > pageHeight - 100) || i == barkodListesi.Count - 1)
                {
                    if (i != barkodListesi.Count - 1)
                    {
                        page = pdf.AddPage();
                        gfx = XGraphics.FromPdfPage(page);
                        y = 40;
                    }
                }
            }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "PDF Dosyası (*.pdf)|*.pdf";
                sfd.FileName = "Barkodlar.pdf";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    pdf.Save(sfd.FileName);
                    MessageBox.Show("PDF başarıyla kaydedildi:\n" + sfd.FileName, "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            // PDF kaynaklarını temizle
            pdf.Dispose();
        }
    }
}
