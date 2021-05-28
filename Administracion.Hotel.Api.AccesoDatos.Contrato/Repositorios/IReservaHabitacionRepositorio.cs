namespace Administracion.Hotel.Api.AccesoDatos.Contrato.Repositorios
{
    using Administracion.Hotel.Api.AccesoDatos.Contrato.Entidades;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IReservaHabitacionRepositorio : IRepositorio<ReservaHabitacionEntidad>
    {
        Task<List<ReservaHabitacionEntidad>> Get(DateTime FechaInicial, DateTime FechaFinal);
    }    
}
