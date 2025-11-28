//using LarAPP.src.Entities;
using LarAPP.src.Entities;
using Microsoft.EntityFrameworkCore;


namespace Projeto.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }


        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Telefone> Telefones { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pessoa>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Nome).IsRequired().HasMaxLength(200);
                entity.Property(e => e.CPF).IsRequired().HasMaxLength(11);
            });


            modelBuilder.Entity<Telefone>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Numero).IsRequired().HasMaxLength(20);
                entity.Property(e => e.Tipo).IsRequired();
                entity.HasOne(t => t.Pessoa)
                .WithMany(p => p.Telefones)
                .HasForeignKey(t => t.PessoaId)
                .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}