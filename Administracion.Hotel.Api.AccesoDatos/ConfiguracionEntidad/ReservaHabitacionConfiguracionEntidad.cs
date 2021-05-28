namespace Administracion.Hotel.Api.AccesoDatos.ConfiguracionEntidad
{
    using Administracion.Hotel.Api.AccesoDatos.Contrato.Entidades;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    public static class ReservaHabitacionConfiguracionEntidad
    {
        public static void SetEntityBuilder(EntityTypeBuilder<ReservaHabitacionEntidad> entityBuilder)
        {
            entityBuilder.ToTable("TblReservaHabitacion");
            entityBuilder.HasKey(reservaHabitacion => reservaHabitacion.Id);
            entityBuilder.Property(reservaHabitacion=> reservaHabitacion.Id).IsRequired();
            entityBuilder.HasOne(alojamiento => alojamiento.Habitacion).WithMany(alojamiento => alojamiento.ReservasHabitacion).HasForeignKey(reserva => reserva.IdHabitacion).HasPrincipalKey(habitacion => habitacion.Id);
            entityBuilder.Property(reservaHabitacion=> reservaHabitacion.IdHabitacion).HasColumnType("INT");
            entityBuilder.HasMany(huespedes => huespedes.Huespedes).WithOne(reserva => reserva.ReservaHabitacion).HasForeignKey(reserva => reserva.Id).HasPrincipalKey(huesped => huesped.IdHuesped);
            entityBuilder.Property(reservaHabitacion=> reservaHabitacion.IdHuesped).HasColumnType("uniqueidentifier");
            entityBuilder.Property(reservaHabitacion=> reservaHabitacion.NombreContacto).HasColumnType("VARCHAR(50)");
            entityBuilder.Property(reservaHabitacion=> reservaHabitacion.TelefonoContacto).HasColumnType("VARCHAR(20)");
            entityBuilder.Property(reservaHabitacion=> reservaHabitacion.FechaIngreso).HasColumnType("DATETIME");
            entityBuilder.Property(reservaHabitacion=> reservaHabitacion.FechaIngreso).HasColumnType("DATETIME(30)");
        }
    }
}
