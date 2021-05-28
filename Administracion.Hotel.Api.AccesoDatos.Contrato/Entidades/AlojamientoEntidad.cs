using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Administracion.Hotel.Api.AccesoDatos.Contrato.Entidades
{
    public class AlojamientoEntidad
    {
        [Key]
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public int Estado { get; set; }
        public List<HabitacionEntidad> Habitacion { get; set; }
    }
}
