/*    ==Параметры сценариев==

    Версия исходного сервера : SQL Server 2017 (14.0.1000)
    Выпуск исходного ядра СУБД : Выпуск Microsoft SQL Server Express Edition
    Тип исходного ядра СУБД : Изолированный SQL Server

    Версия целевого сервера : SQL Server 2017
    Выпуск целевого ядра СУБД : Выпуск Microsoft SQL Server Standard Edition
    Тип целевого ядра СУБД : Изолированный SQL Server
*/
USE [master]
GO
/****** Object:  Database [RetrospectivaDB]    Script Date: 12.05.2024 20:45:27 ******/
CREATE DATABASE [RetrospectivaDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'RetrospectivaDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\RetrospectivaDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'RetrospectivaDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\RetrospectivaDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [RetrospectivaDB] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [RetrospectivaDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [RetrospectivaDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [RetrospectivaDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [RetrospectivaDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [RetrospectivaDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [RetrospectivaDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [RetrospectivaDB] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [RetrospectivaDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [RetrospectivaDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [RetrospectivaDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [RetrospectivaDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [RetrospectivaDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [RetrospectivaDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [RetrospectivaDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [RetrospectivaDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [RetrospectivaDB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [RetrospectivaDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [RetrospectivaDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [RetrospectivaDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [RetrospectivaDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [RetrospectivaDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [RetrospectivaDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [RetrospectivaDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [RetrospectivaDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [RetrospectivaDB] SET  MULTI_USER 
GO
ALTER DATABASE [RetrospectivaDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [RetrospectivaDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [RetrospectivaDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [RetrospectivaDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [RetrospectivaDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [RetrospectivaDB] SET QUERY_STORE = OFF
GO
USE [RetrospectivaDB]
GO
ALTER DATABASE SCOPED CONFIGURATION SET IDENTITY_CACHE = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [RetrospectivaDB]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 12.05.2024 20:45:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 12.05.2024 20:45:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[Id] [int] NOT NULL,
	[Username] [nvarchar](100) NOT NULL,
	[DateOrder] [datetime] NOT NULL,
	[Total] [int] NOT NULL,
	[Paid] [bit] NOT NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderProduct]    Script Date: 12.05.2024 20:45:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderProduct](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrderId] [int] NOT NULL,
	[DoorId] [int] NOT NULL,
	[Count] [int] NOT NULL,
 CONSTRAINT [PK_Pricelist] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderService]    Script Date: 12.05.2024 20:45:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderService](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrderId] [int] NOT NULL,
	[Count] [int] NOT NULL,
	[ServiceId] [int] NOT NULL,
 CONSTRAINT [PK_OrderService] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Photo]    Script Date: 12.05.2024 20:45:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Photo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Photo] [nvarchar](200) NOT NULL,
	[ProductId] [int] NOT NULL,
 CONSTRAINT [PK_Photo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 12.05.2024 20:45:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[Price] [int] NOT NULL,
	[Size] [nvarchar](50) NOT NULL,
	[CategoryId] [int] NOT NULL,
 CONSTRAINT [PK_Weapon] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 12.05.2024 20:45:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Service]    Script Date: 12.05.2024 20:45:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Service](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](100) NOT NULL,
	[Price] [float] NULL,
 CONSTRAINT [PK_Service] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 12.05.2024 20:45:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Username] [nvarchar](100) NOT NULL,
	[Password] [nvarchar](100) NOT NULL,
	[RoleId] [int] NOT NULL,
	[LastName] [nvarchar](50) NULL,
	[FirstName] [nvarchar](50) NULL,
	[MiddleName] [nvarchar](50) NULL,
	[Phone] [nvarchar](50) NULL,
	[Email] [nvarchar](100) NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([Id], [Title]) VALUES (1, N'Фарфор')
INSERT [dbo].[Category] ([Id], [Title]) VALUES (2, N'Картины')
INSERT [dbo].[Category] ([Id], [Title]) VALUES (3, N'Ювелирные изделия')
INSERT [dbo].[Category] ([Id], [Title]) VALUES (4, N'Изделия из бронзы и чугуна')
INSERT [dbo].[Category] ([Id], [Title]) VALUES (5, N'Серебро и мельхиор')
INSERT [dbo].[Category] ([Id], [Title]) VALUES (6, N'Стекло')
INSERT [dbo].[Category] ([Id], [Title]) VALUES (7, N'Букинистика')
INSERT [dbo].[Category] ([Id], [Title]) VALUES (8, N'Фалеристика')
INSERT [dbo].[Category] ([Id], [Title]) VALUES (9, N'Нумизматика')
INSERT [dbo].[Category] ([Id], [Title]) VALUES (10, N'Карты и облигации')
INSERT [dbo].[Category] ([Id], [Title]) VALUES (11, N'Мебель')
INSERT [dbo].[Category] ([Id], [Title]) VALUES (12, N'Часы')
INSERT [dbo].[Category] ([Id], [Title]) VALUES (13, N'Оружие')
INSERT [dbo].[Category] ([Id], [Title]) VALUES (14, N'Самовары')
INSERT [dbo].[Category] ([Id], [Title]) VALUES (15, N'Радиоприёмники и радиолы')
INSERT [dbo].[Category] ([Id], [Title]) VALUES (16, N'Шкатулки')
SET IDENTITY_INSERT [dbo].[Category] OFF
INSERT [dbo].[Order] ([Id], [Username], [DateOrder], [Total], [Paid]) VALUES (1, N'user', CAST(N'2024-05-12T20:36:47.000' AS DateTime), 63000, 0)
INSERT [dbo].[Order] ([Id], [Username], [DateOrder], [Total], [Paid]) VALUES (2, N'amadeus', CAST(N'2024-05-12T20:41:32.000' AS DateTime), 160000, 0)
SET IDENTITY_INSERT [dbo].[OrderProduct] ON 

INSERT [dbo].[OrderProduct] ([Id], [OrderId], [DoorId], [Count]) VALUES (24, 1, 32, 1)
INSERT [dbo].[OrderProduct] ([Id], [OrderId], [DoorId], [Count]) VALUES (25, 1, 31, 1)
INSERT [dbo].[OrderProduct] ([Id], [OrderId], [DoorId], [Count]) VALUES (26, 1, 36, 1)
INSERT [dbo].[OrderProduct] ([Id], [OrderId], [DoorId], [Count]) VALUES (27, 2, 33, 1)
INSERT [dbo].[OrderProduct] ([Id], [OrderId], [DoorId], [Count]) VALUES (28, 2, 29, 1)
SET IDENTITY_INSERT [dbo].[OrderProduct] OFF
SET IDENTITY_INSERT [dbo].[OrderService] ON 

INSERT [dbo].[OrderService] ([Id], [OrderId], [Count], [ServiceId]) VALUES (32, 1, 3, 102)
INSERT [dbo].[OrderService] ([Id], [OrderId], [Count], [ServiceId]) VALUES (33, 2, 3, 100)
INSERT [dbo].[OrderService] ([Id], [OrderId], [Count], [ServiceId]) VALUES (34, 2, 1, 102)
SET IDENTITY_INSERT [dbo].[OrderService] OFF
SET IDENTITY_INSERT [dbo].[Photo] ON 

INSERT [dbo].[Photo] ([Id], [Photo], [ProductId]) VALUES (3, N'photo1712476268.jpeg', 29)
INSERT [dbo].[Photo] ([Id], [Photo], [ProductId]) VALUES (4, N'photo1712476268__2_.jpeg', 29)
INSERT [dbo].[Photo] ([Id], [Photo], [ProductId]) VALUES (5, N'photo1712476268__3_.jpeg', 29)
INSERT [dbo].[Photo] ([Id], [Photo], [ProductId]) VALUES (6, N'photo1712476268__4_.jpeg', 29)
INSERT [dbo].[Photo] ([Id], [Photo], [ProductId]) VALUES (7, N'photo1712476268__6_.jpeg', 29)
INSERT [dbo].[Photo] ([Id], [Photo], [ProductId]) VALUES (8, N'photo1712476268__7_.jpeg', 29)
INSERT [dbo].[Photo] ([Id], [Photo], [ProductId]) VALUES (9, N'photo1712476268__8_.jpeg', 29)
INSERT [dbo].[Photo] ([Id], [Photo], [ProductId]) VALUES (10, N'thumb_photo1712476268__5_.jpeg', 29)
INSERT [dbo].[Photo] ([Id], [Photo], [ProductId]) VALUES (11, N'photo1703492454.jpeg', 30)
INSERT [dbo].[Photo] ([Id], [Photo], [ProductId]) VALUES (12, N'photo1703492454__1_.jpeg', 30)
INSERT [dbo].[Photo] ([Id], [Photo], [ProductId]) VALUES (13, N'photo1703492454__2_.jpeg', 30)
INSERT [dbo].[Photo] ([Id], [Photo], [ProductId]) VALUES (14, N'photo1703492454__3_.jpeg', 30)
INSERT [dbo].[Photo] ([Id], [Photo], [ProductId]) VALUES (15, N'photo1703492454__4_.jpeg', 30)
INSERT [dbo].[Photo] ([Id], [Photo], [ProductId]) VALUES (16, N'full_msg5025939725-24235.jpg', 31)
INSERT [dbo].[Photo] ([Id], [Photo], [ProductId]) VALUES (17, N'msg5025939725-24228.jpg', 31)
INSERT [dbo].[Photo] ([Id], [Photo], [ProductId]) VALUES (18, N'msg5025939725-24229.jpg', 31)
INSERT [dbo].[Photo] ([Id], [Photo], [ProductId]) VALUES (19, N'msg5025939725-24232.jpg', 31)
INSERT [dbo].[Photo] ([Id], [Photo], [ProductId]) VALUES (20, N'msg5025939725-24234.jpg', 31)
INSERT [dbo].[Photo] ([Id], [Photo], [ProductId]) VALUES (21, N'thumb_msg5025939725-24230.jpg', 31)
INSERT [dbo].[Photo] ([Id], [Photo], [ProductId]) VALUES (22, N'________7.jpeg', 32)
INSERT [dbo].[Photo] ([Id], [Photo], [ProductId]) VALUES (23, N'______121.jpeg', 32)
INSERT [dbo].[Photo] ([Id], [Photo], [ProductId]) VALUES (24, N'______217.jpeg', 32)
INSERT [dbo].[Photo] ([Id], [Photo], [ProductId]) VALUES (25, N'IMG_74641.jpg', 33)
INSERT [dbo].[Photo] ([Id], [Photo], [ProductId]) VALUES (26, N'IMG_20210903_140637_resized_20210903_021216356.jpg', 33)
INSERT [dbo].[Photo] ([Id], [Photo], [ProductId]) VALUES (27, N'IMG_20210903_140641_resized_20210903_021216480.jpg', 33)
INSERT [dbo].[Photo] ([Id], [Photo], [ProductId]) VALUES (28, N'IMG_20210903_140651_resized_20210903_021216773.jpg', 33)
INSERT [dbo].[Photo] ([Id], [Photo], [ProductId]) VALUES (29, N'thumb_IMG_20210903_140738_resized_20210903_021216924.jpg', 33)
INSERT [dbo].[Photo] ([Id], [Photo], [ProductId]) VALUES (30, N'__arta___azan_11.jpg', 34)
INSERT [dbo].[Photo] ([Id], [Photo], [ProductId]) VALUES (31, N'__arta___azan_21.jpg', 34)
INSERT [dbo].[Photo] ([Id], [Photo], [ProductId]) VALUES (32, N'full_image-31-01-22-04-09.jpeg', 35)
INSERT [dbo].[Photo] ([Id], [Photo], [ProductId]) VALUES (33, N'full_IMG_20240426_113242__1_.jpg', 36)
INSERT [dbo].[Photo] ([Id], [Photo], [ProductId]) VALUES (34, N'IMG_20240426_113253__1_.jpg', 36)
SET IDENTITY_INSERT [dbo].[Photo] OFF
SET IDENTITY_INSERT [dbo].[Product] ON 

INSERT [dbo].[Product] ([Id], [Title], [Description], [Price], [Size], [CategoryId]) VALUES (29, N'Часы карманные женские золотые (56 проба)', N'Братья Четуновы, конец XIX - начало XX в. Российская империя. Вес 24,6г. Треснут циферблат. Рабочие, требуется профилактика.', 120000, N'Вес 24,6г.', 12)
INSERT [dbo].[Product] ([Id], [Title], [Description], [Price], [Size], [CategoryId]) VALUES (30, N'Карманные часы', N'Карманные часы, золото 56 пр.', 95000, N'вес 86,7 гр.', 12)
INSERT [dbo].[Product] ([Id], [Title], [Description], [Price], [Size], [CategoryId]) VALUES (31, N' Ламповая радиола «Минск Р-7»', N'Радиола "Минск Р-7" собрана на основе приёмника ''''Пионер'''', некоторые партии именовались как "Минск", существовали и радиолы ''''Пионер'''' и "Минск", поэтому с 1947 года во избежание путаницы радиола стала называться ''''Минск Р-7'''', при этом пройдя модернизацию. Р-7 расшифровывается как: Р - радиола, 7 - количество ламп.', 50000, N'60x80x44', 15)
INSERT [dbo].[Product] ([Id], [Title], [Description], [Price], [Size], [CategoryId]) VALUES (32, N' Радиоприемник МПС 58, встроенный динамик', N'Трансляционный радиоприемник МПС 58, встроенный динамик', 10000, N'50X40', 15)
INSERT [dbo].[Product] ([Id], [Title], [Description], [Price], [Size], [CategoryId]) VALUES (33, N'Радиоприемник ламповый 1953 год', N'Радиоприемник Рекорд-53 обеспечивает прием радиостанций в диапазонах ДВ, СВ и КВ. Является модернизацией радиоприемника "Рекорд-52". Иркутский завод. Имеет встроенный Bluetooth', 40000, N'50x40x30', 15)
INSERT [dbo].[Product] ([Id], [Title], [Description], [Price], [Size], [CategoryId]) VALUES (34, N'Карта Казанской Губерний', N'Карта Казанской Губерний,Масштаб 30', 30000, N'42.5х50 см', 10)
INSERT [dbo].[Product] ([Id], [Title], [Description], [Price], [Size], [CategoryId]) VALUES (35, N'Облигация 187,50 рублей (6 и 7 заемъ) г.Санкт Петербург', N'Состояние люк, отличный вариант на подарок!', 6000, N'50x30', 10)
INSERT [dbo].[Product] ([Id], [Title], [Description], [Price], [Size], [CategoryId]) VALUES (36, N'значок ХХХ лет комсомолу', N'значок ХХХ лет комсомолу', 3000, N'3', 8)
SET IDENTITY_INSERT [dbo].[Product] OFF
SET IDENTITY_INSERT [dbo].[Role] ON 

INSERT [dbo].[Role] ([Id], [Title]) VALUES (1, N'администратор')
INSERT [dbo].[Role] ([Id], [Title]) VALUES (2, N'клиент')
SET IDENTITY_INSERT [dbo].[Role] OFF
SET IDENTITY_INSERT [dbo].[Service] ON 

INSERT [dbo].[Service] ([Id], [Title], [Price]) VALUES (99, N'Реставрация', 500)
INSERT [dbo].[Service] ([Id], [Title], [Price]) VALUES (100, N'онлайн оценка по фото', 500)
INSERT [dbo].[Service] ([Id], [Title], [Price]) VALUES (101, N'Оценка и выкуп картины, выезд специалиста', 1000)
INSERT [dbo].[Service] ([Id], [Title], [Price]) VALUES (102, N'Оценка и выкуп  икон, выезд специалиста', 1000)
INSERT [dbo].[Service] ([Id], [Title], [Price]) VALUES (103, N'Оценка и выкуп ювелирных изделий, выезд специалиста', 1000)
SET IDENTITY_INSERT [dbo].[Service] OFF
INSERT [dbo].[User] ([Username], [Password], [RoleId], [LastName], [FirstName], [MiddleName], [Phone], [Email]) VALUES (N'admin', N'1', 1, N'Недашковский', N'Кирилл', N'Игоревич', N'+7 (965) 838-62-02', N'KirillNedashkovskiy454@mail.ru')
INSERT [dbo].[User] ([Username], [Password], [RoleId], [LastName], [FirstName], [MiddleName], [Phone], [Email]) VALUES (N'amadeus', N'1', 2, N'Соколович', N'Амадеус', N'Альбертович', N'+7 (925) 637-57-45', N'AmadeusSokolovich681@mail.ru')
INSERT [dbo].[User] ([Username], [Password], [RoleId], [LastName], [FirstName], [MiddleName], [Phone], [Email]) VALUES (N'leonid', N'1', 2, N'Дубровский', N'Леонид', N'Игоревич', N'+7 (913) 383-14-78', N'LeonidDubrovskiy603@mail.ru')
INSERT [dbo].[User] ([Username], [Password], [RoleId], [LastName], [FirstName], [MiddleName], [Phone], [Email]) VALUES (N'lubos', N'1', 2, N'Сергеев', N'Любосмысл', N'Денисович', N'+7 (928) 037-11-06', N'LyubosmyslSergeev950@mail.ru')
INSERT [dbo].[User] ([Username], [Password], [RoleId], [LastName], [FirstName], [MiddleName], [Phone], [Email]) VALUES (N'margo', N'1', 2, N'Высоцкая', N'Маргарита', N'Робертовна', N'+7 (931) 116-17-08', N'MargaritaVysotskaya569')
INSERT [dbo].[User] ([Username], [Password], [RoleId], [LastName], [FirstName], [MiddleName], [Phone], [Email]) VALUES (N'user', N'1', 2, N'Никитин', N'Евгений', N'Аркадьевич', N'+7 (931) 217-33-38', N'EvgeniyNikitin181@mail.ru')
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_User] FOREIGN KEY([Username])
REFERENCES [dbo].[User] ([Username])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_User]
GO
ALTER TABLE [dbo].[OrderProduct]  WITH CHECK ADD  CONSTRAINT [FK_OrderDoor_Door] FOREIGN KEY([DoorId])
REFERENCES [dbo].[Product] ([Id])
GO
ALTER TABLE [dbo].[OrderProduct] CHECK CONSTRAINT [FK_OrderDoor_Door]
GO
ALTER TABLE [dbo].[OrderProduct]  WITH CHECK ADD  CONSTRAINT [FK_OrderDoor_Order] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Order] ([Id])
GO
ALTER TABLE [dbo].[OrderProduct] CHECK CONSTRAINT [FK_OrderDoor_Order]
GO
ALTER TABLE [dbo].[OrderService]  WITH CHECK ADD  CONSTRAINT [FK_OrderService_Order] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Order] ([Id])
GO
ALTER TABLE [dbo].[OrderService] CHECK CONSTRAINT [FK_OrderService_Order]
GO
ALTER TABLE [dbo].[OrderService]  WITH CHECK ADD  CONSTRAINT [FK_OrderService_Service] FOREIGN KEY([ServiceId])
REFERENCES [dbo].[Service] ([Id])
GO
ALTER TABLE [dbo].[OrderService] CHECK CONSTRAINT [FK_OrderService_Service]
GO
ALTER TABLE [dbo].[Photo]  WITH CHECK ADD  CONSTRAINT [FK_Photo_Product] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([Id])
GO
ALTER TABLE [dbo].[Photo] CHECK CONSTRAINT [FK_Photo_Product]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Door_Category] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Category] ([Id])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Door_Category]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Role] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Role] ([Id])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Role]
GO
USE [master]
GO
ALTER DATABASE [RetrospectivaDB] SET  READ_WRITE 
GO
