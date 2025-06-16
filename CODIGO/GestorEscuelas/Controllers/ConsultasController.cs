using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestorEscuelas.Data;
using GestorEscuelas.Models;
using Microsoft.AspNetCore.Mvc;

namespace GestorEscuelas.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConsultasController : ControllerBase
    {
        private readonly ConsultasDao _dao;

        public ConsultasController(ConsultasDao dao)
        {
            _dao = dao;
        }

        /// <summary>
        /// Consulta los alumnos que imparte un profesor, junto con la escuela a la que pertenecen.
        /// </summary>
        [HttpGet("alumnos-por-profesor/{idProfesor}")]
        public async Task<IActionResult> ObtenerAlumnosPorProfesor(int idProfesor)
        {
            var resultado = await _dao.ObtenerAlumnosPorProfesorAsync(idProfesor);

            if (!resultado.Success)
                return NotFound(resultado);

            return Ok(resultado);
        }

        /// <summary>
        /// Consulta la escuela donde imparte un profesor y todos los alumnos inscritos ahí.
        /// </summary>
        [HttpGet("escuela-y-alumnos-por-profesor/{idProfesor}")]
        public async Task<IActionResult> ObtenerEscuelaYAlumnosDeProfesor(int idProfesor)
        {
            var resultado = await _dao.ObtenerEscuelaYAlumnosDeProfesorAsync(idProfesor);

            if (!resultado.Success)
                return NotFound(resultado);

            return Ok(resultado);
        }
    }
}
