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
    public partial class KitaplariRaporla : Form
    {
        KutuphaneContext db = new KutuphaneContext();

        public KitaplariRaporla()
        {
            InitializeComponent();
            this.Load += KitaplariRaporla_Load;
        }

        private void KitaplariRaporla_Load(object sender, EventArgs e)
        {
            try
            {
                var kitaplar = db.Kitaplars
    .Include(k => k.KitapIslemleri)
        .ThenInclude(i => i.Ogrenci)
    .ToList();


                // DÜZENLEME: RafNo ve ToplamAdet (KitapSayisi) alanları rapora eklendi.
                var rapor = kitaplar.Select(k => new
                {
                    Barkod = k.Barkod,
                    KitapAdi = k.KitapAdi,
                    Yazar = k.Yazar,
                    RafNo = k.RafNo,
                    ToplamAdet = k.KitapSayisi,
                    Durumu = k.KitapIslemleri
                        .Where(i => i.GeriAlinanTarih == null)
                        .Select(i => i.Ogrenci.Ad + " " + i.Ogrenci.Soyad)
                        .DefaultIfEmpty("Kütüphanede")
                        .Aggregate((a, b) => a + ", " + b)
                }).ToList();

                dataGridKitaplar.DataSource = rapor;
                StilUygula();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Rapor verileri yüklenirken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void StilUygula()
        {
            dataGridKitaplar.RowHeadersVisible = false;
            dataGridKitaplar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridKitaplar.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridKitaplar.DefaultCellStyle.SelectionBackColor = Color.DarkGreen;
            dataGridKitaplar.DefaultCellStyle.SelectionForeColor = Color.White;
            dataGridKitaplar.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(230, 255, 230);
            dataGridKitaplar.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkGreen;
            dataGridKitaplar.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridKitaplar.EnableHeadersVisualStyles = false;
            dataGridKitaplar.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10);
            dataGridKitaplar.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 11, System.Drawing.FontStyle.Bold);

            // DÜZENLEME: Sütun başlıkları yeni rapora göre güncellendi.
            if (dataGridKitaplar.Columns.Count > 0)
            {
                dataGridKitaplar.Columns["Barkod"].HeaderText = "Barkod";
                dataGridKitaplar.Columns["KitapAdi"].HeaderText = "Kitap Adı";
                dataGridKitaplar.Columns["Yazar"].HeaderText = "Yazar";
                dataGridKitaplar.Columns["RafNo"].HeaderText = "Raf No";
                dataGridKitaplar.Columns["ToplamAdet"].HeaderText = "Toplam Adet";
                dataGridKitaplar.Columns["Durumu"].HeaderText = "Durumu (Kimde)";
            }
        }

        private void btnPdfAktar_Click(object sender, EventArgs e)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            if (dataGridKitaplar.Rows.Count == 0)
            {
                MessageBox.Show("Aktarılacak veri bulunmamaktadır.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "PDF Dosyası|*.pdf";
            save.Title = "PDF olarak kaydet";
            save.FileName = "KitapDurumRaporu_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".pdf";

            if (save.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (FileStream stream = new FileStream(save.FileName, FileMode.Create))
                    {
                        // DÜZENLEME: Sütun sayısı arttığı için PDF tekrar yatay yapıldı.
                        Document pdfDoc = new Document(PageSize.A4.Rotate(), 25f, 25f, 30f, 30f);
                        PdfWriter.GetInstance(pdfDoc, stream);
                        pdfDoc.Open();

                        string fontPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "ARIAL.TTF");
                        if (!File.Exists(fontPath))
                        {
                            fontPath = Path.Combine(Application.StartupPath, "fonts", "arialuni.ttf");
                            if (!File.Exists(fontPath))
                            {
                                MessageBox.Show("PDF oluşturmak için gerekli font dosyası (Arial) bulunamadı.", "Font Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }

                        BaseFont bfArialUni = BaseFont.CreateFont(fontPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);

                        iTextSharp.text.Font titleFont = new iTextSharp.text.Font(bfArialUni, 16f, iTextSharp.text.Font.BOLD);
                        iTextSharp.text.Font headerFont = new iTextSharp.text.Font(bfArialUni, 11f, iTextSharp.text.Font.BOLD);
                        iTextSharp.text.Font normalFont = new iTextSharp.text.Font(bfArialUni, 10f);

                        Paragraph baslik = new Paragraph("KİTAP DURUM RAPORU", titleFont)
                        {
                            Alignment = Element.ALIGN_CENTER,
                            SpacingAfter = 15f
                        };
                        pdfDoc.Add(baslik);

                        Paragraph tarih = new Paragraph("Rapor Tarihi: " + DateTime.Now.ToString("dd.MM.yyyy HH:mm"), normalFont)
                        {
                            Alignment = Element.ALIGN_RIGHT,
                            SpacingAfter = 20f
                        };
                        pdfDoc.Add(tarih);

                        PdfPTable table = new PdfPTable(dataGridKitaplar.Columns.Count);
                        table.WidthPercentage = 100;

                        foreach (DataGridViewColumn column in dataGridKitaplar.Columns)
                        {
                            PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText, headerFont))
                            {
                                BackgroundColor = new BaseColor(System.Drawing.Color.DarkOliveGreen),
                                HorizontalAlignment = Element.ALIGN_CENTER,
                                VerticalAlignment = Element.ALIGN_MIDDLE,
                                Padding = 5
                            };
                            table.AddCell(cell);
                        }

                        foreach (DataGridViewRow row in dataGridKitaplar.Rows)
                        {
                            foreach (DataGridViewCell cell in row.Cells)
                            {
                                string value = cell.Value?.ToString() ?? "";
                                PdfPCell pdfCell = new PdfPCell(new Phrase(value, normalFont))
                                {
                                    Padding = 5
                                };
                                table.AddCell(pdfCell);
                            }
                        }

                        pdfDoc.Add(table);
                        pdfDoc.Close();
                    }

                    MessageBox.Show("PDF başarıyla oluşturuldu!\nKonum: " + save.FileName, "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("PDF oluşturulurken bir hata oluştu:\n" + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
