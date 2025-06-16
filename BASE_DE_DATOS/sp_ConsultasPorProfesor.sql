CREATE PROCEDURE sp_ConsultasPorProfesor
    @IdProfesor INT,
    @Consulta NVARCHAR(50)	-- 'AlumnosPorProfesor' o 'EscuelaYAlumnos'
AS
BEGIN
    SET NOCOUNT ON;

    IF @Consulta = 'AlumnosPorProfesor'
    BEGIN
        SELECT 
            a.NombreAlumno + ' ' + a.ApellidoAlumno AS NombreAlumnoCompleto,
            e.NombreEscuela
        FROM AlumnoProfesor ap
        INNER JOIN Alumnos a ON ap.IdAlumno = a.IdAlumno
        INNER JOIN EscuelasDeMusica e ON a.EscuelaId = e.IdEscuela
        WHERE ap.IdProfesor = @IdProfesor
    END

    ELSE IF @Consulta = 'EscuelaYAlumnos'
    BEGIN
        SELECT 
		e.NombreEscuela AS Escuela,
		a.NombreAlumno + ' ' + a.ApellidoAlumno AS Alumno
	FROM Profesores p
	INNER JOIN EscuelasDeMusica e ON p.EscuelaId = e.IdEscuela
	INNER JOIN AlumnoProfesor ap ON p.IdProfesor = ap.IdProfesor
	INNER JOIN Alumnos a ON ap.IdAlumno = a.IdAlumno
	WHERE p.IdProfesor = @IdProfesor
    END
END
