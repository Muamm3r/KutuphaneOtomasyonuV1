using iTextSharp.text;
using iTextSharp.text.pdf;
using KutuphaneOtomasyonu.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KutuphaneOtomasyonu
{
    public partial class OgrencileriRaporla : Form
    {
        KutuphaneContext db = new KutuphaneContext();

        public OgrencileriRaporla()
        {
            InitializeComponent();
            this.Load += OgrencileriRaporla_Load;
        }

        private void OgrencileriRaporla_Load(object sender, EventArgs e)
        {
            var now = DateTime.Now;

            var ogrenciler = db.Ogrencilers
    .Include(o => o.Sinif)
    .Include(o => o.KitapIslemleri)
        .ThenInclude(k => k.Kitap)
    .ToList();


            var rapor = ogrenciler
                .Select(o => new
                {
                    AdSoyad = o.Ad + " " + o.Soyad,
                    Sinif = o.Sinif.Seviye + "/" + o.Sinif.Sube,
                    o.Numara,
                    ToplamKitap = o.KitapIslemleri.Count,
                    TeslimEtmedigi = o.KitapIslemleri.Count(k => k.GeriAlinanTarih == null),
                    GecikenKitap = o.KitapIslemleri.Count(k =>
                        k.GeriAlinanTarih == null && (now - k.AlisTarihi).TotalDays > 15),
                    SonAldigiTarih = o.KitapIslemleri
                        .OrderByDescending(k => k.AlisTarihi)
                        .Select(k => (DateTime?)k.AlisTarihi)
                        .FirstOrDefault(),
                    // Ceza tablosuna göre kontrol
                    CezaDurumu = db.Cezalars.Any(c => c.OgrenciId == o.OgrenciId && c.Odendi == false) ? "Var" : "Yok"        })

                .ToList();

            dataGridOgrenciler.DataSource = rapor;
            StilUygula();
        }

        private void StilUygula()
        {
            dataGridOgrenciler.RowHeadersVisible = false;
            dataGridOgrenciler.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridOgrenciler.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridOgrenciler.DefaultCellStyle.SelectionBackColor = Color.DarkGreen;
            dataGridOgrenciler.DefaultCellStyle.SelectionForeColor = Color.White;
            dataGridOgrenciler.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(230, 255, 230);
            dataGridOgrenciler.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkGreen;
            dataGridOgrenciler.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridOgrenciler.EnableHeadersVisualStyles = false;
            dataGridOgrenciler.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10);
            dataGridOgrenciler.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 11, System.Drawing.FontStyle.Bold);
        }

        private void btnPdfAktar_Click(object sender, EventArgs e)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "PDF Dosyası|*.pdf";
            save.Title = "PDF olarak kaydet";
            save.FileName = "OgrenciRaporu.pdf";

            if (save.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (FileStream stream = new FileStream(save.FileName, FileMode.Create))
                    {
                        Document pdfDoc = new Document(PageSize.A4.Rotate(), 10f, 10f, 20f, 20f);
                        PdfWriter.GetInstance(pdfDoc, stream);
                        pdfDoc.Open();

                        string fontPath = Path.Combine(Application.StartupPath, "fonts", "arialuni.ttf");
                        BaseFont bfArialUni = BaseFont.CreateFont(fontPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                        iTextSharp.text.Font titleFont = new iTextSharp.text.Font(bfArialUni, 18f, iTextSharp.text.Font.BOLD);
                        iTextSharp.text.Font normalFont = new iTextSharp.text.Font(bfArialUni, 12f);

                        Paragraph baslik = new Paragraph("Öğrenci Raporları", titleFont)
                        {
                            Alignment = Element.ALIGN_CENTER,
                            SpacingAfter = 10f
                        };
                        pdfDoc.Add(baslik);

                        pdfDoc.Add(new Paragraph("Tarih: " + DateTime.Now.ToString("dd.MM.yyyy HH:mm"), normalFont));
                        pdfDoc.Add(new Paragraph("\n", normalFont));

                        PdfPTable table = new PdfPTable(dataGridOgrenciler.Columns.Count)
                        {
                            WidthPercentage = 100
                        };

                        foreach (DataGridViewColumn column in dataGridOgrenciler.Columns)
                        {
                            PdfPCell headerCell = new PdfPCell(new Phrase(column.HeaderText, normalFont))
                            {
                                BackgroundColor = new BaseColor(0, 128, 0),
                                HorizontalAlignment = Element.ALIGN_CENTER,
                                Padding = 5
                            };
                            table.AddCell(headerCell);
                        }

                        foreach (DataGridViewRow row in dataGridOgrenciler.Rows)
                        {
                            foreach (DataGridViewCell cell in row.Cells)
                            {
                                string value = cell.Value?.ToString() ?? "";
                                table.AddCell(new Phrase(value, normalFont));
                            }
                        }

                        pdfDoc.Add(table);
                        pdfDoc.Close();
                        stream.Close();
                    }

                    MessageBox.Show("PDF başarıyla oluşturuldu!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }
        }
    }
}
