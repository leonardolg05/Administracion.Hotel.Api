using Administracion.Hotel.Api.AccesoDatos.Contrato;
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
    public class HabitacionRepositorio : IHabitacionRepositorio
    {
        private readonly HotelDbContext HotelDbContext;

        public HabitacionRepositorio(HotelDbContext hotelDbContext)
        {
            HotelDbContext = hotelDbContext;
        }
        public async Task<HabitacionEntidad> Add(HabitacionEntidad entity)
        {
            var habitacion = await HotelDbContext.TblHabitacion.AddAsync(entity);
            return habitacion.Entity;
        }

        public async Task<bool> Delete(int id)
        {
            var elimino = false;
            var entidad = await HotelDbContext.TblHabitacion.FirstOrDefaultAsync(habitacion => habitacion.Id == id);
            if (entidad.Id == 0)
                throw new Exception("No existe el hotel");
            var eliminar = HotelDbContext.TblHabitacion.Remove(entidad);
            elimino = true;            
            return elimino;
        }

        public async Task<bool> Exist(int id)
        {
            var barrio = await HotelDbContext.TblHabitacion.FirstOrDefaultAsync(habitacion => habitacion.Id == id);
            return barrio.Id > 0 ? true : false;
        }

        public async Task<List<HabitacionEntidad>> Get(Guid id)
        {
            if (HotelDbContext.TblHabitacion.ToList().Count == 0) { throw new Exception("La habitacion no existe"); }
            var habitacion = await HotelDbContext.TblHabitacion.Where(idHabitacion => idHabitacion.AlojamientoId == id).ToListAsync();
            return habitacion;
        }

        public Task<HabitacionEntidad> Get(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<HabitacionEntidad>> Get(List<ReservaHabitacionEntidad> listaReservas)
        {
            var habitacionesDisponibles = new List<HabitacionEntidad>();
            var ids = new List<int>();
            foreach (var reservas in listaReservas)
            {
                ids.Add(reservas.IdHabitacion);
            }

            var habitacion = await HotelDbContext.TblHabitacion.ToListAsync();
            foreach (var recorreHabicacion in habitacion)
            {
                if (ids.Contains(recorreHabicacion.Id))
                {
                    habitacionesDisponibles.Add(recorreHabicacion);
                };
            
            }
            //var habitacion = HotelDbContext.TblHabitacion.Select(habitacion=> habitacion.Id).ToList();
            return habitacionesDisponibles;
        }

        //public Task<HabitacionEntidad> Get(Guid id)
        //{
        //    throw new NotImplementedException();
        //}

        public async Task<List<HabitacionEntidad>> GetAll()
        {
            var habitaciones = await HotelDbContext.TblHabitacion.Select(habitacionesSeleccionadas => habitacionesSeleccionadas).ToListAsync();
            return habitaciones;
        }

        public async Task<int> Save()
        {
            return await HotelDbContext.SaveChangesAsync();
        }

        public HabitacionEntidad Update(HabitacionEntidad entidad)
        {
            var habitacionActualizada = HotelDbContext.TblHabitacion.Update(entidad);
            return habitacionActualizada.Entity;
        }
    }
}