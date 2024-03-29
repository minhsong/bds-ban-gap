USE [master]
GO
/****** Object:  Database [VMQDB]    Script Date: 07/28/2013 11:16:20 ******/
CREATE DATABASE [VMQDB] ON  PRIMARY 
( NAME = N'VMQDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\VMQDB.mdf' , SIZE = 2304KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'VMQDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\VMQDB_log.LDF' , SIZE = 504KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [VMQDB] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [VMQDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [VMQDB] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [VMQDB] SET ANSI_NULLS OFF
GO
ALTER DATABASE [VMQDB] SET ANSI_PADDING OFF
GO
ALTER DATABASE [VMQDB] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [VMQDB] SET ARITHABORT OFF
GO
ALTER DATABASE [VMQDB] SET AUTO_CLOSE ON
GO
ALTER DATABASE [VMQDB] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [VMQDB] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [VMQDB] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [VMQDB] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [VMQDB] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [VMQDB] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [VMQDB] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [VMQDB] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [VMQDB] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [VMQDB] SET  ENABLE_BROKER
GO
ALTER DATABASE [VMQDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [VMQDB] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [VMQDB] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [VMQDB] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [VMQDB] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [VMQDB] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [VMQDB] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [VMQDB] SET  READ_WRITE
GO
ALTER DATABASE [VMQDB] SET RECOVERY SIMPLE
GO
ALTER DATABASE [VMQDB] SET  MULTI_USER
GO
ALTER DATABASE [VMQDB] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [VMQDB] SET DB_CHAINING OFF
GO
USE [VMQDB]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 07/28/2013 11:16:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[RoleID] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](max) NULL,
	[Descriptoin] [nvarchar](max) NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[CreatedDate] [datetime] NULL,
	[UpdatedBy] [nvarchar](50) NULL,
	[UpdatedDate] [datetime] NULL,
 CONSTRAINT [PK_dbo.Roles] PRIMARY KEY CLUSTERED 
(
	[RoleID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Roles] ON
INSERT [dbo].[Roles] ([RoleID], [RoleName], [Descriptoin], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate]) VALUES (1, N'Administrator', NULL, N'System', CAST(0x0000A20801704F0B AS DateTime), N'System', CAST(0x0000A20801704F0B AS DateTime))
SET IDENTITY_INSERT [dbo].[Roles] OFF
/****** Object:  Table [dbo].[ProductTypes]    Script Date: 07/28/2013 11:16:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[CreatedDate] [datetime] NULL,
	[UpdatedBy] [nvarchar](50) NULL,
	[UpdatedDate] [datetime] NULL,
 CONSTRAINT [PK_dbo.ProductTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Posts]    Script Date: 07/28/2013 11:16:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Posts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](max) NULL,
	[Image] [nvarchar](max) NULL,
	[Conclusion] [nvarchar](max) NULL,
	[Body] [nvarchar](max) NULL,
	[CategoryId] [int] NOT NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[CreatedDate] [datetime] NULL,
	[UpdatedBy] [nvarchar](50) NULL,
	[UpdatedDate] [datetime] NULL,
 CONSTRAINT [PK_dbo.Posts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 07/28/2013 11:16:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Type] [nvarchar](max) NULL,
	[Name] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[CreatedDate] [datetime] NULL,
	[UpdatedBy] [nvarchar](50) NULL,
	[UpdatedDate] [datetime] NULL,
 CONSTRAINT [PK_dbo.Categories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Categories] ON
INSERT [dbo].[Categories] ([Id], [Type], [Name], [Description], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate]) VALUES (1, N'post', N'Post', NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Categories] OFF
/****** Object:  Table [dbo].[Accounts]    Script Date: 07/28/2013 11:16:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Accounts](
	[Username] [nvarchar](20) NOT NULL,
	[Password] [nvarchar](max) NULL,
	[FullName] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[Phone] [nvarchar](max) NULL,
	[Address] [nvarchar](max) NULL,
	[RoleID] [int] NOT NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[CreatedDate] [datetime] NULL,
	[UpdatedBy] [nvarchar](50) NULL,
	[UpdatedDate] [datetime] NULL,
 CONSTRAINT [PK_dbo.Accounts] PRIMARY KEY CLUSTERED 
(
	[Username] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_RoleID] ON [dbo].[Accounts] 
(
	[RoleID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
INSERT [dbo].[Accounts] ([Username], [Password], [FullName], [Email], [Phone], [Address], [RoleID], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate]) VALUES (N'Admin', N'12345', N'Minh Song', N'truongminhsong@gmail.com', N'0938505866', N'14 Hoa Su, p7 , Phu Nhuan', 1, N'System', CAST(0x0000A20801704FF5 AS DateTime), N'System', CAST(0x0000A20801704FF5 AS DateTime))
/****** Object:  Table [dbo].[Products]    Script Date: 07/28/2013 11:16:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](max) NULL,
	[HostName] [nvarchar](max) NULL,
	[Address] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[Year] [int] NOT NULL,
	[TypeId] [int] NOT NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[CreatedDate] [datetime] NULL,
	[UpdatedBy] [nvarchar](50) NULL,
	[UpdatedDate] [datetime] NULL,
 CONSTRAINT [PK_dbo.Products] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_TypeId] ON [dbo].[Products] 
(
	[TypeId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductImages]    Script Date: 07/28/2013 11:16:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductImages](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Link] [nvarchar](max) NULL,
	[ThumbLink] [nvarchar](max) NULL,
	[Caption] [nvarchar](max) NULL,
	[ProductId] [int] NOT NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[CreatedDate] [datetime] NULL,
	[UpdatedBy] [nvarchar](50) NULL,
	[UpdatedDate] [datetime] NULL,
 CONSTRAINT [PK_dbo.ProductImages] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_ProductId] ON [dbo].[ProductImages] 
(
	[ProductId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  ForeignKey [FK_dbo.Accounts_dbo.Roles_RoleID]    Script Date: 07/28/2013 11:16:21 ******/
ALTER TABLE [dbo].[Accounts]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Accounts_dbo.Roles_RoleID] FOREIGN KEY([RoleID])
REFERENCES [dbo].[Roles] ([RoleID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Accounts] CHECK CONSTRAINT [FK_dbo.Accounts_dbo.Roles_RoleID]
GO
/****** Object:  ForeignKey [FK_dbo.Products_dbo.ProductTypes_TypeId]    Script Date: 07/28/2013 11:16:21 ******/
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Products_dbo.ProductTypes_TypeId] FOREIGN KEY([TypeId])
REFERENCES [dbo].[ProductTypes] ([Id])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_dbo.Products_dbo.ProductTypes_TypeId]
GO
/****** Object:  ForeignKey [FK_dbo.ProductImages_dbo.Products_ProductId]    Script Date: 07/28/2013 11:16:21 ******/
ALTER TABLE [dbo].[ProductImages]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ProductImages_dbo.Products_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProductImages] CHECK CONSTRAINT [FK_dbo.ProductImages_dbo.Products_ProductId]
GO
