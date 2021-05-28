namespace Administracion.Hotel.Api.Aplicacion.Contrato.Servicios
{
    using Administracion.Hotel.Api.Negocio.Modelos;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IAlojamientoServicio
    {
        Task<Alojamiento> GetAlojamiento(Guid idEntity);
        Task<List<Alojamiento>> GetAlojamientos();
        Task<Alojamiento> AddAlojamiento(Alojamiento hotel);
        Task<Alojamiento> UpdateAlojamiento(Alojamiento alojamiento);
        Task<bool> DeleteHotel(Guid idEntity);
        Task<int> SaveHotel();
    }
}
