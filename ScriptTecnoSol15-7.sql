USE [TecnoSol]
GO
/****** Object:  Table [dbo].[Bitacora]    Script Date: 15/7/2019 01:04:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bitacora](
	[IdBitacora] [int] IDENTITY(1,1) NOT NULL,
	[NickUsuario] [nvarchar](50) NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[Descripcion] [nvarchar](50) NOT NULL,
	[Criticidad] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Bitacora] PRIMARY KEY CLUSTERED 
(
	[IdBitacora] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DVV]    Script Date: 15/7/2019 01:04:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DVV](
	[IdDVV] [int] IDENTITY(1,1) NOT NULL,
	[NomTabla] [nvarchar](50) NOT NULL,
	[DVV] [int] NOT NULL,
 CONSTRAINT [PK_DVV] PRIMARY KEY CLUSTERED 
(
	[IdDVV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Producto]    Script Date: 15/7/2019 01:04:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Producto](
	[CodProd] [int] NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[Imagen] [nvarchar](50) NOT NULL,
	[Precio] [float] NOT NULL,
	[Categoria] [nvarchar](50) NOT NULL,
	[DV] [int] NOT NULL,
 CONSTRAINT [PK_Producto] PRIMARY KEY CLUSTERED 
(
	[CodProd] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 15/7/2019 01:04:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[IdUsuario] [int] NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[Apellido] [nvarchar](50) NOT NULL,
	[Nick] [nvarchar](50) NOT NULL,
	[Contraseña] [nvarchar](50) NOT NULL,
	[Mail] [nvarchar](200) NOT NULL,
	[Intentos] [int] NOT NULL,
	[Perfil] [int] NOT NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[IdUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Bitacora] ON 

INSERT [dbo].[Bitacora] ([IdBitacora], [NickUsuario], [Fecha], [Descripcion], [Criticidad]) VALUES (1, N'admin', CAST(N'2019-06-02 15:18:51.273' AS DateTime), N'Inicio sesion', N'Baja')
INSERT [dbo].[Bitacora] ([IdBitacora], [NickUsuario], [Fecha], [Descripcion], [Criticidad]) VALUES (2, N'webmaster', CAST(N'2019-06-02 15:19:25.020' AS DateTime), N'Inicio sesion', N'Baja')
INSERT [dbo].[Bitacora] ([IdBitacora], [NickUsuario], [Fecha], [Descripcion], [Criticidad]) VALUES (3, N'MartinPerei', CAST(N'2019-06-02 15:19:42.750' AS DateTime), N'Inicio sesion', N'Baja')
INSERT [dbo].[Bitacora] ([IdBitacora], [NickUsuario], [Fecha], [Descripcion], [Criticidad]) VALUES (4, N'webmaster', CAST(N'2019-06-02 15:30:51.493' AS DateTime), N'Inicio sesion', N'Baja')
INSERT [dbo].[Bitacora] ([IdBitacora], [NickUsuario], [Fecha], [Descripcion], [Criticidad]) VALUES (5, N'webmaster', CAST(N'2019-06-02 15:34:01.437' AS DateTime), N'Inicio sesion', N'Baja')
INSERT [dbo].[Bitacora] ([IdBitacora], [NickUsuario], [Fecha], [Descripcion], [Criticidad]) VALUES (6, N'webmaster', CAST(N'2019-06-02 15:42:26.170' AS DateTime), N'Inicio sesion', N'Baja')
INSERT [dbo].[Bitacora] ([IdBitacora], [NickUsuario], [Fecha], [Descripcion], [Criticidad]) VALUES (7, N'webmaster', CAST(N'2019-06-02 15:47:54.447' AS DateTime), N'Inicio sesion', N'Baja')
INSERT [dbo].[Bitacora] ([IdBitacora], [NickUsuario], [Fecha], [Descripcion], [Criticidad]) VALUES (8, N'webmaster', CAST(N'2019-06-02 15:49:17.037' AS DateTime), N'Inicio sesion', N'Baja')
INSERT [dbo].[Bitacora] ([IdBitacora], [NickUsuario], [Fecha], [Descripcion], [Criticidad]) VALUES (9, N'admin', CAST(N'2019-06-02 15:49:37.177' AS DateTime), N'Inicio sesion', N'Baja')
INSERT [dbo].[Bitacora] ([IdBitacora], [NickUsuario], [Fecha], [Descripcion], [Criticidad]) VALUES (10, N'webmaster', CAST(N'2019-06-02 16:22:51.607' AS DateTime), N'Inicio sesion', N'Baja')
INSERT [dbo].[Bitacora] ([IdBitacora], [NickUsuario], [Fecha], [Descripcion], [Criticidad]) VALUES (11, N'webmaster', CAST(N'2019-06-02 16:24:02.043' AS DateTime), N'Inicio sesion', N'Baja')
INSERT [dbo].[Bitacora] ([IdBitacora], [NickUsuario], [Fecha], [Descripcion], [Criticidad]) VALUES (12, N'webmaster', CAST(N'2019-06-02 16:27:23.753' AS DateTime), N'Inicio sesion', N'Baja')
INSERT [dbo].[Bitacora] ([IdBitacora], [NickUsuario], [Fecha], [Descripcion], [Criticidad]) VALUES (13, N'admin', CAST(N'2019-06-02 16:43:50.473' AS DateTime), N'Inicio sesion', N'Baja')
INSERT [dbo].[Bitacora] ([IdBitacora], [NickUsuario], [Fecha], [Descripcion], [Criticidad]) VALUES (14, N'admin', CAST(N'2019-06-02 16:46:15.473' AS DateTime), N'Inicio sesion', N'Baja')
INSERT [dbo].[Bitacora] ([IdBitacora], [NickUsuario], [Fecha], [Descripcion], [Criticidad]) VALUES (15, N'admin', CAST(N'2019-06-02 16:47:11.377' AS DateTime), N'Inicio sesion', N'Baja')
INSERT [dbo].[Bitacora] ([IdBitacora], [NickUsuario], [Fecha], [Descripcion], [Criticidad]) VALUES (16, N'MartinPerei', CAST(N'2019-06-02 16:47:23.917' AS DateTime), N'Inicio sesion', N'Baja')
INSERT [dbo].[Bitacora] ([IdBitacora], [NickUsuario], [Fecha], [Descripcion], [Criticidad]) VALUES (17, N'Webmaster', CAST(N'2019-06-02 16:49:20.413' AS DateTime), N'Inicio sesion', N'Baja')
INSERT [dbo].[Bitacora] ([IdBitacora], [NickUsuario], [Fecha], [Descripcion], [Criticidad]) VALUES (18, N'admin', CAST(N'2019-06-02 16:56:29.660' AS DateTime), N'Inicio sesion', N'Baja')
INSERT [dbo].[Bitacora] ([IdBitacora], [NickUsuario], [Fecha], [Descripcion], [Criticidad]) VALUES (19, N'webmaster', CAST(N'2019-06-02 16:56:45.693' AS DateTime), N'Inicio sesion', N'Baja')
INSERT [dbo].[Bitacora] ([IdBitacora], [NickUsuario], [Fecha], [Descripcion], [Criticidad]) VALUES (20, N'webmaster', CAST(N'2019-06-02 22:11:19.247' AS DateTime), N'Inicio sesion', N'Baja')
INSERT [dbo].[Bitacora] ([IdBitacora], [NickUsuario], [Fecha], [Descripcion], [Criticidad]) VALUES (21, N'webmaster', CAST(N'2019-06-02 22:12:16.867' AS DateTime), N'Inicio sesion', N'Baja')
INSERT [dbo].[Bitacora] ([IdBitacora], [NickUsuario], [Fecha], [Descripcion], [Criticidad]) VALUES (22, N'webmaster', CAST(N'2019-06-02 22:12:47.553' AS DateTime), N'Inicio sesion', N'Baja')
INSERT [dbo].[Bitacora] ([IdBitacora], [NickUsuario], [Fecha], [Descripcion], [Criticidad]) VALUES (1002, N'admin', CAST(N'2019-06-03 23:16:09.973' AS DateTime), N'Inicio sesion', N'Baja')
INSERT [dbo].[Bitacora] ([IdBitacora], [NickUsuario], [Fecha], [Descripcion], [Criticidad]) VALUES (1003, N'webmaster', CAST(N'2019-06-03 23:16:37.757' AS DateTime), N'Inicio sesion', N'Baja')
INSERT [dbo].[Bitacora] ([IdBitacora], [NickUsuario], [Fecha], [Descripcion], [Criticidad]) VALUES (1004, N'webmaster', CAST(N'2019-06-03 23:20:27.497' AS DateTime), N'Inicio sesion', N'Baja')
INSERT [dbo].[Bitacora] ([IdBitacora], [NickUsuario], [Fecha], [Descripcion], [Criticidad]) VALUES (1005, N'MartinPerei', CAST(N'2019-07-14 17:40:07.137' AS DateTime), N'Inicio sesion', N'Baja')
INSERT [dbo].[Bitacora] ([IdBitacora], [NickUsuario], [Fecha], [Descripcion], [Criticidad]) VALUES (1006, N'admin', CAST(N'2019-07-14 17:41:11.700' AS DateTime), N'Inicio sesion', N'Baja')
INSERT [dbo].[Bitacora] ([IdBitacora], [NickUsuario], [Fecha], [Descripcion], [Criticidad]) VALUES (1007, N'admin', CAST(N'2019-07-14 17:44:35.627' AS DateTime), N'Inicio sesion', N'Baja')
INSERT [dbo].[Bitacora] ([IdBitacora], [NickUsuario], [Fecha], [Descripcion], [Criticidad]) VALUES (1008, N'MartinPerei', CAST(N'2019-07-14 17:47:05.510' AS DateTime), N'Inicio sesion', N'Baja')
INSERT [dbo].[Bitacora] ([IdBitacora], [NickUsuario], [Fecha], [Descripcion], [Criticidad]) VALUES (1009, N'MartinPerei', CAST(N'2019-07-14 17:53:51.210' AS DateTime), N'Inicio sesion', N'Baja')
INSERT [dbo].[Bitacora] ([IdBitacora], [NickUsuario], [Fecha], [Descripcion], [Criticidad]) VALUES (1010, N'MartinPerei', CAST(N'2019-07-14 17:58:19.467' AS DateTime), N'Inicio sesion', N'Baja')
INSERT [dbo].[Bitacora] ([IdBitacora], [NickUsuario], [Fecha], [Descripcion], [Criticidad]) VALUES (1011, N'MartinPerei', CAST(N'2019-07-14 19:11:32.010' AS DateTime), N'Inicio sesion', N'Baja')
INSERT [dbo].[Bitacora] ([IdBitacora], [NickUsuario], [Fecha], [Descripcion], [Criticidad]) VALUES (1012, N'MartinPerei', CAST(N'2019-07-14 19:11:47.713' AS DateTime), N'Compra realizada', N'Baja')
INSERT [dbo].[Bitacora] ([IdBitacora], [NickUsuario], [Fecha], [Descripcion], [Criticidad]) VALUES (1013, N'MartinPerei', CAST(N'2019-07-14 19:11:59.283' AS DateTime), N'Compra realizada', N'Baja')
INSERT [dbo].[Bitacora] ([IdBitacora], [NickUsuario], [Fecha], [Descripcion], [Criticidad]) VALUES (1014, N'admin', CAST(N'2019-07-14 19:44:54.197' AS DateTime), N'Inicio sesion', N'Baja')
INSERT [dbo].[Bitacora] ([IdBitacora], [NickUsuario], [Fecha], [Descripcion], [Criticidad]) VALUES (1015, N'MartinPerei', CAST(N'2019-07-14 20:22:53.783' AS DateTime), N'Inicio sesion', N'Baja')
INSERT [dbo].[Bitacora] ([IdBitacora], [NickUsuario], [Fecha], [Descripcion], [Criticidad]) VALUES (1016, N'MartinPerei', CAST(N'2019-07-14 20:23:30.690' AS DateTime), N'Compra realizada', N'Baja')
INSERT [dbo].[Bitacora] ([IdBitacora], [NickUsuario], [Fecha], [Descripcion], [Criticidad]) VALUES (1017, N'MartinPerei', CAST(N'2019-07-14 20:32:25.997' AS DateTime), N'Inicio sesion', N'Baja')
INSERT [dbo].[Bitacora] ([IdBitacora], [NickUsuario], [Fecha], [Descripcion], [Criticidad]) VALUES (1018, N'admin', CAST(N'2019-07-14 23:38:52.420' AS DateTime), N'Usuario BLOQUEADO', N'Medio')
INSERT [dbo].[Bitacora] ([IdBitacora], [NickUsuario], [Fecha], [Descripcion], [Criticidad]) VALUES (1019, N'admin', CAST(N'2019-07-14 23:40:51.960' AS DateTime), N'Usuario BLOQUEADO', N'Medio')
INSERT [dbo].[Bitacora] ([IdBitacora], [NickUsuario], [Fecha], [Descripcion], [Criticidad]) VALUES (1020, N'admin', CAST(N'2019-07-14 23:42:19.940' AS DateTime), N'Usuario BLOQUEADO', N'Medio')
INSERT [dbo].[Bitacora] ([IdBitacora], [NickUsuario], [Fecha], [Descripcion], [Criticidad]) VALUES (1021, N'admin', CAST(N'2019-07-14 23:43:45.210' AS DateTime), N'Inicio sesion', N'Baja')
INSERT [dbo].[Bitacora] ([IdBitacora], [NickUsuario], [Fecha], [Descripcion], [Criticidad]) VALUES (1022, N'admin', CAST(N'2019-07-15 00:33:25.257' AS DateTime), N'Inicio sesion', N'Baja')
INSERT [dbo].[Bitacora] ([IdBitacora], [NickUsuario], [Fecha], [Descripcion], [Criticidad]) VALUES (1023, N'admin', CAST(N'2019-07-15 00:39:21.917' AS DateTime), N'Inicio sesion', N'Baja')
SET IDENTITY_INSERT [dbo].[Bitacora] OFF
SET IDENTITY_INSERT [dbo].[DVV] ON 

INSERT [dbo].[DVV] ([IdDVV], [NomTabla], [DVV]) VALUES (1, N'Producto', 1)
SET IDENTITY_INSERT [dbo].[DVV] OFF
INSERT [dbo].[Producto] ([CodProd], [Nombre], [Imagen], [Precio], [Categoria], [DV]) VALUES (1, N'Placa de video', N'img002.jpg', 15750, N'GeForce', 3085)
INSERT [dbo].[Producto] ([CodProd], [Nombre], [Imagen], [Precio], [Categoria], [DV]) VALUES (2, N'Compu gamer', N'img003.jpg', 45000, N'Computadora', 3353)
INSERT [dbo].[Producto] ([CodProd], [Nombre], [Imagen], [Precio], [Categoria], [DV]) VALUES (3, N'Nvidia GeForce gtx 1080 ti', N'img002.jpg', 56000, N'Placa de video', 4572)
INSERT [dbo].[Usuario] ([IdUsuario], [Nombre], [Apellido], [Nick], [Contraseña], [Mail], [Intentos], [Perfil]) VALUES (1, N'Juan', N'Perez', N'admin', N'21232f297a57a5a743894a0e4a801fc3', N'juan@gmail.com', 0, 1)
INSERT [dbo].[Usuario] ([IdUsuario], [Nombre], [Apellido], [Nick], [Contraseña], [Mail], [Intentos], [Perfil]) VALUES (2, N'Agustin', N'Martinez', N'webmaster', N'08345ebdf7f1d961d5f07398d3e8b24d', N'agustin@gmail.com', 0, 2)
INSERT [dbo].[Usuario] ([IdUsuario], [Nombre], [Apellido], [Nick], [Contraseña], [Mail], [Intentos], [Perfil]) VALUES (3, N'Martine', N'Perei', N'MartinPerei', N'34f74c049edea51851c6924f4a386762', N'martin@gmail.com', 0, 3)
/****** Object:  StoredProcedure [dbo].[AltaArticulo]    Script Date: 15/7/2019 01:04:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[AltaArticulo]
@CodProd nvarchar(50),@Nombre nvarchar(50),@Imagen nvarchar(50),@Precio float,@Categoria nvarchar(50),@DV int
as
begin
insert into Producto(CodProd,Nombre,Imagen,Precio,Categoria,DV)
values (@CodProd,@Nombre,@Imagen,@Precio,@Categoria,@DV)
end
GO
/****** Object:  StoredProcedure [dbo].[BajaArticulo]    Script Date: 15/7/2019 01:04:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[BajaArticulo]
@CodProd nvarchar(50)
as
begin
delete from Producto where CodProd = @CodProd
end
GO
/****** Object:  StoredProcedure [dbo].[InsertarBitacora]    Script Date: 15/7/2019 01:04:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[InsertarBitacora]
@NickUsuario nvarchar(50),@Fecha datetime,@Descripcion nvarchar(50),@Criticidad nvarchar(50)
as
begin
insert into Bitacora (NickUsuario,Fecha,Descripcion,Criticidad)
values (@NickUsuario,@Fecha,@Descripcion,@Criticidad)
END
GO
/****** Object:  StoredProcedure [dbo].[ListarBitacora]    Script Date: 15/7/2019 01:04:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[ListarBitacora]
as
begin
select NickUsuario,Fecha,Descripcion,Criticidad from Bitacora
end
GO
/****** Object:  StoredProcedure [dbo].[ListarProducto]    Script Date: 15/7/2019 01:04:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[ListarProducto]
as
begin
select Nombre,Precio from Producto
end

GO
/****** Object:  StoredProcedure [dbo].[ModificarArticulo]    Script Date: 15/7/2019 01:04:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[ModificarArticulo]
@CodProd nvarchar(50),@Nombre nvarchar(50),@Imagen nvarchar(50),@Precio float,@Categoria nvarchar(50),@DV int
as
begin
update Producto
set
Nombre = @Nombre, Imagen = @Imagen, Precio = @Precio, Categoria = @Categoria,DV = @DV
where CodProd = @CodProd
end
GO
/****** Object:  StoredProcedure [dbo].[TraerPerfil]    Script Date: 15/7/2019 01:04:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[TraerPerfil]
@Nick nvarchar(50),@Clave nvarchar(50)
as
begin
select Perfil from Usuario where Nick = @Nick and Contraseña = @Clave
end
GO
