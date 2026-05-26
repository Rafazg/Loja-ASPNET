using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MinhaApi.Application.Interfaces;
using MinhaApi.Application.Mappings;
using MinhaApi.Application.Services;
using MinhaApi.Domain.Interfaces;
using MinhaApi.Infrastructure.Data;
using MinhaApi.Infrastructure.Repositories;

namespace MinhaApi.CrossCutting.IoC;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        // EF Core + SQL Server
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(
                configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly("MinhaApi.Infrastructure")));

        // Repositories
        services.AddScoped<IProdutoRepository, ProdutoRepository>();

        return services;
    }

    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        // AutoMapper
        services.AddAutoMapper(cfg => cfg.AddProfile<ProdutoProfile>());

        // Services
        services.AddScoped<IProdutoService, ProdutoService>();

        return services;
    }
}