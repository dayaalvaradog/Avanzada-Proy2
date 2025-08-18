using Core.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Especie> Especies { get; internal set; }
        public DbSet<Familia> Familias { get; internal set; }
        public DbSet<Ubicacion> Ubicaciones { get; internal set; }
        public DbSet<Semilla> Semillas { get; internal set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Especie>()
                .HasKey(e => e.idEspecie);

            modelBuilder.Entity<Familia>()
                .HasKey(e => e.idFamilia);

            modelBuilder.Entity<Ubicacion>()
                .HasKey(e => e.idUbicacion);

            modelBuilder.Entity<Semilla>()
                .HasKey(e => e.idSemilla);
        }
    }
}
