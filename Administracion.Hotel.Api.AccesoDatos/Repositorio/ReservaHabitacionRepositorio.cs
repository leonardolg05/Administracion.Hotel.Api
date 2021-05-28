using Administracion.Hotel.Api.AccesoDatos.Contrato.Entidades;
using Administracion.Hotel.Api.AccesoDatos.Contrato.Repositorios;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Administracion.Hotel.Api.AccesoDatos.Repositorio
{
    public class ReservaHabitacionRepositorio: IReservaHabitacionRepositorio
    {
        private readonly HotelDbContext HotelDbContext;

        public ReservaHabitacionRepositorio(HotelDbContext hotelDbContext)
        {
            HotelDbContext = hotelDbContext;
        }
        public async Task<ReservaHabitacionEntidad> Add(ReservaHabitacionEntidad entity)
        {
            var reservaHabitacion = await HotelDbContext.TblReservaHabitacion.AddAsync(entity);
            return reservaHabitacion.Entity;
        }

        public async Task<bool> Delete(int id)
        {
            var elimino = false;
            var entidad = await HotelDbContext.TblReservaHabitacion.FirstOrDefaultAsync(reservaHabitacion => reservaHabitacion.Id == id);
            if (entidad.Id > 0)
                throw new Exception("No existe el reservaHabitacion");

            var eliminar = HotelDbContext.TblReservaHabitacion.Remove(entidad);
            elimino = true;

            return elimino;
        }

        public async Task<bool> Exist(int id)
        {
            var reservaHabitacion = await HotelDbContext.TblReservaHabitacion.FirstOrDefaultAsync(reservaHabitacion => reservaHabitacion.Id == id);
            return reservaHabitacion.Id > 0? true : false;
        }

        public async Task<ReservaHabitacionEntidad> Get(int id)
        {
            if (HotelDbContext.TblReservaHabitacion.ToList().Count == 0) { throw new Exception("La reservaHabitacion no existe"); }
            var reservaHabitacion = await HotelDbContext.TblReservaHabitacion.FirstOrDefaultAsync(idReservaHabitacion => idReservaHabitacion.Id == id);
            return reservaHabitacion;
        }

        public async Task<List<ReservaHabitacionEntidad>> Get(DateTime FechaInicial, DateTime FechaFinal)
        {
            var reservaHabitacion = await HotelDbContext.TblReservaHabitacion.Where(ReservaHabitacion => (ReservaHabitacion.FechaIngreso >= FechaInicial && ReservaHabitacion.FechaSalida <= FechaFinal)).ToListAsync();
            return reservaHabitacion;
        }

        public async Task<List<ReservaHabitacionEntidad>> GetAll()
        {
            var reservaHabitaciones = await HotelDbContext.TblReservaHabitacion.Select(reservaHabitacionesSeleccionados => reservaHabitacionesSeleccionados).ToListAsync();
            return reservaHabitaciones;
        }

        public async Task<int> Save()
        {
            return await HotelDbContext.SaveChangesAsync();
        }

        public ReservaHabitacionEntidad Update(ReservaHabitacionEntidad entidad)
        {
            var reservaHabitacionActualizado = HotelDbContext.TblReservaHabitacion.Update(entidad);
            return reservaHabitacionActualizado.Entity;
        }
    }
}
