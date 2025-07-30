using KutuphaneOtomasyonu.Models;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace KutuphaneOtomasyonu
{
    public partial class OgrenciSil : Form
    {
        KutuphaneContext db = new KutuphaneContext();

        public OgrenciSil()
        {
            InitializeComponent();
            this.Load += OgrenciSil_Load;
            txtAra.TextChanged += TxtAra_TextChanged;
            dataGridOgrenciler.CellContentClick += DataGridOgrenciler_CellContentClick;
        }

        private void OgrenciSil_Load(object sender, EventArgs e)
        {
            OgrencileriListele();
            GridStilAyarlari();
        }

        private void OgrencileriListele(string filtre = "")
        {
            var ogrenciler = db.Ogrencilers
                .Where(o =>
                    o.Ad.Contains(filtre) ||
                    o.Soyad.Contains(filtre) ||
                    o.Numara.Contains(filtre)
                )
                .Select(o => new
                {
                    o.OgrenciId,
                    o.Ad,
                    o.Soyad,
                    o.Numara,
                    Sinif = o.Sinif.Seviye + " / " + o.Sinif.Sube
                })
                .ToList();

            dataGridOgrenciler.DataSource = ogrenciler;
            dataGridOgrenciler.Columns["OgrenciId"].Visible = false;


            if (!dataGridOgrenciler.Columns.Contains("Sil"))
            {
                DataGridViewButtonColumn silBtn = new DataGridViewButtonColumn();
                silBtn.Name = "Sil";
                silBtn.HeaderText = "Sil";
                silBtn.Text = "Sil";
                silBtn.UseColumnTextForButtonValue = true;
                dataGridOgrenciler.Columns.Add(silBtn);
            }
        }

        private void TxtAra_TextChanged(object sender, EventArgs e)
        {
            string arama = txtAra.Text.ToLower();

            var filtrelenmis = db.Ogrencilers
                .Where(o =>
                    (o.Ad ?? string.Empty).ToLower().Contains(arama) ||
                    (o.Soyad ?? string.Empty).ToLower().Contains(arama) ||
                    (o.Numara ?? string.Empty).ToLower().Contains(arama)
                )
                .Select(o => new
                {
                    o.OgrenciId,
                    o.Ad,
                    o.Soyad,
                    o.Numara,
                    Sinif = o.Sinif.Seviye + " / " + o.Sinif.Sube
                })
                .ToList();

            dataGridOgrenciler.DataSource = filtrelenmis;
            dataGridOgrenciler.Columns["OgrenciId"].Visible = false;


        }

        private void DataGridOgrenciler_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridOgrenciler.Columns["Sil"].Index && e.RowIndex >= 0)
            {
                int ogrenciId = Convert.ToInt32(dataGridOgrenciler.Rows[e.RowIndex].Cells["OgrenciId"].Value);
                var ogrenci = db.Ogrencilers.Find(ogrenciId);

                if (ogrenci != null)
                {
                    // 📌 Teslim edilmemiş kitap kontrolü
                    bool kitapVar = db.KitapIslemleris
    .Any(k => k.OgrenciId == ogrenciId &&
              k.GeriAlinanTarih == null &&
              k.Kitap != null); // Navigasyonla kitap hâlâ var mı kontrolü


                    if (kitapVar)
                    {
                        MessageBox.Show("Bu öğrenciye ait teslim edilmemiş kitap(lar) var.\nLütfen önce kitapları teslim ettirin.",
                            "Silme Engellendi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    DialogResult result = MessageBox.Show($"“{ogrenci.Ad} {ogrenci.Soyad}” adlı öğrenciyi silmek istiyor musunuz?",
                        "Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        db.Ogrencilers.Remove(ogrenci);
                        db.SaveChanges();
                        MessageBox.Show("Öğrenci başarıyla silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        OgrencileriListele(txtAra.Text);
                    }
                }
            }
        }


        private void GridStilAyarlari()
        {
            dataGridOgrenciler.RowHeadersVisible = false;
            dataGridOgrenciler.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridOgrenciler.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridOgrenciler.DefaultCellStyle.SelectionBackColor = Color.DarkRed;
            dataGridOgrenciler.DefaultCellStyle.SelectionForeColor = Color.White;
            dataGridOgrenciler.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);
            dataGridOgrenciler.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(40, 40, 80);
            dataGridOgrenciler.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridOgrenciler.EnableHeadersVisualStyles = false;
            dataGridOgrenciler.DefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            dataGridOgrenciler.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Bold);
        }
    }
}
