using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Administracion.Hotel.Api.AccesoDatos.Contrato.Entidades
{
    public class FechasReservaHabitacionEntidad
    {
        public DateTime FechaIngreso { get; set; }
        public DateTime FechaSalida { get; set; }
    }
}
