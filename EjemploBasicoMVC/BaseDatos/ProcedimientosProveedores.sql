USE TiendaOnline;
GO

--************************************************************************
CREATE PROCEDURE ProveedorAlta
(
	@clave CHAR(15),
	@nombre VARCHAR(50)
)
AS
BEGIN
	SET NOCOUNT ON
	INSERT INTO Proveedor (clave, nombre,fechaAlta,horaAlta)
	VALUES (@clave, @nombre,GETDATE(),GETDATE());
END
GO

--************************************************************************
CREATE PROCEDURE ProveedorBaja
(
	@id INT
)
AS
BEGIN
	SET NOCOUNT ON
	UPDATE Proveedor
	SET activo = 0, fechaBaja=GETDATE(), horaBaja=GETDATE()
	WHERE id = @id;
END
GO

--************************************************************************
CREATE PROCEDURE ProveedorActualiza
(
	@id INT,
	@clave VARCHAR(15),
	@nombre VARCHAR(50)
)
AS
BEGIN
	SET NOCOUNT ON
	UPDATE Proveedor
	SET clave = @clave,  nombre = @nombre
	WHERE id = @id;
END
GO

--************************************************************************
CREATE PROCEDURE ProveedorConsultaClave
(
	@clave CHAR(15)
)
AS
BEGIN
	SET NOCOUNT ON;
	SELECT * FROM Proveedor WHERE clave = @clave;
END
GO

--************************************************************************
CREATE PROCEDURE ProveedorConsultaId
(
	@id INT
)
AS
BEGIN
	SET NOCOUNT ON;
	SELECT * FROM Proveedor WHERE id = @id;
END
GO

--************************************************************************
CREATE PROCEDURE ProveedorListar
(
  @pagenum  AS INT = 1,
  @pagesize AS INT = 10,
  @totalPages AS INT OUT
)
AS
BEGIN
	SET @totalPages = (SELECT COUNT(id) FROM Proveedor);

	SELECT *
	FROM Proveedor
	ORDER BY id
	OFFSET (@pagenum - 1) * @pagesize ROWS 
	FETCH NEXT @pagesize ROWS ONLY;
END
GO

--************************************************************************