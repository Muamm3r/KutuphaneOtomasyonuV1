using ExcelDataReader;
using KutuphaneOtomasyonu.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;

namespace KutuphaneOtomasyonu
{
    public partial class KitapEkle : Form
    {
        public KitapEkle()
        {
            InitializeComponent();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            // Giriş kontrolü
            if (string.IsNullOrWhiteSpace(txtKitapAd.Text) ||
                string.IsNullOrWhiteSpace(txtYazar.Text) ||
                string.IsNullOrWhiteSpace(txtYayinEvi.Text) ||
                string.IsNullOrWhiteSpace(txtRafNo.Text) ||
                string.IsNullOrWhiteSpace(txtTur.Text) ||
                string.IsNullOrWhiteSpace(txtKitapSayisi.Text) ||
                string.IsNullOrWhiteSpace(txtMevcutKitapSayisi.Text) ||
                string.IsNullOrWhiteSpace(txtBasimYeri.Text))
            {
                MessageBox.Show("Lütfen tüm alanları doldurunuz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var db = new KutuphaneContext())
                {
                    Kitaplar kitap = new Kitaplar
                    {
                        KitapAdi = txtKitapAd.Text.Trim(),
                        Yazar = txtYazar.Text.Trim(),
                        YayinEvi = txtYayinEvi.Text.Trim(),
                        RafNo = txtRafNo.Text.Trim(),
                        Tur = txtTur.Text.Trim(),
                        KitapSayisi = Convert.ToInt32(txtKitapSayisi.Text),
                        MevcutAdet = Convert.ToInt32(txtMevcutKitapSayisi.Text),
                        Barkod = null,// Barkod daha sonra eklenecek
                        BasimYeri = txtBasimYeri.Text.Trim(),
                        // DateTime değerini direkt atayın, string'e dönüştürmeyin
                        BasimTarihi = dtpBasimTarihi.Value,
                        SayfaSayisi = (int)nudSayfaSayisi.Value
                    };

                    db.Kitaplars.Add(kitap);
                    db.SaveChanges();
                }

                MessageBox.Show("Kitap başarıyla eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close(); // Formu kapat (isteğe bağlı)
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu:\n" + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExceldenKitapYukle_Click(object sender, EventArgs e)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Excel Dosyaları|*.xlsx;*.xls";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (var stream = new FileStream(ofd.FileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                        using (var reader = ExcelReaderFactory.CreateReader(stream))
                        {
                            var result = reader.AsDataSet(new ExcelDataSetConfiguration()
                            {
                                ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                                {
                                    UseHeaderRow = true
                                }
                            });
                            var table = result.Tables[0];

                            int eklenen = 0;
                            int satirNo = 2; // Başlık satırı sonrası
                            StringBuilder hatalar = new StringBuilder();

                            using (var db = new KutuphaneContext())
                            {
                                foreach (DataRow row in table.Rows)
                                {
                                    try
                                    {
                                        string kitapAdi = row["Kitap Adı"]?.ToString().Trim();
                                        string yazar = row["Yazar"]?.ToString().Trim();
                                        string kitapSayisiStr = row["Kitap Sayısı"]?.ToString().Trim();
                                        string mevcutAdetStr = row["Mevcut Kitap Sayısı"]?.ToString().Trim();

                                        if (string.IsNullOrWhiteSpace(kitapAdi) || string.IsNullOrWhiteSpace(yazar))
                                        {
                                            hatalar.AppendLine($"Satır {satirNo}: Kitap Adı veya Yazar boş.");
                                            satirNo++;
                                            continue;
                                        }

                                        if (!int.TryParse(kitapSayisiStr, out int kitapSayisi))
                                        {
                                            hatalar.AppendLine($"Satır {satirNo}: Kitap Sayısı geçersiz.");
                                            satirNo++;
                                            continue;
                                        }

                                        if (!int.TryParse(mevcutAdetStr, out int mevcutAdet))
                                        {
                                            hatalar.AppendLine($"Satır {satirNo}: Mevcut Kitap Sayısı geçersiz.");
                                            satirNo++;
                                            continue;
                                        }

                                        // Diğer opsiyonel alanlar
                                        string yayinEvi = row["Yayın Evi"]?.ToString().Trim();
                                        string rafNo = row["Raf Numarası"]?.ToString().Trim();
                                        string tur = row["Tür"]?.ToString().Trim();
                                        string basimYeri = row["Basım Yeri"]?.ToString().Trim();
                                        string basimTarihiStr = row["Basım Tarihi"]?.ToString().Trim();
                                        string sayfaSayisiStr = row["Sayfa Sayısı"]?.ToString().Trim();

                                        int.TryParse(sayfaSayisiStr, out int sayfaSayisi);
                                        DateTime.TryParse(basimTarihiStr, out DateTime basimTarihi);

                                        var kitap = new Kitaplar
                                        {
                                            KitapAdi = kitapAdi,
                                            Yazar = yazar,
                                            YayinEvi = yayinEvi,
                                            RafNo = rafNo,
                                            Tur = tur,
                                            KitapSayisi = kitapSayisi,
                                            MevcutAdet = mevcutAdet,
                                            Barkod = null,
                                            BasimYeri = basimYeri,
                                            BasimTarihi = basimTarihi == DateTime.MinValue ? null : (DateTime?)basimTarihi,
                                            SayfaSayisi = sayfaSayisi
                                        };

                                        db.Kitaplars.Add(kitap);
                                        eklenen++;
                                    }
                                    catch (Exception exSatir)
                                    {
                                        hatalar.AppendLine($"Satır {satirNo}: {exSatir.Message}");
                                    }

                                    satirNo++;
                                }

                                db.SaveChanges();
                            }

                            if (eklenen > 0)
                            {
                                MessageBox.Show($"{eklenen} kitap başarıyla yüklendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Hiçbir kitap eklenmedi. Hatalar:\n" + hatalar.ToString(), "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Yükleme sırasında hata oluştu:\n" + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

    }
}