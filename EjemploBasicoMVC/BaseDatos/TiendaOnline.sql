CREATE DATABASE TiendaOnline;
GO

USE TiendaOnline;
GO

CREATE TABLE Usuario
(
	id INT IDENTITY(1,1),
	clave CHAR(15) NOT NULL,
	nombre VARCHAR(50) NOT NULL,
	contrasena VARCHAR(20) NOT NULL,
	activo BIT DEFAULT(1) NOT NULL,
	fechaAlta DATE DEFAULT GETDATE() NOT NULL,
	horaAlta TIME DEFAULT GETDATE() NOT NULL,
	fechaBaja DATE,
	horaBaja TIME,
	CONSTRAINT PK_Usuario PRIMARY KEY (id),
	CONSTRAINT UC_UsuarioClave UNIQUE (clave)
);

CREATE TABLE Proveedor
(
	id INT IDENTITY(1,1),
	clave CHAR(15) NOT NULL,
	nombre VARCHAR(50) NOT NULL,
	activo BIT DEFAULT(1) NOT NULL,
	fechaAlta DATE DEFAULT GETDATE() NOT NULL,
	horaAlta TIME DEFAULT GETDATE() NOT NULL,
	fechaBaja DATE,
	horaBaja TIME,
	CONSTRAINT PK_Proveedor PRIMARY KEY (id),
	CONSTRAINT UC_ProveedorClave UNIQUE (clave)
);

CREATE TABLE Cliente
(
	id INT IDENTITY(1,1),
	clave CHAR(15) NOT NULL,
	nombre VARCHAR(50) NOT NULL,
	limiteCredito DECIMAL(4,2) DEFAULT 0 NOT NULL,
	activo BIT DEFAULT(1) NOT NULL,
	fechaAlta DATE DEFAULT GETDATE() NOT NULL,
	horaAlta TIME DEFAULT GETDATE() NOT NULL,
	fechaBaja DATE,
	horaBaja TIME,
	CONSTRAINT PK_Cliente PRIMARY KEY (id),
	CONSTRAINT UC_ClienteClave UNIQUE (clave)
);

CREATE TABLE Unidad
(
	id INT IDENTITY(1,1),
	descripcion VARCHAR(20) NOT NULL,
	simbolo VARCHAR(10) NOT NULL,
	activo BIT DEFAULT(1) NOT NULL,
	fechaAlta DATE DEFAULT GETDATE() NOT NULL,
	horaAlta TIME DEFAULT GETDATE() NOT NULL,
	fechaBaja DATE,
	horaBaja TIME,
	CONSTRAINT PK_Unidad PRIMARY KEY (id),
	CONSTRAINT UC_UnidadSimbolo UNIQUE (simbolo)
);

CREATE TABLE Producto
(
	id INT IDENTITY(1,1),
	clave CHAR(10) NOT NULL,
	descripcion VARCHAR(25) NOT NULL,
	existencia DECIMAL(4,4) DEFAULT 0 NOT NULL,
	unidad_id INT NOT NULL,
	activo BIT DEFAULT(1) NOT NULL,
	fechaAlta DATE DEFAULT GETDATE() NOT NULL,
	horaAlta TIME DEFAULT GETDATE() NOT NULL,
	fechaCambio DATE DEFAULT GETDATE() NOT NULL,
	horaCambio TIME DEFAULT GETDATE() NOT NULL,
	fechaBaja DATE,
	horaBaja TIME,
	CONSTRAINT PK_Producto PRIMARY KEY (id),
	CONSTRAINT FK_ProductoUnidad FOREIGN KEY (unidad_id) REFERENCES Unidad(id),
	CONSTRAINT UC_ProductoClave UNIQUE (clave)
);

