using KutuphaneOtomasyonu.Models;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace KutuphaneOtomasyonu
{
    public partial class OgrenciGuncelle : Form
    {
        public OgrenciGuncelle()
        {
            InitializeComponent();
            this.Load += OgrenciGuncelle_Load;
        }

        private void OgrenciGuncelle_Load(object sender, EventArgs e)
        {
            using (var db = new KutuphaneContext())
            {
                // 🔃 Öğrenci listesi
                var ogrenciler = db.Ogrencilers
                    .Select(o => new
                    {
                        o.OgrenciId,
                        AdSoyad = o.Ad + " " + o.Soyad + " (" + o.Numara + ")"
                    }).ToList();

                cbOgrenci.DisplayMember = "AdSoyad";
                cbOgrenci.ValueMember = "OgrenciId";
                cbOgrenci.DataSource = ogrenciler;
                cbOgrenci.DropDownStyle = ComboBoxStyle.DropDown;
                cbOgrenci.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cbOgrenci.AutoCompleteSource = AutoCompleteSource.ListItems;
                cbOgrenci.SelectedIndex = -1;

                // 📚 Sınıf listesi
                var siniflar = db.Siniflars
                    .Select(s => new
                    {
                        s.SinifId,
                        Sınıf = s.Seviye + " / " + s.Sube
                    }).ToList();

                cbSinif.DisplayMember = "Sınıf";
                cbSinif.ValueMember = "SinifId";
                cbSinif.DataSource = siniflar;
                cbSinif.SelectedIndex = -1;
            }

            cbOgrenci.SelectedIndexChanged += cbOgrenci_SelectedIndexChanged;
        }

        private void cbOgrenci_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbOgrenci.SelectedIndex == -1)
                return;

            int secilenId = Convert.ToInt32(cbOgrenci.SelectedValue);

            using (var db = new KutuphaneContext())
            {
                var ogrenci = db.Ogrencilers.FirstOrDefault(x => x.OgrenciId == secilenId);
                if (ogrenci != null)
                {
                    txtAd.Text = ogrenci.Ad;
                    txtSoyad.Text = ogrenci.Soyad;
                    txtOgrenciNo.Text = ogrenci.Numara;
                    cbSinif.SelectedValue = ogrenci.SinifId;
                }
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (cbOgrenci.SelectedIndex == -1 ||
                string.IsNullOrWhiteSpace(txtAd.Text) ||
                string.IsNullOrWhiteSpace(txtSoyad.Text) ||
                string.IsNullOrWhiteSpace(txtOgrenciNo.Text) ||
                cbSinif.SelectedIndex == -1)
            {
                MessageBox.Show("Lütfen tüm alanları doldurunuz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int secilenId = Convert.ToInt32(cbOgrenci.SelectedValue);
            string yeniNumara = txtOgrenciNo.Text.Trim();

            using (var db = new KutuphaneContext())
            {
                var ogrenci = db.Ogrencilers.FirstOrDefault(x => x.OgrenciId == secilenId);

                if (ogrenci == null)
                {
                    MessageBox.Show("Öğrenci bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // 🔒 Numara benzersiz mi?
                bool baskaAyniNumara = db.Ogrencilers.Any(x => x.Numara == yeniNumara && x.OgrenciId != secilenId);
                if (baskaAyniNumara)
                {
                    MessageBox.Show("Bu numara başka bir öğrenciye ait!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                ogrenci.Ad = txtAd.Text.Trim();
                ogrenci.Soyad = txtSoyad.Text.Trim();
                ogrenci.Numara = yeniNumara;
                ogrenci.SinifId = Convert.ToInt32(cbSinif.SelectedValue);

                db.SaveChanges();
                MessageBox.Show("Öğrenci bilgileri güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }
    }
}
