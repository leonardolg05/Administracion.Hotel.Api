namespace Administracion.Hotel.Api.AccesoDatos.Contrato.Repositorios
{
    using Administracion.Hotel.Api.AccesoDatos.Contrato.Entidades;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System;

    public interface IHabitacionRepositorio : IRepositorio<HabitacionEntidad>
    {
        Task<List<HabitacionEntidad>> Get(Guid id);
        Task<List<HabitacionEntidad>> Get(List<ReservaHabitacionEntidad> listaReservas);
    }
}
