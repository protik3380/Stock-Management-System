USE [master]
GO
/****** Object:  Database [Stock_DB]    Script Date: 12-Aug-18 10:31:38 PM ******/
CREATE DATABASE [Stock_DB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Stock_DB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\Stock_DB.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Stock_DB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\Stock_DB_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Stock_DB] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Stock_DB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Stock_DB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Stock_DB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Stock_DB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Stock_DB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Stock_DB] SET ARITHABORT OFF 
GO
ALTER DATABASE [Stock_DB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Stock_DB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Stock_DB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Stock_DB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Stock_DB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Stock_DB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Stock_DB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Stock_DB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Stock_DB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Stock_DB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Stock_DB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Stock_DB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Stock_DB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Stock_DB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Stock_DB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Stock_DB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Stock_DB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Stock_DB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Stock_DB] SET  MULTI_USER 
GO
ALTER DATABASE [Stock_DB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Stock_DB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Stock_DB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Stock_DB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [Stock_DB] SET DELAYED_DURABILITY = DISABLED 
GO
USE [Stock_DB]
GO
/****** Object:  Table [dbo].[Category_tbl]    Script Date: 12-Aug-18 10:31:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Category_tbl](
	[Category_Id] [int] IDENTITY(1,1) NOT NULL,
	[Category_Name] [varchar](50) NULL,
 CONSTRAINT [PK_Category_tbl] PRIMARY KEY CLUSTERED 
(
	[Category_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Company_tbl]    Script Date: 12-Aug-18 10:31:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Company_tbl](
	[Company_Id] [int] IDENTITY(1,1) NOT NULL,
	[Company_Name] [varchar](50) NULL,
 CONSTRAINT [PK_Company_tbl] PRIMARY KEY CLUSTERED 
(
	[Company_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Item_tbl]    Script Date: 12-Aug-18 10:31:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Item_tbl](
	[Item_Id] [int] IDENTITY(1,1) NOT NULL,
	[Category_Id] [int] NULL,
	[Company_Id] [int] NULL,
	[Item_Name] [varchar](50) NULL,
	[Reorder] [int] NULL,
	[Available_Quantity] [int] NULL,
 CONSTRAINT [PK_Items_tbl] PRIMARY KEY CLUSTERED 
(
	[Item_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Stock_tbl]    Script Date: 12-Aug-18 10:31:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Stock_tbl](
	[StockOut_id] [int] IDENTITY(1,1) NOT NULL,
	[Company_Name] [varchar](50) NULL,
	[Item_Name] [varchar](50) NULL,
	[Quantity] [int] NULL,
	[Item_Id] [int] NULL,
 CONSTRAINT [PK_Stock_tbl] PRIMARY KEY CLUSTERED 
(
	[StockOut_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[StockOut_tbl]    Script Date: 12-Aug-18 10:31:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[StockOut_tbl](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Item_Id] [int] NULL,
	[Item_Name] [varchar](50) NULL,
	[Company_Name] [varchar](50) NULL,
	[Quantity] [int] NULL,
	[Date] [date] NULL,
	[StockOut_type] [varchar](50) NULL,
 CONSTRAINT [PK_StockOut_tbl] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Category_tbl] ON 

INSERT [dbo].[Category_tbl] ([Category_Id], [Category_Name]) VALUES (9, N'hardware')
INSERT [dbo].[Category_tbl] ([Category_Id], [Category_Name]) VALUES (10, N'software')
INSERT [dbo].[Category_tbl] ([Category_Id], [Category_Name]) VALUES (11, N'computer')
INSERT [dbo].[Category_tbl] ([Category_Id], [Category_Name]) VALUES (12, N'Mobile')
INSERT [dbo].[Category_tbl] ([Category_Id], [Category_Name]) VALUES (13, N'Accesories')
INSERT [dbo].[Category_tbl] ([Category_Id], [Category_Name]) VALUES (14, N'Game')
INSERT [dbo].[Category_tbl] ([Category_Id], [Category_Name]) VALUES (15, N'Other field')
SET IDENTITY_INSERT [dbo].[Category_tbl] OFF
SET IDENTITY_INSERT [dbo].[Company_tbl] ON 

INSERT [dbo].[Company_tbl] ([Company_Id], [Company_Name]) VALUES (1005, N'A4tech')
INSERT [dbo].[Company_tbl] ([Company_Id], [Company_Name]) VALUES (1006, N'Dell')
INSERT [dbo].[Company_tbl] ([Company_Id], [Company_Name]) VALUES (1007, N'Hp')
INSERT [dbo].[Company_tbl] ([Company_Id], [Company_Name]) VALUES (1008, N'EA Sports')
INSERT [dbo].[Company_tbl] ([Company_Id], [Company_Name]) VALUES (1009, N'Robotics BD')
INSERT [dbo].[Company_tbl] ([Company_Id], [Company_Name]) VALUES (1010, N'BD Soft')
INSERT [dbo].[Company_tbl] ([Company_Id], [Company_Name]) VALUES (1011, N'It Next')
INSERT [dbo].[Company_tbl] ([Company_Id], [Company_Name]) VALUES (1012, N'Nokia')
INSERT [dbo].[Company_tbl] ([Company_Id], [Company_Name]) VALUES (1013, N'Game Lock')
INSERT [dbo].[Company_tbl] ([Company_Id], [Company_Name]) VALUES (1014, N'Intel')
INSERT [dbo].[Company_tbl] ([Company_Id], [Company_Name]) VALUES (1015, N'samgsung')
SET IDENTITY_INSERT [dbo].[Company_tbl] OFF
SET IDENTITY_INSERT [dbo].[Item_tbl] ON 

INSERT [dbo].[Item_tbl] ([Item_Id], [Category_Id], [Company_Id], [Item_Name], [Reorder], [Available_Quantity]) VALUES (1016, 9, 1014, N'Processor', 0, 9)
INSERT [dbo].[Item_tbl] ([Item_Id], [Category_Id], [Company_Id], [Item_Name], [Reorder], [Available_Quantity]) VALUES (1017, 9, 1014, N'Motherboard', 0, 0)
INSERT [dbo].[Item_tbl] ([Item_Id], [Category_Id], [Company_Id], [Item_Name], [Reorder], [Available_Quantity]) VALUES (1018, 9, 1014, N'RAM', 10, 0)
INSERT [dbo].[Item_tbl] ([Item_Id], [Category_Id], [Company_Id], [Item_Name], [Reorder], [Available_Quantity]) VALUES (1019, 10, 1013, N'GTA vice city', 9, 0)
INSERT [dbo].[Item_tbl] ([Item_Id], [Category_Id], [Company_Id], [Item_Name], [Reorder], [Available_Quantity]) VALUES (1020, 11, 1005, N'keyboard', 111, 35)
INSERT [dbo].[Item_tbl] ([Item_Id], [Category_Id], [Company_Id], [Item_Name], [Reorder], [Available_Quantity]) VALUES (1021, 11, 1005, N'mouse', 0, 10)
INSERT [dbo].[Item_tbl] ([Item_Id], [Category_Id], [Company_Id], [Item_Name], [Reorder], [Available_Quantity]) VALUES (1022, 11, 1005, N'pendrive', 0, 285)
INSERT [dbo].[Item_tbl] ([Item_Id], [Category_Id], [Company_Id], [Item_Name], [Reorder], [Available_Quantity]) VALUES (1023, 12, 1012, N'nkia 1100', 0, 0)
INSERT [dbo].[Item_tbl] ([Item_Id], [Category_Id], [Company_Id], [Item_Name], [Reorder], [Available_Quantity]) VALUES (1024, 12, 1012, N'105', 0, 0)
INSERT [dbo].[Item_tbl] ([Item_Id], [Category_Id], [Company_Id], [Item_Name], [Reorder], [Available_Quantity]) VALUES (1025, 9, 1014, N'ROM', 0, 0)
INSERT [dbo].[Item_tbl] ([Item_Id], [Category_Id], [Company_Id], [Item_Name], [Reorder], [Available_Quantity]) VALUES (1026, 14, 1008, N'Cricket', 10, 2)
SET IDENTITY_INSERT [dbo].[Item_tbl] OFF
SET IDENTITY_INSERT [dbo].[StockOut_tbl] ON 

INSERT [dbo].[StockOut_tbl] ([Id], [Item_Id], [Item_Name], [Company_Name], [Quantity], [Date], [StockOut_type]) VALUES (6, 1020, N'keyboard', N'A4tech', 5, CAST(N'2001-01-01' AS Date), N'Sell')
INSERT [dbo].[StockOut_tbl] ([Id], [Item_Id], [Item_Name], [Company_Name], [Quantity], [Date], [StockOut_type]) VALUES (7, 1021, N'mouse', N'A4tech', 5, CAST(N'1900-01-01' AS Date), N'Sell')
INSERT [dbo].[StockOut_tbl] ([Id], [Item_Id], [Item_Name], [Company_Name], [Quantity], [Date], [StockOut_type]) VALUES (8, 1026, N'Cricket', N'EA Sports', 1, CAST(N'2001-01-01' AS Date), N'Sell')
SET IDENTITY_INSERT [dbo].[StockOut_tbl] OFF
ALTER TABLE [dbo].[Item_tbl]  WITH CHECK ADD  CONSTRAINT [FK_Item_tbl_Category_tbl] FOREIGN KEY([Category_Id])
REFERENCES [dbo].[Category_tbl] ([Category_Id])
GO
ALTER TABLE [dbo].[Item_tbl] CHECK CONSTRAINT [FK_Item_tbl_Category_tbl]
GO
ALTER TABLE [dbo].[Item_tbl]  WITH CHECK ADD  CONSTRAINT [FK_Item_tbl_Company_tbl] FOREIGN KEY([Company_Id])
REFERENCES [dbo].[Company_tbl] ([Company_Id])
GO
ALTER TABLE [dbo].[Item_tbl] CHECK CONSTRAINT [FK_Item_tbl_Company_tbl]
GO
USE [master]
GO
ALTER DATABASE [Stock_DB] SET  READ_WRITE 
GO
