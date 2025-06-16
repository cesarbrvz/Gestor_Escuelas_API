CREATE PROCEDURE sp_CrudEscuela
    @Operacion NVARCHAR(20),	-- 'Insertar', 'Actualizar', 'Eliminar', 'Consultar', 'ConsultarPorId'
    @Id INT = NULL,
    @Codigo NVARCHAR(10) = NULL,
    @Nombre NVARCHAR(100) = NULL,
    @Descripcion NVARCHAR(255) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    IF @Operacion = 'Insertar'
    BEGIN
        INSERT INTO EscuelasDeMusica (CodigoEscuela, NombreEscuela, DescripcionEscuela)
        VALUES (@Codigo, @Nombre, @Descripcion);

        SELECT SCOPE_IDENTITY() AS IdEscuela;
    END
    ELSE IF @Operacion = 'Actualizar'
    BEGIN
        UPDATE EscuelasDeMusica
        SET CodigoEscuela = @Codigo,
            NombreEscuela = @Nombre,
            DescripcionEscuela = @Descripcion
        WHERE IdEscuela = @Id
    END
    ELSE IF @Operacion = 'Eliminar'
    BEGIN
        DELETE FROM EscuelasDeMusica WHERE IdEscuela = @Id
    END
    ELSE IF @Operacion = 'Consultar'
    BEGIN
        SELECT * FROM EscuelasDeMusica
    END
    ELSE IF @Operacion = 'ConsultarPorId'
    BEGIN
        SELECT * FROM EscuelasDeMusica WHERE IdEscuela = @Id
    END
END