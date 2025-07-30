using KutuphaneOtomasyonu.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace KutuphaneOtomasyonu
{
    public partial class KitapGuncelleForm : Form
    {
        KutuphaneContext db = new KutuphaneContext();

        public KitapGuncelleForm()
        {
            InitializeComponent();
        }

        private void KitapGuncelleForm_Load(object sender, EventArgs e)
        {
            // Kitapları combobox'a yükle
            cmbKitapAdi.DropDownStyle = ComboBoxStyle.DropDown;
            cmbKitapAdi.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbKitapAdi.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbKitapAdi.DisplayMember = "KitapAdi";
            cmbKitapAdi.ValueMember = "KitapId";
            cmbKitapAdi.DataSource = db.Kitaplars.ToList();
        }

        private void cmbKitapAdi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbKitapAdi.SelectedValue is int kitapId)
            {
                var kitap = db.Kitaplars.FirstOrDefault(k => k.KitapId == kitapId);
                if (kitap != null)
                {
                    // Kitap bilgilerini ilgili kontrollere ata
                    txtKitapAd.Text = kitap.KitapAdi;
                    txtYazar.Text = kitap.Yazar;
                    txtYayinEvi.Text = kitap.YayinEvi;
                    txtRafNo.Text = kitap.RafNo;
                    txtTur.Text = kitap.Tur;
                    txtKitapSayisi.Text = kitap.KitapSayisi.ToString();
                    txtMevcutKitapSayisi.Text = kitap.MevcutAdet.ToString();

                    // EKLENEN KISIMLAR
                    txtBasimYeri.Text = kitap.BasimYeri;
                    // Basım Tarihi null olabileceğinden kontrol ekleniyor. Null ise bugünün tarihini gösterir.
                    dtpBasimTarihi.Value = kitap.BasimTarihi ?? DateTime.Now;

                    // HATA DÜZELTMESİ: Kontrolün maksimum değerini artırarak hatayı önle.
                    nudSayfaSayisi.Maximum = 10000;

                    // HATA DÜZELTMESİ: SayfaSayisi null ise 0 olarak ayarlandı.
                    nudSayfaSayisi.Value = (decimal)(kitap.SayfaSayisi ?? 0);
                }
                else
                {
                    Temizle();
                    MessageBox.Show("Seçilen kitap bulunamadı.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void Temizle()
        {
            txtKitapAd.Clear();
            txtYazar.Clear();
            txtYayinEvi.Clear();
            txtRafNo.Clear();
            txtTur.Clear();
            txtKitapSayisi.Clear();
            txtMevcutKitapSayisi.Clear();
            txtBasimYeri.Clear();
            dtpBasimTarihi.Value = DateTime.Now;
            nudSayfaSayisi.Value = 0;
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (cmbKitapAdi.SelectedValue is int kitapId)
            {
                var kitap = db.Kitaplars.Find(kitapId);
                if (kitap != null)
                {
                    // Formdaki verilerle kitap nesnesini güncelle
                    kitap.KitapAdi = txtKitapAd.Text.Trim();
                    kitap.Yazar = txtYazar.Text.Trim();
                    kitap.YayinEvi = txtYayinEvi.Text.Trim();
                    kitap.RafNo = txtRafNo.Text.Trim();
                    kitap.Tur = txtTur.Text.Trim();
                    kitap.KitapSayisi = int.TryParse(txtKitapSayisi.Text, out int sayi) ? sayi : 0;
                    kitap.MevcutAdet = int.TryParse(txtMevcutKitapSayisi.Text, out int mevcut) ? mevcut : 0;

                    // EKLENEN KISIMLAR
                    kitap.BasimYeri = txtBasimYeri.Text.Trim();
                    kitap.BasimTarihi = dtpBasimTarihi.Value.Date;
                    kitap.SayfaSayisi = (int)nudSayfaSayisi.Value;

                    // Değişiklikleri veritabanına kaydet
                    db.SaveChanges();
                    MessageBox.Show("Kitap başarıyla güncellendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            this.Close(); // Formu kapat (isteğe bağlı)
        }
    }
}
