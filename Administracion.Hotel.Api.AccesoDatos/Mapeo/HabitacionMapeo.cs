using Administracion.Hotel.Api.AccesoDatos.Contrato.Entidades;
using Administracion.Hotel.Api.Negocio.Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Administracion.Hotel.Api.AccesoDatos.Mapeo
{
    public class HabitacionMapeo
    {
        public static HabitacionEntidad Map(Habitacion habitacion)
        {
            return new HabitacionEntidad()
            {
                Id = habitacion.Id,
                CapacidadPersonas = habitacion.CapacidadPersonas,
                Estado = habitacion.Estado,
                //Alojamiento = AlojamientoMapeo.Map(habitacion.Alojamiento),
                AlojamientoId = habitacion.AlojamientoId,
                Localizacion = habitacion.Localizacion,
                Numero = habitacion.Numero,
                NumeroCamas = habitacion.NumeroCamas,
                Piso = habitacion.Piso,
                TipoHabitacion = habitacion.TipoHabitacion,
                Vista = habitacion.Vista
            };
        }
        public static List<HabitacionEntidad> Map(List<Habitacion> habitaciones)
        {
            var listaHabitaciones = new List<HabitacionEntidad>();
            foreach (Habitacion habitacion in habitaciones)
            {
                listaHabitaciones.Add(Map(habitacion));
            }
            return listaHabitaciones;
        }
        public static Habitacion MapEntidad(HabitacionEntidad habitacion)
        {
            return new Habitacion()
            {
                Id = habitacion.Id,
                CapacidadPersonas = habitacion.CapacidadPersonas,
                Estado = habitacion.Estado,
                //Alojamiento = AlojamientoMapeo.MapEntidad(habitacion.Alojamiento),
                AlojamientoId = habitacion.AlojamientoId,
                Localizacion = habitacion.Localizacion,
                Numero = habitacion.Numero,
                NumeroCamas = habitacion.NumeroCamas,
                Piso = habitacion.Piso,
                TipoHabitacion = habitacion.TipoHabitacion,
                Vista = habitacion.Vista,
                //ReservasHabitacion = ReservaHabitacionMapeo.MapEntidad(habitacion.ReservasHabitacion)
            };
        }
        public static List<Habitacion> MapEntidad(List<HabitacionEntidad> habitaciones)
        {
            var listaHabitaciones = new List<Habitacion>();
            foreach (HabitacionEntidad habitacion in habitaciones)
            {
                listaHabitaciones.Add(MapEntidad(habitacion));
            }
            return listaHabitaciones;
        }
    }
}
