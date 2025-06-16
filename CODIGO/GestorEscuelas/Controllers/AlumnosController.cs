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
    public class AlumnosController : ControllerBase
    {
        private readonly AlumnosDao _dao;

        public AlumnosController(AlumnosDao dao)
        {
            _dao = dao;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var resultado = await _dao.ObtenerTodosAsync();

            if (!resultado.Success)
                return StatusCode(500, resultado.Message);

            return Ok(resultado);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var resultado = await _dao.ObtenerPorIdAsync(id);

            if (!resultado.Success)
                return NotFound(resultado.Message);

            return Ok(resultado);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Alumno model)
        {
            var resultado = await _dao.CrearAsync(model);

            if (!resultado.Success)
                return BadRequest(resultado.Message);

            // Redirige a la consulta por ID si deseas devolver el alumno creado
            return CreatedAtAction(nameof(GetById), new { id = resultado.Data }, model);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Alumno model)
        {
            if (id != model.IdAlumno)
                return BadRequest("El ID no coincide con el del modelo.");

            var resultado = await _dao.ActualizarAsync(model);

            if (!resultado.Success)
                return NotFound(resultado.Message);

            return Ok(resultado);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var resultado = await _dao.EliminarAsync(id);

            if (!resultado.Success)
                return NotFound(resultado.Message);

            return Ok(resultado);
        }
    }
}
