using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestorEscuelas.Models.DTOs
{
        public class ProfesorConEscuelaDto
    {
        public int IdProfesor { get; set; }
        public string? NombreProfesor { get; set; }
        public string? ApellidoProfesor { get; set; }
        public string IdentificacionProfesor { get; set; } = null!;
        public int EscuelaId { get; set; }
        public string NombreEscuela { get; set; } = null!;
    }
}