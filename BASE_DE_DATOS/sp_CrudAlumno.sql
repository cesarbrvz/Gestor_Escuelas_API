CREATE PROCEDURE sp_CrudAlumno
    @Operacion NVARCHAR(20),	-- 'Insertar', 'Actualizar', 'Eliminar', 'Consultar', 'ConsultarPorId'
    @Id INT = NULL,
    @Nombre NVARCHAR(100) = NULL,
    @Apellido NVARCHAR(100) = NULL,
    @FechaNac DATE = NULL,
    @Identificacion NCHAR(10) = NULL,
    @EscuelaId INT = NULL
AS
BEGIN
    SET NOCOUNT ON;

    IF @Operacion = 'Insertar'
    BEGIN
        INSERT INTO Alumnos (NombreAlumno, ApellidoAlumno, FechaNac, IdentificacionAlumno, EscuelaId)
        VALUES (@Nombre, @Apellido, @FechaNac, @Identificacion, @EscuelaId);

        SELECT SCOPE_IDENTITY() AS IdAlumno;
    END
    ELSE IF @Operacion = 'Actualizar'
    BEGIN
        UPDATE Alumnos
        SET NombreAlumno = @Nombre,
            ApellidoAlumno = @Apellido,
            FechaNac = @FechaNac,
            IdentificacionAlumno = @Identificacion,
            EscuelaId = @EscuelaId
        WHERE IdAlumno = @Id
    END
    ELSE IF @Operacion = 'Eliminar'
    BEGIN
        DELETE FROM Alumnos WHERE IdAlumno = @Id
    END
    ELSE IF @Operacion = 'Consultar'
    BEGIN
        SELECT a.*, e.NombreEscuela
        FROM Alumnos a
        INNER JOIN EscuelasDeMusica e ON a.EscuelaId = e.IdEscuela
    END
    ELSE IF @Operacion = 'ConsultarPorId'
    BEGIN
        SELECT a.*, e.NombreEscuela
        FROM Alumnos a
        INNER JOIN EscuelasDeMusica e ON a.EscuelaId = e.IdEscuela
        WHERE a.IdAlumno = @Id
    END
END