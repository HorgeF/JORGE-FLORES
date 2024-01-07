USE [master]
GO
/****** Object:  Database [XYZ]    Script Date: 7/01/2024 00:57:04 ******/
CREATE DATABASE [XYZ]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'XYZ', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\XYZ.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'XYZ_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\XYZ_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [XYZ] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [XYZ].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [XYZ] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [XYZ] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [XYZ] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [XYZ] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [XYZ] SET ARITHABORT OFF 
GO
ALTER DATABASE [XYZ] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [XYZ] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [XYZ] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [XYZ] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [XYZ] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [XYZ] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [XYZ] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [XYZ] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [XYZ] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [XYZ] SET  ENABLE_BROKER 
GO
ALTER DATABASE [XYZ] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [XYZ] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [XYZ] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [XYZ] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [XYZ] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [XYZ] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [XYZ] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [XYZ] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [XYZ] SET  MULTI_USER 
GO
ALTER DATABASE [XYZ] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [XYZ] SET DB_CHAINING OFF 
GO
ALTER DATABASE [XYZ] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [XYZ] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [XYZ] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [XYZ] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [XYZ] SET QUERY_STORE = ON
GO
ALTER DATABASE [XYZ] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [XYZ]
GO
/****** Object:  Table [dbo].[ESTADOS]    Script Date: 7/01/2024 00:57:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ESTADOS](
	[ID_ESTADO] [int] NULL,
	[NOMBRE] [varchar](100) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PEDIDOS_CAB]    Script Date: 7/01/2024 00:57:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PEDIDOS_CAB](
	[ID_PEDIDO] [int] NULL,
	[NRO_PEDIDO] [varchar](10) NULL,
	[FECHA_PEDIDO] [datetime] NULL,
	[FECHA_RECEPCION] [datetime] NULL,
	[FECHA_DESPACHO] [datetime] NULL,
	[FECHA_ENTREGA] [datetime] NULL,
	[ID_VENDEDOR] [int] NULL,
	[ID_ESTADO] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PEDIDOS_DET]    Script Date: 7/01/2024 00:57:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PEDIDOS_DET](
	[ID_PEDIDO_DET] [int] NULL,
	[ID_PEDIDO] [int] NULL,
	[ID_PRODUCTO] [int] NULL,
	[PRECIO] [decimal](18, 2) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PRODUCTOS]    Script Date: 7/01/2024 00:57:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PRODUCTOS](
	[ID_PRODUCTO] [int] NULL,
	[SKU] [varchar](15) NULL,
	[NOMBRE] [varchar](1000) NULL,
	[TIPO] [varchar](300) NULL,
	[ETIQUETAS] [varchar](max) NULL,
	[PRECIO] [decimal](18, 2) NULL,
	[UNI_MEDIDA] [varchar](300) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ROLES]    Script Date: 7/01/2024 00:57:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ROLES](
	[ID_ROL] [int] NULL,
	[DESCRIPCION] [varchar](300) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[USUARIOS]    Script Date: 7/01/2024 00:57:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[USUARIOS](
	[COD_TRABAJADOR] [varchar](8) NULL,
	[NOMBRE] [varchar](100) NULL,
	[CORREO] [varchar](100) NULL,
	[TELEFONO] [varchar](12) NULL,
	[PUESTO] [varchar](200) NULL,
	[ID_ROL] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[SP_GET_PEDIDOS]    Script Date: 7/01/2024 00:57:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--exec SP_GET_PEDIDOS 1
CREATE PROCEDURE [dbo].[SP_GET_PEDIDOS]
    @ID_PEDIDO INT
AS
BEGIN
    SELECT CAB.* ,EST.NOMBRE AS ESTADO
    FROM PEDIDOS_CAB CAB
	INNER JOIN ESTADOS EST ON EST.ID_ESTADO = CAB.ID_ESTADO
    WHERE CAB.ID_PEDIDO = @ID_PEDIDO
END;
GO
/****** Object:  StoredProcedure [dbo].[SP_GET_PEDIDOS_DET]    Script Date: 7/01/2024 00:57:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--exec SP_GET_PEDIDOS 1
CREATE PROCEDURE [dbo].[SP_GET_PEDIDOS_DET]
    @ID_PEDIDO INT
AS
BEGIN
SELECT DET.ID_PEDIDO , DET.ID_PEDIDO_DET  , PRO.NOMBRE , PRO.SKU , PRO.TIPO , PRO.PRECIO , PRO.UNI_MEDIDA FROM PEDIDOS_DET DET
INNER JOIN PEDIDOS_CAB PE ON PE.ID_PEDIDO = DET.ID_PEDIDO
INNER JOIN PRODUCTOS PRO ON PRO.ID_PRODUCTO = DET.ID_PRODUCTO
WHERE PE.ID_PEDIDO = @ID_PEDIDO
END;
GO
/****** Object:  StoredProcedure [dbo].[SP_GET_USUARIO]    Script Date: 7/01/2024 00:57:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_GET_USUARIO]  
@usuario VARCHAR(30),  
@contrasenia VARCHAR(30)  
AS  
  
SELECT 
COD_TRABAJADOR,	
NOMBRE,	
CORREO,	
TELEFONO,	
PUESTO,	
ID_ROL 

FROM USUARIOS WHERE CORREO = @usuario and  COD_TRABAJADOR = @contrasenia

GO
/****** Object:  StoredProcedure [dbo].[SP_LISTAR_PEDIDOS]    Script Date: 7/01/2024 00:57:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_LISTAR_PEDIDOS]
    @NRO_PEDIDO VARCHAR(15) = ''
AS
BEGIN
    SELECT CAB.* , EST.NOMBRE AS ESTADO
    FROM PEDIDOS_CAB CAB
	INNER JOIN ESTADOS EST ON EST.ID_ESTADO = CAB.ID_ESTADO
    WHERE (@NRO_PEDIDO IS NULL OR CAB.NRO_PEDIDO  LIKE '%' + @NRO_PEDIDO + '%' )
END;
GO
/****** Object:  StoredProcedure [dbo].[SP_LISTAR_PRODUCTOS]    Script Date: 7/01/2024 00:57:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_LISTAR_PRODUCTOS]
    @SKU VARCHAR(15) = '',
    @NOMBRE VARCHAR(500) = ''
AS
BEGIN
    SELECT *
    FROM PRODUCTOS
    WHERE (@SKU IS NULL OR SKU  LIKE '%' + @SKU + '%' )
      AND (@NOMBRE IS NULL OR NOMBRE LIKE '%' + @NOMBRE + '%');
END;
GO
/****** Object:  StoredProcedure [dbo].[SP_LISTAR_USUARIOS]    Script Date: 7/01/2024 00:57:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[SP_LISTAR_USUARIOS] 
@ID_ROL int 
as


select * from USUARIOS where (ID_ROL = @ID_ROL OR @ID_ROL = 0)
GO
/****** Object:  StoredProcedure [dbo].[USP_INS_PEDIDO_CAB]    Script Date: 7/01/2024 00:57:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[USP_INS_PEDIDO_CAB]
@ACCION INT,
@FECHA VARCHAR(8) = '',
@ID_VENDEDOR INT = 0,
@ID_ESTADO INT ,
@ID_PEDIDO INT ,
@ID_RESULT iNT output
AS



IF (@ACCION = 1)
BEGIN 

  SELECT @ID_PEDIDO = ISNULL(MAX(ID_PEDIDO), 0) + 1 FROM PEDIDOS_CAB;

  DECLARE @NRO_PEDIDO VARCHAR(10) = RIGHT('00000000' + CAST(@ID_PEDIDO AS VARCHAR(8)), 8);

  insert into PEDIDOS_CAB values (@ID_PEDIDO,@NRO_PEDIDO,GETDATE(),NULL,NULL,NULL,@ID_VENDEDOR,1)



END


IF (@ACCION = 2)
BEGIN 

			IF @ID_ESTADO = 1
			BEGIN
				UPDATE PEDIDOS_CAB
				SET FECHA_PEDIDO = GETDATE(),
				ID_ESTADO = @ID_ESTADO
				WHERE ID_PEDIDO = @ID_PEDIDO;

			END
			ELSE IF @ID_ESTADO = 2
			BEGIN
				-- Actualizar con una fecha específica si el ID es 2
				UPDATE PEDIDOS_CAB
				SET FECHA_RECEPCION = GETDATE(),
				ID_ESTADO = @ID_ESTADO
				WHERE ID_PEDIDO = @ID_PEDIDO;
			END
  			ELSE IF @ID_ESTADO = 3
			BEGIN
				UPDATE PEDIDOS_CAB
				SET FECHA_DESPACHO = GETDATE(),
				ID_ESTADO = @ID_ESTADO
				WHERE ID_PEDIDO = @ID_PEDIDO;
			END   
  			ELSE IF @ID_ESTADO = 4
			BEGIN
				UPDATE PEDIDOS_CAB
				SET FECHA_ENTREGA = GETDATE(),
				ID_ESTADO = @ID_ESTADO
				WHERE ID_PEDIDO = @ID_PEDIDO;
			END  

END


set @ID_RESULT = @ID_PEDIDO
GO
/****** Object:  StoredProcedure [dbo].[USP_INS_PEDIDO_DET]    Script Date: 7/01/2024 00:57:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[USP_INS_PEDIDO_DET]  
@ACCION INT,  
@ID_PRODUCTO INT = 0,  
@ID_PEDIDO INT ,  
@ID_PEDIDO_DET INT ,  
@ID_RESULT iNT output  
AS  
  
DECLARE @PRECIO DECIMAL(18,2)  
  
IF (@ACCION = 1)  
BEGIN   
  
  SELECT @ID_PEDIDO_DET = ISNULL(MAX(ID_PEDIDO_DET), 0) + 1 FROM PEDIDOS_DET;  
  SELECT @PRECIO = PRECIO FROM PRODUCTOS WHERE ID_PRODUCTO = @ID_PRODUCTO;  
  
  insert into PEDIDOS_DET values (@ID_PEDIDO_DET,@ID_PEDIDO,@ID_PRODUCTO,@PRECIO)  
  
  
  
END  
  
  
IF (@ACCION = 2)  
BEGIN   
  
 SELECT @ID_PEDIDO_DET  
  
END  
  
IF (@ACCION = 3)  
BEGIN   
  
 DELETE FROM PEDIDOS_DET WHERE ID_PEDIDO_DET = @ID_PEDIDO_DET  
  
END  
  
set @ID_RESULT = @ID_PEDIDO_DET
GO
USE [master]
GO
ALTER DATABASE [XYZ] SET  READ_WRITE 
GO
