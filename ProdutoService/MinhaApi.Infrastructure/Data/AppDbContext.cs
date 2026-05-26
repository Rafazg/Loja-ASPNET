using Microsoft.EntityFrameworkCore;
using MinhaApi.Domain.Entities;
using MinhaApi.Infrastructure.Configurations;

namespace MinhaApi.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Produto> Produtos
    {
        get
        {
            return Set<Produto>();
        }
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ProdutoConfiguration());
        base.OnModelCreating(modelBuilder);
    }
}