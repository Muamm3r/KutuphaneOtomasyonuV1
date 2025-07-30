using KutuphaneOtomasyonu.Models;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;

namespace KutuphaneOtomasyonu
{
    public partial class Ogrenciler : Form
    {
        KutuphaneContext db = new KutuphaneContext();

        public Ogrenciler()
        {
            InitializeComponent();
            this.Load += Ogrenciler_Load;
            txtAra.TextChanged += TxtAra_TextChanged;
        }

        private void Ogrenciler_Load(object sender, EventArgs e)
        {
            OgrencileriListele();
            GridStilAyarlari();
        }

        private void OgrencileriListele(string filtre = "")
        {
            try
            {
                var sonuclar = new List<object>();

                var sql = @"
            SELECT 
                o.Ad,
                o.Soyad,
                o.Numara,
                COALESCE(s.Seviye || ' / ' || s.Sube, '') as Sinif,
                COALESCE(GROUP_CONCAT(k.KitapAdi, ', '), '') as Kitaplar
            FROM Ogrenciler o
            LEFT JOIN Siniflar s ON o.SinifId = s.SinifId
            LEFT JOIN KitapIslemleri ki ON o.OgrenciId = ki.OgrenciId AND ki.GeriAlinanTarih IS NULL
            LEFT JOIN Kitaplar k ON ki.KitapId = k.KitapId
            WHERE (@filtre = '' OR 
                   o.Ad LIKE '%' || @filtre || '%' OR 
                   o.Soyad LIKE '%' || @filtre || '%' OR 
                   o.Numara LIKE '%' || @filtre || '%')
            GROUP BY o.OgrenciId, o.Ad, o.Soyad, o.Numara, s.Seviye, s.Sube
            ORDER BY o.Ad, o.Soyad";

                using (var command = db.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = sql;
                    var parameter = command.CreateParameter();
                    parameter.ParameterName = "@filtre";
                    parameter.Value = filtre ?? "";
                    command.Parameters.Add(parameter);

                    if (db.Database.GetDbConnection().State != System.Data.ConnectionState.Open)
                        db.Database.OpenConnection();

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            sonuclar.Add(new
                            {
                                Ad = reader.IsDBNull("Ad") ? "" : reader.GetString("Ad"),
                                Soyad = reader.IsDBNull("Soyad") ? "" : reader.GetString("Soyad"),
                                Numara = reader.IsDBNull("Numara") ? "" : reader.GetString("Numara"),
                                Sinif = reader.IsDBNull("Sinif") ? "" : reader.GetString("Sinif"),
                                Kitaplar = reader.IsDBNull("Kitaplar") ? "" : reader.GetString("Kitaplar")
                            });
                        }
                    }
                }

                dataGridOgrenciler.DataSource = sonuclar;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Veritabanı Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void TxtAra_TextChanged(object sender, EventArgs e)
        {
            OgrencileriListele(txtAra.Text.ToLower());
        }

        private void GridStilAyarlari()
        {
            dataGridOgrenciler.RowHeadersVisible = false;
            dataGridOgrenciler.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridOgrenciler.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridOgrenciler.DefaultCellStyle.SelectionBackColor = Color.SteelBlue;
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
