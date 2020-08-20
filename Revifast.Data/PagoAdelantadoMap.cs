using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Revifast.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Revifast.Data
{
    public class PagoAdelantadoMap : IEntityTypeConfiguration<PagoAdelantado>
    {
        public void Configure(EntityTypeBuilder<PagoAdelantado> builder)
        {
            // ID
            builder.ToTable("PagoAdelantado")
                .HasKey(p => p.PagoAdelantadoId);
            // NOMBRE
            builder.Property(p => p.Nombre)
                .HasColumnName("Nombre")
                .HasMaxLength(20)
                .IsUnicode(false);
            // PORCENTAJE
            builder.Property(p => p.Procentaje)
                .HasColumnName("Procentaje");
            // DESCRIPCION
            builder.Property(p => p.Descripcion)
                .HasColumnName("Descripcion")
                .HasMaxLength(250)
                .IsUnicode(false);
            // ---------- HAS ONE

        }
    }
}
