USE TiendaOnline;
GO

--************************************************************************
CREATE PROCEDURE CompraAlta
(
	@usuario_id INT,
	@proveedor_id INT,
	@total DECIMAL(4,4)
)
AS
BEGIN
	SET NOCOUNT ON
	INSERT INTO Compra (usuario_id, proveedor_id, total, fechaCompra, horaCompra)
	VALUES (@usuario_id, @proveedor_id, @total, GETDATE(), GETDATE());
END
GO

--************************************************************************
CREATE PROCEDURE CompraConsultaNumero
(
	@noCompra CHAR(20)
)
AS
BEGIN
	SET NOCOUNT ON;
	SELECT * FROM Compra WHERE noCompra = @noCompra;
END
GO

--************************************************************************
CREATE PROCEDURE CompraConsultaId
(
	@id INT
)
AS
BEGIN
	SET NOCOUNT ON;
	SELECT * FROM Compra WHERE id = @id;
END
GO

--************************************************************************
CREATE PROCEDURE CompraListar
(
  @pagenum  AS INT = 1,
  @pagesize AS INT = 10,
  @totalPages AS INT OUT
)
AS
BEGIN
	SET @totalPages = (SELECT COUNT(id) FROM Compra);

	SELECT *
	FROM Compra
	ORDER BY id
	OFFSET (@pagenum - 1) * @pagesize ROWS 
	FETCH NEXT @pagesize ROWS ONLY;
END
GO

--************************************************************************
CREATE PROCEDURE CompraActualiza
(
	@id INT,
	@noCompra VARCHAR(20),
	@total DECIMAL(4,4),
	@cancelado BIT
)
AS
BEGIN
	SET NOCOUNT ON
	UPDATE Compra
	SET total = @total
	WHERE (id = @id OR noCompra = @noCompra);
END
GO

--************************************************************************
CREATE PROCEDURE CompraBaja
(
	@id INT
)
AS
BEGIN
	SET NOCOUNT ON
	UPDATE Compra
	SET cancelado = 1, fechaCancelacionCompra=GETDATE(), horaCancelacionCompra=GETDATE()
	WHERE id = @id;
END
GO

--************************************************************************
CREATE PROCEDURE CompraDetAlta
(
	@compra_id INT,
	@producto_id INT,
	@costo DECIMAL(4,4),
	@cantidad DECIMAL(4,4),
	@subtotal DECIMAL(4,4),
	@lote CHAR(20)
)
AS
BEGIN
	SET NOCOUNT ON
	INSERT INTO CompraDet(compra_id, producto_id, costo, cantidad, subtotal, lote)
	VALUES (@compra_id, @producto_id, @costo, @cantidad, @subtotal, @lote)
END
GO

--************************************************************************
CREATE PROCEDURE CompraDetActualiza
(
	@id INT,
	@compra_id INT,
	@costo DECIMAL(4,4),
	@cantidad DECIMAL(4,4),
	@subtotal DECIMAL(4,4),
	@lote CHAR(20),
	@activo BIT
)
AS
BEGIN
	SET NOCOUNT ON
	UPDATE CompraDet
	SET costo = @costo, cantidad = @cantidad, subtotal = @subtotal, lote = @lote, activo = @activo
	WHERE id = @id AND compra_id = @compra_id;
END
GO

--************************************************************************
CREATE PROCEDURE CompraDetListarCompra
(
	@compra_id int
)
AS
BEGIN
	SET NOCOUNT ON
	SELECT * FROM CompraDet
	WHERE compra_id = @compra_id
END
GO

--************************************************************************


