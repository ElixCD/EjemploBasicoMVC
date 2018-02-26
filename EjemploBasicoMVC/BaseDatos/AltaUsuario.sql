CREATE PROCEDURE AltaUsuario
(
	@clave CHAR(15),
	@nombre VARCHAR(50),
	@contrasenia VARCHAR(20)
)
AS
BEGIN
	SET NOCOUNT ON
	INSERT INTO USUARIO (clave, nombre,contrasena,fechaAlta,horaAlta)
	VALUES (@clave, @nombre,@contrasenia,GETDATE(),GETDATE());
END