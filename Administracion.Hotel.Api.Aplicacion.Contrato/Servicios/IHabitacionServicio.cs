namespace Administracion.Hotel.Api.Aplicacion.Contrato.Servicios
{
    using Administracion.Hotel.Api.Negocio.Modelos;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    public interface IHabitacionServicio
    {
        Task<Habitacion> GetHabitacion(int idEntity);
        Task<List<Habitacion>> GetHabitaciones(Guid idAlojamiento);
        Task<Habitacion> AddHabitacion(Habitacion habitacion);
        Task<bool> DeleteHabitacion(int idEntity);
        Task<int> SaveHabitacion();
    }
}
