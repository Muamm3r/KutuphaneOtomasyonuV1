using System;
using System.Collections.Generic;

namespace KutuphaneOtomasyonu.Models;

public partial class Kullanicilar
{
    public int KullaniciId { get; set; }

    public string? Ad { get; set; }

    public string? Soyad { get; set; }

    public string? KullaniciAdi { get; set; }

    public string? Sifre { get; set; }

    public string? Rol { get; set; }
}
