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
    public class AlumnosDao
    {
        private readonly GestorEscuelaDbContext _context;

        public AlumnosDao(GestorEscuelaDbContext context)
        {
            _context = context;
        }

        public async Task<ResultOperation<List<AlumnoConEscuelaDto>>> ObtenerTodosAsync()
        {
            try
            {
                var resultado = await _context.Set<AlumnoConEscuelaDto>()
                    .FromSqlRaw("EXEC sp_CrudAlumno @Operacion = 'Consultar'")
                    .ToListAsync();

                return ResultOperation<List<AlumnoConEscuelaDto>>.SuccessResult(resultado);
            }
            catch (Exception ex)
            {
                return ResultOperation<List<AlumnoConEscuelaDto>>.FailureResult("Error al obtener alumnos: " + ex.Message);
            }
        }

        public async Task<ResultOperation<AlumnoConEscuelaDto?>> ObtenerPorIdAsync(int id)
        {
            try
            {
                var resultado = await _context.Set<AlumnoConEscuelaDto>()
                    .FromSqlRaw("EXEC sp_CrudAlumno @Operacion = 'ConsultarPorId', @Id = {0}", id)
                    .ToListAsync();

                var alumno = resultado.FirstOrDefault();

                if (alumno == null)
                    return ResultOperation<AlumnoConEscuelaDto?>.FailureResult("Alumno no encontrado.");

                return ResultOperation<AlumnoConEscuelaDto?>.SuccessResult(alumno);
            }
            catch (Exception ex)
            {
                return ResultOperation<AlumnoConEscuelaDto?>.FailureResult("Error al obtener alumno: " + ex.Message);
            }
        }

        public async Task<ResultOperation<int>> CrearAsync(Alumno alumno)
        {
            try
            {
                var idParam = new SqlParameter("@Id", System.Data.SqlDbType.Int)
                {
                    Direction = System.Data.ParameterDirection.Output
                };

                await _context.Database.ExecuteSqlRawAsync(
                    "EXEC sp_CrudAlumno @Operacion = 'Insertar', @Nombre = {0}, @Apellido = {1}, @FechaNac = {2}, @Identificacion = {3}, @EscuelaId = {4}",
                    alumno.NombreAlumno, alumno.ApellidoAlumno, alumno.FechaNac, alumno.IdentificacionAlumno, alumno.EscuelaId
                );

                return ResultOperation<int>.SuccessResult(0, "Alumno creado correctamente");
            }
            catch (Exception ex)
            {
                return ResultOperation<int>.FailureResult("Error al crear alumno: " + ex.Message);
            }
        }

        public async Task<ResultOperation<string>> ActualizarAsync(Alumno alumno)
        {
            try
            {
                var filas = await _context.Database.ExecuteSqlRawAsync(
                    "EXEC sp_CrudAlumno @Operacion = 'Actualizar', @Id = {0}, @Nombre = {1}, @Apellido = {2}, @FechaNac = {3}, @Identificacion = {4}, @EscuelaId = {5}",
                    alumno.IdAlumno, alumno.NombreAlumno, alumno.ApellidoAlumno, alumno.FechaNac, alumno.IdentificacionAlumno, alumno.EscuelaId);

                if (filas > 0)
                    return ResultOperation<string>.SuccessResult("Alumno actualizado correctamente");

                return ResultOperation<string>.FailureResult("No se encontró el alumno a actualizar.");
            }
            catch (Exception ex)
            {
                return ResultOperation<string>.FailureResult("Error al actualizar alumno: " + ex.Message);
            }
        }

        public async Task<ResultOperation<string>> EliminarAsync(int id)
        {
            try
            {
                var filas = await _context.Database.ExecuteSqlRawAsync(
                    "EXEC sp_CrudAlumno @Operacion = 'Eliminar', @Id = {0}", id);

                if (filas > 0)
                    return ResultOperation<string>.SuccessResult("Alumno eliminado correctamente");

                return ResultOperation<string>.FailureResult("No se encontró el alumno a eliminar.");
            }
            catch (Exception ex)
            {
                return ResultOperation<string>.FailureResult("Error al eliminar alumno: " + ex.Message);
            }
        }
    }
}
