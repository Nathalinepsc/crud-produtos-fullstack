using Microsoft.EntityFrameworkCore;
using ProjetoNsaSenhora.Models;

namespace ProjetoNsaSenhora.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {
        }

        public DbSet<Produto> Produtos { get; set; }

    }
}