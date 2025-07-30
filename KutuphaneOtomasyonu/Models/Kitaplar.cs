using System;
using System.Collections.Generic;

namespace KutuphaneOtomasyonu.Models;

public partial class Kitaplar
{
    public int KitapId { get; set; }

    public string KitapAdi { get; set; } = null!;

    public string? Yazar { get; set; }

    public string? YayinEvi { get; set; }

    public string? Barkod { get; set; }

    public string? RafNo { get; set; }

    public string? Tur { get; set; }

    public int KitapSayisi { get; set; }

    public int MevcutAdet { get; set; }

    public string? BasimYeri { get; set; }

    public DateTime? BasimTarihi { get; set; }

    public int? SayfaSayisi { get; set; }

    public virtual ICollection<Cezalar> Cezalars { get; set; } = new List<Cezalar>();
    public virtual ICollection<KitapIslemleri> KitapIslemleri { get; set; } = new List<KitapIslemleri>();


}
