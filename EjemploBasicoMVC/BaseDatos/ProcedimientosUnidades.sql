USE TiendaOnline;
GO

--************************************************************************
CREATE PROCEDURE UnidadAlta
(
	@descripcion CHAR(15),
	@simbolo VARCHAR(50)
)
AS
BEGIN
	SET NOCOUNT ON
	INSERT INTO Unidad (descripcion, simbolo,fechaAlta,horaAlta)
	VALUES (@descripcion, @simbolo,GETDATE(),GETDATE());
END
GO

--************************************************************************
CREATE PROCEDURE UnidadConsultaSimbolo
(
	@simbolo VARCHAR(10)
)
AS
BEGIN
	SET NOCOUNT ON;
	SELECT * FROM Unidad WHERE simbolo = @simbolo;
END
GO

--************************************************************************
CREATE PROCEDURE UnidadConsultaId
(
	@id INT
)
AS
BEGIN
	SET NOCOUNT ON;
	SELECT * FROM Unidad WHERE id = @id;
END
GO

--************************************************************************
CREATE PROCEDURE UnidadListar
(
  @pagenum  AS INT = 1,
  @pagesize AS INT = 10
)
AS
BEGIN
	SELECT *
	FROM Unidad
	ORDER BY id
	OFFSET (@pagenum - 1) * @pagesize ROWS 
	FETCH NEXT @pagesize ROWS ONLY;
END
GO

--************************************************************************
CREATE PROCEDURE UnidadActualiza
(
	@id INT,
	@descripcion VARCHAR(15),
	@simbolo VARCHAR(50)
)
AS
BEGIN
	SET NOCOUNT ON
	UPDATE Unidad
	SET descripcion = @descripcion,  simbolo = @simbolo
	WHERE id = @id;
END
GO

--************************************************************************
CREATE PROCEDURE UnidadBaja
(
	@id INT
)
AS
BEGIN
	SET NOCOUNT ON
	UPDATE Unidad
	SET activo = 0, fechaBaja=GETDATE(), horaBaja=GETDATE()
	WHERE id = @id;
END
GO

--************************************************************************