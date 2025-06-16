using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestorEscuelas.Models;
using GestorEscuelas.Models.DTOs;
using GestorEscuelas.Utils;
using Microsoft.EntityFrameworkCore;

namespace GestorEscuelas.Data
{
    public class ConsultasDao
    {
        private readonly GestorEscuelaDbContext _context;

        public ConsultasDao(GestorEscuelaDbContext context)
        {
            _context = context;
        }

        public async Task<ResultOperation<List<AlumnoNombreEscuelaDto>>> ObtenerAlumnosPorProfesorAsync(int idProfesor)
        {
            try
            {
                var resultado = await _context.Set<AlumnoNombreEscuelaDto>()
                    .FromSqlRaw("EXEC sp_ConsultasPorProfesor @Consulta = 'AlumnosPorProfesor', @IdProfesor = {0}", idProfesor)
                    .ToListAsync();

                return ResultOperation<List<AlumnoNombreEscuelaDto>>.SuccessResult(resultado);
            }
            catch (Exception ex)
            {
                return ResultOperation<List<AlumnoNombreEscuelaDto>>.FailureResult("Error al consultar alumnos por profesor: " + ex.Message);
            }
        }

        public async Task<ResultOperation<List<EscuelaYAlumnosDto>>> ObtenerEscuelaYAlumnosDeProfesorAsync(int idProfesor)
        {
            try
            {
                var resultado = await _context.Set<EscuelaYAlumnosDto>()
                    .FromSqlRaw("EXEC sp_ConsultasPorProfesor @Consulta = 'EscuelaYAlumnos', @IdProfesor = {0}", idProfesor)
                    .ToListAsync();

                return ResultOperation<List<EscuelaYAlumnosDto>>.SuccessResult(resultado);
            }
            catch (Exception ex)
            {
                return ResultOperation<List<EscuelaYAlumnosDto>>.FailureResult("Error al consultar escuelas y alumnos por profesor: " + ex.Message);
            }
        }
    }
}
