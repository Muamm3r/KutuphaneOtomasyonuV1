using System;
using System.Collections.Generic;

namespace KutuphaneOtomasyonu.Models;

public partial class Siniflar
{
    public int SinifId { get; set; }

    public int Seviye { get; set; }

    public string Sube { get; set; } = null!;

    public virtual ICollection<Ogrenciler> Ogrencilers { get; set; } = new List<Ogrenciler>();
}
