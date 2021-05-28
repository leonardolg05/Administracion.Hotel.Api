using Administracion.Hotel.Api.Negocio.Modelos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Administracion.Hotel.Api.Aplicacion.Contrato.Servicios
{
    public interface IHuespedServicio
    {
        Task<Huesped> GetHuesped(Guid idEntity);
        Task<Huesped> AddHuesped(Huesped huesped);
        Task<bool> DeleteHuesped(Guid idEntity);
        Task<int> SaveHuesped();
    }
}
