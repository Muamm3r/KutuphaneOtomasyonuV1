using KutuphaneOtomasyonu.Models;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;

namespace KutuphaneOtomasyonu
{
    public partial class EnCokOkuyanOgrenciler : Form
    {
        KutuphaneContext db = new KutuphaneContext();

        public EnCokOkuyanOgrenciler()
        {
            InitializeComponent();
            this.Load += EnCokOkuyanOgrenciler_Load;
        }

        private void EnCokOkuyanOgrenciler_Load(object sender, EventArgs e)
        {
            EnCokOkuyanOgrenciListesi();
            EnCokOkuyanSinifListesi();
            StilUygula(dataGridOgrenciler);
            StilUygula(dataGridSiniflar);
        }

        private void EnCokOkuyanOgrenciListesi()
        {
            var liste = db.KitapIslemleris
                .Include(k => k.Ogrenci)
                .Include(k => k.Ogrenci.Sinif)
                .GroupBy(k => new
                {
                    k.OgrenciId,
                    k.Ogrenci.Ad,
                    k.Ogrenci.Soyad,
                    k.Ogrenci.Numara,
                    Sinif = k.Ogrenci.Sinif.Seviye + "/" + k.Ogrenci.Sinif.Sube
                })
                .Select(g => new
                {
                    Ad = g.Key.Ad,
                    Soyad = g.Key.Soyad,
                    Numara = g.Key.Numara,
                    Sinif = g.Key.Sinif,
                    OkunanKitap = g.Count()
                })
                .OrderByDescending(o => o.OkunanKitap)
                .ToList();

            dataGridOgrenciler.DataSource = liste;
        }

        private void EnCokOkuyanSinifListesi()
        {
            var siniflar = db.KitapIslemleris
                .Include(k => k.Ogrenci.Sinif)
                .Where(k => k.Ogrenci != null && k.Ogrenci.Sinif != null)
                .GroupBy(k => new
                {
                    Sinif = k.Ogrenci.Sinif.Seviye + "/" + k.Ogrenci.Sinif.Sube
                })
                .Select(g => new
                {
                    Sinif = g.Key.Sinif,
                    OkunanKitap = g.Count()
                })
                .OrderByDescending(g => g.OkunanKitap)
                .ToList();

            dataGridSiniflar.DataSource = siniflar;
        }

        private void StilUygula(DataGridView grid)
        {
            grid.RowHeadersVisible = false;
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.DefaultCellStyle.SelectionBackColor = Color.DarkSlateBlue;
            grid.DefaultCellStyle.SelectionForeColor = Color.White;
            grid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 255);
            grid.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkSlateBlue;
            grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            grid.EnableHeadersVisualStyles = false;
            grid.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            grid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Bold);
        }
    }
}
