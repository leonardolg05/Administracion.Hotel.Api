using Administracion.Hotel.Api.AccesoDatos.Contrato.Entidades;
using Administracion.Hotel.Api.Aplicacion.Contrato.Servicios;
using Administracion.Hotel.Api.Negocio.Modelos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Administracion.Hotel.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ReservaController : ControllerBase
    {
        private readonly IReservaHabitacionServicio ReservaHabitacionServicio;
        public ReservaController(IReservaHabitacionServicio reservaHabitacionServicio)
        {
            ReservaHabitacionServicio = reservaHabitacionServicio;
        }

        [AllowAnonymous]
        [Route("ObtenerHabitaciones")]
        [HttpPost]
        public async Task<List<ReservaHabitacion>> ObtenerHabitaciones(FechasReservaHabitacionEntidad fechas)
        {            
            return await ReservaHabitacionServicio.GetReserva(fechas.FechaIngreso,fechas.FechaSalida);

        }
    }
}
