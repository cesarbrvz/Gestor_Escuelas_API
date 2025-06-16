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
    public class ProfesoresController : ControllerBase
    {
        private readonly ProfesoresDao _dao;

        public ProfesoresController(ProfesoresDao dao)
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
        public async Task<IActionResult> Post([FromBody] Profesore model)
        {
            var resultado = await _dao.CrearAsync(model);

            if (!resultado.Success)
                return BadRequest(resultado.Message);

            // Nota: si quieres devolver el objeto creado, deberías recuperarlo por ID
            return CreatedAtAction(nameof(GetById), new { id = resultado.Data }, model);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Profesore model)
        {
            if (id != model.IdProfesor)
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
