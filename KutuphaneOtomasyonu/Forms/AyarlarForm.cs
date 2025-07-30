using KutuphaneOtomasyonu.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KutuphaneOtomasyonu
{
    public partial class AyarlarForm : Form
    {
        KutuphaneContext db = new KutuphaneContext();

        public AyarlarForm()
        {
            InitializeComponent();
            this.Load += AyarlarForm_Load;
        }

        private void AyarlarForm_Load(object sender, EventArgs e)
        {
            SubeListele();

            using (var db = new KutuphaneContext())
            {
                var okulAdi = db.Ayarlars.FirstOrDefault(a => a.AyarAdi == "OkulAdi");
                if (okulAdi != null)
                {
                    rtxtOkulAdi.Text = okulAdi.Deger;
                }
            }
            var okulAdiAyar = db.Ayarlars.FirstOrDefault(a => a.AyarAdi == "OkulAdi");
            if (okulAdiAyar != null)
            {
                rtxtOkulAdi.Text = okulAdiAyar.Deger;
            }
        }

        private void btnSinifKaydet_Click(object sender, EventArgs e)
        {
            int seviye = (int)nudSeviye.Value;
            string sube = txtSube.Text.Trim().ToUpper();

            if (string.IsNullOrEmpty(sube))
            {
                MessageBox.Show("Lütfen bir şube harfi girin.");
                return;
            }

            bool zatenVar = db.Siniflars.Any(s => s.Seviye == seviye && s.Sube == sube);
            if (zatenVar)
            {
                MessageBox.Show("Bu sınıf zaten mevcut.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Siniflar yeniSinif = new Siniflar
            {
                Seviye = seviye,
                Sube = sube
            };

            db.Siniflars.Add(yeniSinif);
            db.SaveChanges();
            MessageBox.Show("Şube başarıyla eklendi.");
            txtSube.Clear();
            SubeListele();

        }
        private void SubeListele()
        {
            var siniflar = db.Siniflars
                .Select(s => new { s.Seviye, s.Sube })
                .OrderBy(s => s.Seviye)
                .ThenBy(s => s.Sube)
                .ToList();

            dgvSiniflar.DataSource = siniflar;

            // Görsel Ayarlar
            dgvSiniflar.RowHeadersVisible = false; // <-- Sol boşluk kalkar
            dgvSiniflar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSiniflar.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSiniflar.DefaultCellStyle.SelectionBackColor = Color.SteelBlue;
            dgvSiniflar.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvSiniflar.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkSlateGray;
            dgvSiniflar.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvSiniflar.EnableHeadersVisualStyles = false;
            dgvSiniflar.DefaultCellStyle.Font = new Font("Segoe UI", 11);
            dgvSiniflar.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12, FontStyle.Bold);
        }

        private void dgvSiniflar_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var hit = dgvSiniflar.HitTest(e.X, e.Y);
                if (hit.RowIndex >= 0)
                {
                    dgvSiniflar.ClearSelection();
                    dgvSiniflar.Rows[hit.RowIndex].Selected = true;
                    dgvSiniflar.CurrentCell = dgvSiniflar.Rows[hit.RowIndex].Cells[0]; // Satırı aktif et
                    contextMenuStrip1.Show(dgvSiniflar, new Point(e.X, e.Y));
                }
            }
        }

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvSiniflar.SelectedRows.Count > 0)
            {
                var seciliSeviye = Convert.ToInt32(dgvSiniflar.SelectedRows[0].Cells["Seviye"].Value);
                var seciliSube = dgvSiniflar.SelectedRows[0].Cells["Sube"].Value.ToString();

                var sinif = db.Siniflars.FirstOrDefault(s => s.Seviye == seciliSeviye && s.Sube == seciliSube);
                if (sinif != null)
                {
                    // 🔍 Bu sınıfa bağlı öğrenci var mı kontrol et
                    bool ogrenciVarMi = db.Ogrencilers.Any(o => o.SinifId == sinif.SinifId);

                    if (ogrenciVarMi)
                    {
                        MessageBox.Show($"Bu sınıfa ait öğrenciler bulunduğu için silinemez.\nLütfen önce sınıfa ait öğrencileri silin.",
                            "Silme Engellendi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // ✅ Öğrenci yoksa silinebilir
                    DialogResult dr = MessageBox.Show($"{seciliSeviye}-{seciliSube} sınıfını silmek istiyor musunuz?",
                        "Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (dr == DialogResult.Yes)
                    {
                        db.Siniflars.Remove(sinif);
                        db.SaveChanges();
                        MessageBox.Show("Sınıf başarıyla silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        SubeListele(); // tabloyu yenile
                    }
                }
            }
        }


        private void btnKaydetOkulAdi_Click(object sender, EventArgs e)
        {
            string okulAdi = rtxtOkulAdi.Text.Trim();

            if (string.IsNullOrEmpty(okulAdi))
            {
                MessageBox.Show("Okul adı boş olamaz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var ayar = db.Ayarlars.FirstOrDefault(a => a.AyarAdi == "OkulAdi");
            if (ayar == null)
            {
                ayar = new Ayarlar { AyarAdi = "OkulAdi", Deger = okulAdi };
                db.Ayarlars.Add(ayar);
            }
            else
            {
                ayar.Deger = okulAdi; // Bu satır yeterlidir
            }

            db.SaveChanges();
            MessageBox.Show("Okul adı güncellendi. Lütfen programı yeniden başlatınız.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
    }
}
