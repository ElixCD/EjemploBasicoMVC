CREATE PROCEDURE RelProductoProveedorAlta
(
	@producto_id INT,
	@proveedor_id INT
)
AS
BEGIN
	SET NOCOUNT ON
	INSERT INTO Rel_ProductoProveedor (producto_id, proveedor_id, fechaAlta, horaAlta)
	VALUES (@producto_id, @proveedor_id, GETDATE(), GETDATE());
END
GO

--************************************************************************
CREATE PROCEDURE RelProductoProveedorBaja
(
	@id INT
)
AS
BEGIN
	SET NOCOUNT ON
	UPDATE Rel_ProductoProveedor
	SET activo = 0, fechaBaja = GETDATE(), horaBaja = GETDATE()
END