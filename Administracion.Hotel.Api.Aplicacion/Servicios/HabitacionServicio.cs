namespace Administracion.Hotel.Api.Aplicacion.Servicios
{
    using Administracion.Hotel.Api.AccesoDatos.Contrato.Repositorios;
    using Administracion.Hotel.Api.Aplicacion.Contrato.Servicios;
    using Administracion.Hotel.Api.AccesoDatos.Mapeo;
    using Administracion.Hotel.Api.Negocio.Modelos;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    public class HabitacionServicio : IHabitacionServicio
    {
        private readonly IHabitacionRepositorio HabitacionRepositorio;
        public HabitacionServicio(IHabitacionRepositorio habitacionRepositorio)
        {
            HabitacionRepositorio = habitacionRepositorio;
        }
        public async Task<Habitacion> AddHabitacion(Habitacion habitacion)
        {
            var addEntidad = await HabitacionRepositorio.Add(HabitacionMapeo.Map(habitacion));
            await HabitacionRepositorio.Save();
            return HabitacionMapeo.MapEntidad(addEntidad);
        }

        public Task<bool> DeleteHabitacion(Guid idEntity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteHabitacion(int idEntity)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Habitacion>> GetHabitaciones(Guid idEntity)
        {
            var habitacion = await HabitacionRepositorio.Get(idEntity);
            return HabitacionMapeo.MapEntidad(habitacion);
        }

        public Task<Habitacion> GetHabitacion(int idEntity)
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveHabitacion()
        {
            throw new NotImplementedException();
        }
    }
}
