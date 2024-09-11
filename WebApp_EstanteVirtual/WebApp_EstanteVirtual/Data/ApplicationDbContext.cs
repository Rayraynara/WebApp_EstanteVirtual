using Microsoft.EntityFrameworkCore;
using WebApp_EstanteVirtual.Models;

namespace WebApp_EstanteVirtual.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Livro> Livros { get; set; }
        public DbSet<Venda> Vendas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(u => u.Id);
                entity.Property(u => u.Id).IsRequired();
                entity.Property(u => u.Nome).IsRequired();
                entity.Property(u => u.CPF).IsRequired();
                entity.Property(u => u.Email).IsRequired();
            });

            modelBuilder.Entity<Livro>()
                .Property(l => l.Preco)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Venda>()
                .Property(v => v.Total)
                .HasPrecision(18, 2);
        }
    }
}
