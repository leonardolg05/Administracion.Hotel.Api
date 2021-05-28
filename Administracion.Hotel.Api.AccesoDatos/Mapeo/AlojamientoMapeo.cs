using Administracion.Hotel.Api.AccesoDatos.Contrato.Entidades;
using Administracion.Hotel.Api.Negocio.Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Administracion.Hotel.Api.AccesoDatos.Mapeo
{
    public static class AlojamientoMapeo
    {
        public static AlojamientoEntidad Map(Alojamiento alojamiento)
        {
            return new AlojamientoEntidad()
            {
                Id = alojamiento.Id,
                Nombre = alojamiento.Nombre,
                Direccion = alojamiento.Direccion,
                Estado = alojamiento.Estado,
             //   Habitacion = HabitacionMapeo.Map(alojamiento.Habitacion != null? alojamiento.Habitacion:new Habitacion),
                Telefono = alojamiento.Telefono
            };
        }
        public static Alojamiento MapEntidad(AlojamientoEntidad alojamiento)
        {
            return new Alojamiento()
            {
                Id = alojamiento.Id,
                Nombre = alojamiento.Nombre,
                Direccion = alojamiento.Direccion,
                Estado = alojamiento.Estado,
               // Habitacion = HabitacionMapeo.MapEntidad(alojamiento.Habitacion),
                Telefono = alojamiento.Telefono
            };
        }
    }
}
