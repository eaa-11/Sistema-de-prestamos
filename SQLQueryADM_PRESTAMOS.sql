USE [master]
GO
/****** Object:  Database [dbprestamos]    Script Date: 11/24/2020 1:03:56 PM ******/
CREATE DATABASE [dbprestamos]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'dbprestamos', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\dbprestamos.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'dbprestamos_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\dbprestamos_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [dbprestamos] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [dbprestamos].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [dbprestamos] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [dbprestamos] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [dbprestamos] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [dbprestamos] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [dbprestamos] SET ARITHABORT OFF 
GO
ALTER DATABASE [dbprestamos] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [dbprestamos] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [dbprestamos] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [dbprestamos] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [dbprestamos] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [dbprestamos] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [dbprestamos] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [dbprestamos] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [dbprestamos] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [dbprestamos] SET  ENABLE_BROKER 
GO
ALTER DATABASE [dbprestamos] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [dbprestamos] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [dbprestamos] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [dbprestamos] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [dbprestamos] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [dbprestamos] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [dbprestamos] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [dbprestamos] SET RECOVERY FULL 
GO
ALTER DATABASE [dbprestamos] SET  MULTI_USER 
GO
ALTER DATABASE [dbprestamos] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [dbprestamos] SET DB_CHAINING OFF 
GO
ALTER DATABASE [dbprestamos] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [dbprestamos] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [dbprestamos] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [dbprestamos] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'dbprestamos', N'ON'
GO
ALTER DATABASE [dbprestamos] SET QUERY_STORE = OFF
GO
USE [dbprestamos]
GO
/****** Object:  Table [dbo].[Clientes]    Script Date: 11/24/2020 1:03:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clientes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Cedula] [nchar](60) NOT NULL,
	[Nombre] [nchar](60) NOT NULL,
	[Email] [nchar](60) NULL,
	[Direccion] [nchar](60) NULL,
	[Telefono] [nchar](60) NULL,
 CONSTRAINT [PK_Clientes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MovimientosPrestamos]    Script Date: 11/24/2020 1:03:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MovimientosPrestamos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Monto_Pendiente] [decimal](18, 2) NULL,
	[Prestamo_Id] [int] NULL,
 CONSTRAINT [PK_MovimientosPrestamos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pagos]    Script Date: 11/24/2020 1:03:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pagos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Fecha] [date] NULL,
	[Monto_pagado] [decimal](18, 2) NULL,
	[Prestamo_Id] [int] NULL,
	[Cliente_Id] [int] NULL,
 CONSTRAINT [PK_Pagos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Prestamos]    Script Date: 11/24/2020 1:03:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Prestamos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Fecha] [date] NULL,
	[Monto_prestado] [int] NULL,
	[Cuotas] [int] NULL,
	[Cliente_Id] [int] NULL,
 CONSTRAINT [PK_Prestamos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Clientes] ON 
GO
INSERT [dbo].[Clientes] ([Id], [Cedula], [Nombre], [Email], [Direccion], [Telefono]) VALUES (4, N'19837287483                                                 ', N'Alejandra                                                   ', N'Alejandra@                                                  ', N'C/Gregorio Luperon #58                                      ', N'8299069805                                                  ')
GO
INSERT [dbo].[Clientes] ([Id], [Cedula], [Nombre], [Email], [Direccion], [Telefono]) VALUES (5, N'22222                                                       ', N'Estrella                                                    ', N'Estrella@                                                   ', N'jkswnds                                                     ', N'8128383                                                     ')
GO
SET IDENTITY_INSERT [dbo].[Clientes] OFF
GO
SET IDENTITY_INSERT [dbo].[Prestamos] ON 
GO
INSERT [dbo].[Prestamos] ([Id], [Fecha], [Monto_prestado], [Cuotas], [Cliente_Id]) VALUES (4, CAST(N'2020-11-24' AS Date), 100, 2, 2)
GO
SET IDENTITY_INSERT [dbo].[Prestamos] OFF
GO
ALTER TABLE [dbo].[MovimientosPrestamos]  WITH CHECK ADD  CONSTRAINT [FK_MovimientosPrestamos_Prestamos] FOREIGN KEY([Prestamo_Id])
REFERENCES [dbo].[Prestamos] ([Id])
GO
ALTER TABLE [dbo].[MovimientosPrestamos] CHECK CONSTRAINT [FK_MovimientosPrestamos_Prestamos]
GO
ALTER TABLE [dbo].[Pagos]  WITH CHECK ADD  CONSTRAINT [FK_Pagos_Clientes] FOREIGN KEY([Cliente_Id])
REFERENCES [dbo].[Clientes] ([Id])
GO
ALTER TABLE [dbo].[Pagos] CHECK CONSTRAINT [FK_Pagos_Clientes]
GO
ALTER TABLE [dbo].[Pagos]  WITH CHECK ADD  CONSTRAINT [FK_Pagos_Prestamos] FOREIGN KEY([Prestamo_Id])
REFERENCES [dbo].[Prestamos] ([Id])
GO
ALTER TABLE [dbo].[Pagos] CHECK CONSTRAINT [FK_Pagos_Prestamos]
GO
/****** Object:  StoredProcedure [dbo].[sp_actualizarClientes]    Script Date: 11/24/2020 1:03:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_actualizarClientes] 
@id int,
@cedula nchar(60),
@nombre nchar(60),
@email nchar(60),
@direccion nchar(60),
@telefono nchar(60)
AS
BEGIN
	UPDATE [dbo].[Clientes] 
	SET Cedula = @cedula, Nombre = @nombre, Email = @email, Direccion = @direccion, Telefono = @telefono
	WHERE Id = @id
END
GO
/****** Object:  StoredProcedure [dbo].[sp_actualizarPagos]    Script Date: 11/24/2020 1:03:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_actualizarPagos] 
@id int,
@fecha date,
@monto_pagado int,
@prestamo_id int,
@cliente_id int
AS
BEGIN
	UPDATE [dbo].[Pagos] 
	SET Fecha = @fecha, Monto_pagado = @monto_pagado, Prestamo_Id = @prestamo_id, Cliente_Id = @cliente_id
	WHERE Id = @id
END

GO
/****** Object:  StoredProcedure [dbo].[sp_actualizarPrestamos]    Script Date: 11/24/2020 1:03:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_actualizarPrestamos] 
@id int,
@fecha date,
@monto_prestado int,
@cuotas int,
@cliente_id int
AS
BEGIN
	UPDATE [dbo].[Prestamos] 
	SET Fecha = @fecha, Monto_prestado = @monto_prestado, Cuotas = @cuotas, Cliente_Id = @cliente_id
	WHERE Id = @id
END

GO
/****** Object:  StoredProcedure [dbo].[sp_allPagos]    Script Date: 11/24/2020 1:03:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_allPagos] 

AS
BEGIN
	SELECT p.Id, p.Fecha, p.Monto_pagado, p.Prestamo_Id, p.Cliente_Id 
	FROM Pagos p 
END

GO
/****** Object:  StoredProcedure [dbo].[sp_buscarClientes]    Script Date: 11/24/2020 1:03:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_buscarClientes] 
@id int
AS
BEGIN
	SELECT * FROM Clientes WHERE Id = @id
END

GO
/****** Object:  StoredProcedure [dbo].[sp_buscarPagos]    Script Date: 11/24/2020 1:03:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_buscarPagos] 
@id int
AS
BEGIN
	SELECT * FROM Pagos WHERE Id = @id
END

GO
/****** Object:  StoredProcedure [dbo].[sp_buscarPrestamos]    Script Date: 11/24/2020 1:03:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_buscarPrestamos] 
@id int
AS
BEGIN
	SELECT * FROM Prestamos WHERE Id = @id
END

GO
/****** Object:  StoredProcedure [dbo].[sp_eliminarClientes]    Script Date: 11/24/2020 1:03:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_eliminarClientes] 
@id int
AS
BEGIN
	DELETE FROM Clientes WHERE Id = @id
END
GO
/****** Object:  StoredProcedure [dbo].[sp_eliminarPagos]    Script Date: 11/24/2020 1:03:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_eliminarPagos] 
@id int
AS
BEGIN
	DELETE FROM Pagos WHERE Id = @id
	DELETE FROM MovimientosPrestamos WHERE Prestamo_Id = @id
END
GO
/****** Object:  StoredProcedure [dbo].[sp_eliminarPrestamos]    Script Date: 11/24/2020 1:03:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_eliminarPrestamos] 
@id int
AS
BEGIN
	DELETE FROM MovimientosPrestamos WHERE Prestamo_Id = @id
	DELETE FROM Prestamos WHERE Id = @id
END
GO
/****** Object:  StoredProcedure [dbo].[sp_filtrarClientes]    Script Date: 11/24/2020 1:03:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_filtrarClientes] 
@filter nchar(60)
AS
BEGIN
	SELECT * FROM Clientes WHERE Cedula LIKE RTRIM(@filter) + '%' OR Nombre LIKE RTRIM(@filter) + '%' OR Email LIKE RTRIM(@filter) + '%'
END

GO
/****** Object:  StoredProcedure [dbo].[sp_filtrarMovimientosPrestamos]    Script Date: 11/24/2020 1:03:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_filtrarMovimientosPrestamos] 
@filter nchar(10)
AS
BEGIN
	SELECT * FROM [dbo].[MovimientosPrestamos] WHERE Id LIKE RTRIM(@filter) + '%' OR Prestamo_Id LIKE RTRIM(@filter) + '%'
END

GO
/****** Object:  StoredProcedure [dbo].[sp_filtrarPagos]    Script Date: 11/24/2020 1:03:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_filtrarPagos] 
@fecha_inicio date,
@fecha_fin date

AS
BEGIN
	SELECT p.Id, p.Fecha, p.Monto_pagado, p.prestamo_id, p.Cliente_Id 
	FROM Pagos p 
	WHERE p.Fecha >= @fecha_inicio AND p.Fecha <= @fecha_fin
END
GO
/****** Object:  StoredProcedure [dbo].[sp_filtrarPrestamos]    Script Date: 11/24/2020 1:03:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_filtrarPrestamos] 
@filter nchar(60)
AS
BEGIN
	SELECT p.Id, p.Fecha, p.Monto_prestado, p.Cuotas, p.Cliente_Id 
	FROM Prestamos p 
	INNER JOIN Clientes c ON c.Id = p.Cliente_Id
	WHERE c.Cedula LIKE RTRIM(@filter) + '%' OR p.Fecha LIKE RTRIM(@filter) + '%'
END

GO
/****** Object:  StoredProcedure [dbo].[sp_insertarClientes]    Script Date: 11/24/2020 1:03:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_insertarClientes] 
@cedula nchar(60),
@nombre nchar(60),
@email nchar(60),
@direccion nchar(60),
@telefono nchar(60)
AS
BEGIN
	INSERT INTO [dbo].[Clientes](Cedula, Nombre, Email,Direccion, Telefono) VALUES (@cedula, @nombre, @email, @direccion, @telefono)
END
GO
/****** Object:  StoredProcedure [dbo].[sp_insertarPagos]    Script Date: 11/24/2020 1:03:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_insertarPagos] 
@fecha date,
@monto_pagado int,
@prestamo_id int,
@cliente_id int
AS
BEGIN
	INSERT INTO [dbo].[Pagos](Fecha, Monto_pagado, Prestamo_Id, Cliente_Id) VALUES (@fecha, @monto_pagado, @prestamo_id, @cliente_id)
END

GO
/****** Object:  StoredProcedure [dbo].[sp_insertarPrestamos]    Script Date: 11/24/2020 1:03:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_insertarPrestamos] 
@fecha date,
@monto_prestado int,
@cuotas int,
@cliente_id int
AS
BEGIN
	INSERT INTO [dbo].[Prestamos](Fecha, Monto_prestado, Cuotas, Cliente_Id) 
	VALUES (@fecha, @monto_prestado, @cuotas, @cliente_id)

END

GO
/****** Object:  Trigger [dbo].[TR_ActualizarMovimiento]    Script Date: 11/24/2020 1:03:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER TRIGGER [dbo].[TR_ActualizarMovimiento]
ON [dbo].[Pagos]
 AFTER INSERT AS 
 BEGIN

	UPDATE [dbo].[MovimientosPrestamos] SET Monto_Pendiente =  Monto_Pendiente - (SELECT Monto_pagado FROM inserted) WHERE Prestamo_Id = (SELECT Prestamo_Id FROM inserted)
END
GO
ALTER TABLE [dbo].[Pagos] ENABLE TRIGGER [TR_ActualizarMovimiento]
GO
/****** Object:  Trigger [dbo].[TR_InsertarMovimiento]    Script Date: 11/24/2020 1:03:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

 CREATE TRIGGER [dbo].[TR_InsertarMovimiento]
ON [dbo].[Prestamos]
 AFTER INSERT AS 
 BEGIN

	INSERT INTO [dbo].[MovimientosPrestamos] (Monto_Pendiente, Prestamo_Id)  (SELECT Monto_prestado, Id FROM inserted i)
END 
GO
ALTER TABLE [dbo].[Prestamos] ENABLE TRIGGER [TR_InsertarMovimiento]
GO
USE [master]
GO
ALTER DATABASE [dbprestamos] SET  READ_WRITE 
GO
 