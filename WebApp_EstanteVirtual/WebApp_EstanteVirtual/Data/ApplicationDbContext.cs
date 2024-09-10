using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApp_EstanteVirtual.Models;

namespace WebApp_EstanteVirtual.Data
{
    public class ApplicationDbContext : IdentityDbContext<Usuario>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Livro> Livros { get; set; }
        public DbSet<Venda> Vendas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Livro>()
                .Property(l => l.Preco)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Venda>()
                .Property(v => v.Total)
                .HasPrecision(18, 2);

            // Removendo as colunas padrão do Identity que eu n quero
            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.Ignore(u => u.UserName);
                entity.Ignore(u => u.ConcurrencyStamp);
                entity.Ignore(u => u.EmailConfirmed);
                entity.Ignore(u => u.LockoutEnabled);
                entity.Ignore(u => u.LockoutEnd);
                entity.Ignore(u => u.PhoneNumber);
                entity.Ignore(u => u.PhoneNumberConfirmed);
                entity.Ignore(u => u.SecurityStamp);
                entity.Ignore(u => u.TwoFactorEnabled);
                entity.Ignore(u => u.AccessFailedCount);
                entity.Ignore(u => u.CEP);
                entity.Ignore(u => u.NumeroCartao);
                entity.Ignore(u => u.Endereco);
                entity.Ignore(u => u.Telefone);


            });

        }
    }
}
