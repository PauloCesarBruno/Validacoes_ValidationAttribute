using Microsoft.EntityFrameworkCore;
using ValidacoesAPI.Models;

namespace ValidacoesAPI.Data.DataContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }

        public DbSet<Cliente> Clientes { get; set; }
    }
}
