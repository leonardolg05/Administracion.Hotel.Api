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
    public class HotelController : ControllerBase
    {
        private readonly IAlojamientoServicio HotelServicio;

        public HotelController(IAlojamientoServicio hotelServicio)
        {
            HotelServicio = hotelServicio;
        }
        [AllowAnonymous]
        [Route("ObtenerAlojamientos")]
        [HttpPost]
        public async Task<List<Alojamiento>> ObtenerAlojamientos()
        {
                return await HotelServicio.GetAlojamientos();

        }
        [Route("ObtenerAlojamientoPorId")]
        [HttpPost()]
        public IActionResult ObtenerAlojamientoPorId([FromBody] Alojamiento alojamiento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var alojamientoSeleccion = HotelServicio.GetAlojamiento(alojamiento.Id);
            if (alojamientoSeleccion == null)
            {
                return NotFound();
            }
            return Ok(alojamientoSeleccion);
        }

        [AllowAnonymous]
        [Route("CrearAlojamiento")]
        [HttpPost]
        public async Task<ActionResult<Alojamiento>> CrearAlojamiento([FromBody] Alojamiento alojamiento)
        {
            try
            {
                if (!ModelState.IsValid) { return BadRequest(ModelState); }
                var alojamientoCreado = await HotelServicio.AddAlojamiento(alojamiento);
                return alojamientoCreado.Id != Guid.Empty ? alojamientoCreado : throw new Exception("No se pudo guardar el alojamiento");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [Route("ActualizarAlojamiento")]
        [HttpPost]
        public async Task<IActionResult> ActualizarAlojamiento([FromBody] Alojamiento alojamiento)
        {
            try
            {
                if (!ModelState.IsValid && alojamiento.Id == Guid.Empty && alojamiento== null) { return BadRequest(); }
                var alojamientoActualizado = await HotelServicio.UpdateAlojamiento(alojamiento);
                return Ok(alojamientoActualizado);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
