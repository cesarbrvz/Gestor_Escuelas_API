using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestorEscuelas.Models.DTOs
{
    public class AlumnoConEscuelaDto
    {
        public int IdAlumno { get; set; }
        public string? NombreAlumno { get; set; }
        public string? ApellidoAlumno { get; set; }
        public DateOnly? FechaNac { get; set; }
        public string IdentificacionAlumno { get; set; } = null!;
        public int EscuelaId { get; set; }
        public string NombreEscuela { get; set; } = null!;
    }
}