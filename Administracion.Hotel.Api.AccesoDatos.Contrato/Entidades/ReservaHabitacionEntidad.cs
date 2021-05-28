using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Administracion.Hotel.Api.AccesoDatos.Contrato.Entidades
{
    public class ReservaHabitacionEntidad
    {
        public int Id { get; set; }
        [ForeignKey("Habitacion")]
        public int IdHabitacion { get; set; }
        public HabitacionEntidad Habitacion { get; set; }
        [ForeignKey("Huesped")]
        public Guid IdHuesped { get; set; }
        public List<HuespedEntidad> Huespedes { get; set; }
        public DateTime FechaIngreso { get; set; }
        public DateTime FechaSalida { get; set; }
        public string NombreContacto { get; set; }
        public string TelefonoContacto { get; set; }
    }
}
