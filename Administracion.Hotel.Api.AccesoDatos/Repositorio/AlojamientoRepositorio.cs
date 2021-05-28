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
    public class AlojamientoRepositorio : IAlojamientoRepositorio
    {
        private readonly HotelDbContext HotelDbContext;

        public AlojamientoRepositorio(HotelDbContext hotelDbContext)
        {
            HotelDbContext = hotelDbContext;
        }
        public async Task<AlojamientoEntidad> Add(AlojamientoEntidad entity)
        {
            var alojamiento = await HotelDbContext.TblAlojamiento.AddAsync(entity);
            return alojamiento.Entity;
        }

        public async Task<bool> Delete(Guid id)
        {
            var entidad = await HotelDbContext.TblAlojamiento.FirstOrDefaultAsync(alojamiento => alojamiento.Id == id);
            if (entidad.Id == Guid.Empty)
                throw new Exception("No existe el hotel");
            var eliminar = HotelDbContext.TblAlojamiento.Remove(entidad);
            return true;
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Exist(string nombre)
        {
            var alojamiento = await HotelDbContext.TblAlojamiento.FirstOrDefaultAsync(alojamiento => alojamiento.Nombre == nombre);
            return alojamiento != null;
        }

        public Task<bool> Exist(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<AlojamientoEntidad> Get(Guid id)
        {
            var alojamiento = await HotelDbContext.TblAlojamiento.FirstOrDefaultAsync(idAlojamiento => idAlojamiento.Id == id);
            return alojamiento;
        }

        public Task<AlojamientoEntidad> Get(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<AlojamientoEntidad>> GetAll()
        {
            var alojamientos = await HotelDbContext.TblAlojamiento.Select(alojamientosSeleccionadas => alojamientosSeleccionadas).ToListAsync();
            return alojamientos;
        }

        public async Task<int> Save()
        {
            return await HotelDbContext.SaveChangesAsync();
        }

        public AlojamientoEntidad Update(AlojamientoEntidad entidad)
        {
            var alojamientoActualizada = HotelDbContext.TblAlojamiento.Update(entidad);
            return alojamientoActualizada.Entity;
        }
    }
}
