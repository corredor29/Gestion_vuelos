using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gestion_vuelos.src.Modules.DominiosEmail.infrastructure.Entity;

public class DominiosEmailEntityConfiguration : IEntityTypeConfiguration<DominiosEmailEntity>
{
    public void Configure(EntityTypeBuilder<DominiosEmailEntity> builder)
    {
        builder.ToTable("email_domains");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("id")
            .HasMaxLength(64)
            .IsRequired();

        builder.Property(x => x.Dominio)
            .HasColumnName("Dominio")
            .HasMaxLength(150)
            .IsRequired();

    }
}
