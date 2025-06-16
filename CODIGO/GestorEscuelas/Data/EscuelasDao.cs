using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestorEscuelas.Models;
using GestorEscuelas.Utils;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace GestorEscuelas.Data
{
    public class EscuelasDao
    {
        private readonly GestorEscuelaDbContext _context;

        public EscuelasDao(GestorEscuelaDbContext context)
        {
            _context = context;
        }

        public async Task<ResultOperation<List<EscuelasDeMusica>>> ObtenerTodosAsync()
        {
            try
            {
                var lista = await _context.EscuelasDeMusicas
                    .FromSqlRaw("EXEC sp_CrudEscuela @Operacion = 'Consultar'")
                    .ToListAsync();

                return ResultOperation<List<EscuelasDeMusica>>.SuccessResult(lista);
            }
            catch (Exception ex)
            {
                return ResultOperation<List<EscuelasDeMusica>>.FailureResult("Error al consultar escuelas: " + ex.Message);
            }
        }

        public async Task<ResultOperation<EscuelasDeMusica?>> ObtenerPorIdAsync(int id)
        {
            try
            {
                var lista = await _context.EscuelasDeMusicas
                    .FromSqlRaw("EXEC sp_CrudEscuela @Operacion = 'ConsultarPorId', @Id = {0}", id)
                    .ToListAsync();

                var escuela = lista.FirstOrDefault();

                if (escuela == null)
                    return ResultOperation<EscuelasDeMusica?>.FailureResult("Escuela no encontrada.");

                return ResultOperation<EscuelasDeMusica?>.SuccessResult(escuela);
            }
            catch (Exception ex)
            {
                return ResultOperation<EscuelasDeMusica?>.FailureResult("Error al consultar escuela: " + ex.Message);
            }
        }

        public async Task<ResultOperation<int>> CrearAsync(EscuelasDeMusica escuela)
        {
            try
            {
                var idParam = new SqlParameter
                {
                    ParameterName = "@IdEscuela",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Direction = System.Data.ParameterDirection.Output
                };

                // Ejecutar el insert
                await _context.Database.ExecuteSqlRawAsync(
                    "EXEC sp_CrudEscuela @Operacion = 'Insertar', @Codigo = {0}, @Nombre = {1}, @Descripcion = {2}",
                    escuela.CodigoEscuela, escuela.NombreEscuela, escuela.DescripcionEscuela
                );

                // No podemos obtener el ID insertado directamente sin cambiar el SP a OUTPUT o a SELECT SCOPE_IDENTITY
                return ResultOperation<int>.SuccessResult(0, "Escuela creada correctamente.");
            }
            catch (Exception ex)
            {
                return ResultOperation<int>.FailureResult("Error al crear escuela: " + ex.Message);
            }
        }

        public async Task<ResultOperation<string>> ActualizarAsync(EscuelasDeMusica escuela)
        {
            try
            {
                var filas = await _context.Database.ExecuteSqlRawAsync(
                    "EXEC sp_CrudEscuela @Operacion = 'Actualizar', @Id = {0}, @Codigo = {1}, @Nombre = {2}, @Descripcion = {3}",
                    escuela.IdEscuela, escuela.CodigoEscuela, escuela.NombreEscuela, escuela.DescripcionEscuela
                );

                if (filas > 0)
                    return ResultOperation<string>.SuccessResult("Escuela actualizada correctamente.");

                return ResultOperation<string>.FailureResult("No se encontró la escuela para actualizar.");
            }
            catch (Exception ex)
            {
                return ResultOperation<string>.FailureResult("Error al actualizar escuela: " + ex.Message);
            }
        }

        public async Task<ResultOperation<string>> EliminarAsync(int id)
        {
            try
            {
                var filas = await _context.Database.ExecuteSqlRawAsync(
                    "EXEC sp_CrudEscuela @Operacion = 'Eliminar', @Id = {0}", id);

                if (filas > 0)
                    return ResultOperation<string>.SuccessResult("Escuela eliminada correctamente.");

                return ResultOperation<string>.FailureResult("No se encontró la escuela para eliminar.");
            }
            catch (Exception ex)
            {
                return ResultOperation<string>.FailureResult("Error al eliminar escuela: " + ex.Message);
            }
        }
    }
}
