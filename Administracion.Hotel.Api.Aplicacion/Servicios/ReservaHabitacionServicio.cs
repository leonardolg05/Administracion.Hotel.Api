namespace Administracion.Hotel.Api.Aplicacion.Servicios
{
    using Administracion.Hotel.Api.AccesoDatos.Contrato.Repositorios;
    using Administracion.Hotel.Api.AccesoDatos.Mapeo;
    using Administracion.Hotel.Api.Aplicacion.Contrato.Servicios;
    using Administracion.Hotel.Api.Negocio.Modelos;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class ReservaHabitacionServicio : IReservaHabitacionServicio
    {
        private readonly IReservaHabitacionRepositorio ReservaRepositorio;
        private readonly IHabitacionRepositorio HabitacionRepositorio;

        public ReservaHabitacionServicio(IReservaHabitacionRepositorio reservaRepositorio, IHabitacionRepositorio habitacionRepositorio)
        {
            ReservaRepositorio = reservaRepositorio;
            HabitacionRepositorio = habitacionRepositorio;
        }

        public Task<ReservaHabitacion> AddReserva(ReservaHabitacion huesped)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteReserva(Guid idEntity)
        {
            throw new NotImplementedException();
        }

        public Task<ReservaHabitacion> GetReserva(Guid idEntity)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ReservaHabitacion>> GetReserva(DateTime fechaInicial, DateTime fechaFinal)
        {
            var reservas = await ReservaRepositorio.Get(fechaInicial,fechaFinal);
            var habitacionesDisponibles = await HabitacionRepositorio.Get(reservas);
            return ReservaHabitacionMapeo.MapEntidad(reservas);
        }

        public Task<int> SaveReserva()
        {
            throw new NotImplementedException();
        }
    }
}
