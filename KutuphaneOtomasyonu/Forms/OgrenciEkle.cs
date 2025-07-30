using KutuphaneOtomasyonu.Models;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using ExcelDataReader;
using System.Text;

namespace KutuphaneOtomasyonu
{
    public partial class OgrenciEkle : Form
    {
        public OgrenciEkle()
        {
            InitializeComponent();

        }

        private void OgrenciEkle_Load(object sender, EventArgs e)
        {
            try
            {
                using (var db = new KutuphaneContext())
                {
                    var siniflar = db.Siniflars
                        .Select(s => new
                        {
                            s.SinifId,
                            Sınıf = s.Seviye + " / " + s.Sube
                        })
                        .ToList();

                    if (siniflar.Count == 0)
                    {
                        MessageBox.Show("Henüz sınıf / şube tanımlanmamış.\nExcel'den aktarım yaparak ya da Ayarlar > Sınıf bölümünden sınıf tanımlayabilirsiniz.",
                            "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        cbSinif.Enabled = false;
                        btnKaydet.Enabled = false;

                        // ❌ Burası yorumda kalsın: Aktar butonunu pasifleştirme
                        // btnExceldenYukle.Enabled = false; 
                        return;
                    }

                    cbSinif.DisplayMember = "Sınıf";
                    cbSinif.ValueMember = "SinifId";
                    cbSinif.DataSource = siniflar;
                    cbSinif.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sınıf listesi yüklenemedi:\n" + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAd.Text) ||
                string.IsNullOrWhiteSpace(txtSoyad.Text) ||
                string.IsNullOrWhiteSpace(txtOgrenciNo.Text) ||
                cbSinif.SelectedIndex == -1)
            {
                MessageBox.Show("Lütfen tüm alanları doldurunuz ve sınıf seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var db = new KutuphaneContext())
                {
                    string girilenNumara = txtOgrenciNo.Text.Trim();

                    bool numaraVarMi = db.Ogrencilers.Any(o => o.Numara == girilenNumara);
                    if (numaraVarMi)
                    {
                        MessageBox.Show("Bu numaraya sahip bir öğrenci zaten var!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    int secilenSinifId = Convert.ToInt32(cbSinif.SelectedValue);

                    KutuphaneOtomasyonu.Models.Ogrenciler yeniOgrenci = new KutuphaneOtomasyonu.Models.Ogrenciler
                    {
                        Ad = txtAd.Text.Trim(),
                        Soyad = txtSoyad.Text.Trim(),
                        Numara = girilenNumara,
                        SinifId = secilenSinifId
                    };

                    db.Ogrencilers.Add(yeniOgrenci);
                    db.SaveChanges();
                }

                MessageBox.Show("Öğrenci başarıyla eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kayıt sırasında hata oluştu:\n" + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExceldenYukle_Click(object sender, EventArgs e)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Excel Dosyaları|*.xlsx;*.xls";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (var stream = File.Open(ofd.FileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                        using (var reader = ExcelReaderFactory.CreateReader(stream))
                        {
                            var conf = new ExcelDataSetConfiguration
                            {
                                ConfigureDataTable = _ => new ExcelDataTableConfiguration { UseHeaderRow = true }
                            };

                            var dataset = reader.AsDataSet(conf);
                            var table = dataset.Tables[0];

                            int eklenen = 0;
                            int satirNo = 2;
                            StringBuilder hatalar = new StringBuilder();

                            using (var db = new KutuphaneContext())
                            {
                                foreach (DataRow row in table.Rows)
                                {
                                    try
                                    {
                                        string ad = row["Ad"]?.ToString().Trim();
                                        string soyad = row["Soyad"]?.ToString().Trim();
                                        string numara = row["Numara"]?.ToString().Trim();
                                        string seviye = row["Seviye"]?.ToString().Trim();
                                        string sube = row["Şube"].ToString().Trim().ToUpper(); // küçük harfi büyük yap

                                        if (string.IsNullOrWhiteSpace(ad) ||
                                            string.IsNullOrWhiteSpace(soyad) ||
                                            string.IsNullOrWhiteSpace(numara) ||
                                            string.IsNullOrWhiteSpace(seviye) ||
                                            string.IsNullOrWhiteSpace(sube))
                                        {
                                            hatalar.AppendLine($"Satır {satirNo}: Eksik bilgi.");
                                            satirNo++;
                                            continue;
                                        }

                                        if (db.Ogrencilers.Any(o => o.Numara == numara))
                                        {
                                            hatalar.AppendLine($"Satır {satirNo}: Numara zaten kayıtlı.");
                                            satirNo++;
                                            continue;
                                        }

                                        if (!int.TryParse(seviye, out int seviyeInt))
                                        {
                                            hatalar.AppendLine($"Satır {satirNo}: Seviye geçersiz.");
                                            satirNo++;
                                            continue;
                                        }

                                        var sinif = db.Siniflars.FirstOrDefault(s => s.Seviye == seviyeInt && s.Sube == sube);
                                        if (sinif == null)
                                        {
                                            sinif = new Siniflar { Seviye = seviyeInt, Sube = sube };
                                            db.Siniflars.Add(sinif);
                                            db.SaveChanges(); // ID alabilmesi için
                                        }

                                        var ogr = new KutuphaneOtomasyonu.Models.Ogrenciler
                                        {
                                            Ad = ad,
                                            Soyad = soyad,
                                            Numara = numara,
                                            SinifId = sinif.SinifId
                                        };


                                        db.Ogrencilers.Add(ogr);
                                        eklenen++;
                                    }
                                    catch (Exception exSatir)
                                    {
                                        hatalar.AppendLine($"Satır {satirNo}: Hata - {exSatir.Message}");
                                    }

                                    satirNo++;
                                }

                                db.SaveChanges();
                            }

                            if (eklenen > 0)
                            {
                                MessageBox.Show($"{eklenen} öğrenci başarıyla eklendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Hiçbir öğrenci eklenmedi. Hatalar:\n" + hatalar.ToString(), "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
