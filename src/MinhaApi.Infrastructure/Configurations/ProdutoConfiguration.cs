using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MinhaApi.Domain.Entities;

namespace MinhaApi.Infrastructure.Configurations;

public class ProdutoConfiguration : IEntityTypeConfiguration<Produto>
{
    public void Configure(EntityTypeBuilder<Produto> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Nome)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(p => p.Descricao)
            .IsRequired()
            .HasMaxLength(500);

        builder.Property(p => p.Preco)
            .IsRequired()
            .HasPrecision(18, 2); // DECIMAL(18,2)

        builder.Property(p => p.QuantidadeEstoque)
            .IsRequired();

        builder.Property(p => p.DataCriacao)
            .IsRequired();

        builder.Property(p => p.Ativo)
            .IsRequired();

        builder.HasIndex(p => p.Nome);
        builder.HasQueryFilter(p => p.Ativo); // Soft delete global
    }
}