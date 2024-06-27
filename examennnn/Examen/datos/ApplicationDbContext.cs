using Examen.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace Examen.datos
{
    public class ApplicationDbContext : DbContext

    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Vehiculo> Vehiculos { get; set; }
        public DbSet<Modelo> Modelos { get; set; }
        public DbSet<Marca> Marca { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuración de la relación entre Vehiculo y Modelo
            modelBuilder.Entity<Vehiculo>()
                .HasOne(v => v.Modelo)
                .WithMany(m => m.Vehiculos)
                .HasForeignKey(v => v.ModeloId)
                .OnDelete(DeleteBehavior.Restrict);

            // Configuración de la relación entre Vehiculo y Marca
            modelBuilder.Entity<Vehiculo>()
                .HasOne(v => v.Marca)
                .WithMany(m => m.vehiculos)
                .HasForeignKey(v => v.MarcaId)
                .OnDelete(DeleteBehavior.Restrict);

            // Configuración de la relación entre Modelo y Marca
            modelBuilder.Entity<Modelo>()
                .HasOne(m => m.Marca)
                .WithMany(ma => ma.Modelos)
                .HasForeignKey(m => m.MarcaId)
                .OnDelete(DeleteBehavior.Restrict);

            // Datos de ejemplo
            modelBuilder.Entity<Marca>().HasData(
                new Marca { Id = 1, NombreMarca = "Toyota" },
                new Marca { Id = 2, NombreMarca = "Ford" }
            );

            modelBuilder.Entity<Modelo>().HasData(
                new Modelo { Id = 1, NombreModelo = "Corolla", MarcaId = 1 },
                new Modelo { Id = 2, NombreModelo = "Camry", MarcaId = 1 },
                new Modelo { Id = 3, NombreModelo = "F-150", MarcaId = 2 }

            );

            modelBuilder.Entity<Vehiculo>().HasData(
                new Vehiculo { Id = 1, NroPlaca = "ABC-123", MarcaId = 1, ModeloId = 1, Año = new DateTime(2020, 1, 1), Color = "Rojo" },
                new Vehiculo { Id = 2, NroPlaca = "XYZ-789", MarcaId = 1, ModeloId = 2, Año = new DateTime(2020, 1, 1), Color = "Azul" },
                new Vehiculo { Id = 3, NroPlaca = "LMN-456", MarcaId = 2, ModeloId = 3, Año = new DateTime(2020, 1, 1), Color = "Negro" }
            );
        }
    }
}
