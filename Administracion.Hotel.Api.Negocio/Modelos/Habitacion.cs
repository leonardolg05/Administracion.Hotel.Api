namespace Administracion.Hotel.Api.Negocio.Modelos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Habitacion
    {
        [Key]
        public int Id { get; set; }
        public int Numero { get; set; }
        public int Piso {get;set;}
        public int TipoHabitacion { get; set; }
        public int Vista { get; set; }
        public int Localizacion { get; set; }
        public int NumeroCamas { get; set; }
        public int CapacidadPersonas { get; set; }
        public int Estado { get; set; }

        [ForeignKey("Alojamiento")]
        public Guid AlojamientoId { get; set; }
        public Alojamiento Alojamiento { get; set; }
        [ForeignKey("ReservaHabitacion")]
        public List<ReservaHabitacion> ReservasHabitacion { get; set; }

    }
}
