using KutuphaneOtomasyonu.Models;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace KutuphaneOtomasyonu
{
    public partial class KitapSilForm : Form
    {
        KutuphaneContext db = new KutuphaneContext();

        public KitapSilForm()
        {
            InitializeComponent();
            this.Load += KitapSilForm_Load;
            txtAra.TextChanged += TxtAra_TextChanged;
            dataGridKitaplar.CellContentClick += DataGridKitaplar_CellContentClick;
        }

        private void KitapSilForm_Load(object sender, EventArgs e)
        {
            KitaplariListele();
            GridStilAyarlari();
        }

        private void KitaplariListele(string filtre = "")
        {
            var kitaplar = db.Kitaplars
                .Where(k => k.KitapAdi.Contains(filtre) || k.Yazar.Contains(filtre))
                .Select(k => new
                {
                    k.KitapId,
                    k.KitapAdi,
                    k.Yazar,
                    k.YayinEvi,
                    k.RafNo,
                    k.Tur,
                    k.KitapSayisi,
                    k.MevcutAdet,
                    k.Barkod
                })
                .ToList();

            dataGridKitaplar.DataSource = kitaplar;
            dataGridKitaplar.Columns["KitapId"].Visible = false;


            if (!dataGridKitaplar.Columns.Contains("Sil"))
            {
                DataGridViewButtonColumn silBtn = new DataGridViewButtonColumn();
                silBtn.Name = "Sil";
                silBtn.HeaderText = "Sil";
                silBtn.Text = "Sil";
                silBtn.UseColumnTextForButtonValue = true;
                dataGridKitaplar.Columns.Add(silBtn);
            }
        }

        private void TxtAra_TextChanged(object sender, EventArgs e)
        {
            string arama = txtAra.Text.ToLower();

            var filtrelenmis = db.Kitaplars
                .Where(k =>
                    (k.KitapAdi ?? string.Empty).ToLower().Contains(arama) ||
                    (k.Yazar ?? string.Empty).ToLower().Contains(arama) ||
                    (k.Barkod ?? string.Empty).Contains(arama))
                .Select(k => new
                {
                    k.KitapId,
                    k.KitapAdi,
                    k.Yazar,
                    k.YayinEvi,
                    k.RafNo,
                    k.Tur,
                    k.KitapSayisi,
                    k.MevcutAdet,
                    k.Barkod
                })
                .ToList();

            dataGridKitaplar.DataSource = filtrelenmis;
            dataGridKitaplar.Columns["KitapId"].Visible = false;


        }

        private void DataGridKitaplar_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridKitaplar.Columns["Sil"].Index && e.RowIndex >= 0)
            {
                int kitapId = Convert.ToInt32(dataGridKitaplar.Rows[e.RowIndex].Cells["KitapId"].Value);
                var kitap = db.Kitaplars.Find(kitapId);

                if (kitap != null)
                {
                    DialogResult result = MessageBox.Show(
                        $"“{kitap.KitapAdi}” adlı kitabı silmek istiyor musunuz?",
                        "Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        //var iliskiliIslemVarMi = db.KitapIslemleri.Any(i => i.KitapId == kitapId);

                        //if (iliskiliIslemVarMi)
                        //{
                        //    MessageBox.Show(
                        //        "Bu kitap daha önce ödünç verilmiş. Lütfen önce ilişkili işlemleri silin veya bu kitabı silmeyin.",
                        //        "Silme Engellendi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        //    return;
                        //}

                        db.Kitaplars.Remove(kitap);
                        db.SaveChanges();
                        MessageBox.Show("Kitap başarıyla silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        KitaplariListele(txtAra.Text);
                    }
                }
            }
        }

        private void GridStilAyarlari()
        {
            dataGridKitaplar.RowHeadersVisible = false;
            dataGridKitaplar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridKitaplar.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridKitaplar.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dataGridKitaplar.DefaultCellStyle.SelectionForeColor = Color.White;
            dataGridKitaplar.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);
            dataGridKitaplar.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(30, 30, 60);
            dataGridKitaplar.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridKitaplar.EnableHeadersVisualStyles = false;
            dataGridKitaplar.DefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            dataGridKitaplar.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Bold);
        }
    }
}
