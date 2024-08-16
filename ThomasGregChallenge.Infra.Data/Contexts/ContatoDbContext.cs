using Microsoft.EntityFrameworkCore;

using ThomasGregChallenge.Domain.Entidades.Cliente;
using ThomasGregChallenge.Infra.Data.Feature;

namespace ThomasGregChallenge.Infra.Data.Contexts
{
    public class ClienteDbContext : DbContext
    {
        public ClienteDbContext(DbContextOptions<ClienteDbContext> options) : base(options)
        {
        }

        public DbSet<ClienteVO> Empresa { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClienteConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies(false);
        }
    }
}
