using Administracion.Hotel.Api.AccesoDatos.Contrato.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Administracion.Hotel.Api.AccesoDatos.Contrato.Repositorios
{
    public interface IHuespedRepositorio :IRepositorio<HuespedEntidad>
    {
        Task<bool> Exist(Guid id);
        Task<HuespedEntidad> Get(Guid id);
        Task<bool> Delete(Guid id);
    }
}
