using System.Collections.Generic;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using ProjetoCinema.Models;



namespace ProjetoCinema.Data
{
    public class CinemaDBContext : DbContext
    {
        public CinemaDBContext(DbContextOptions<CinemaDBContext> options) : base(options) { }

        public DbSet<Diretor> Diretores { get; set; }
        public DbSet<Filme> Filmes { get; set; }
        public DbSet<Premiacao> Premiacoes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Definir o nome correto das tabelas
            modelBuilder.Entity<Diretor>().ToTable("tbDiretores");
            modelBuilder.Entity<Filme>().ToTable("tbFilmes");
            modelBuilder.Entity<Premiacao>().ToTable("tbPremiacoes");


            // Definição das chaves primárias
            modelBuilder.Entity<Diretor>().HasKey(d => d.idDiretor);
            modelBuilder.Entity<Filme>().HasKey(f => f.idFilme);
            modelBuilder.Entity<Premiacao>().HasKey(p => p.idPremiacao);


            modelBuilder.Entity<Filme>()
                .HasOne(d => d.Diretor)
                .WithMany(d => d.FilmeDiretor)
                .HasForeignKey(d => d.IdDiretor)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Premiacao>()
                .HasOne(f => f.Filme)
                .WithMany(f => f.PremioFilme)
                .HasForeignKey(f => f.idFilme)
                .OnDelete(DeleteBehavior.Restrict);

        


        }

    }
}
