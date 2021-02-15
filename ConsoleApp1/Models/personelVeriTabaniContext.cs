using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ConsoleApp1.Models
{
    public partial class personelVeriTabaniContext : DbContext
    {
        public personelVeriTabaniContext()
        {
        }

        public personelVeriTabaniContext(DbContextOptions<personelVeriTabaniContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblPersonel> TblPersonel { get; set; }
        public virtual DbSet<TblYonetici> TblYonetici { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-J7TKCO6\\SQLEXPRESS;Initial Catalog=personelVeriTabani;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblPersonel>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Tbl_personel");

                entity.Property(e => e.PerAd)
                    .HasColumnName("perAd")
                    .HasMaxLength(15);

                entity.Property(e => e.PerDurum).HasColumnName("perDurum");

                entity.Property(e => e.PerId).HasColumnName("perId");

                entity.Property(e => e.PerMaas).HasColumnName("perMaas");

                entity.Property(e => e.PerMeslek)
                    .HasColumnName("perMeslek")
                    .HasMaxLength(30);

                entity.Property(e => e.PerSehir)
                    .HasColumnName("perSehir")
                    .HasMaxLength(13);

                entity.Property(e => e.PerSoyad)
                    .HasColumnName("perSoyad")
                    .HasMaxLength(25);
            });

            modelBuilder.Entity<TblYonetici>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Tbl_yonetici");

                entity.Property(e => e.Admin).HasColumnName("admin");

                entity.Property(e => e.KullaniciAd)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Sifre)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
