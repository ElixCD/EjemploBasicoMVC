--************************************************************************
CREATE PROCEDURE ClienteAlta
(
	@clave CHAR(15),
	@nombre VARCHAR(50)
)
AS
BEGIN
	SET NOCOUNT ON
	INSERT INTO Cliente (clave, nombre,fechaAlta,horaAlta)
	VALUES (@clave, @nombre,GETDATE(),GETDATE());
END
GO

--************************************************************************
CREATE PROCEDURE ClienteBaja
(
	@id INT
)
AS
BEGIN
	SET NOCOUNT ON
	UPDATE Cliente
	SET activo = 0, fechaBaja=GETDATE(), horaBaja=GETDATE()
	WHERE id = @id;
END
GO

--************************************************************************
CREATE PROCEDURE ClienteActualiza
(
	@id INT,
	@clave VARCHAR(15),
	@nombre VARCHAR(50),
	@limiteCredito DECIMAL(4,2)
)
AS
BEGIN
	SET NOCOUNT ON
	UPDATE Cliente
	SET clave = @clave,  nombre = @nombre, limiteCredito = @limiteCredito
	WHERE id = @id;
END
GO

--************************************************************************

CREATE PROCEDURE ClienteConsultaClave
(
	@clave CHAR(10)
)
AS
BEGIN
	SET NOCOUNT ON;
	SELECT * FROM Cliente WHERE clave = @clave;
END
GO

--************************************************************************
CREATE PROCEDURE ClienteConsultaId
(
	@id INT
)
AS
BEGIN
	SET NOCOUNT ON;
	SELECT * FROM Cliente WHERE id = @id;
END
GO
--************************************************************************
CREATE PROCEDURE ClientesListar
(
  @pagenum  AS INT = 1,
  @pagesize AS INT = 10,
  @totalPages AS INT OUT
)
AS
BEGIN
	SET @totalPages = (SELECT COUNT(id) FROM Cliente);

	SELECT *
	FROM Cliente
	ORDER BY id
	OFFSET (@pagenum - 1) * @pagesize ROWS 
	FETCH NEXT @pagesize ROWS ONLY;
END
GO

--************************************************************************
