USE [master]
GO
/****** Object:  Database [StockManagementSystemDB]    Script Date: 28-Apr-19 11:21:18 PM ******/
CREATE DATABASE [StockManagementSystemDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'StockManagementSystemDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\StockManagementSystemDB.mdf' , SIZE = 3136KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'StockManagementSystemDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\StockManagementSystemDB_log.ldf' , SIZE = 832KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [StockManagementSystemDB] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [StockManagementSystemDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [StockManagementSystemDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [StockManagementSystemDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [StockManagementSystemDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [StockManagementSystemDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [StockManagementSystemDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [StockManagementSystemDB] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [StockManagementSystemDB] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [StockManagementSystemDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [StockManagementSystemDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [StockManagementSystemDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [StockManagementSystemDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [StockManagementSystemDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [StockManagementSystemDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [StockManagementSystemDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [StockManagementSystemDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [StockManagementSystemDB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [StockManagementSystemDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [StockManagementSystemDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [StockManagementSystemDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [StockManagementSystemDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [StockManagementSystemDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [StockManagementSystemDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [StockManagementSystemDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [StockManagementSystemDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [StockManagementSystemDB] SET  MULTI_USER 
GO
ALTER DATABASE [StockManagementSystemDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [StockManagementSystemDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [StockManagementSystemDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [StockManagementSystemDB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [StockManagementSystemDB]
GO
/****** Object:  StoredProcedure [dbo].[SelectAllItemByCategoryId]    Script Date: 28-Apr-19 11:21:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SelectAllItemByCategoryId] @CategoryId int

AS

SELECT 

i.ItemName,
c.Company,
i.AvailableQuantity,
i.ReorderLevel

FROM Item AS i
INNER JOIN Company AS c
ON i.CompanyID=c.CompanyID
WHERE i.CategoryID=@CategoryId
GO
/****** Object:  StoredProcedure [dbo].[SelectAllItemByCompanyId]    Script Date: 28-Apr-19 11:21:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SelectAllItemByCompanyId] @CompanyId int

AS

SELECT 

i.ItemName,
c.Company,
i.AvailableQuantity,
i.ReorderLevel

FROM Item AS i
INNER JOIN Company AS c
ON i.CompanyID=c.CompanyID
WHERE i.CompanyId=@CompanyId
GO
/****** Object:  StoredProcedure [dbo].[SelectAllItemByCompanyIdandCategoryId]    Script Date: 28-Apr-19 11:21:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SelectAllItemByCompanyIdandCategoryId] @CompanyId int,@CategoryId int

AS

SELECT 

i.ItemName,
c.Company,
i.AvailableQuantity,
i.ReorderLevel

FROM Item AS i
INNER JOIN Company AS c
ON i.CompanyID=c.CompanyID
WHERE i.CompanyId=@CompanyId AND i.CategoryID=@CategoryId
GO
/****** Object:  Table [dbo].[Administrator]    Script Date: 28-Apr-19 11:21:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Administrator](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [varchar](50) NOT NULL,
	[Username] [varchar](50) NOT NULL,
	[Password] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Administrator] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Cart]    Script Date: 28-Apr-19 11:21:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Cart](
	[ItemID] [int] NOT NULL,
	[ItemName] [varchar](50) NOT NULL,
	[CompanyID] [int] NOT NULL,
	[CompanyName] [varchar](50) NOT NULL,
	[Quantity] [int] NOT NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Category]    Script Date: 28-Apr-19 11:21:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Category](
	[CategoryID] [int] IDENTITY(1,1) NOT NULL,
	[Category] [varchar](30) NOT NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[CategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Company]    Script Date: 28-Apr-19 11:21:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Company](
	[CompanyID] [int] IDENTITY(1,1) NOT NULL,
	[Company] [varchar](30) NOT NULL,
 CONSTRAINT [PK_Company] PRIMARY KEY CLUSTERED 
(
	[CompanyID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Item]    Script Date: 28-Apr-19 11:21:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Item](
	[ItemID] [int] IDENTITY(1,1) NOT NULL,
	[ItemName] [varchar](50) NOT NULL,
	[ReorderLevel] [int] NOT NULL,
	[CategoryID] [int] NOT NULL,
	[CompanyID] [int] NOT NULL,
	[AvailableQuantity] [int] NULL,
 CONSTRAINT [PK_Item] PRIMARY KEY CLUSTERED 
(
	[ItemID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[StockOut]    Script Date: 28-Apr-19 11:21:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[StockOut](
	[StockOutID] [int] IDENTITY(1,1) NOT NULL,
	[CompanyName] [varchar](50) NOT NULL,
	[ItemName] [varchar](50) NOT NULL,
	[Quantity] [int] NOT NULL,
	[Status] [varchar](50) NOT NULL,
	[Date] [date] NULL,
 CONSTRAINT [PK_StockOut] PRIMARY KEY CLUSTERED 
(
	[StockOutID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[User]    Script Date: 28-Apr-19 11:21:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[User](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [varchar](50) NOT NULL,
	[Username] [varchar](50) NOT NULL,
	[Password] [varchar](50) NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Administrator] ON 

INSERT [dbo].[Administrator] ([UserID], [FullName], [Username], [Password]) VALUES (1, N'Abdullah Al Tajbir', N'tajbir', N'01681650106')
INSERT [dbo].[Administrator] ([UserID], [FullName], [Username], [Password]) VALUES (2, N'Hasan', N'hasan', N'01850179564')
SET IDENTITY_INSERT [dbo].[Administrator] OFF
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([CategoryID], [Category]) VALUES (106, N'Biscuit')
INSERT [dbo].[Category] ([CategoryID], [Category]) VALUES (104, N'Chanachur')
INSERT [dbo].[Category] ([CategoryID], [Category]) VALUES (108, N'Chips')
INSERT [dbo].[Category] ([CategoryID], [Category]) VALUES (105, N'Icecreame')
INSERT [dbo].[Category] ([CategoryID], [Category]) VALUES (107, N'Jhal Moshla')
INSERT [dbo].[Category] ([CategoryID], [Category]) VALUES (103, N'Juice')
SET IDENTITY_INSERT [dbo].[Category] OFF
SET IDENTITY_INSERT [dbo].[Company] ON 

INSERT [dbo].[Company] ([CompanyID], [Company]) VALUES (41, N'Al-Amin')
INSERT [dbo].[Company] ([CompanyID], [Company]) VALUES (40, N'Bd')
INSERT [dbo].[Company] ([CompanyID], [Company]) VALUES (38, N'Pran')
INSERT [dbo].[Company] ([CompanyID], [Company]) VALUES (42, N'Rfl')
INSERT [dbo].[Company] ([CompanyID], [Company]) VALUES (39, N'Ruchi')
INSERT [dbo].[Company] ([CompanyID], [Company]) VALUES (43, N'Samsung')
SET IDENTITY_INSERT [dbo].[Company] OFF
SET IDENTITY_INSERT [dbo].[Item] ON 

INSERT [dbo].[Item] ([ItemID], [ItemName], [ReorderLevel], [CategoryID], [CompanyID], [AvailableQuantity]) VALUES (38, N'Toast', 0, 106, 38, 30)
INSERT [dbo].[Item] ([ItemID], [ItemName], [ReorderLevel], [CategoryID], [CompanyID], [AvailableQuantity]) VALUES (39, N'Spicy Biscuit', 10, 106, 38, 45)
INSERT [dbo].[Item] ([ItemID], [ItemName], [ReorderLevel], [CategoryID], [CompanyID], [AvailableQuantity]) VALUES (40, N'Mango', 0, 103, 38, 100)
INSERT [dbo].[Item] ([ItemID], [ItemName], [ReorderLevel], [CategoryID], [CompanyID], [AvailableQuantity]) VALUES (41, N'Orange', 20, 103, 38, 90)
INSERT [dbo].[Item] ([ItemID], [ItemName], [ReorderLevel], [CategoryID], [CompanyID], [AvailableQuantity]) VALUES (42, N'Jhal', 10, 104, 41, 70)
INSERT [dbo].[Item] ([ItemID], [ItemName], [ReorderLevel], [CategoryID], [CompanyID], [AvailableQuantity]) VALUES (43, N'BBQ', 0, 104, 40, 100)
INSERT [dbo].[Item] ([ItemID], [ItemName], [ReorderLevel], [CategoryID], [CompanyID], [AvailableQuantity]) VALUES (44, N'Chocbar', 12, 105, 41, 35)
INSERT [dbo].[Item] ([ItemID], [ItemName], [ReorderLevel], [CategoryID], [CompanyID], [AvailableQuantity]) VALUES (45, N'moricher Gura', 10, 107, 40, 0)
INSERT [dbo].[Item] ([ItemID], [ItemName], [ReorderLevel], [CategoryID], [CompanyID], [AvailableQuantity]) VALUES (46, N'Chicken Crespy Chips', 20, 108, 38, 50)
SET IDENTITY_INSERT [dbo].[Item] OFF
SET IDENTITY_INSERT [dbo].[StockOut] ON 

INSERT [dbo].[StockOut] ([StockOutID], [CompanyName], [ItemName], [Quantity], [Status], [Date]) VALUES (4, N'Al-Amin', N'Chocbar', 30, N'Sold', CAST(0xF93E0B00 AS Date))
INSERT [dbo].[StockOut] ([StockOutID], [CompanyName], [ItemName], [Quantity], [Status], [Date]) VALUES (5, N'Bd', N'BBQ', 100, N'Sold', CAST(0xFA3E0B00 AS Date))
INSERT [dbo].[StockOut] ([StockOutID], [CompanyName], [ItemName], [Quantity], [Status], [Date]) VALUES (6, N'Pran', N'Orange', 100, N'Sold', CAST(0xFB3E0B00 AS Date))
INSERT [dbo].[StockOut] ([StockOutID], [CompanyName], [ItemName], [Quantity], [Status], [Date]) VALUES (7, N'Pran', N'Spicy Biscuit', 50, N'Lost', CAST(0xFC3E0B00 AS Date))
INSERT [dbo].[StockOut] ([StockOutID], [CompanyName], [ItemName], [Quantity], [Status], [Date]) VALUES (8, N'Pran', N'Spicy Biscuit', 30, N'Damage', CAST(0xFE3E0B00 AS Date))
INSERT [dbo].[StockOut] ([StockOutID], [CompanyName], [ItemName], [Quantity], [Status], [Date]) VALUES (9, N'Pran', N'Orange', 10, N'Sold', CAST(0xFF3E0B00 AS Date))
INSERT [dbo].[StockOut] ([StockOutID], [CompanyName], [ItemName], [Quantity], [Status], [Date]) VALUES (10, N'Al-Amin', N'Chocbar', 10, N'Sold', CAST(0x003F0B00 AS Date))
INSERT [dbo].[StockOut] ([StockOutID], [CompanyName], [ItemName], [Quantity], [Status], [Date]) VALUES (11, N'Al-Amin', N'Jhal', 30, N'Sold', CAST(0x1F3F0B00 AS Date))
INSERT [dbo].[StockOut] ([StockOutID], [CompanyName], [ItemName], [Quantity], [Status], [Date]) VALUES (12, N'Pran', N'Chicken Crespy Chips', 100, N'Sold', CAST(0x5A3F0B00 AS Date))
SET IDENTITY_INSERT [dbo].[StockOut] OFF
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([UserID], [FullName], [Username], [Password]) VALUES (1, N'Abdullah Al Tajbir', N'tajbir', N'01681650106')
SET IDENTITY_INSERT [dbo].[User] OFF
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Administrator]    Script Date: 28-Apr-19 11:21:19 PM ******/
ALTER TABLE [dbo].[Administrator] ADD  CONSTRAINT [IX_Administrator] UNIQUE NONCLUSTERED 
(
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Category]    Script Date: 28-Apr-19 11:21:19 PM ******/
ALTER TABLE [dbo].[Category] ADD  CONSTRAINT [IX_Category] UNIQUE NONCLUSTERED 
(
	[Category] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Company]    Script Date: 28-Apr-19 11:21:19 PM ******/
ALTER TABLE [dbo].[Company] ADD  CONSTRAINT [IX_Company] UNIQUE NONCLUSTERED 
(
	[Company] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_User]    Script Date: 28-Apr-19 11:21:19 PM ******/
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [IX_User] UNIQUE NONCLUSTERED 
(
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Category]  WITH CHECK ADD  CONSTRAINT [FK_Category_Category] FOREIGN KEY([CategoryID])
REFERENCES [dbo].[Category] ([CategoryID])
GO
ALTER TABLE [dbo].[Category] CHECK CONSTRAINT [FK_Category_Category]
GO
ALTER TABLE [dbo].[Item]  WITH CHECK ADD  CONSTRAINT [FK_Item_Category1] FOREIGN KEY([CategoryID])
REFERENCES [dbo].[Category] ([CategoryID])
GO
ALTER TABLE [dbo].[Item] CHECK CONSTRAINT [FK_Item_Category1]
GO
ALTER TABLE [dbo].[Item]  WITH CHECK ADD  CONSTRAINT [FK_Item_Company1] FOREIGN KEY([CompanyID])
REFERENCES [dbo].[Company] ([CompanyID])
GO
ALTER TABLE [dbo].[Item] CHECK CONSTRAINT [FK_Item_Company1]
GO
USE [master]
GO
ALTER DATABASE [StockManagementSystemDB] SET  READ_WRITE 
GO
