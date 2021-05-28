namespace Administracion.Hotel.Api.AccesoDatos.Repositorio
{
    using Administracion.Hotel.Api.AccesoDatos.Contrato;
    using Administracion.Hotel.Api.AccesoDatos.Contrato.Entidades;
    using Administracion.Hotel.Api.AccesoDatos.Contrato.Repositorios;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class HuespedRepositorio : IHuespedRepositorio
    {
        private readonly HotelDbContext HotelDbContext;

        public HuespedRepositorio(HotelDbContext hotelDbContext)
        {
            HotelDbContext = hotelDbContext;
        }
        public async Task<HuespedEntidad> Add(HuespedEntidad entity)
        {
            var huesped = await HotelDbContext.TblHuesped.AddAsync(entity);
            return huesped.Entity;
        }

        public async Task<bool> Delete(Guid id)
        {
            var elimino = false;
            var entidad = await HotelDbContext.TblHuesped.FirstOrDefaultAsync(huesped => huesped.Id == id);
            if (entidad.Id == Guid.Empty)
                throw new Exception("No existe el huesped");

            var eliminar = HotelDbContext.TblHuesped.Remove(entidad);
            elimino = true;

            return elimino;
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Exist(Guid id)
        {
            var huesped = await HotelDbContext.TblHuesped.FirstOrDefaultAsync(huesped => huesped.Id == id);
            return huesped.Id != Guid.Empty;
        }

        public Task<bool> Exist(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<HuespedEntidad> Get(Guid id)
        {
            if (HotelDbContext.TblHuesped.ToList().Count == 0) { throw new Exception("La huesped no existe"); }
            var huesped = await HotelDbContext.TblHuesped.FirstOrDefaultAsync(idHuesped => idHuesped.Id == id);
            return huesped;
        }

        public Task<HuespedEntidad> Get(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<HuespedEntidad>> GetAll()
        {
            var huespedes = await HotelDbContext.TblHuesped.Select(huespedesSeleccionados => huespedesSeleccionados).ToListAsync();
            return huespedes;
        }

        public async Task<int> Save()
        {
            return await HotelDbContext.SaveChangesAsync();
        }

        public HuespedEntidad Update(HuespedEntidad entidad)
        {
            var huespedActualizado = HotelDbContext.TblHuesped.Update(entidad);
            return huespedActualizado.Entity;
        }
    }
}
