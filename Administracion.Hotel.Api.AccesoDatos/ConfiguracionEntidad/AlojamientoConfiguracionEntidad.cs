namespace Administracion.Hotel.Api.AccesoDatos.ConfiguracionEntidad
{
    using Administracion.Hotel.Api.AccesoDatos.Contrato.Entidades;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    public class AlojamientoConfiguracionEntidad
    {
        public static void SetEntityBuilder(EntityTypeBuilder<AlojamientoEntidad> entityBuilder)
        {
            entityBuilder.ToTable("TblHotel");
            entityBuilder.HasKey(habitacion => habitacion.Id);
            entityBuilder.Property(habitacion => habitacion.Id).IsRequired();
            entityBuilder.Property(habitacion => habitacion.Nombre).HasColumnType("VARCHAR(100)");
            entityBuilder.Property(habitacion => habitacion.Telefono).HasColumnType("VARCHAR(20)");
            entityBuilder.Property(habitacion => habitacion.Direccion).HasColumnType("VARCHAR(100)");
            entityBuilder.Property(habitacion => habitacion.Estado).HasColumnType("INT");
        }
    }
}
