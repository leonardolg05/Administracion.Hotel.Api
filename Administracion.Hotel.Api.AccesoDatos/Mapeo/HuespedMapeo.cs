using Administracion.Hotel.Api.AccesoDatos.Contrato.Entidades;
using Administracion.Hotel.Api.Negocio.Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Administracion.Hotel.Api.AccesoDatos.Mapeo
{
    public class HuespedMapeo
    {
        public static HuespedEntidad Map(Huesped huesped)
        {
            return new HuespedEntidad()
            {
                Id = huesped.Id,
                PrimerApellido = huesped.PrimerApellido,
                SegundoApellido = huesped.SegundoApellido,
                PrimerNombre = huesped.PrimerNombre,
                SegundoNombre = huesped.SegundoNombre,
                Estado = huesped.Estado,
                FechaNacimiento = huesped.FechaNacimiento,
                Identificacion = huesped.Identificacion,
                TipoIdentificacion = huesped.TipoIdentificacion,
                Email = huesped.Email,
                Genero = huesped.Genero,
                TelefonoContacto = huesped.TelefonoContacto
            };
        }
        public static List<HuespedEntidad> Map(List<Huesped> huespedes)
        {
            var listaHuesped = new List<HuespedEntidad>();
            foreach (Huesped huesped in huespedes)
            {
                listaHuesped.Add(Map(huesped));
            }
            return listaHuesped;
        }
        public static Huesped MapEntidad(HuespedEntidad huesped)
        {
            return new Huesped()
            {
                Id = huesped.Id,
                PrimerApellido = huesped.PrimerApellido,
                SegundoApellido = huesped.SegundoApellido,
                PrimerNombre = huesped.PrimerNombre,
                SegundoNombre = huesped.SegundoNombre,
                Estado = huesped.Estado,
                FechaNacimiento = huesped.FechaNacimiento,
                Identificacion = huesped.Identificacion,
                TipoIdentificacion = huesped.TipoIdentificacion,
                Email = huesped.Email,
                Genero = huesped.Genero,
                TelefonoContacto = huesped.TelefonoContacto
            };
        }

        public static List<Huesped> MapEntidad(List<HuespedEntidad> huespedes)
        {
            var listaHuesped = new List<Huesped>();
            foreach (HuespedEntidad huesped in huespedes)
            {
                listaHuesped.Add(MapEntidad(huesped));
            }
            return listaHuesped;
        }
    }
}
