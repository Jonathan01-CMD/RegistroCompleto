using Microsoft.EntityFrameworkCore;
using RegistroCompleto.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace RegistroCompleto.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Usuario> Usuario { get; set; }

        public DbSet<Roles> Roles { get; set; }
        public DbSet<Permisos> Permisos { get; set; }
        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source = DATA\BaseDeDatos.DB");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Permisos>().HasData(
            new Permisos()
            {
                PermisoId = 1,
                DetallePermiso = "Descuento"
            },
            new Permisos()
            {
                PermisoId = 2,
                DetallePermiso = "Venta"
            },
            new Permisos()
            {
                PermisoId = 3,
                DetallePermiso = "Cobrar"
            });
        }
    }
}
