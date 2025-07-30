using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace KutuphaneOtomasyonu.Models;

public partial class KutuphaneContext : DbContext
{
    public KutuphaneContext()
    {
    }

    public KutuphaneContext(DbContextOptions<KutuphaneContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Ayarlar> Ayarlars { get; set; }

    public virtual DbSet<Cezalar> Cezalars { get; set; }

    public virtual DbSet<KitapIslemleri> KitapIslemleris { get; set; }

    public virtual DbSet<Kitaplar> Kitaplars { get; set; }

    public virtual DbSet<Kullanicilar> Kullanicilars { get; set; }

    public virtual DbSet<Ogrenciler> Ogrencilers { get; set; }

    public virtual DbSet<Siniflar> Siniflars { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlite("Data Source=Kutuphane.db");


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Ayarlar>(entity =>
        {
            entity.HasKey(e => e.AyarAdi);

            entity.ToTable("Ayarlar");
        });

        // KutuphaneContext.cs dosyasında OnModelCreating metodundaki Cezalar kısmını şu şekilde değiştirin:

        modelBuilder.Entity<Cezalar>(entity =>
        {
            entity.HasKey(e => e.CezaId);
            entity.ToTable("Cezalar");

            // Boolean için varsayılan değeri false olarak ayarlayın (0 yerine)
            entity.Property(e => e.Odendi).HasDefaultValue(false);

            entity.Property(e => e.Tarih).HasDefaultValueSql("CURRENT_TIMESTAMP");

            entity.HasOne(d => d.Islem).WithMany(p => p.Cezalars)
                .HasForeignKey(d => d.IslemId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Kitap).WithMany(p => p.Cezalars)
                .HasForeignKey(d => d.KitapId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Ogrenci).WithMany(p => p.Cezalars)
                .HasForeignKey(d => d.OgrenciId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<KitapIslemleri>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.ToTable("KitapIslemleri");
        });

        modelBuilder.Entity<Kitaplar>(entity =>
        {
            entity.HasKey(e => e.KitapId);

            entity.ToTable("Kitaplar");
        });

        modelBuilder.Entity<Kullanicilar>(entity =>
        {
            entity.HasKey(e => e.KullaniciId);

            entity.ToTable("Kullanicilar");
        });

        modelBuilder.Entity<Ogrenciler>(entity =>
        {
            entity.HasKey(e => e.OgrenciId);

            entity.ToTable("Ogrenciler");

            entity.HasIndex(e => e.Numara, "IX_Ogrenciler_Numara").IsUnique();

            entity.HasOne(d => d.Sinif).WithMany(p => p.Ogrencilers)
                .HasForeignKey(d => d.SinifId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Siniflar>(entity =>
        {
            entity.HasKey(e => e.SinifId);

            entity.ToTable("Siniflar");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
