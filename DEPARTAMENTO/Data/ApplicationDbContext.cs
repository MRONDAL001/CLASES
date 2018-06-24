using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using DEPARTAMENTO.Models;
using DEPARTAMENTO.Models.DEP;
namespace DEPARTAMENTO.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            // inicio context // 
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.IdCliente);

                entity.ToTable("CLIENTE");

                entity.Property(e => e.Cedula)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Direccion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .HasMaxLength(9)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Detalledep>(entity =>
            {
                entity.HasKey(e => e.IdDepartamento);

                entity.ToTable("DETALLEDEP");

                entity.Property(e => e.Banios)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Detalle)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Dormitorios)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Ubicacion)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Formulario>(entity =>
            {
                entity.HasKey(e => e.IdFormulario);

                entity.ToTable("FORMULARIO");

                entity.Property(e => e.FechaContrato).HasColumnType("date");

                entity.Property(e => e.FechaFinal).HasColumnType("date");

                entity.Property(e => e.FechaInicio).HasColumnType("date");

                entity.Property(e => e.Precio).HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.Formulario)
                    .HasForeignKey(d => d.IdCliente)
                    .HasConstraintName("FK__FORMULARI__IdCli__286302EC");

                entity.HasOne(d => d.IdDepartamentoNavigation)
                    .WithMany(p => p.Formulario)
                    .HasForeignKey(d => d.IdDepartamento)
                    .HasConstraintName("FK__FORMULARI__IdDep__276EDEB3");
            });



            // fin contexto // 
        }

        public DbSet<DEPARTAMENTO.Models.DEP.Cliente> Cliente { get; set; }

        public DbSet<DEPARTAMENTO.Models.DEP.Detalledep> Detalledep { get; set; }

        public DbSet<DEPARTAMENTO.Models.DEP.Formulario> Formulario { get; set; }
    }
}
