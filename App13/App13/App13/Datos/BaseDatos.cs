using System;
using System.Collections.Generic;
using System.Text;
using App13.Modelos;
using App13.Servicios;
using Microsoft.EntityFrameworkCore;
using Xamarin.Forms;

namespace App13.Datos
{
    public class BaseDatos:DbContext
    {
        public DbSet<Tarea> Tareas { get; set; }
        public DbSet<Emocion> Emocion { get; set; }

        private readonly string rutaBD;

        public BaseDatos(string rutaBD)
        {
            this.rutaBD = rutaBD;
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            var dbPath = DependencyService.Get<IBaseDatos>().GetDatabasePath();
            optionsBuilder.UseSqlite($"Filename={dbPath}");
        }

    }
}