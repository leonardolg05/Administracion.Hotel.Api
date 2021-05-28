using Administracion.Hotel.Api.AccesoDatos.Contrato.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Administracion.Hotel.Api.AccesoDatos.ConfiguracionEntidad
{
    public static class HuespedConfiguracionEntidad
    {
        public static void SetEntityBuilder(EntityTypeBuilder<HuespedEntidad> entityBuilder)
        {
            entityBuilder.ToTable("TblHuesped");
            entityBuilder.HasKey(huesped => huesped.Id);
            entityBuilder.Property(huesped => huesped.Id).IsRequired();
            entityBuilder.Property(huesped => huesped.SegundoNombre).HasColumnType("VARCHAR(200)");
            entityBuilder.Property(huesped => huesped.SegundoNombre).HasColumnType("VARCHAR(30)");
            entityBuilder.Property(huesped => huesped.PrimerApellido).HasColumnType("VARCHAR(30)");
            entityBuilder.Property(huesped => huesped.SegundoApellido).HasColumnType("VARCHAR(30)");
        }
    }
}
