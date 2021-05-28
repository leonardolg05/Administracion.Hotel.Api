using Administracion.Hotel.Api.AccesoDatos.Contrato.Repositorios;
using Administracion.Hotel.Api.AccesoDatos.Mapeo;
using Administracion.Hotel.Api.Aplicacion.Contrato.Servicios;
using Administracion.Hotel.Api.Negocio.Modelos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Administracion.Hotel.Api.Aplicacion.Servicios
{
    public class AlojamientoServicio : IAlojamientoServicio
    {
        private readonly IAlojamientoRepositorio AlojamientoRepositorio;

        public AlojamientoServicio(IAlojamientoRepositorio alojamientoRepositorio)
        {
            AlojamientoRepositorio = alojamientoRepositorio;
        }
        public async Task<Alojamiento> AddAlojamiento(Alojamiento alojamiento)
        {
            if (await AlojamientoRepositorio.Exist(alojamiento.Nombre)) {
                throw new Exception("el nombre ya esta registrado");
            }
            var addEntidad = await AlojamientoRepositorio.Add(AlojamientoMapeo.Map(alojamiento));
            await AlojamientoRepositorio.Save();
            return AlojamientoMapeo.MapEntidad(addEntidad);
        }

        public Task<bool> DeleteHotel(Guid idEntity)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Alojamiento>> GetAlojamientos()
        {
            var alojamientos = await AlojamientoRepositorio.GetAll();
            if (alojamientos.Count == 0)
            { throw new Exception("No se encontraron alojamientos"); }
            var ListaAlojamientos = new List<Alojamiento>();
            for (var cantidadAlojamientos = 0; cantidadAlojamientos < alojamientos.Count; cantidadAlojamientos++)
            {
                ListaAlojamientos.Add(AlojamientoMapeo.MapEntidad(alojamientos[cantidadAlojamientos]));
            }
            return ListaAlojamientos;
        }

        public Task<Alojamiento> GetAlojamiento(Guid idEntity)
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveHotel()
        {
            throw new NotImplementedException();
        }

        public async Task<Alojamiento> UpdateAlojamiento(Alojamiento alojamiento)
        {
            var datosAlojamiento = await AlojamientoRepositorio.Get(alojamiento.Id);
            if (datosAlojamiento is null) { throw new Exception("alojamiento no encontrado"); }
            AlojamientoRepositorio.Update(AlojamientoMapeo.Map(alojamiento));
            await AlojamientoRepositorio.Save();
            return alojamiento;
        }
    }
}
