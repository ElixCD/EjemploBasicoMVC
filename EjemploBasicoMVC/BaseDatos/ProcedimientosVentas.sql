--************************************************************************
CREATE PROCEDURE VentaAlta
(
	@usuario_id INT,
	@cliente_id INT,
	@total DECIMAL(4,4)
)
AS
BEGIN
	SET NOCOUNT ON
	INSERT INTO Venta (usuario_id, cliente_id, total, fechaVenta, horaVenta)
	VALUES (@usuario_id, @cliente_id, @total, GETDATE(), GETDATE());
END
GO

--************************************************************************
CREATE PROCEDURE VentaConsultaNumero
(
	@noVenta CHAR(20)
)
AS
BEGIN
	SET NOCOUNT ON;
	SELECT * FROM Venta WHERE noVenta = @noVenta;
END
GO

--************************************************************************
CREATE PROCEDURE VentaConsultaId
(
	@id INT
)
AS
BEGIN
	SET NOCOUNT ON;
	SELECT * FROM Venta WHERE id = @id;
END
GO

--************************************************************************
CREATE PROCEDURE VentaListar
(
  @pagenum  AS INT = 1,
  @pagesize AS INT = 10,
  @totalPages AS INT OUT
)
AS
BEGIN
	SET @totalPages = (SELECT COUNT(id) FROM Venta);

	SELECT *
	FROM Venta
	ORDER BY id
	OFFSET (@pagenum - 1) * @pagesize ROWS 
	FETCH NEXT @pagesize ROWS ONLY;
END
GO

--************************************************************************
CREATE PROCEDURE VentaActualiza
(
	@id INT,
	@noVenta VARCHAR(20),
	@total DECIMAL(4,4),
	@cancelado BIT
)
AS
BEGIN
	SET NOCOUNT ON
	UPDATE Venta
	SET total = @total
	WHERE (id = @id OR noVenta = @noVenta);
END
GO

--************************************************************************
CREATE PROCEDURE VentaBaja
(
	@id INT
)
AS
BEGIN
	SET NOCOUNT ON
	UPDATE Venta
	SET cancelado = 1, fechaCancelacionVenta=GETDATE(), horaCancelacionVenta=GETDATE()
	WHERE id = @id;
END
GO

--************************************************************************
CREATE PROCEDURE VentaDetAlta
(
	@Venta_id INT,
	@producto_id INT,
	@precio DECIMAL(4,4),
	@cantidad DECIMAL(4,4),
	@subtotal DECIMAL(4,4)
)
AS
BEGIN
	SET NOCOUNT ON
	INSERT INTO VentaDet(Venta_id, producto_id, precio, cantidad, subtotal)
	VALUES (@Venta_id, @producto_id, @precio, @cantidad, @subtotal)
END
GO

--************************************************************************
CREATE PROCEDURE VentaDetActualiza
(
	@id INT,
	@venta_id INT,
	@precio DECIMAL(4,4),
	@cantidad DECIMAL(4,4),
	@subtotal DECIMAL(4,4),
	@activo BIT
)
AS
BEGIN
	SET NOCOUNT ON
	UPDATE VentaDet
	SET precio = @precio, cantidad = @cantidad, subtotal = @subtotal, activo = @activo
	WHERE id = @id AND venta_id = @venta_id;
END
GO

--************************************************************************
CREATE PROCEDURE VentaDetListarVenta
(
	@Venta_id int
)
AS
BEGIN
	SET NOCOUNT ON
	SELECT * FROM VentaDet
	WHERE Venta_id = @Venta_id
END
GO

--************************************************************************


