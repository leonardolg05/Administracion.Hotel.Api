using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Administracion.Hotel.Api.AccesoDatos.Contrato.Entidades
{
    public class HabitacionEntidad
    {
        [Key]
        public int Id { get; set; }
        public int Numero { get; set; }
        public int Piso { get; set; }
        public int TipoHabitacion { get; set; }
        public int Vista { get; set; }
        public int Localizacion { get; set; }
        public int NumeroCamas { get; set; }
        public int CapacidadPersonas { get; set; }
        public int Estado { get; set; }

        [ForeignKey("Alojamiento")]
        public Guid AlojamientoId { get; set; }
        public AlojamientoEntidad Alojamiento { get; set; }
        public List<ReservaHabitacionEntidad> ReservasHabitacion { get; set; }


    }
}
