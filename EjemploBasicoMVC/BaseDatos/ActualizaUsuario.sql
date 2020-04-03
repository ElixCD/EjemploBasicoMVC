USE TiendaOnline;
GO

CREATE PROCEDURE ActualizaUsuario
(
	@id INT,
	@clave VARCHAR(15),
	@nombre VARCHAR(50),
	@contrasena VARCHAR(20)
)
AS
BEGIN
	SET NOCOUNT ON
	UPDATE Usuario
	SET clave = @clave,  nombre = @nombre, contrasena = @contrasena
	WHERE id = @id;
END
GO