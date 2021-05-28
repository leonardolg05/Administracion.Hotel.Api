using Administracion.Hotel.Api.AccesoDatos.Contrato.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Administracion.Hotel.Api.AccesoDatos.ConfiguracionEntidad
{
    public static class HabitacionConfiguracionEntidad
    {
        public static void SetEntityBuilder(EntityTypeBuilder<HabitacionEntidad> entityBuilder)
        {
            entityBuilder.ToTable("TblHabitacion");
            entityBuilder.HasKey(habitacion => habitacion.Id);
            entityBuilder.Property(habitacion => habitacion.Id).IsRequired();
            entityBuilder.Property(habitacion => habitacion.Piso).HasColumnType("INT");
            entityBuilder.HasOne(habitacion => habitacion.Alojamiento).WithMany(alojamiento => alojamiento.Habitacion).HasForeignKey(habitacion => habitacion.AlojamientoId).HasPrincipalKey(alojamiento => alojamiento.Id);
            entityBuilder.HasMany(habitacion => habitacion.ReservasHabitacion).WithOne(reservas => reservas.Habitacion).HasForeignKey(reserva => reserva.IdHabitacion).HasPrincipalKey(habitacion => habitacion.Id);
            entityBuilder.Property(habitacion => habitacion.Numero).HasColumnType("INT");
            entityBuilder.Property(habitacion => habitacion.Localizacion).HasColumnType("VARCHAR(30)");
            entityBuilder.Property(habitacion => habitacion.Estado).HasColumnType("INT");
        }
    }
}
