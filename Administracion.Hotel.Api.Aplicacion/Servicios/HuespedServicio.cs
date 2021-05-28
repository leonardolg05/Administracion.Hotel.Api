namespace Administracion.Hotel.Api.Aplicacion.Servicios
{
    using Administracion.Hotel.Api.Aplicacion.Contrato.Servicios;
    using Administracion.Hotel.Api.Negocio.Modelos;
    using System;
    using System.Threading.Tasks;

    public class HuespedServicio : IHuespedServicio
    {
        public Task<Huesped> AddHuesped(Huesped huesped)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteHuesped(Guid idEntity)
        {
            throw new NotImplementedException();
        }

        public Task<Huesped> GetHuesped(Guid idEntity)
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveHuesped()
        {
            throw new NotImplementedException();
        }
    }
}
