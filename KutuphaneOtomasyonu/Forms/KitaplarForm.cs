using KutuphaneOtomasyonu.Models;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace KutuphaneOtomasyonu
{
    public partial class KitaplarForm : Form
    {
        KutuphaneContext db = new KutuphaneContext();
        private BindingSource bindingSource = new BindingSource();

        public KitaplarForm()
        {
            InitializeComponent();
            this.Load += KitaplarForm_Load;
            txtAra.TextChanged += TxtAra_TextChanged;
        }

        private void KitaplarForm_Load(object sender, EventArgs e)
        {
            KitaplariYukle();
            GridStilAyarlari();
        }

        private void KitaplariYukle()
        {
            var kitaplar = db.Kitaplars
                .Select(k => new
                {
                    k.Barkod,
                    k.KitapAdi,
                    k.Yazar,
                    k.YayinEvi,
                    k.Tur,
                    k.SayfaSayisi,
                    k.RafNo,
                    k.MevcutAdet,
                    k.BasimTarihi,
                    k.BasimYeri
                })
                .ToList();

            bindingSource.DataSource = kitaplar;
            dataGridKitaplar.DataSource = bindingSource;
        }

        private void TxtAra_TextChanged(object sender, EventArgs e)
        {
            string arama = txtAra.Text.ToLower();

            var filtrelenmis = db.Kitaplars
                .Where(k =>
            (k.KitapAdi ?? string.Empty).ToLower().Contains(arama) ||
            (k.Yazar ?? string.Empty).ToLower().Contains(arama) ||
            (k.Barkod ?? string.Empty).Contains(arama) || // 👈 Barkodu string'e çevirerek ara
            (k.Tur ?? string.Empty).ToLower().Contains(arama) ||
            (k.RafNo ?? string.Empty).Contains(arama)
        )
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
        }


        private void GridStilAyarlari()
        {
            dataGridKitaplar.RowHeadersVisible = false; // <-- Sol boşluk kalkar
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
