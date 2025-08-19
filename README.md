<img width="333" height="426" alt="imagen" src="https://github.com/user-attachments/assets/4a43e97e-f3f0-4aa7-b8ba-1429b70aff14" />

[ScriptBD.sql](https://github.com/user-attachments/files/21848462/ScriptBD.sql)
USE [master]
GO
/****** Object:  Database [Arca]    Script Date: 18/08/2025 23:03:45 ******/
CREATE DATABASE [Arca]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Arca', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\Arca.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Arca_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\Arca_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [Arca] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Arca].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Arca] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Arca] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Arca] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Arca] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Arca] SET ARITHABORT OFF 
GO
ALTER DATABASE [Arca] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Arca] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Arca] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Arca] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Arca] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Arca] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Arca] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Arca] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Arca] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Arca] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Arca] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Arca] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Arca] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Arca] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Arca] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Arca] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Arca] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Arca] SET RECOVERY FULL 
GO
ALTER DATABASE [Arca] SET  MULTI_USER 
GO
ALTER DATABASE [Arca] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Arca] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Arca] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Arca] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Arca] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Arca] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'Arca', N'ON'
GO
ALTER DATABASE [Arca] SET QUERY_STORE = ON
GO
ALTER DATABASE [Arca] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [Arca]
GO
/****** Object:  Table [dbo].[Destinatarios_Reporte]    Script Date: 18/08/2025 23:03:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Destinatarios_Reporte](
	[idDestinatario] [int] IDENTITY(1,1) NOT NULL,
	[idReporte] [int] NOT NULL,
	[nombre] [varchar](150) NOT NULL,
	[apellido] [varchar](150) NOT NULL,
	[email] [varchar](35) NOT NULL,
 CONSTRAINT [PK_Destinatarios_Reporte] PRIMARY KEY CLUSTERED 
(
	[idDestinatario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Especies]    Script Date: 18/08/2025 23:03:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Especies](
	[idEspecie] [int] IDENTITY(1,1) NOT NULL,
	[nombreCientifico] [varchar](100) NOT NULL,
	[nombreComun] [varchar](100) NOT NULL,
	[idFamilia] [int] NOT NULL,
	[descripcion] [nvarchar](500) NOT NULL,
 CONSTRAINT [PK_Especies] PRIMARY KEY CLUSTERED 
(
	[idEspecie] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Especies_Parametro]    Script Date: 18/08/2025 23:03:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Especies_Parametro](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[idParametro] [int] NOT NULL,
	[idEspecie] [int] NOT NULL,
 CONSTRAINT [PK_Especies_Reporte] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Familias]    Script Date: 18/08/2025 23:03:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Familias](
	[idFamilia] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](100) NOT NULL,
 CONSTRAINT [PK_Familias] PRIMARY KEY CLUSTERED 
(
	[idFamilia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Parametros_Reporte]    Script Date: 18/08/2025 23:03:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Parametros_Reporte](
	[IdParametro] [int] IDENTITY(1,1) NOT NULL,
	[idReporte] [int] NOT NULL,
	[fechaDesde] [date] NULL,
	[fechaHasta] [date] NULL,
 CONSTRAINT [PK_Parametros_Reporte] PRIMARY KEY CLUSTERED 
(
	[IdParametro] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reportes]    Script Date: 18/08/2025 23:03:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reportes](
	[idReporte] [int] IDENTITY(1,1) NOT NULL,
	[nombreReporte] [varchar](50) NOT NULL,
	[cantFrecuencia] [int] NOT NULL,
	[diaInicio] [date] NOT NULL,
	[diaFin] [date] NOT NULL,
	[hora] [int] NOT NULL,
	[minuto] [int] NOT NULL,
	[idTipoFrecuencia] [int] NOT NULL,
	[idParametro] [int] NOT NULL,
	[proximoEnvio] [datetime] NULL,
	[idUsuario] [int] NOT NULL,
 CONSTRAINT [PK_Reportes] PRIMARY KEY CLUSTERED 
(
	[idReporte] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Semillas]    Script Date: 18/08/2025 23:03:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Semillas](
	[idSemilla] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](150) NOT NULL,
	[idEspecie] [int] NOT NULL,
	[idUbicacion] [int] NOT NULL,
	[cantidad] [int] NOT NULL,
	[fechaAlmacenamiento] [datetime] NOT NULL,
 CONSTRAINT [PK_Semillas] PRIMARY KEY CLUSTERED 
(
	[idSemilla] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoFrecuencia]    Script Date: 18/08/2025 23:03:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoFrecuencia](
	[idTipoFrecuencia] [int] IDENTITY(1,1) NOT NULL,
	[frecuencia] [varchar](50) NOT NULL,
	[unidadFrecuencia] [varchar](50) NULL,
 CONSTRAINT [PK_TipoFrecuencia] PRIMARY KEY CLUSTERED 
(
	[idTipoFrecuencia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ubicaciones]    Script Date: 18/08/2025 23:03:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ubicaciones](
	[idUbicacion] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[descripcion] [varchar](max) NOT NULL,
	[condicionesAlmacenamiento] [varchar](max) NOT NULL,
 CONSTRAINT [PK_Ubicaciones] PRIMARY KEY CLUSTERED 
(
	[idUbicacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ubicaciones_Parametro]    Script Date: 18/08/2025 23:03:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ubicaciones_Parametro](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[idParametro] [int] NOT NULL,
	[idUbicacion] [int] NOT NULL,
 CONSTRAINT [PK_Ubicaciones_Reporte] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 18/08/2025 23:03:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[idUsuario] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](max) NOT NULL,
	[Apellido] [nvarchar](max) NOT NULL,
	[Correo] [nvarchar](max) NOT NULL,
	[HashContrasena] [nvarchar](max) NOT NULL,
	[Rol] [nvarchar](max) NOT NULL,
	[Activo] [bit] NOT NULL,
 CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED 
(
	[idUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Destinatarios_Reporte]  WITH CHECK ADD  CONSTRAINT [FK_Destinatarios_Reporte_Reportes] FOREIGN KEY([idReporte])
REFERENCES [dbo].[Reportes] ([idReporte])
GO
ALTER TABLE [dbo].[Destinatarios_Reporte] CHECK CONSTRAINT [FK_Destinatarios_Reporte_Reportes]
GO
ALTER TABLE [dbo].[Especies]  WITH CHECK ADD  CONSTRAINT [FK_Especies_Familias] FOREIGN KEY([idFamilia])
REFERENCES [dbo].[Familias] ([idFamilia])
GO
ALTER TABLE [dbo].[Especies] CHECK CONSTRAINT [FK_Especies_Familias]
GO
ALTER TABLE [dbo].[Especies_Parametro]  WITH CHECK ADD  CONSTRAINT [FK_Especies_Parametro_Parametros_Reporte] FOREIGN KEY([idParametro])
REFERENCES [dbo].[Parametros_Reporte] ([IdParametro])
GO
ALTER TABLE [dbo].[Especies_Parametro] CHECK CONSTRAINT [FK_Especies_Parametro_Parametros_Reporte]
GO
ALTER TABLE [dbo].[Especies_Parametro]  WITH CHECK ADD  CONSTRAINT [FK_Especies_Reporte_Especies] FOREIGN KEY([idEspecie])
REFERENCES [dbo].[Especies] ([idEspecie])
GO
ALTER TABLE [dbo].[Especies_Parametro] CHECK CONSTRAINT [FK_Especies_Reporte_Especies]
GO
ALTER TABLE [dbo].[Parametros_Reporte]  WITH CHECK ADD  CONSTRAINT [FK_Parametros_Reporte_Reportes] FOREIGN KEY([idReporte])
REFERENCES [dbo].[Reportes] ([idReporte])
GO
ALTER TABLE [dbo].[Parametros_Reporte] CHECK CONSTRAINT [FK_Parametros_Reporte_Reportes]
GO
ALTER TABLE [dbo].[Reportes]  WITH CHECK ADD  CONSTRAINT [FK_Reportes_TipoFrecuencia] FOREIGN KEY([idTipoFrecuencia])
REFERENCES [dbo].[TipoFrecuencia] ([idTipoFrecuencia])
GO
ALTER TABLE [dbo].[Reportes] CHECK CONSTRAINT [FK_Reportes_TipoFrecuencia]
GO
ALTER TABLE [dbo].[Reportes]  WITH CHECK ADD  CONSTRAINT [FK_Reportes_Usuarios] FOREIGN KEY([idUsuario])
REFERENCES [dbo].[Usuarios] ([idUsuario])
GO
ALTER TABLE [dbo].[Reportes] CHECK CONSTRAINT [FK_Reportes_Usuarios]
GO
ALTER TABLE [dbo].[Semillas]  WITH CHECK ADD  CONSTRAINT [FK_Semillas_Especies] FOREIGN KEY([idEspecie])
REFERENCES [dbo].[Especies] ([idEspecie])
GO
ALTER TABLE [dbo].[Semillas] CHECK CONSTRAINT [FK_Semillas_Especies]
GO
ALTER TABLE [dbo].[Semillas]  WITH CHECK ADD  CONSTRAINT [FK_Semillas_Ubicaciones] FOREIGN KEY([idUbicacion])
REFERENCES [dbo].[Ubicaciones] ([idUbicacion])
GO
ALTER TABLE [dbo].[Semillas] CHECK CONSTRAINT [FK_Semillas_Ubicaciones]
GO
ALTER TABLE [dbo].[Ubicaciones_Parametro]  WITH CHECK ADD  CONSTRAINT [FK_Ubicaciones_Reporte_Reportes] FOREIGN KEY([idParametro])
REFERENCES [dbo].[Parametros_Reporte] ([IdParametro])
GO
ALTER TABLE [dbo].[Ubicaciones_Parametro] CHECK CONSTRAINT [FK_Ubicaciones_Reporte_Reportes]
GO
ALTER TABLE [dbo].[Ubicaciones_Parametro]  WITH CHECK ADD  CONSTRAINT [FK_Ubicaciones_Reporte_Ubicaciones] FOREIGN KEY([idUbicacion])
REFERENCES [dbo].[Ubicaciones] ([idUbicacion])
GO
ALTER TABLE [dbo].[Ubicaciones_Parametro] CHECK CONSTRAINT [FK_Ubicaciones_Reporte_Ubicaciones]
GO
USE [master]
GO
ALTER DATABASE [Arca] SET  READ_WRITE 
GO
