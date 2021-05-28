namespace Administracion.Hotel.Api.AccesoDatos.Mapeo
{
    using Administracion.Hotel.Api.AccesoDatos.Contrato.Entidades;
    using Administracion.Hotel.Api.Negocio.Modelos;
    using System.Collections.Generic;

    public class ReservaHabitacionMapeo
    {
        public static ReservaHabitacionEntidad Map(ReservaHabitacion reserva)
        {
            return new ReservaHabitacionEntidad()
            {
                Id = reserva.Id,
                FechaIngreso = reserva.FechaIngreso,
                FechaSalida = reserva.FechaSalida,
                IdHabitacion = reserva.IdHabitacion,
                IdHuesped = reserva.IdHuesped,
                NombreContacto = reserva.NombreContacto,
                TelefonoContacto = reserva.TelefonoContacto,
                Huespedes = HuespedMapeo.Map(reserva.Huespedes)
            };
        }

        public static List<ReservaHabitacionEntidad> Map(List<ReservaHabitacion> reservas)
        {
            var reservaHabitaciones = new List<ReservaHabitacionEntidad>();
            foreach(ReservaHabitacion reserva in reservas)
            {
                reservaHabitaciones.Add(Map(reserva));
            }
            return reservaHabitaciones;
        }
        public static ReservaHabitacion MapEntidad(ReservaHabitacionEntidad reserva)
        {
            return new ReservaHabitacion()
            {
                Id = reserva.Id,
                FechaIngreso = reserva.FechaIngreso,
                FechaSalida = reserva.FechaSalida,
                IdHabitacion = reserva.IdHabitacion,
                IdHuesped = reserva.IdHuesped,
                NombreContacto = reserva.NombreContacto,
                TelefonoContacto = reserva.TelefonoContacto
            };
        }

        public static List<ReservaHabitacion> MapEntidad(List<ReservaHabitacionEntidad> reservaHabitaciones)
        {
            var listaHabitaciones = new List<ReservaHabitacion>();
            foreach (ReservaHabitacionEntidad reserva in reservaHabitaciones)
            {
                listaHabitaciones.Add(MapEntidad(reserva));
            }
            return listaHabitaciones;
        }
    }
}
