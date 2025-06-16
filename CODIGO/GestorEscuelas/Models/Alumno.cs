using System;
using System.Collections.Generic;

namespace GestorEscuelas.Models;

public partial class Alumno
{
    public int IdAlumno { get; set; }

    public string? NombreAlumno { get; set; }

    public string? ApellidoAlumno { get; set; }

    public DateOnly? FechaNac { get; set; }

    public string IdentificacionAlumno { get; set; } = null!;

    public int EscuelaId { get; set; }

    public virtual EscuelasDeMusica Escuela { get; set; } = null!;

    public virtual ICollection<Profesore> IdProfesors { get; set; } = new List<Profesore>();
}


