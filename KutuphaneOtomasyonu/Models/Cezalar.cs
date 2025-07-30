using System;
using System.Collections.Generic;

namespace KutuphaneOtomasyonu.Models;

public partial class Cezalar
{
    public int CezaId { get; set; }

    public int OgrenciId { get; set; }

    public int KitapId { get; set; }

    public int IslemId { get; set; }

    public int? GecikmeGun { get; set; }

    public string? CezaTuru { get; set; }

    public string? Aciklama { get; set; }

    public bool? Odendi { get; set; }

    public DateTime? Tarih { get; set; }

    public virtual KitapIslemleri Islem { get; set; } = null!;

    public virtual Kitaplar Kitap { get; set; } = null!;

    public virtual Ogrenciler Ogrenci { get; set; } = null!;
}
