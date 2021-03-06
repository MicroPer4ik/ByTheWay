USE [master]
GO
/****** Object:  Database [CleaningDb]    Script Date: 01.06.2022 11:11:57 ******/
CREATE DATABASE [CleaningDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CleaningDb', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\CleaningDb.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'CleaningDb_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\CleaningDb_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [CleaningDb] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CleaningDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CleaningDb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CleaningDb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CleaningDb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CleaningDb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CleaningDb] SET ARITHABORT OFF 
GO
ALTER DATABASE [CleaningDb] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CleaningDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CleaningDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CleaningDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CleaningDb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CleaningDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CleaningDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CleaningDb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CleaningDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CleaningDb] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CleaningDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CleaningDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CleaningDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CleaningDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CleaningDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CleaningDb] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CleaningDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CleaningDb] SET RECOVERY FULL 
GO
ALTER DATABASE [CleaningDb] SET  MULTI_USER 
GO
ALTER DATABASE [CleaningDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CleaningDb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CleaningDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CleaningDb] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [CleaningDb] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [CleaningDb] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'CleaningDb', N'ON'
GO
ALTER DATABASE [CleaningDb] SET QUERY_STORE = OFF
GO
USE [CleaningDb]
GO
/****** Object:  Table [dbo].[Blogs]    Script Date: 01.06.2022 11:11:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Blogs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdEmployee] [int] NOT NULL,
	[Blog] [nvarchar](500) NOT NULL,
	[DatePublish] [nvarchar](500) NOT NULL,
 CONSTRAINT [PK_Blogs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Clients]    Script Date: 01.06.2022 11:11:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clients](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Surname] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Patronymic] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[PhoneNumber] [nvarchar](50) NOT NULL,
	[Address] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Clients] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employees]    Script Date: 01.06.2022 11:11:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employees](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[IdStatus] [int] NOT NULL,
	[Surname] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Patronymic] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_UserId] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 01.06.2022 11:11:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PriceOrder] [decimal](18, 0) NULL,
	[DateSubmission] [date] NOT NULL,
	[DateBeginning] [date] NULL,
	[DateEnd] [date] NULL,
	[IdStatus] [int] NOT NULL,
	[EmployeeId] [int] NULL,
	[IdClient] [int] NOT NULL,
	[Description] [nvarchar](500) NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderService]    Script Date: 01.06.2022 11:11:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderService](
	[IdOrder] [int] NOT NULL,
	[IdService] [int] NOT NULL,
 CONSTRAINT [PK_OrderService] PRIMARY KEY CLUSTERED 
(
	[IdOrder] ASC,
	[IdService] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderStatus]    Script Date: 01.06.2022 11:11:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderStatus](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StatusName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_OrderStatus] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reviews]    Script Date: 01.06.2022 11:11:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reviews](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdClient] [int] NOT NULL,
	[ReviewText] [nvarchar](500) NOT NULL,
	[DatePublish] [date] NOT NULL,
 CONSTRAINT [PK_Reviews] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Services]    Script Date: 01.06.2022 11:11:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Services](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TitleService] [nvarchar](50) NOT NULL,
	[CostService] [decimal](18, 0) NOT NULL,
	[IdServiceType] [int] NOT NULL,
 CONSTRAINT [PK_Services] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ServiceTypes]    Script Date: 01.06.2022 11:11:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ServiceTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TypeTitle] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_ServiceTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StatusEmployees]    Script Date: 01.06.2022 11:11:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StatusEmployees](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_EmployeeStatuses] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Clients] ON 

INSERT [dbo].[Clients] ([Id], [Surname], [Name], [Patronymic], [Email], [PhoneNumber], [Address]) VALUES (1, N'Балякин', N'Данил', N'Андреевич', N'balyakin.danil19@gmail.com', N'+79022644585', N'ул. Сулимова 29 кв. 226')
INSERT [dbo].[Clients] ([Id], [Surname], [Name], [Patronymic], [Email], [PhoneNumber], [Address]) VALUES (2, N'Брагина', N'Елизaвета', N'Александровна', N'lizabrag11@gmail.com', N'+79527389202', N'ул. Заводская 45а кв. 47')
INSERT [dbo].[Clients] ([Id], [Surname], [Name], [Patronymic], [Email], [PhoneNumber], [Address]) VALUES (6, N'Балякин', N'Ярослав', N'Андреевич', N'Yarick2007@yandex.ru', N'+79193601786', N'Патруши, ул. Колхозная 2г')
INSERT [dbo].[Clients] ([Id], [Surname], [Name], [Patronymic], [Email], [PhoneNumber], [Address]) VALUES (11, N'123', N'123', N'213', N'123', N'123', N'123')
INSERT [dbo].[Clients] ([Id], [Surname], [Name], [Patronymic], [Email], [PhoneNumber], [Address]) VALUES (12, N'5555', N'5555', N'555', N'555', N'555', N'555')
INSERT [dbo].[Clients] ([Id], [Surname], [Name], [Patronymic], [Email], [PhoneNumber], [Address]) VALUES (13, N'555555555', N'555555555', N'555555555', N'5555555555', N'555555555555', N'555555555555')
INSERT [dbo].[Clients] ([Id], [Surname], [Name], [Patronymic], [Email], [PhoneNumber], [Address]) VALUES (14, N'11111111111', N'11111111111', N'11111111111', N'11111111111', N'11111111111', N'11111111111')
INSERT [dbo].[Clients] ([Id], [Surname], [Name], [Patronymic], [Email], [PhoneNumber], [Address]) VALUES (15, N'2', N'2', N'2', N'2', N'2', N'2')
SET IDENTITY_INSERT [dbo].[Clients] OFF
GO
SET IDENTITY_INSERT [dbo].[Orders] ON 

INSERT [dbo].[Orders] ([Id], [PriceOrder], [DateSubmission], [DateBeginning], [DateEnd], [IdStatus], [EmployeeId], [IdClient], [Description]) VALUES (1, CAST(0 AS Decimal(18, 0)), CAST(N'2022-06-01' AS Date), NULL, NULL, 1, NULL, 11, N'33333333333333333333333')
INSERT [dbo].[Orders] ([Id], [PriceOrder], [DateSubmission], [DateBeginning], [DateEnd], [IdStatus], [EmployeeId], [IdClient], [Description]) VALUES (2, CAST(0 AS Decimal(18, 0)), CAST(N'2022-06-01' AS Date), NULL, NULL, 1, NULL, 12, N'5555555555555555555555555')
INSERT [dbo].[Orders] ([Id], [PriceOrder], [DateSubmission], [DateBeginning], [DateEnd], [IdStatus], [EmployeeId], [IdClient], [Description]) VALUES (3, CAST(0 AS Decimal(18, 0)), CAST(N'2022-06-01' AS Date), NULL, NULL, 1, NULL, 13, N'11111111111111111111111111111')
INSERT [dbo].[Orders] ([Id], [PriceOrder], [DateSubmission], [DateBeginning], [DateEnd], [IdStatus], [EmployeeId], [IdClient], [Description]) VALUES (4, CAST(0 AS Decimal(18, 0)), CAST(N'2022-06-01' AS Date), NULL, NULL, 1, NULL, 14, N'11111111111')
INSERT [dbo].[Orders] ([Id], [PriceOrder], [DateSubmission], [DateBeginning], [DateEnd], [IdStatus], [EmployeeId], [IdClient], [Description]) VALUES (5, CAST(0 AS Decimal(18, 0)), CAST(N'2022-06-01' AS Date), NULL, NULL, 1, NULL, 15, N'2')
SET IDENTITY_INSERT [dbo].[Orders] OFF
GO
SET IDENTITY_INSERT [dbo].[OrderStatus] ON 

INSERT [dbo].[OrderStatus] ([Id], [StatusName]) VALUES (1, N'Новая')
INSERT [dbo].[OrderStatus] ([Id], [StatusName]) VALUES (2, N'В работе')
INSERT [dbo].[OrderStatus] ([Id], [StatusName]) VALUES (3, N'Выполнена')
SET IDENTITY_INSERT [dbo].[OrderStatus] OFF
GO
SET IDENTITY_INSERT [dbo].[Services] ON 

INSERT [dbo].[Services] ([Id], [TitleService], [CostService], [IdServiceType]) VALUES (1, N'ГЕНЕРАЛЬНАЯ УБОРКА ПОМЕЩЕНИЙ ', CAST(90 AS Decimal(18, 0)), 1)
INSERT [dbo].[Services] ([Id], [TitleService], [CostService], [IdServiceType]) VALUES (3, N'УБОРКА КВАРТИР', CAST(120 AS Decimal(18, 0)), 1)
INSERT [dbo].[Services] ([Id], [TitleService], [CostService], [IdServiceType]) VALUES (4, N'УБОРКА КОТТЕДЖЕЙ', CAST(80 AS Decimal(18, 0)), 1)
INSERT [dbo].[Services] ([Id], [TitleService], [CostService], [IdServiceType]) VALUES (5, N'УБОРКА ОФИСОВ', CAST(55 AS Decimal(18, 0)), 1)
INSERT [dbo].[Services] ([Id], [TitleService], [CostService], [IdServiceType]) VALUES (6, N'УБОРКА ПОСЛЕ РЕМОНТА', CAST(80 AS Decimal(18, 0)), 1)
INSERT [dbo].[Services] ([Id], [TitleService], [CostService], [IdServiceType]) VALUES (7, N'УХОД ЗА ПОЛОМ', CAST(40 AS Decimal(18, 0)), 1)
INSERT [dbo].[Services] ([Id], [TitleService], [CostService], [IdServiceType]) VALUES (8, N'МЫТЬЕ ОКОН', CAST(80 AS Decimal(18, 0)), 1)
INSERT [dbo].[Services] ([Id], [TitleService], [CostService], [IdServiceType]) VALUES (9, N'УБОРКА ТЕРРИТОРИИ И ВЫВОЗ МУСОРА', CAST(13 AS Decimal(18, 0)), 2)
INSERT [dbo].[Services] ([Id], [TitleService], [CostService], [IdServiceType]) VALUES (10, N'УБОРКА И ВЫВОЗ СНЕГА', CAST(15 AS Decimal(18, 0)), 2)
INSERT [dbo].[Services] ([Id], [TitleService], [CostService], [IdServiceType]) VALUES (11, N'ВЫКАШИВАНИЕ ТРАВЫ', CAST(4 AS Decimal(18, 0)), 2)
INSERT [dbo].[Services] ([Id], [TitleService], [CostService], [IdServiceType]) VALUES (12, N'ХИМЧИСТКА КОВРОВ И КОВРОВЫХ ПОКРЫТИЙ ', CAST(120 AS Decimal(18, 0)), 3)
INSERT [dbo].[Services] ([Id], [TitleService], [CostService], [IdServiceType]) VALUES (13, N'ХИМЧИСТКА МЕБЕЛИ', CAST(150 AS Decimal(18, 0)), 3)
SET IDENTITY_INSERT [dbo].[Services] OFF
GO
SET IDENTITY_INSERT [dbo].[ServiceTypes] ON 

INSERT [dbo].[ServiceTypes] ([Id], [TypeTitle]) VALUES (1, N'Уборка помещений')
INSERT [dbo].[ServiceTypes] ([Id], [TypeTitle]) VALUES (2, N'Уборка территории')
INSERT [dbo].[ServiceTypes] ([Id], [TypeTitle]) VALUES (3, N'Химчистка')
SET IDENTITY_INSERT [dbo].[ServiceTypes] OFF
GO
SET IDENTITY_INSERT [dbo].[StatusEmployees] ON 

INSERT [dbo].[StatusEmployees] ([Id], [RoleName]) VALUES (1, N'Менеджер')
INSERT [dbo].[StatusEmployees] ([Id], [RoleName]) VALUES (2, N'Рабочий')
SET IDENTITY_INSERT [dbo].[StatusEmployees] OFF
GO
ALTER TABLE [dbo].[Blogs]  WITH CHECK ADD  CONSTRAINT [FK_Blogs_Employees] FOREIGN KEY([IdEmployee])
REFERENCES [dbo].[Employees] ([Id])
GO
ALTER TABLE [dbo].[Blogs] CHECK CONSTRAINT [FK_Blogs_Employees]
GO
ALTER TABLE [dbo].[Employees]  WITH CHECK ADD  CONSTRAINT [FK_Employees_EmployeeStatuses] FOREIGN KEY([IdStatus])
REFERENCES [dbo].[StatusEmployees] ([Id])
GO
ALTER TABLE [dbo].[Employees] CHECK CONSTRAINT [FK_Employees_EmployeeStatuses]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Clients] FOREIGN KEY([IdClient])
REFERENCES [dbo].[Clients] ([Id])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Clients]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Employees] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employees] ([Id])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Employees]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_OrderStatus] FOREIGN KEY([IdStatus])
REFERENCES [dbo].[OrderStatus] ([Id])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_OrderStatus]
GO
ALTER TABLE [dbo].[OrderService]  WITH CHECK ADD  CONSTRAINT [FK_OrderService_Orders] FOREIGN KEY([IdOrder])
REFERENCES [dbo].[Orders] ([Id])
GO
ALTER TABLE [dbo].[OrderService] CHECK CONSTRAINT [FK_OrderService_Orders]
GO
ALTER TABLE [dbo].[OrderService]  WITH CHECK ADD  CONSTRAINT [FK_OrderService_Services] FOREIGN KEY([IdService])
REFERENCES [dbo].[Services] ([Id])
GO
ALTER TABLE [dbo].[OrderService] CHECK CONSTRAINT [FK_OrderService_Services]
GO
ALTER TABLE [dbo].[Reviews]  WITH CHECK ADD  CONSTRAINT [FK_Reviews_Clients] FOREIGN KEY([IdClient])
REFERENCES [dbo].[Clients] ([Id])
GO
ALTER TABLE [dbo].[Reviews] CHECK CONSTRAINT [FK_Reviews_Clients]
GO
ALTER TABLE [dbo].[Services]  WITH CHECK ADD  CONSTRAINT [FK_Services_ServiceTypes] FOREIGN KEY([IdServiceType])
REFERENCES [dbo].[ServiceTypes] ([Id])
GO
ALTER TABLE [dbo].[Services] CHECK CONSTRAINT [FK_Services_ServiceTypes]
GO
USE [master]
GO
ALTER DATABASE [CleaningDb] SET  READ_WRITE 
GO
