using Administracion.Hotel.Api.AccesoDatos.Contrato.Repositorios;
using Administracion.Hotel.Api.AccesoDatos.Repositorio;
using Administracion.Hotel.Api.Aplicacion.Contrato.Servicios;
using Administracion.Hotel.Api.Aplicacion.Servicios;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Administracion.Hotel.Api.ComponentesTransversales.Registro
{
    public static class IoCRegistros
    {
        public static IServiceCollection AddRegistration(this IServiceCollection service)
        {
            AddRegisterServices(service);
            AddRegistrationRepositories(service);
            return service;
        }

        private static IServiceCollection AddRegisterServices(IServiceCollection service)
        {
            service.AddTransient<IHabitacionServicio, HabitacionServicio>();
            service.AddTransient<IAlojamientoServicio, AlojamientoServicio>();
            service.AddTransient<IHuespedServicio, HuespedServicio>();
            service.AddTransient<IReservaHabitacionServicio, ReservaHabitacionServicio>();
            return service;
        }

        private static IServiceCollection AddRegistrationRepositories(IServiceCollection service)
        {
            service.AddTransient<IHabitacionRepositorio, HabitacionRepositorio>();
            service.AddTransient<IAlojamientoRepositorio, AlojamientoRepositorio>();
            service.AddTransient<IHuespedRepositorio, HuespedRepositorio>();
            service.AddTransient<IReservaHabitacionRepositorio, ReservaHabitacionRepositorio>();
            return service;
        }

        private static IServiceCollection AddRegistrationOthers(IServiceCollection service)
        {
            //service.AddTransient<IAppConfig, AppConfig>();
            return service;
        }
    }
}
