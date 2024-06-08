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

        public DbSet<Livro> Livros { get; set; }
    }
}
