using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NerdStore.Catalogo.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace NerdStore.Catalogo.Data.Mappings
{
    public class CategoriaMapping : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(x => x.Nome)
                .IsRequired()
                .HasColumnType("varchar(250)");

            builder.Property(x => x.Codigo)
                .IsRequired()
                .HasColumnType("int");

            builder.HasMany(c => c.Produtos)
                .WithOne(p=> p.Categoria)
                .HasForeignKey(p=> p.IdCategoria);

            builder.ToTable("Categoria");
        }
    }
}
