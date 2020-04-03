USE TiendaOnline;
GO

--************************************************************************
CREATE PROCEDURE ProductoAlta
(
	@clave CHAR(15),
	@descripcion VARCHAR(25),
	@unidad_id INT
)
AS
BEGIN
	SET NOCOUNT ON
	INSERT INTO Producto (clave, descripcion,fechaAlta,horaAlta)
	VALUES (@clave, @descripcion,GETDATE(),GETDATE());
END
GO

--************************************************************************
CREATE PROCEDURE ProductoBaja
(
	@id INT
)
AS
BEGIN
	SET NOCOUNT ON
	UPDATE Producto
	SET activo = 0, fechaBaja=GETDATE(), horaBaja=GETDATE()
	WHERE id = @id;
END
GO

--************************************************************************
CREATE PROCEDURE ProductoActualiza
(
	@id INT,
	@clave CHAR(15),
	@descripcion VARCHAR(25),
	@unidad_id INT
)
AS
BEGIN
	SET NOCOUNT ON
	UPDATE Producto
	SET clave = @clave,  descripcion = @descripcion, unidad_id= @unidad_id
	WHERE id = @id;
END
GO

--************************************************************************
CREATE PROCEDURE ProductoConsultaClave
(
	@clave CHAR(10)
)
AS
BEGIN
	SET NOCOUNT ON;
	SELECT * FROM Producto WHERE clave = @clave;
END
GO

--************************************************************************
CREATE PROCEDURE ProductoConsultaId
(
	@id INT
)
AS
BEGIN
	SET NOCOUNT ON;
	SELECT * FROM Producto WHERE id = @id;
END
GO

--************************************************************************
CREATE PROCEDURE ProductoListar
(
  @pagenum  AS INT = 1,
  @pagesize AS INT = 10,
  @totalPages AS INT OUT
)
AS
BEGIN
	SET @totalPages = (SELECT COUNT(id) FROM Producto);

	SELECT *
	FROM Producto
	ORDER BY id
	OFFSET (@pagenum - 1) * @pagesize ROWS 
	FETCH NEXT @pagesize ROWS ONLY;
END
GO

--************************************************************************
