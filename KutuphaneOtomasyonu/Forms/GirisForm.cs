using KutuphaneOtomasyonu.Models;
// MetroFramework formunu kullanmak için bu using ifadesi gereklidir.
using MetroFramework.Forms;
using System;
using System.Linq;
using System.Windows.Forms;

namespace KutuphaneOtomasyonu
{
    // Formun MetroForm'dan miras aldığından emin olalım.
    public partial class GirisForm : Form
    {
        public GirisForm()
        {
            InitializeComponent();
        }

        private void GirisForm_Load(object sender, EventArgs e)
        {
            try
            {
                using (var dbContext = new KutuphaneContext())
                {
                    var ayar = dbContext.Ayarlars.FirstOrDefault(a => a.AyarAdi == "OkulAdi");
                    if (ayar != null)
                    {
                        // Not: Eğer lblOkulAdi bir MetroLabel ise, bu atama doğru çalışır.
                        lblOkulAdi.Text = ayar.Deger;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veritabanı bağlantısı kurulamadı. Ayarlar okunamadı.\n" + ex.Message, "Kritik Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGirisYap_Click(object sender, EventArgs e)
        {
            // .Trim() kullanarak baştaki ve sondaki boşlukları temizlemek iyi bir pratik.
            string kullaniciAdi = txtKullaniciAdi.Text.Trim();
            string sifre = txtSifre.Text; // Şifrelerde boşluk olabileceğinden .Trim() kullanmayabiliriz.

            if (string.IsNullOrWhiteSpace(kullaniciAdi) || string.IsNullOrWhiteSpace(sifre))
            {
                MessageBox.Show("Lütfen kullanıcı adı ve şifreyi girin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var db = new KutuphaneContext())
                {
                    // İYİLEŞTİRME: Sorguyu veritabanında daha verimli çalışacak şekilde güncelledik.
                    // ToUpper() metodu, büyük/küçük harf duyarsız karşılaştırma için kullanılır.
                    var kullanici = db.Kullanicilars
                                      .FirstOrDefault(k =>
                                          k.KullaniciAdi.ToUpper() == kullaniciAdi.ToUpper() &&
                                          k.Sifre == sifre);

                    // GÜVENLİK UYARISI: Yukarıdaki şifre karşılaştırması güvenli değildir!
                    // Gerçek bir projede şifreler hash'lenerek karşılaştırılmalıdır.
                    // Örnek: if (BCrypt.Net.BCrypt.Verify(sifre, kullanici.SifreHash)) { ... }

                    if (kullanici != null)
                    {
                        // Giriş başarılı, rol kontrolü yap ve ilgili paneli aç.
                        if (kullanici.Rol == "Yönetici")
                        {
                            var yoneticiPanel = new YoneticiPanel();
                            // İYİLEŞTİRME: Yeni form kapandığında, bu formun da kapanmasını sağlıyoruz.
                            yoneticiPanel.FormClosed += (s, args) => this.Close();
                            yoneticiPanel.Show();
                        }
                        else if (kullanici.Rol == "Görevli")
                        {
                            var gorevliPanel = new GorevliPanel();
                            // İYİLEŞTİRME: Yeni form kapandığında, bu formun da kapanmasını sağlıyoruz.
                            gorevliPanel.FormClosed += (s, args) => this.Close();
                            gorevliPanel.Show();
                        }
                        else
                        {
                            MessageBox.Show("Kullanıcının rolü tanımlı değil!", "Yetki Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return; // Rolü olmayan giriş yapamasın.
                        }

                        // Panellerden biri açıldıktan sonra giriş formunu gizle.
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Hatalı kullanıcı adı veya şifre!", "Giriş Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veritabanı işlemi sırasında bir hata oluştu: " + ex.Message, "Sistem Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
        private void txtKullaniciAdi_Click(object sender, EventArgs e)
        {
            if (txtKullaniciAdi.Text == "Kullanıcı Adı")
                txtKullaniciAdi.Text = "";
        }

        private void txtSifre_Click(object sender, EventArgs e)
        {
            if (txtSifre.Text == "Şifre")
                txtSifre.Text = "";
        }
        
    }
}