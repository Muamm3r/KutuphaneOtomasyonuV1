using System;
using System.Collections.Generic;

namespace KutuphaneOtomasyonu.Models;

public partial class Ogrenciler
{
    public int OgrenciId { get; set; }

    public string? Ad { get; set; }

    public string? Soyad { get; set; }

    public string? Numara { get; set; }

    public int SinifId { get; set; }

    public virtual ICollection<Cezalar> Cezalars { get; set; } = new List<Cezalar>();

    public virtual Siniflar Sinif { get; set; } = null!;
    public virtual ICollection<KitapIslemleri> KitapIslemleri { get; set; } = new List<KitapIslemleri>();


}
