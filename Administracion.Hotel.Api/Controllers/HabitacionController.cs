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
    public class HabitacionController : ControllerBase
    {
        private readonly IHabitacionServicio HabitacionServicio;

        public HabitacionController(IHabitacionServicio hotelServicio)
        {
            HabitacionServicio = hotelServicio;
        }
        [AllowAnonymous]
        [Route("ObtenerHabitacions")]
        [HttpPost]
        public async Task<List<Habitacion>> ObtenerHabitaciones(Guid idHotel)
        {
            return await HabitacionServicio.GetHabitaciones(idHotel);

        }
        [Route("ObtenerHabitacionPorId")]
        [HttpPost()]
        public IActionResult ObtenerHabitacionPorId([FromBody] Habitacion habitacion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var habitacionSeleccion = HabitacionServicio.GetHabitacion(habitacion.Id);
            if (habitacionSeleccion == null)
            {
                return NotFound();
            }
            return Ok(habitacionSeleccion);
        }

        [AllowAnonymous]
        [Route("CrearHabitacion")]
        [HttpPost]
        public async Task<ActionResult<Habitacion>> CrearHabitacion([FromBody] Habitacion habitacion)
        {
            try
            {
                if (!ModelState.IsValid) { return BadRequest(ModelState); }
                var habitacionCreado = await HabitacionServicio.AddHabitacion(habitacion);
                return habitacionCreado.Id == 0 ? habitacionCreado : throw new Exception("No se pudo guardar el habitacion");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //[Route("ActualizarHabitacion")]
        //[HttpPost]
        //public async Task<IActionResult> ActualizarHabitacion([FromBody] Habitacion habitacion)
        //{
        //    try
        //    {
        //        if (!ModelState.IsValid && habitacion.Id == 0 && habitacion== null) { return BadRequest(); }
        //        var habitacionActualizado = await HabitacionServicio.UpdateHabitacion(habitacion);
        //        return Ok(habitacionActualizado);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}

    }
}
