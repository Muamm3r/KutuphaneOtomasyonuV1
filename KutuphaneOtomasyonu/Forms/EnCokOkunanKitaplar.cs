using KutuphaneOtomasyonu.Models;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;

namespace KutuphaneOtomasyonu
{
    public partial class EnCokOkunanKitaplar : Form
    {
        KutuphaneContext db = new KutuphaneContext();

        public EnCokOkunanKitaplar()
        {
            InitializeComponent();
            this.Load += EnCokOkunanKitaplar_Load;
        }

        private void EnCokOkunanKitaplar_Load(object sender, EventArgs e)
        {
            var liste = db.KitapIslemleris
                .Include(k => k.Kitap)
                .GroupBy(k => new { k.KitapId, k.Kitap.KitapAdi })
                .Select(g => new
                {
                    KitapAdi = g.Key.KitapAdi,
                    OkunmaSayisi = g.Count()
                })
                .OrderByDescending(k => k.OkunmaSayisi)
                .ToList();

            dataGridKitaplar.DataSource = liste;
            StilUygula();
        }

        private void StilUygula()
        {
            dataGridKitaplar.RowHeadersVisible = false;
            dataGridKitaplar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridKitaplar.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridKitaplar.DefaultCellStyle.SelectionBackColor = Color.DarkGreen;
            dataGridKitaplar.DefaultCellStyle.SelectionForeColor = Color.White;
            dataGridKitaplar.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(230, 255, 230);
            dataGridKitaplar.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkGreen;
            dataGridKitaplar.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridKitaplar.EnableHeadersVisualStyles = false;
            dataGridKitaplar.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dataGridKitaplar.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Bold);
        }
    }
}
