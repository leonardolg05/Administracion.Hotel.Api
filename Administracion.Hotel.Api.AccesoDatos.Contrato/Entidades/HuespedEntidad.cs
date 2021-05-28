using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Administracion.Hotel.Api.AccesoDatos.Contrato.Entidades
{
    public class HuespedEntidad
    {
        [Key]
        public Guid Id { get; set; }
        public int Estado { get; set; }
        public int Identificacion { get; set; }
        public int TipoIdentificacion { get; set; }
        public int Genero { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string Email { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string TelefonoContacto { get; set; }
        public ReservaHabitacionEntidad ReservaHabitacion {get;set;}
    }
}
