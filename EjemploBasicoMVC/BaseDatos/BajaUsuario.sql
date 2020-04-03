USE TiendaOnline;
GO

CREATE PROCEDURE BajaUsuario
(
	@id INT
)
AS
BEGIN
	SET NOCOUNT ON
	UPDATE Usuario
	SET estatus = 0, fechaBaja=GETDATE(), horaBaja=GETDATE()
	WHERE id = @id;
END
GO