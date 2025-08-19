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
        public DbSet<Reporte> Reportes { get; internal set; }
        public DbSet<TipoFrecuencia> TiposFrecuencia { get; internal set; }
        public DbSet<Parametro> Parametros { get; internal set; }
        public DbSet<Destinatario> Destinatarios { get; internal set; }
        public DbSet<Especies_Parametro> Especies_Reporte { get; internal set; }
        public DbSet<Ubicaciones_Parametro> Ubicaciones_Reporte { get; internal set; }

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

            modelBuilder.Entity<Reporte>()
                .HasKey(e => e.idReporte);

            modelBuilder.Entity<TipoFrecuencia>()
                .HasKey(e => e.idTipoFrecuencia);

            modelBuilder.Entity<Parametro>()
                .HasKey(e => e.idParametro);

            modelBuilder.Entity<Destinatario>()
                .HasKey(e => e.idDestinatario);

            modelBuilder.Entity<Especies_Parametro>()
                .HasKey(e => e.Id);

            modelBuilder.Entity<Ubicaciones_Parametro>()
                .HasKey(e => e.Id);
        }
    }
}
