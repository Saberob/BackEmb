using System;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ExamenDWBE.Models
{
    public partial class RFIDContext : DbContext
    {
        public readonly IConfiguration config;
        public RFIDContext(IConfiguration _config)
        {
            config = _config;
        }

        public RFIDContext(DbContextOptions<RFIDContext> options, IConfiguration _config)
            : base(options)
        {
            config = _config;
        }

        public virtual DbSet<Empleado> Empleado { get; set; }
        public virtual DbSet<Ingresos> Ingresos { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Empleado>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Nombre)
                    .HasColumnName("nombre")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Rfid)
                    .HasColumnName("RFID")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Ingresos>(entity =>
            {
                entity.HasKey(e => e.RegistroId)
                    .HasName("PK__ingresos__9DF6E3CE93D08061");

                entity.ToTable("ingresos");

                entity.Property(e => e.RegistroId)
                    .HasColumnName("registro_id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.EmpleadoId).HasColumnName("empleado_id");

                entity.Property(e => e.Fecha)
                    .HasColumnName("fecha")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.Empleado)
                    .WithMany(p => p.Ingresos)
                    .HasForeignKey(d => d.EmpleadoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ingresos__emplea__267ABA7A");
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.Property(e => e.usuarioId)
                     .HasColumnName("usuarioId")
                     .ValueGeneratedOnAdd();

                entity.Property(e => e.userName)
                    .HasColumnName("UserName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.password)
                    .HasColumnName("password")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.sal)
                   .HasColumnName("sal")
                   .HasMaxLength(500)
                   .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
