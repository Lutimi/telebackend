using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Revifast.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Revifast.Data
{
    public class ProvinciaMap : IEntityTypeConfiguration<Provincia>
    {
        public void Configure(EntityTypeBuilder<Provincia> builder)
        {
            // ID
            builder.ToTable("Provincia")
                .HasKey(p => p.ProvinciaId);
            // NOMBRE
            builder.Property(p => p.Nombre)
                .HasColumnName("Nombre")
                .HasMaxLength(20)
                .IsUnicode(false);
            // ---------- HAS ONE
            builder.HasOne(p => p.Departamento)
                .WithMany(p => p.Provincias)
                .HasForeignKey(p => p.DepartamentoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Provincia_Departamento");
        }
    }
}
