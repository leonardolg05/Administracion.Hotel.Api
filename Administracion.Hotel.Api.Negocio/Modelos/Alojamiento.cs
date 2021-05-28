using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Administracion.Hotel.Api.Negocio.Modelos
{
    public class Alojamiento
    {
        [Key]
        public Guid Id { get; set; }
        [StringLength(50)]
        public string Nombre { get; set;}
        [StringLength(50)]
        public string Direccion { get; set; }
        [StringLength(12)]
        public string Telefono{ get; set; }
        public int Estado { get; set; }
        public List<Habitacion> Habitacion { get; set; }
    }
}
