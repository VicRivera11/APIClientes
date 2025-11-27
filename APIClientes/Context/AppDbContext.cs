using Microsoft.EntityFrameworkCore;
using APIClientes.Dtos; 

namespace APIClientes.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        
        public DbSet<ClienteDto> Clientes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<ClienteDto>().ToTable("Cliente");
        }
    }
}