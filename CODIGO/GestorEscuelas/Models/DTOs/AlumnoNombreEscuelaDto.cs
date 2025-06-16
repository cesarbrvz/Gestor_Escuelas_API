using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestorEscuelas.Models.DTOs
{
    public class AlumnoNombreEscuelaDto
    {
        public string NombreAlumnoCompleto { get; set; } = null!;
        public string NombreEscuela { get; set; } = null!;
    }
}