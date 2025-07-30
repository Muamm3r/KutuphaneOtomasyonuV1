using KutuphaneOtomasyonu.Models;
using System;
using System.Data.SqlClient; // YENİ EKLENDİ
using System.IO; // YENİ EKLENDİ
using System.Windows.Forms;
using System.Linq;
using System.Drawing;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

namespace KutuphaneOtomasyonu
{
    public partial class YoneticiPanel : Form
    {
        public YoneticiPanel()
        {
            InitializeComponent();
            // FormClosing olayını dinlemek için constructor'a ekleme yapıldı.
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.YoneticiPanel_FormClosing);
        }

        private void YoneticiPanel_Load(object sender, EventArgs e)
        {
            // Okul adını yükle
            using (var db = new KutuphaneContext())
            {
                var ayar = db.Ayarlars.FirstOrDefault(a => a.AyarAdi == "OkulAdi");
                if (ayar != null)
                {
                    lblOkulAdi.Text = ayar.Deger;
                    lblOkulAdi.TextAlign = ContentAlignment.MiddleCenter; // Ortalamak için
                }
            }
            // --- ÖNCEKİ YEDEKLEME KODU KALDIRILDI ---
        }

        // --- YENİ EKLENEN METOT ---
        // Program kapatılırken otomatik yedekleme yapar.


        private void btnKitapEkle_Click(object sender, EventArgs e)
        {
            KitapEkle kitapEkle = new KitapEkle();
            kitapEkle.ShowDialog();
        }

        private void btnOgrenciEkle_Click(object sender, EventArgs e)
        {
            OgrenciEkle ogrenciEkle = new OgrenciEkle();
            ogrenciEkle.ShowDialog();
        }

        private void btnBarkodOlustur_Click(object sender, EventArgs e)
        {
            BarkodOlusturForm barkodOlusturForm = new BarkodOlusturForm();
            barkodOlusturForm.ShowDialog();
        }

        private void btnKitapGuncelle_Click(object sender, EventArgs e)
        {
            KitapGuncelleForm kitapGuncelleForm = new KitapGuncelleForm();
            kitapGuncelleForm.ShowDialog();
        }

        private void btnKitaplar_Click(object sender, EventArgs e)
        {
            KitaplarForm kitaplarForm = new KitaplarForm();
            kitaplarForm.ShowDialog();
        }

        private void btnKitapSil_Click(object sender, EventArgs e)
        {
            KitapSilForm kitapSilForm = new KitapSilForm();
            kitapSilForm.ShowDialog();
        }

        private void btnAyarlar_Click(object sender, EventArgs e)
        {
            AyarlarForm ayarForm = new AyarlarForm();
            ayarForm.ShowDialog();
        }

        private void btnOgrenciGuncelle_Click(object sender, EventArgs e)
        {
            OgrenciGuncelle ogrenciGuncelle = new OgrenciGuncelle();
            ogrenciGuncelle.ShowDialog();
        }

        private void btnOgrenciSil_Click(object sender, EventArgs e)
        {
            OgrenciSil ogrenciSil = new OgrenciSil();
            ogrenciSil.ShowDialog();
        }

        private void btnKitapVerAl_Click(object sender, EventArgs e)
        {
            KitapVerAlForm kitapVerAlForm = new KitapVerAlForm();
            kitapVerAlForm.ShowDialog();
        }

        private void btnTopluSinifAtlat_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show(
                "Tüm öğrencileri bir üst sınıfa taşımak istiyor musunuz?",
                "Toplu Sınıf Atlama", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                using (var db = new KutuphaneContext())
                {
                    var siniflar = db.Ogrencilers
                        .Select(o => o.Sinif)
                        .Distinct()
                        .ToList();

                    bool eksikSinifVar = false;

                    foreach (var sinif in siniflar)
                    {
                        int yeniSeviye = sinif.Seviye + 1;
                        string sube = sinif.Sube;

                        var yeniSinif = db.Siniflars
                            .FirstOrDefault(s => s.Seviye == yeniSeviye && s.Sube == sube);

                        if (yeniSinif == null)
                        {
                            MessageBox.Show($"'{yeniSeviye}-{sube}' sınıfı bulunamadı.\nLütfen önce bu sınıfı oluşturun.",
                                "Eksik Sınıf", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            eksikSinifVar = true;
                            break;
                        }

                        var ogrenciler = db.Ogrencilers.Where(o => o.SinifId == sinif.SinifId).ToList();
                        foreach (var ogrenci in ogrenciler)
                        {
                            ogrenci.SinifId = yeniSinif.SinifId;
                        }
                    }

                    if (!eksikSinifVar)
                    {
                        db.SaveChanges();
                        MessageBox.Show("Tüm öğrenciler başarıyla bir üst sınıfa atlatıldı.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void btnOgrenciler_Click(object sender, EventArgs e)
        {
            Ogrenciler ogrenciler = new Ogrenciler();
            ogrenciler.ShowDialog();
        }

        private void btnEnCokOkunanKitap_Click(object sender, EventArgs e)
        {
            EnCokOkunanKitaplar enCokOkunanKitaplar = new EnCokOkunanKitaplar();
            enCokOkunanKitaplar.ShowDialog();
        }

        private void btnEnCokKitapOkuyan_Click(object sender, EventArgs e)
        {
            EnCokOkuyanOgrenciler enCokOkuyanOgrenciler = new EnCokOkuyanOgrenciler();
            enCokOkuyanOgrenciler.ShowDialog();
        }

        private void btnOgrenciRaporla_Click(object sender, EventArgs e)
        {
            OgrencileriRaporla ogrencileriRaporla = new OgrencileriRaporla();
            ogrencileriRaporla.ShowDialog();
        }

        private void btnKitapRaporla_Click(object sender, EventArgs e)
        {
            KitaplariRaporla kitaplariRaporla = new KitaplariRaporla();
            kitaplariRaporla.ShowDialog();
        }

        private void btnKullaniciYonetimi_Click(object sender, EventArgs e)
        {
            KullaniciYonetimi kullaniciYonetimi = new KullaniciYonetimi();
            kullaniciYonetimi.ShowDialog();
        }

        private void btnCezalar_Click(object sender, EventArgs e)
        {
            CezaForm cezaForm = new CezaForm();
            cezaForm.ShowDialog();
        }

        // --- ÖNCEKİ FormClosed METODU DEĞİŞTİRİLDİ ---
        // Bu metot, form kapatılmadan hemen önce tetiklenir.
        private void YoneticiPanel_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