CREATE TABLE Rel_ProductoProveedor
(
	id INT IDENTITY(1,1),
	producto_id INT NOT NULL,
	proveedor_id INT NOT NULL,
	activo BIT DEFAULT 1 NOT NULL,
	fechaAlta DATE DEFAULT GETDATE() NOT NULL,
	horaAlta TIME DEFAULT GETDATE() NOT NULL,
	fechaBaja DATE,
	horaBaja TIME,
	CONSTRAINT PK_RelProductoProveedor PRIMARY KEY (id),
	CONSTRAINT FK_RelPPProducto FOREIGN KEY (producto_id) REFERENCES Producto(id),
	CONSTRAINT FK_RelPPProveedor FOREIGN KEY (proveedor_id) REFERENCES Proveedor(id)
);

CREATE TABLE Compra
(
	id INT IDENTITY(1,1),
	noCompra VARCHAR(20) NOT NULL,
	usuario_id INT NOT NULL,
	proveedor_id INT NOT NULL,
	total DECIMAL(4,4) NOT NULL,
	fechaCompra DATE DEFAULT GETDATE() NOT NULL,
	horaCompra TIME DEFAULT GETDATE() NOT NULL,
	cancelado BIT DEFAULT (0) NOT NULL,
	fechaCancelacionCompra DATE,
	horaCancelacionCompra TIME,
	CONSTRAINT PK_Compra PRIMARY KEY (id),
	CONSTRAINT FK_CompraUsuario FOREIGN KEY (usuario_id) REFERENCES Usuario(id),
	CONSTRAINT FK_CompraProveedor FOREIGN KEY (proveedor_id) REFERENCES Proveedor(id),
	CONSTRAINT UC_CompraNoCompra UNIQUE (noCompra)
);

CREATE TABLE CompraDet
(
	id INT IDENTITY(1,1),
	compra_id INT NOT NULL,
	producto_id INT NOT NULL,
	costo DECIMAL(4,4) NOT NULL,
	cantidad DECIMAL(4,4) NOT NULL,
	subtotal DECIMAL(4,4) NOT NULL,
	lote CHAR(20) NOT NULL,
	activo BIT DEFAULT (1) NOT NULL,
	CONSTRAINT PK_CompraDet PRIMARY KEY (producto_id, lote),
	CONSTRAINT FK_CompraDetCompra FOREIGN KEY (compra_id) REFERENCES Compra(id),
	CONSTRAINT FK_CompraDetProducto FOREIGN KEY (producto_id) REFERENCES Producto(id),
	CONSTRAINT UC_CompraDetLote UNIQUE (lote)
);

CREATE TABLE Venta
(
	id INT IDENTITY(1,1),
	noVenta VARCHAR(20) NOT NULL,
	usuario_id INT NOT NULL,
	cliente_id INT NOT NULL,
	total DECIMAL(4,4) NOT NULL,
	fechaVenta DATE DEFAULT GETDATE() NOT NULL,
	horaVenta TIME DEFAULT GETDATE() NOT NULL,
	cancelado BIT DEFAULT(0) NOT NULL,
	fechaCancelacionVenta DATE,
	horaCancelacionVenta TIME,
	CONSTRAINT PK_Venta PRIMARY KEY (id),
	CONSTRAINT FK_VentaUsuario FOREIGN KEY (usuario_id) REFERENCES Usuario(id),
	CONSTRAINT FK_VentaCliente FOREIGN KEY (cliente_id) REFERENCES Cliente(id),
	CONSTRAINT UC_VentaNoVenta UNIQUE (noVenta)
);

CREATE TABLE VentaDet
(
	id INT IDENTITY(1,1),
	venta_id INT NOT NULL,
	producto_id INT NOT NULL,
	precio DECIMAL (4,4) NOT NULL,
	cantidad DECIMAL(4,4) NOT NULL,
	subtotal DECIMAL (4,4) NOT NULL,
	activo BIT DEFAULT (1) NOT NULL,
	CONSTRAINT PK_VentaDet PRIMARY KEY (id),
	CONSTRAINT FK_VentaDetVenta FOREIGN KEY (venta_id) REFERENCES Venta(id),
	CONSTRAINT FK_VentaDetProducto FOREIGN KEY (producto_id) REFERENCES Producto(id)
);

