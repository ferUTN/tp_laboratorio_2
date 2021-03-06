USE [master]
GO
/****** Object:  Database [lab2_tp4]    Script Date: 23/11/2020 01:38:16 ******/
CREATE DATABASE [lab2_tp4]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'lab2_tp4', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\lab2_tp4.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'lab2_tp4_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\lab2_tp4_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [lab2_tp4] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [lab2_tp4].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [lab2_tp4] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [lab2_tp4] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [lab2_tp4] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [lab2_tp4] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [lab2_tp4] SET ARITHABORT OFF 
GO
ALTER DATABASE [lab2_tp4] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [lab2_tp4] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [lab2_tp4] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [lab2_tp4] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [lab2_tp4] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [lab2_tp4] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [lab2_tp4] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [lab2_tp4] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [lab2_tp4] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [lab2_tp4] SET  DISABLE_BROKER 
GO
ALTER DATABASE [lab2_tp4] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [lab2_tp4] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [lab2_tp4] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [lab2_tp4] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [lab2_tp4] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [lab2_tp4] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [lab2_tp4] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [lab2_tp4] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [lab2_tp4] SET  MULTI_USER 
GO
ALTER DATABASE [lab2_tp4] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [lab2_tp4] SET DB_CHAINING OFF 
GO
ALTER DATABASE [lab2_tp4] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [lab2_tp4] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [lab2_tp4] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [lab2_tp4] SET QUERY_STORE = OFF
GO
USE [lab2_tp4]
GO
/****** Object:  Table [dbo].[osciloscopio]    Script Date: 23/11/2020 01:38:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[osciloscopio](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[codigo] [int] NOT NULL,
	[descripcion] [varchar](50) NOT NULL,
	[precio] [float] NOT NULL,
	[puertoUsb] [bit] NOT NULL,
	[portatil] [bit] NOT NULL,
 CONSTRAINT [PK_osciloscopio] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tester]    Script Date: 23/11/2020 01:38:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tester](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[codigo] [int] NOT NULL,
	[descripcion] [varchar](50) NOT NULL,
	[precio] [float] NOT NULL,
	[cantidadCuentas] [int] NOT NULL,
	[cantidadFunciones] [int] NOT NULL,
 CONSTRAINT [PK_tester] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[osciloscopio] ON 

INSERT [dbo].[osciloscopio] ([id], [codigo], [descripcion], [precio], [puertoUsb], [portatil]) VALUES (27, 200, N'Osciloscopio Analógico', 35000, 0, 0)
INSERT [dbo].[osciloscopio] ([id], [codigo], [descripcion], [precio], [puertoUsb], [portatil]) VALUES (28, 201, N'Osciloscopio Analógico 60 Mhz', 60000, 0, 0)
INSERT [dbo].[osciloscopio] ([id], [codigo], [descripcion], [precio], [puertoUsb], [portatil]) VALUES (29, 202, N'Osciloscopio Digital 100 Mhz', 85000, 1, 0)
INSERT [dbo].[osciloscopio] ([id], [codigo], [descripcion], [precio], [puertoUsb], [portatil]) VALUES (30, 203, N'Osciloscopio Digital 200 Mhz', 125300, 1, 1)
SET IDENTITY_INSERT [dbo].[osciloscopio] OFF
GO
SET IDENTITY_INSERT [dbo].[tester] ON 

INSERT [dbo].[tester] ([id], [codigo], [descripcion], [precio], [cantidadCuentas], [cantidadFunciones]) VALUES (41, 100, N'Tester Analógico', 800, 1, 3)
INSERT [dbo].[tester] ([id], [codigo], [descripcion], [precio], [cantidadCuentas], [cantidadFunciones]) VALUES (42, 101, N'Tester Digital Básico', 1200, 1000, 3)
INSERT [dbo].[tester] ([id], [codigo], [descripcion], [precio], [cantidadCuentas], [cantidadFunciones]) VALUES (43, 102, N'Tester Digital Semi Profesional', 2200, 5000, 6)
INSERT [dbo].[tester] ([id], [codigo], [descripcion], [precio], [cantidadCuentas], [cantidadFunciones]) VALUES (44, 103, N'Tester Digital Profesional', 4700, 10000, 8)
SET IDENTITY_INSERT [dbo].[tester] OFF
GO
USE [master]
GO
ALTER DATABASE [lab2_tp4] SET  READ_WRITE 
GO
