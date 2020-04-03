USE TiendaOnline;
GO

CREATE PROCEDURE ConsultaUsuarioClave
(
	@clave INT
)
AS
BEGIN
	SET NOCOUNT ON;
	SELECT * FROM Usuario WHERE clave = @clave;
END