using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Proyecto.Entities;

namespace Proyecto.Data
{
    public partial class ProyectoPDCContext : DbContext
    {
        public ProyectoPDCContext()
        {
        }

        public ProyectoPDCContext(DbContextOptions<ProyectoPDCContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Docente> Docente { get; set; }
        public virtual DbSet<Entrega> Entrega { get; set; }
        public virtual DbSet<Estudiante> Estudiante { get; set; }
        public virtual DbSet<Grupo> Grupo { get; set; }
        public virtual DbSet<Integracion> Integracion { get; set; }
        public virtual DbSet<PermisosRol> PermisosRol { get; set; }
        public virtual DbSet<Rol> Rol { get; set; }
        public virtual DbSet<RolUsuario> RolUsuario { get; set; }
        public virtual DbSet<Tema> Tema { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }


        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=ProyectoPDC;Trusted_Connection=True;");
            }
        }*/

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Docente>(entity =>
            {
                entity.Property(e => e.Codigo)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Entrega>(entity =>
            {
                entity.Property(e => e.FechaEntrega)
                    .HasColumnName("Fecha_Entrega")
                    .HasColumnType("date");

                entity.Property(e => e.GrupoId).HasColumnName("Grupo_Id");

                entity.Property(e => e.IntegracionId).HasColumnName("Integracion_Id");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Nota).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.NroEntrega)
                    .IsRequired()
                    .HasColumnName("Nro_Entrega")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Grupo)
                    .WithMany(p => p.Entrega)
                    .HasForeignKey(d => d.GrupoId)
                    .HasConstraintName("FK_Entrega_Grupo");

                entity.HasOne(d => d.Integracion)
                    .WithMany(p => p.Entrega)
                    .HasForeignKey(d => d.IntegracionId)
                    .HasConstraintName("FK_Entrega_Integracion");
            });

            modelBuilder.Entity<Estudiante>(entity =>
            {
                entity.Property(e => e.Codigo)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Grupo>(entity =>
            {
                entity.Property(e => e.DocenteId).HasColumnName("Docente_Id");

                entity.Property(e => e.Estudiante1)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Estudiante2)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Estudiante3)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TemaId).HasColumnName("Tema_Id");

                entity.HasOne(d => d.Docente)
                    .WithMany(p => p.Grupo)
                    .HasForeignKey(d => d.DocenteId)
                    .HasConstraintName("FK_Grupo_Docente");

                entity.HasOne(d => d.Tema)
                    .WithMany(p => p.Grupo)
                    .HasForeignKey(d => d.TemaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Grupo_Tema");
            });

            modelBuilder.Entity<Integracion>(entity =>
            {
                entity.Property(e => e.Asignatura1)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Asignatura2)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Asignatura3)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PermisosRol>(entity =>
            {
                entity.ToTable("Permisos_Rol");

                entity.Property(e => e.CodigoFuncion)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RolId).HasColumnName("Rol_Id");

                entity.HasOne(d => d.Rol)
                    .WithMany(p => p.PermisosRol)
                    .HasForeignKey(d => d.RolId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Permisos_Rol_Rol");
            });

            modelBuilder.Entity<Rol>(entity =>
            {
                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RolUsuario>(entity =>
            {
                entity.ToTable("Rol_Usuario");

                entity.Property(e => e.RolId).HasColumnName("Rol_Id");

                entity.Property(e => e.UsuarioId).HasColumnName("Usuario_Id");

                entity.HasOne(d => d.Rol)
                    .WithMany(p => p.RolUsuario)
                    .HasForeignKey(d => d.RolId)
                    .HasConstraintName("FK_Rol_Usuario_Rol");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.RolUsuario)
                    .HasForeignKey(d => d.UsuarioId)
                    .HasConstraintName("FK_Rol_Usuario_Usuario");
            });

            modelBuilder.Entity<Tema>(entity =>
            {
                entity.Property(e => e.Descripcion)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Usuario1)
                    .IsRequired()
                    .HasColumnName("Usuario")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
