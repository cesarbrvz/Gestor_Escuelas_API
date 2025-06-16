CREATE PROCEDURE sp_CrudProfesor
    @Operacion NVARCHAR(20),	-- 'Insertar', 'Actualizar', 'Eliminar', 'Consultar', 'ConsultarPorId'
    @IdProfesor INT = NULL,
    @NombreProfesor NVARCHAR(100) = NULL,
    @ApellidoProfesor NVARCHAR(100) = NULL,
    @IdentificacionProfesor NCHAR(10) = NULL,
    @EscuelaId INT = NULL
AS
BEGIN
    SET NOCOUNT ON;

    IF @Operacion = 'Insertar'
    BEGIN
        INSERT INTO Profesores (NombreProfesor, ApellidoProfesor, IdentificacionProfesor, EscuelaId)
        VALUES (@NombreProfesor, @ApellidoProfesor, @IdentificacionProfesor, @EscuelaId)
    END
    ELSE IF @Operacion = 'Actualizar'
    BEGIN
        UPDATE Profesores
        SET NombreProfesor = @NombreProfesor,
            ApellidoProfesor = @ApellidoProfesor,
            IdentificacionProfesor = @IdentificacionProfesor,
            EscuelaId = @EscuelaId
        WHERE IdProfesor = @IdProfesor
    END
    ELSE IF @Operacion = 'Eliminar'
    BEGIN
        DELETE FROM Profesores WHERE IdProfesor = @IdProfesor
    END
    ELSE IF @Operacion = 'Consultar'
    BEGIN
        SELECT p.*, e.NombreEscuela
        FROM Profesores p
        INNER JOIN EscuelasDeMusica e ON p.EscuelaId = e.IdEscuela
    END
    ELSE IF @Operacion = 'ConsultarPorId'
    BEGIN
        SELECT p.*, e.NombreEscuela
        FROM Profesores p
        INNER JOIN EscuelasDeMusica e ON p.EscuelaId = e.IdEscuela
        WHERE p.IdProfesor = @IdProfesor
    END
END