using System;
using System.Collections.Generic;
using GestorEscuelas.Models.DTOs;
using Microsoft.EntityFrameworkCore;

namespace GestorEscuelas.Models;

public partial class GestorEscuelaDbContext : DbContext
{
    public GestorEscuelaDbContext()
    {
    }

    public GestorEscuelaDbContext(DbContextOptions<GestorEscuelaDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Alumno> Alumnos { get; set; }

    public virtual DbSet<EscuelasDeMusica> EscuelasDeMusicas { get; set; }

    public virtual DbSet<Profesore> Profesores { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=localhost;Database=GestorEscuelasMusicaDb;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<ProfesorConEscuelaDto>(entity =>
        {
            entity.HasNoKey();
            entity.ToView(null);
        });

        modelBuilder.Entity<AlumnoConEscuelaDto>(entity =>
        {
            entity.HasNoKey();
            entity.ToView(null);
        });

        modelBuilder.Entity<EscuelaYAlumnosDto>(entity =>
        {
            entity.HasNoKey();
            entity.ToView(null);
        });

        modelBuilder.Entity<AlumnoNombreEscuelaDto>(entity =>
        {
            entity.HasNoKey();
            entity.ToView(null);
        });


        modelBuilder.Entity<Alumno>(entity =>
        {
            entity.HasKey(e => e.IdAlumno).HasName("PK__Alumnos__460B4740E21AC95A");

            entity.HasIndex(e => e.IdentificacionAlumno, "UQ__Alumnos__6BDBA5D513500037").IsUnique();

            entity.Property(e => e.ApellidoAlumno).HasMaxLength(100);
            entity.Property(e => e.IdentificacionAlumno)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.NombreAlumno).HasMaxLength(100);


            entity.HasMany(d => d.IdProfesors).WithMany(p => p.IdAlumnos)
                .UsingEntity<Dictionary<string, object>>(
                    "AlumnoProfesor",
                    r => r.HasOne<Profesore>().WithMany()
                        .HasForeignKey("IdProfesor")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__AlumnoPro__IdPro__4316F928"),
                    l => l.HasOne<Alumno>().WithMany()
                        .HasForeignKey("IdAlumno")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__AlumnoPro__IdAlu__4222D4EF"),
                    j =>
                    {
                        j.HasKey("IdAlumno", "IdProfesor").HasName("PK__AlumnoPr__4A3C3B7A33E09406");
                        j.ToTable("AlumnoProfesor");
                    });
        });

        modelBuilder.Entity<EscuelasDeMusica>(entity =>
        {
            entity.HasKey(e => e.IdEscuela).HasName("PK__Escuelas__D6C6BBF55DAD322E");

            entity.ToTable("EscuelasDeMusica");

            entity.HasIndex(e => e.CodigoEscuela, "UQ__Escuelas__EA0F19DCAFBE2D39").IsUnique();

            entity.Property(e => e.CodigoEscuela)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.DescripcionEscuela).HasMaxLength(255);
            entity.Property(e => e.NombreEscuela).HasMaxLength(100);
        });

        modelBuilder.Entity<Profesore>(entity =>
        {
            entity.HasKey(e => e.IdProfesor).HasName("PK__Profesor__C377C3A10A8E766B");

            entity.HasIndex(e => e.IdentificacionProfesor, "UQ__Profesor__028AE0ACE50DA925").IsUnique();

            entity.Property(e => e.ApellidoProfesor).HasMaxLength(100);
            entity.Property(e => e.IdentificacionProfesor)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.NombreProfesor).HasMaxLength(100);

        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
