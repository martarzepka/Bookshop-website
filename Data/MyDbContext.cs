using Ksiegarnia.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Ksiegarnia.Data
{
    public class MyDbContext:DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {

        }

        public DbSet<Ksiazka> Ksiazki { get; set; }
        public DbSet<Kategoria> Kategorie { get; set; }
        public DbSet<Autor> Autorzy { get; set; }
        public DbSet<Cena> Ceny { get; set; }
        public DbSet<KsiazkaAutor> KsiazkaAutor { get; set; }
        public DbSet<KsiazkaKategoria> KsiazkaKategoria { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<KsiazkaAutor>()
                        .HasKey(t => new { t.KsiazkaId, t.AutorId });
            modelBuilder.Entity<KsiazkaAutor>()
                        .HasOne(ka => ka.Ksiazka)
                        .WithMany(k => k.KsiazkaAutor)
                        .HasForeignKey(ka => ka.KsiazkaId);
            modelBuilder.Entity<KsiazkaAutor>()
                        .HasOne(ka => ka.Autor)
                        .WithMany(a => a.KsiazkaAutor)
                        .HasForeignKey(ka => ka.AutorId);

            modelBuilder.Entity<KsiazkaKategoria>()
                        .HasKey(t => new { t.KsiazkaId, t.KategoriaId });
            modelBuilder.Entity<KsiazkaKategoria>()
                        .HasOne(kk => kk.Ksiazka)
                        .WithMany(k => k.KsiazkaKategoria)
                        .HasForeignKey(kk => kk.KsiazkaId);
            modelBuilder.Entity<KsiazkaKategoria>()
                        .HasOne(kk => kk.Kategoria)
                        .WithMany(k => k.KsiazkaKategoria)
                        .HasForeignKey(kk => kk.KategoriaId);

            modelBuilder.Seed();
        }
    }
}
