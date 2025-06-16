using System;
using System.Collections.Generic;

namespace GestorEscuelas.Models;

public partial class Profesore
{
    public int IdProfesor { get; set; }

    public string? NombreProfesor { get; set; }

    public string? ApellidoProfesor { get; set; }

    public string IdentificacionProfesor { get; set; } = null!;

    public int EscuelaId { get; set; }

    public virtual EscuelasDeMusica Escuela { get; set; } = null!;

    public virtual ICollection<Alumno> IdAlumnos { get; set; } = new List<Alumno>();
}
