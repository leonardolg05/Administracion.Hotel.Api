using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Administracion.Hotel.Api.Negocio.Modelos
{
    public class ReservaHabitacion
    {
        public int Id { get; set; }
        [ForeignKey("Habitacion")]
        public int IdHabitacion { get; set; }
        public Habitacion Habitacion { get; set; }
        [ForeignKey("Huesped")]
        public Guid IdHuesped { get; set; }
        public List<Huesped> Huespedes { get; set; }
        public DateTime FechaIngreso { get; set; }
        public DateTime FechaSalida { get; set; }
        public string NombreContacto { get; set; }
        public string TelefonoContacto { get; set; }
    }
}
