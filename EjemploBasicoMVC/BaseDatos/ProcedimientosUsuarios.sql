USE TiendaOnline;
GO

--************************************************************************
CREATE PROCEDURE UsuarioAlta
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
GO

--************************************************************************
CREATE PROCEDURE UsuarioConsultaClave
(
	@clave CHAR(15)
)
AS
BEGIN
	SET NOCOUNT ON;
	SELECT * FROM Usuario WHERE clave = @clave;
END
GO

--************************************************************************
CREATE PROCEDURE UsuarioConsultaId
(
	@id INT
)
AS
BEGIN
	SET NOCOUNT ON;
	SELECT * FROM Usuario WHERE id = @id;
END
GO

--************************************************************************
CREATE PROCEDURE UsuarioListar
(
  @pagenum  AS INT = 1,
  @pagesize AS INT = 10,
  @totalPages AS INT OUT
)
AS
BEGIN
	SET @totalPages = (SELECT COUNT(id) FROM Usuario);

	SELECT *
	FROM Usuario
	ORDER BY id
	OFFSET (@pagenum - 1) * @pagesize ROWS 
	FETCH NEXT @pagesize ROWS ONLY;
END
GO

--************************************************************************
CREATE PROCEDURE UsuarioLogin
(
	@nombre VARCHAR(50),
	@contrasena VARCHAR(20)
)
AS
BEGIN
	SET NOCOUNT ON;
	SELECT * FROM Usuario 
	WHERE (nombre = @nombre OR clave = @nombre) AND contrasena = @contrasena
	AND activo = 1;
END
GO

--************************************************************************
CREATE PROCEDURE UsuarioActualiza
(
	@id INT,
	@clave VARCHAR(15),
	@nombre VARCHAR(50),
	@contrasena VARCHAR(20)
)
AS
BEGIN
	SET NOCOUNT ON
	UPDATE Usuario
	SET clave = @clave,  nombre = @nombre, contrasena = @contrasena
	WHERE id = @id;
END
GO

--************************************************************************
CREATE PROCEDURE UsuarioBaja
(
	@id INT
)
AS
BEGIN
	SET NOCOUNT ON
	UPDATE Usuario
	SET activo = 0, fechaBaja=GETDATE(), horaBaja=GETDATE()
	WHERE id = @id;
END
GO

--************************************************************************