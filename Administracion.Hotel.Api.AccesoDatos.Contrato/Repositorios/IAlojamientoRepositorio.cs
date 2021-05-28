namespace Administracion.Hotel.Api.AccesoDatos.Contrato.Repositorios
{
    using Administracion.Hotel.Api.AccesoDatos.Contrato.Entidades;
    using System;
    using System.Threading.Tasks;

    public interface IAlojamientoRepositorio : IRepositorio<AlojamientoEntidad>
    {
        Task<bool> Exist(string nombre);
        Task<AlojamientoEntidad> Get(Guid id);
        Task<bool> Delete(Guid id);
    }
}
