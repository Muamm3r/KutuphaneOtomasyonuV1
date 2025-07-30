using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KutuphaneOtomasyonu.Models;

public partial class KitapIslemleri
{
    [Key]
    [Column("IslemId")]
    public int Id { get; set; }
    public int KitapId { get; set; }
    public int OgrenciId { get; set; }
    public DateTime AlisTarihi { get; set; }
    public DateTime TeslimTarihi { get; set; }
    public DateTime? GeriAlinanTarih { get; set; }

    public virtual Kitaplar Kitap { get; set; } // <--- BU KISMI EKLE

    public virtual ICollection<Cezalar> Cezalars { get; set; } = new List<Cezalar>();
    public virtual Ogrenciler Ogrenci { get; set; }

}
