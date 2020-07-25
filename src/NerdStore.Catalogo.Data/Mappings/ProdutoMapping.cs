using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NerdStore.Catalogo.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace NerdStore.Catalogo.Data.Mappings
{
    public class ProdutoMapping : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome)
                .IsRequired()
                .HasColumnType("varchar(250)");

            builder.Property(x => x.Descricao)
                .IsRequired()
                .HasColumnType("varchar(500)");

            builder.Property(x => x.Imagem)
                .IsRequired()
                .HasColumnType("varchar(250)");

            builder.OwnsOne(x => x.Dimensoes, c =>
             {
                 c.Property(x => x.Altura)
                    .HasColumnType("int");

                 c.Property(x => x.Largura)
                    .HasColumnType("int");

                 c.Property(x => x.Profundidade)
                    .HasColumnType("int");

             });

            builder.ToTable("Produto");
        }
    }
}
