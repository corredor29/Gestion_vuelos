using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gestion_vuelos.src.Modules.Paises.infrastructure.Entity;

public class PaisesEntityConfiguration : IEntityTypeConfiguration<PaisesEntity>
{
    public void Configure(EntityTypeBuilder<PaisesEntity> builder)
    {
        builder.ToTable("Country");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("id")
            .HasMaxLength(64)
            .IsRequired();

        builder.Property(x => x.Name)
            .HasColumnName("name")
            .HasMaxLength(150)
            .IsRequired();
        builder.Property(x => x.CodigoIso)
            .HasColumnName("codigoIso")
            .HasMaxLength(3)
            .IsRequired();
        builder.HasIndex(x => x.CodigoIso)
            .IsUnique();
    }
}
