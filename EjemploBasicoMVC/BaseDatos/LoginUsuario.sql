CREATE PROCEDURE LoginUsuario
(
	@nombre VARCHAR(50),
	@contrasena VARCHAR(20)
)
AS
BEGIN
	SET NOCOUNT ON;
	SELECT * FROM Usuario 
	WHERE (nombre = @nombre OR clave = @nombre) AND contrasena = @contrasena
	AND estatus = 1;
END