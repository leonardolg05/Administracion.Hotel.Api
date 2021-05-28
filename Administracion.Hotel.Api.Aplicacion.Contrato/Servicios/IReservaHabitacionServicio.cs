using Administracion.Hotel.Api.Negocio.Modelos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Administracion.Hotel.Api.Aplicacion.Contrato.Servicios
{
    public interface IReservaHabitacionServicio
    {
        Task<ReservaHabitacion> GetReserva(Guid idEntity);
        Task<List<ReservaHabitacion>> GetReserva(DateTime fechaInicial, DateTime fechafinal);
        Task<ReservaHabitacion> AddReserva(ReservaHabitacion huesped);
        Task<bool> DeleteReserva(Guid idEntity);
        Task<int> SaveReserva();
    }
}
