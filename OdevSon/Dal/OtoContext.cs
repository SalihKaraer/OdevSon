using OdevSon.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace OdevSon.Dal
{
    public class OtoContext : DbContext
    {
        public OtoContext() : base("cstr")
        {

        }
        public DbSet<Oto> Otomobil { get; set; }
        public DbSet<Kullanici> Kullanicilar { get; set; }
        public DbSet<Parca> Parcalar { get; set; }
        // veritabanındaki belleklerin karşılığı

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Oto>().ToTable("tblAraclar");
            modelBuilder.Entity<Oto>().Property(a => a.Marka).HasColumnType("varchar").HasMaxLength(50).IsRequired();
            modelBuilder.Entity<Oto>().Property(a => a.Model).HasColumnType("varchar").HasMaxLength(75).IsRequired();


            modelBuilder.Entity<Parca>().ToTable("tblParca");
            modelBuilder.Entity<Parca>().Property(p => p.ParcaAd).HasColumnType("varchar").HasMaxLength(50).IsRequired();
            modelBuilder.Entity<Parca>().Property(p => p.ParcaTur).HasColumnType("varchar").HasMaxLength(75).IsRequired();

            modelBuilder.Entity<Kullanici>().ToTable("tblKullanici");
            modelBuilder.Entity<Kullanici>().Property(k => k.KullaniciAd).HasColumnType("varchar").HasMaxLength(25).IsRequired();
            modelBuilder.Entity<Kullanici>().Property(k=> k.Sifre).HasColumnType("varchar").HasMaxLength(15).IsRequired();

        }
    }
}
        
        
