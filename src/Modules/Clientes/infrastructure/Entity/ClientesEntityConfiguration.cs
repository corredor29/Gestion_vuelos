using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gestion_vuelos.src.Modules.Clientes.infrastructure.Entity;

public class ClientesEntityConfiguration : IEntityTypeConfiguration<ClientesEntity>
{
 public void Configure(EntityTypeBuilder<ClientesEntity> builder)
        {
            builder.ToTable("Clientes");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("id")
                .IsRequired();

            builder.Property(x => x.Tipo_Documento_Id)
                .HasColumnName("Tipo_Documento_Id")
                .IsRequired();

            builder.HasOne(x => x.TipoDocumento)
                .WithMany()
                .HasForeignKey(x => x.Tipo_Documento_Id)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Property(x => x.NumeroDocumento)
                .HasColumnName("Document Number")
                .HasMaxLength(50)
                .IsRequired();
            builder.Property(x => x.Name)
                .HasColumnName("name")
                .HasMaxLength(50)
                .IsRequired();
            builder.Property(x => x.Last_name)
                .HasColumnName("Last_name")
                .HasMaxLength(50)
                .IsRequired();     
                
                
        }
}
