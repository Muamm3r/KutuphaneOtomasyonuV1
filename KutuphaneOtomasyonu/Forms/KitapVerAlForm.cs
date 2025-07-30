using KutuphaneOtomasyonu.Models;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace KutuphaneOtomasyonu
{
    public partial class KitapVerAlForm : Form
    {
        KutuphaneContext db = new KutuphaneContext();

        public KitapVerAlForm()
        {
            InitializeComponent();
            cbOgrenci.SelectedIndexChanged += CbOgrenci_SelectedIndexChanged;
        }

        private void KitapVerAlForm_Load(object sender, EventArgs e)
        {
            // Öğrenci listesi
            cbOgrenci.DisplayMember = "AdSoyad";
            cbOgrenci.ValueMember = "OgrenciId";
            cbOgrenci.DataSource = db.Ogrencilers
                .Select(o => new
                {
                    o.OgrenciId,
                    AdSoyad = o.Ad + " " + o.Soyad + " (" + o.Numara + ")"
                }).ToList();
            cbOgrenci.SelectedIndex = -1;

            // Kitap listesi
            cbKitap.DisplayMember = "KitapAdi";
            cbKitap.ValueMember = "KitapId";
            cbKitap.DataSource = db.Kitaplars.ToList();
            cbKitap.SelectedIndex = -1;

            // 🔽 AutoComplete Özelliği Ekle
            cbOgrenci.DropDownStyle = ComboBoxStyle.DropDown;
            cbOgrenci.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbOgrenci.AutoCompleteSource = AutoCompleteSource.ListItems;

            cbKitap.DropDownStyle = ComboBoxStyle.DropDown;
            cbKitap.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbKitap.AutoCompleteSource = AutoCompleteSource.ListItems;

            KitaplariListele();
            GridStilAyarlari();
            GridStilOgrenciAyarlari();
        }


        private void KitaplariListele()
        {
            var kitaplar = db.Kitaplars
                .Select(k => new
                {
                    k.KitapAdi,
                    k.RafNo,
                    k.KitapSayisi,
                    k.MevcutAdet
                }).ToList();

            dataGridKitaplar.DataSource = kitaplar;
        }

        private void CbOgrenci_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbOgrenci.SelectedIndex == -1) return;

            int ogrId = Convert.ToInt32(cbOgrenci.SelectedValue);
            var islemListesi = db.KitapIslemleris
                .Where(i => i.OgrenciId == ogrId)
                .Select(i => new
                {
                    Kitap = i.Kitap.KitapAdi,
                    i.AlisTarihi,
                    i.TeslimTarihi,
                    i.GeriAlinanTarih
                })
                .OrderByDescending(i => i.AlisTarihi)
                .ToList();

            dataGridIslemler.DataSource = islemListesi;
        }

        private void BtnVer_Click(object sender, EventArgs e)
        {
            if (cbOgrenci.SelectedIndex == -1 || cbKitap.SelectedIndex == -1)
            {
                MessageBox.Show("Lütfen öğrenci ve kitap seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int ogrId = Convert.ToInt32(cbOgrenci.SelectedValue);
            int kitapId = Convert.ToInt32(cbKitap.SelectedValue);

            // Aynı kitap zaten verilmiş mi?
            bool ayniKitapVar = db.KitapIslemleris.Any(i =>
                i.OgrenciId == ogrId && i.KitapId == kitapId && i.GeriAlinanTarih == null);

            if (ayniKitapVar)
            {
                MessageBox.Show("Bu kitap zaten bu öğrencide. Aynı kitap ikinci kez verilemez!", "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Öğrencinin başka kitapları var mı?
            var kitaplar = db.KitapIslemleris
                .Where(i => i.OgrenciId == ogrId && i.GeriAlinanTarih == null)
                .Select(i => i.Kitap.KitapAdi)
                .ToList();

            if (kitaplar.Any())
            {
                string liste = string.Join(", ", kitaplar);
                DialogResult dr = MessageBox.Show(
                    $"Bu öğrencide hâlâ şu kitap(lar) var:\n{liste}\n\nYine de vermek istiyor musunuz?",
                    "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (dr == DialogResult.No)
                    return;
            }

            // Mevcut adet kontrol
            var kitapEntity = db.Kitaplars.FirstOrDefault(k => k.KitapId == kitapId);
            if (kitapEntity != null && kitapEntity.MevcutAdet <= 0)
            {
                MessageBox.Show("Bu kitabın stoğu kalmamış!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kitap ver
            var islem = new KitapIslemleri
            {
                OgrenciId = ogrId,
                KitapId = kitapId,
                AlisTarihi = DateTime.Now,
                TeslimTarihi = DateTime.Now.AddDays(15),
                GeriAlinanTarih = null
            };

            db.KitapIslemleris.Add(islem);

            // MevcutAdet azalt
            kitapEntity.MevcutAdet -= 1;

            db.SaveChanges();

            MessageBox.Show("Kitap başarıyla teslim edildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            CbOgrenci_SelectedIndexChanged(null, null);
            KitaplariListele(); // Liste güncelle
        }

        private void BtnAl_Click(object sender, EventArgs e)
        {
            if (cbOgrenci.SelectedIndex == -1 || cbKitap.SelectedIndex == -1)
            {
                MessageBox.Show("Lütfen öğrenci ve kitap seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int ogrId = Convert.ToInt32(cbOgrenci.SelectedValue);
            int kitapId = Convert.ToInt32(cbKitap.SelectedValue);

            var islem = db.KitapIslemleris
                .FirstOrDefault(i => i.OgrenciId == ogrId && i.KitapId == kitapId && i.GeriAlinanTarih == null);

            if (islem == null)
            {
                MessageBox.Show("Bu öğrenciye ait açık bir kitap kaydı bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            islem.GeriAlinanTarih = DateTime.Now;

            // MevcutAdet artır
            var kitapEntity = db.Kitaplars.FirstOrDefault(k => k.KitapId == kitapId);
            if (kitapEntity != null)
            {
                kitapEntity.MevcutAdet += 1;
            }

            db.SaveChanges();

            TimeSpan? fark = islem.GeriAlinanTarih - islem.TeslimTarihi;
            int gecikmeGun = fark.HasValue ? fark.Value.Days : 0;

            if (gecikmeGun > 0)
            {
                MessageBox.Show($"Kitap {gecikmeGun} gün geç teslim edildi. Ceza listesine eklenecek.",
                    "Gecikme", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("Kitap zamanında teslim edildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            CbOgrenci_SelectedIndexChanged(null, null);
            KitaplariListele(); // Liste güncelle
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

        private void GridStilOgrenciAyarlari()
        {
            dataGridIslemler.RowHeadersVisible = false;
            dataGridIslemler.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridIslemler.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridIslemler.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dataGridIslemler.DefaultCellStyle.SelectionForeColor = Color.White;
            dataGridIslemler.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);
            dataGridIslemler.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(30, 30, 60);
            dataGridIslemler.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridIslemler.EnableHeadersVisualStyles = false;
            dataGridIslemler.DefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            dataGridIslemler.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Bold);
        }

        private void dataGridKitaplar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string secilenKitapAdi = dataGridKitaplar.Rows[e.RowIndex].Cells["KitapAdi"].Value.ToString();

                // ComboBox'ta eşleşen kitabı bul
                foreach (var item in cbKitap.Items)
                {
                    var kitap = item as Kitaplar;
                    if (kitap != null && kitap.KitapAdi == secilenKitapAdi)
                    {
                        cbKitap.SelectedItem = item;
                        break;
                    }
                }
            }
        }
    }
}
