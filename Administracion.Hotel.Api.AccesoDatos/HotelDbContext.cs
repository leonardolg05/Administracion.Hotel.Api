using Administracion.Hotel.Api.AccesoDatos.Contrato;
using Administracion.Hotel.Api.AccesoDatos.Contrato.Entidades;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Administracion.Hotel.Api.AccesoDatos
{
    public class HotelDbContext : IdentityDbContext<ApplicationUser>, IHotelDbContext
    {
        public HotelDbContext(DbContextOptions<HotelDbContext> options)
       : base(options)
        { }
        public DbSet<HabitacionEntidad> TblHabitacion { get; set; }
        public DbSet<AlojamientoEntidad> TblAlojamiento { get; set; }
        public DbSet<HuespedEntidad> TblHuesped { get; set; }
        public DbSet<ReservaHabitacionEntidad> TblReservaHabitacion { get; set; }
    }
}
