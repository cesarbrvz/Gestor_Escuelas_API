using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestorEscuelas.Models;
using GestorEscuelas.Models.DTOs;
using GestorEscuelas.Utils;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace GestorEscuelas.Data
{
    public class ProfesoresDao
    {
        private readonly GestorEscuelaDbContext _context;

        public ProfesoresDao(GestorEscuelaDbContext context)
        {
            _context = context;
        }

        public async Task<ResultOperation<List<ProfesorConEscuelaDto>>> ObtenerTodosAsync()
        {
            try
            {
                var resultado = await _context.Set<ProfesorConEscuelaDto>()
                    .FromSqlRaw("EXEC sp_CrudProfesor @Operacion = 'Consultar'")
                    .ToListAsync();

                return ResultOperation<List<ProfesorConEscuelaDto>>.SuccessResult(resultado);
            }
            catch (Exception ex)
            {
                return ResultOperation<List<ProfesorConEscuelaDto>>.FailureResult("Error al obtener profesores: " + ex.Message);
            }
        }

        public async Task<ResultOperation<ProfesorConEscuelaDto?>> ObtenerPorIdAsync(int id)
        {
            try
            {
                var resultado = await _context.Set<ProfesorConEscuelaDto>()
                    .FromSqlRaw("EXEC sp_CrudProfesor @Operacion = 'ConsultarPorId', @IdProfesor = {0}", id)
                    .ToListAsync();

                var profesor = resultado.FirstOrDefault();

                if (profesor == null)
                    return ResultOperation<ProfesorConEscuelaDto?>.FailureResult("Profesor no encontrado.");

                return ResultOperation<ProfesorConEscuelaDto?>.SuccessResult(profesor);
            }
            catch (Exception ex)
            {
                return ResultOperation<ProfesorConEscuelaDto?>.FailureResult("Error al obtener profesor: " + ex.Message);
            }
        }

        public async Task<ResultOperation<int>> CrearAsync(Profesore entidad)
        {
            try
            {
                // Opción A: Si el SP devuelve el ID insertado con SELECT SCOPE_IDENTITY()
                var idParam = new SqlParameter("@IdProfesor", System.Data.SqlDbType.Int)
                {
                    Direction = System.Data.ParameterDirection.Output
                };

                await _context.Database.ExecuteSqlRawAsync(
                    "EXEC sp_CrudProfesor @Operacion = 'Insertar', @NombreProfesor = {0}, @ApellidoProfesor = {1}, @IdentificacionProfesor = {2}, @EscuelaId = {3}",
                    entidad.NombreProfesor, entidad.ApellidoProfesor, entidad.IdentificacionProfesor, entidad.EscuelaId
                );

                return ResultOperation<int>.SuccessResult(0, "Profesor creado correctamente");
            }
            catch (Exception ex)
            {
                return ResultOperation<int>.FailureResult("Error al crear profesor: " + ex.Message);
            }
        }

        public async Task<ResultOperation<string>> ActualizarAsync(Profesore entidad)
        {
            try
            {
                var filas = await _context.Database.ExecuteSqlRawAsync(
                    "EXEC sp_CrudProfesor @Operacion = 'Actualizar', @IdProfesor = {0}, @NombreProfesor = {1}, @ApellidoProfesor = {2}, @IdentificacionProfesor = {3}, @EscuelaId = {4}",
                    entidad.IdProfesor, entidad.NombreProfesor, entidad.ApellidoProfesor, entidad.IdentificacionProfesor, entidad.EscuelaId);

                if (filas > 0)
                    return ResultOperation<string>.SuccessResult("Profesor actualizado correctamente");

                return ResultOperation<string>.FailureResult("No se encontró el profesor a actualizar.");
            }
            catch (Exception ex)
            {
                return ResultOperation<string>.FailureResult("Error al actualizar profesor: " + ex.Message);
            }
        }

        public async Task<ResultOperation<string>> EliminarAsync(int id)
        {
            try
            {
                var filas = await _context.Database.ExecuteSqlRawAsync(
                    "EXEC sp_CrudProfesor @Operacion = 'Eliminar', @IdProfesor = {0}", id);

                if (filas > 0)
                    return ResultOperation<string>.SuccessResult("Profesor eliminado correctamente");

                return ResultOperation<string>.FailureResult("No se encontró el profesor a eliminar.");
            }
            catch (Exception ex)
            {
                return ResultOperation<string>.FailureResult("Error al eliminar profesor: " + ex.Message);
            }
        }
    }
}
