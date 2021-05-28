namespace Administracion.Hotel.Api.AccesoDatos.Contrato.Repositorios
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IRepositorio<T> where T : class
    {
        Task<bool> Exist(int id);
        Task<List<T>> GetAll();
        Task<T> Get(int id);
        Task<bool> Delete(int id);
        T Update(T Element);
        Task<T> Add(T element);
        Task<int> Save();
    }
}
