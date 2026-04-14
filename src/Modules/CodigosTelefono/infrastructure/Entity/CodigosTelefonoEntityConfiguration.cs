using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gestion_vuelos.src.Modules.CodigosTelefono.infrastructure.Entity;

public class CodigosTelefonoEntityConfiguration : IEntityTypeConfiguration<CodigosTelefonoEntity>
{
 public void Configure(EntityTypeBuilder<CodigosTelefonoEntity> builder)
        {
            builder.ToTable("phone_codes");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("id")
                .IsRequired();

            builder.Property(x => x.Country_code)
                .HasColumnName("Country_code")
                .HasMaxLength(50)
                .IsRequired();
                
            builder.Property(x => x.Pais)
                .HasColumnName("Pais")
                .HasMaxLength(10)
                .IsRequired();                
        }
}
