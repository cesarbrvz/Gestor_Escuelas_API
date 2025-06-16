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
    public class EscuelasController : ControllerBase
    {
        private readonly EscuelasDao _dao;

        public EscuelasController(EscuelasDao dao)
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
        public async Task<IActionResult> Post([FromBody] EscuelasDeMusica escuela)
        {
            var resultado = await _dao.CrearAsync(escuela);

            if (!resultado.Success)
                return BadRequest(resultado.Message);

            return CreatedAtAction(nameof(GetById), new { id = resultado.Data }, escuela);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] EscuelasDeMusica escuela)
        {
            if (id != escuela.IdEscuela)
                return BadRequest("El ID no coincide con el objeto enviado.");

            var resultado = await _dao.ActualizarAsync(escuela);

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
