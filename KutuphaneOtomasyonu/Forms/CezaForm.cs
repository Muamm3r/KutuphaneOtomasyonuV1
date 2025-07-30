using KutuphaneOtomasyonu.Models;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;

namespace KutuphaneOtomasyonu
{
    public partial class CezaForm : Form
    {
        private KutuphaneContext db = new KutuphaneContext();

        public CezaForm()
        {
            InitializeComponent();

            // Sağ tık menüleri
            ContextMenuStrip cezaMenu = new ContextMenuStrip();
            ToolStripMenuItem cezaSilItem = new ToolStripMenuItem("Ceza Sil");
            cezaSilItem.Click += CezaSil_Click;
            cezaMenu.Items.Add(cezaSilItem);
            dataGridCezalar.ContextMenuStrip = cezaMenu;

            ContextMenuStrip gecikmeMenu = new ContextMenuStrip();
            ToolStripMenuItem gecikmeSilItem = new ToolStripMenuItem("Gecikmeyi Sil");
            gecikmeSilItem.Click += GecikmeSatiriniSil_Click;
            gecikmeMenu.Items.Add(gecikmeSilItem);
            dataGridGecikmeler.ContextMenuStrip = gecikmeMenu;
        }

        private void CezaForm_Load(object sender, EventArgs e)
        {
            GecikenKitaplariListele();
            CezalariListele();
            GridStilAyarlari();
        }

        private void GecikenKitaplariListele()
        {
            var bugun = DateTime.Now;

            var gecikmeliIslemler = db.KitapIslemleris
                .Where(k => k.TeslimTarihi < bugun && k.GeriAlinanTarih == null)
                .Include(k => k.Kitap)
                .Include(k => k.Ogrenci)
                .ToList();

            var cezalikListesi = gecikmeliIslemler
                .Select(k => new
                {
                    IslemId = k.Id,
                    Ogrenci = k.Ogrenci.Ad + " " + k.Ogrenci.Soyad,
                    k.OgrenciId,
                    k.KitapId,
                    Kitap = k.Kitap.KitapAdi,
                    k.TeslimTarihi,
                    GecikmeGun = (bugun - k.TeslimTarihi).Days
                })
                .Where(k => k.GecikmeGun > 15)
                .ToList();

            dataGridGecikmeler.DataSource = cezalikListesi;

            dataGridGecikmeler.Columns["OgrenciId"].Visible = false;
            dataGridGecikmeler.Columns["KitapId"].Visible = false;
            dataGridGecikmeler.Columns["IslemId"].Visible = false;
        }

        private void CezalariListele()
        {
            var cezalar = db.Cezalars
                .Include(c => c.Ogrenci)
                .Include(c => c.Kitap)
                .Include(c => c.Islem) // ← BURAYA DİKKAT!
                .Select(c => new
                {
                    c.CezaId,
                    Ogrenci = c.Ogrenci.Ad + " " + c.Ogrenci.Soyad,
                    Kitap = c.Kitap.KitapAdi,
                    c.GecikmeGun,
                    c.CezaTuru,
                    c.Aciklama,
                    CezaDurumu = c.Odendi == true ? "Tamamlandı" : "Bekliyor"
                })
                .ToList();

            dataGridCezalar.DataSource = cezalar;

            if (dataGridCezalar.Columns.Contains("CezaId"))
                dataGridCezalar.Columns["CezaId"].Visible = false;
        }

        private void GridStilAyarlari()
        {
            foreach (var grid in new[] { dataGridGecikmeler, dataGridCezalar })
            {
                grid.RowHeadersVisible = false;
                grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                grid.DefaultCellStyle.BackColor = Color.White;
                grid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);
                grid.DefaultCellStyle.SelectionBackColor = Color.SteelBlue;
                grid.DefaultCellStyle.SelectionForeColor = Color.White;
                grid.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(30, 30, 60);
                grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                grid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Bold);
                grid.EnableHeadersVisualStyles = false;
                grid.DefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            }
        }

        private void btnCezaVer_Click(object sender, EventArgs e)
        {
            if (dataGridGecikmeler.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen ceza verilecek öğrenciyi seçin.");
                return;
            }

            var row = dataGridGecikmeler.SelectedRows[0];
            int ogrenciId = (int)row.Cells["OgrenciId"].Value;
            int kitapId = (int)row.Cells["KitapId"].Value;
            int islemId = (int)row.Cells["IslemId"].Value;
            int gecikmeGun = (int)row.Cells["GecikmeGun"].Value;
            string cezaTuru = txtCezaTuru.Text.Trim();
            string aciklama = txtAciklama.Text.Trim();

            var ceza = new Cezalar
            {
                OgrenciId = ogrenciId,
                KitapId = kitapId,
                IslemId = islemId,
                GecikmeGun = gecikmeGun,
                CezaTuru = cezaTuru,
                Aciklama = aciklama,
                Odendi = false,
                Tarih = DateTime.Now // ← BU ALANIN MODELDE DateTime? OLMASI GEREK!
            };

            db.Cezalars.Add(ceza);
            db.SaveChanges();

            MessageBox.Show("Ceza başarıyla eklendi.");
            GecikenKitaplariListele();
            CezalariListele();
        }

        private void btnDurumGuncelle_Click(object sender, EventArgs e)
        {
            if (dataGridCezalar.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen güncellenecek cezayı seçin.");
                return;
            }

            int cezaId = (int)dataGridCezalar.SelectedRows[0].Cells["CezaId"].Value;
            var ceza = db.Cezalars.Find(cezaId);

            if (ceza != null)
            {
                ceza.Odendi = !(ceza.Odendi ?? false); // Nullable bool için güvenli kullanım
                db.SaveChanges();
                MessageBox.Show("Ceza durumu güncellendi.");
                CezalariListele();
            }
        }

        private void CezaSil_Click(object sender, EventArgs e)
        {
            if (dataGridCezalar.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen silinecek cezayı seçin.");
                return;
            }

            int cezaId = (int)dataGridCezalar.SelectedRows[0].Cells["CezaId"].Value;
            var ceza = db.Cezalars.Find(cezaId);

            if (ceza != null)
            {
                var onay = MessageBox.Show("Ceza silinsin mi?", "Onay", MessageBoxButtons.YesNo);
                if (onay == DialogResult.Yes)
                {
                    db.Cezalars.Remove(ceza);
                    db.SaveChanges();
                    MessageBox.Show("Ceza silindi.");
                    CezalariListele();
                }
            }
        }

        private void GecikmeSatiriniSil_Click(object sender, EventArgs e)
        {
            if (dataGridGecikmeler.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen silinecek gecikmeli işlemi seçin.");
                return;
            }

            int islemId = (int)dataGridGecikmeler.SelectedRows[0].Cells["IslemId"].Value;
            var islem = db.KitapIslemleris.Find(islemId);

            if (islem != null)
            {
                var onay = MessageBox.Show("Bu gecikmiş kitap işlemi silinsin mi?\n(Not: Kitap hareket geçmişi etkilenir.)", "Onay", MessageBoxButtons.YesNo);
                if (onay == DialogResult.Yes)
                {
                    db.KitapIslemleris.Remove(islem);
                    db.SaveChanges();
                    MessageBox.Show("Gecikmiş işlem silindi.");
                    GecikenKitaplariListele();
                }
            }
        }
    }
}
