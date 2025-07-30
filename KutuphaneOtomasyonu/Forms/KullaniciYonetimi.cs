using KutuphaneOtomasyonu.Models;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace KutuphaneOtomasyonu
{
    public partial class KullaniciYonetimi : Form
    {
        KutuphaneContext db = new KutuphaneContext();
        int seciliKullaniciId = 0;

        public KullaniciYonetimi()
        {
            InitializeComponent();
        }

        private void KullaniciYonetimi_Load(object sender, EventArgs e)
        {
            cbRol.Items.Clear();
            cbRol.Items.Add("Yönetici");
            cbRol.Items.Add("Görevli");
            cbRol.SelectedIndex = 0;

            Listele();
            StilUygula();
        }

        private void Listele()
        {
            dataGridKullanicilar.DataSource = db.Kullanicilars
                .Select(k => new
                {
                    k.KullaniciId,
                    Kullanici_Adi = k.KullaniciAdi,
                    Rolü = k.Rol
                }).ToList();

            dataGridKullanicilar.Columns["KullaniciId"].Visible = false;
        }

        private void StilUygula()
        {
            dataGridKullanicilar.RowHeadersVisible = false;
            dataGridKullanicilar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridKullanicilar.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridKullanicilar.DefaultCellStyle.SelectionBackColor = Color.DarkOliveGreen;
            dataGridKullanicilar.DefaultCellStyle.SelectionForeColor = Color.White;
            dataGridKullanicilar.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(230, 255, 230);
            dataGridKullanicilar.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkOliveGreen;
            dataGridKullanicilar.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridKullanicilar.EnableHeadersVisualStyles = false;
            dataGridKullanicilar.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dataGridKullanicilar.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Bold);
        }

        private void Temizle()
        {
            txtAd.Clear();
            txtSoyad.Clear();
            txtKullaniciAdi.Clear();
            txtSifre.Clear();
            cbRol.SelectedIndex = 0;
            seciliKullaniciId = 0;
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            string kullaniciAdi = txtKullaniciAdi.Text.Trim();

            if (string.IsNullOrWhiteSpace(kullaniciAdi))
            {
                MessageBox.Show("Kullanıcı adı boş bırakılamaz.");
                return;
            }

            var kullanici = db.Kullanicilars.FirstOrDefault(k => k.KullaniciAdi == kullaniciAdi);

            if (kullanici == null)
            {
                kullanici = new Kullanicilar
                {
                    Ad = txtAd.Text.Trim(),
                    Soyad = txtSoyad.Text.Trim(),
                    KullaniciAdi = kullaniciAdi,
                    Sifre = txtSifre.Text.Trim(),
                    Rol = cbRol.SelectedItem?.ToString()
                };

                db.Kullanicilars.Add(kullanici);
                MessageBox.Show("Yeni kullanıcı eklendi.");
            }
            else
            {
                kullanici.Ad = txtAd.Text.Trim();
                kullanici.Soyad = txtSoyad.Text.Trim();
                kullanici.Sifre = txtSifre.Text.Trim();
                kullanici.Rol = cbRol.SelectedItem?.ToString();

                MessageBox.Show("Kullanıcı bilgileri güncellendi.");
            }

            db.SaveChanges();
            Listele();
            Temizle();
        }

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridKullanicilar.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dataGridKullanicilar.SelectedRows[0].Cells["KullaniciId"].Value);
                var silinecek = db.Kullanicilars.Find(id);

                if (silinecek != null)
                {
                    DialogResult sonuc = MessageBox.Show("Bu kullanıcıyı silmek istediğinizden emin misiniz?", "Sil", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (sonuc == DialogResult.Yes)
                    {
                        db.Kullanicilars.Remove(silinecek);
                        db.SaveChanges();
                        Listele();
                        Temizle();
                        MessageBox.Show("Kullanıcı silindi.");
                    }
                }
            }
        }

        private void düzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridKullanicilar.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dataGridKullanicilar.SelectedRows[0].Cells["KullaniciId"].Value);
                var k = db.Kullanicilars.Find(id);

                if (k != null)
                {
                    txtAd.Text = k.Ad;
                    txtSoyad.Text = k.Soyad;
                    txtKullaniciAdi.Text = k.KullaniciAdi;
                    txtSifre.Text = k.Sifre;
                    cbRol.SelectedItem = k.Rol;
                    seciliKullaniciId = k.KullaniciId;
                }
            }
        }

        private void dataGridKullanicilar_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var hitTest = dataGridKullanicilar.HitTest(e.X, e.Y);
                if (hitTest.RowIndex >= 0)
                {
                    dataGridKullanicilar.ClearSelection();
                    dataGridKullanicilar.Rows[hitTest.RowIndex].Selected = true;
                    contextMenuStrip1.Show(dataGridKullanicilar, e.Location);
                }
            }
        }
    }
}
