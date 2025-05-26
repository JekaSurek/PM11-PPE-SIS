USE [master]
GO
/****** Object:  Database [БелкаФаворитСпичечнаяФабрикаБазаДанных]    Script Date: 25.05.2025 21:20:09 ******/
CREATE DATABASE [БелкаФаворитСпичечнаяФабрикаБазаДанных]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'БелкаФаворитСпичечнаяФабрикаБазаДанных', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\БелкаФаворитСпичечнаяФабрикаБазаДанных.mdf' , SIZE = 73728KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'БелкаФаворитСпичечнаяФабрикаБазаДанных_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\БелкаФаворитСпичечнаяФабрикаБазаДанных_log.ldf' , SIZE = 73728KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [БелкаФаворитСпичечнаяФабрикаБазаДанных] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [БелкаФаворитСпичечнаяФабрикаБазаДанных].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [БелкаФаворитСпичечнаяФабрикаБазаДанных] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [БелкаФаворитСпичечнаяФабрикаБазаДанных] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [БелкаФаворитСпичечнаяФабрикаБазаДанных] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [БелкаФаворитСпичечнаяФабрикаБазаДанных] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [БелкаФаворитСпичечнаяФабрикаБазаДанных] SET ARITHABORT OFF 
GO
ALTER DATABASE [БелкаФаворитСпичечнаяФабрикаБазаДанных] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [БелкаФаворитСпичечнаяФабрикаБазаДанных] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [БелкаФаворитСпичечнаяФабрикаБазаДанных] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [БелкаФаворитСпичечнаяФабрикаБазаДанных] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [БелкаФаворитСпичечнаяФабрикаБазаДанных] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [БелкаФаворитСпичечнаяФабрикаБазаДанных] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [БелкаФаворитСпичечнаяФабрикаБазаДанных] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [БелкаФаворитСпичечнаяФабрикаБазаДанных] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [БелкаФаворитСпичечнаяФабрикаБазаДанных] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [БелкаФаворитСпичечнаяФабрикаБазаДанных] SET  DISABLE_BROKER 
GO
ALTER DATABASE [БелкаФаворитСпичечнаяФабрикаБазаДанных] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [БелкаФаворитСпичечнаяФабрикаБазаДанных] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [БелкаФаворитСпичечнаяФабрикаБазаДанных] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [БелкаФаворитСпичечнаяФабрикаБазаДанных] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [БелкаФаворитСпичечнаяФабрикаБазаДанных] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [БелкаФаворитСпичечнаяФабрикаБазаДанных] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [БелкаФаворитСпичечнаяФабрикаБазаДанных] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [БелкаФаворитСпичечнаяФабрикаБазаДанных] SET RECOVERY FULL 
GO
ALTER DATABASE [БелкаФаворитСпичечнаяФабрикаБазаДанных] SET  MULTI_USER 
GO
ALTER DATABASE [БелкаФаворитСпичечнаяФабрикаБазаДанных] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [БелкаФаворитСпичечнаяФабрикаБазаДанных] SET DB_CHAINING OFF 
GO
ALTER DATABASE [БелкаФаворитСпичечнаяФабрикаБазаДанных] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [БелкаФаворитСпичечнаяФабрикаБазаДанных] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [БелкаФаворитСпичечнаяФабрикаБазаДанных] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [БелкаФаворитСпичечнаяФабрикаБазаДанных] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'БелкаФаворитСпичечнаяФабрикаБазаДанных', N'ON'
GO
ALTER DATABASE [БелкаФаворитСпичечнаяФабрикаБазаДанных] SET QUERY_STORE = ON
GO
ALTER DATABASE [БелкаФаворитСпичечнаяФабрикаБазаДанных] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [БелкаФаворитСпичечнаяФабрикаБазаДанных]
GO
/****** Object:  User [ManagerSIZ]    Script Date: 25.05.2025 21:20:10 ******/
CREATE USER [ManagerSIZ] FOR LOGIN [ManagerSIZ] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [AdminSIZ]    Script Date: 25.05.2025 21:20:10 ******/
CREATE USER [AdminSIZ] FOR LOGIN [AdminSIZ] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [AccountantSIZ]    Script Date: 25.05.2025 21:20:10 ******/
CREATE USER [AccountantSIZ] FOR LOGIN [AccountantSIZ] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  DatabaseRole [Manager]    Script Date: 25.05.2025 21:20:10 ******/
CREATE ROLE [Manager]
GO
/****** Object:  DatabaseRole [AdminDB]    Script Date: 25.05.2025 21:20:10 ******/
CREATE ROLE [AdminDB]
GO
/****** Object:  DatabaseRole [Accountant]    Script Date: 25.05.2025 21:20:10 ******/
CREATE ROLE [Accountant]
GO
ALTER ROLE [Manager] ADD MEMBER [ManagerSIZ]
GO
ALTER ROLE [db_owner] ADD MEMBER [AdminSIZ]
GO
ALTER ROLE [Accountant] ADD MEMBER [AccountantSIZ]
GO
/****** Object:  Table [dbo].[Выдача]    Script Date: 25.05.2025 21:20:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Выдача](
	[id_Выдачи] [int] IDENTITY(1,1) NOT NULL,
	[id_сотрудника] [int] NOT NULL,
	[id_сиз] [int] NOT NULL,
	[Дата_выдачи] [date] NOT NULL,
	[количество] [int] NOT NULL,
	[Срок_износа] [date] NULL,
	[Дата_создания] [datetime] NOT NULL,
	[Дата_изменения] [datetime] NOT NULL,
	[Кем_создана] [int] NULL,
 CONSTRAINT [PK_Выдача] PRIMARY KEY CLUSTERED 
(
	[id_Выдачи] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ДерматологическоеСредство]    Script Date: 25.05.2025 21:20:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ДерматологическоеСредство](
	[id_ДерматологическогоСредства] [int] IDENTITY(1,1) NOT NULL,
	[id_профессии] [int] NOT NULL,
	[Наименование] [nvarchar](100) NOT NULL,
	[Норма] [nvarchar](70) NOT NULL,
 CONSTRAINT [PK_ДерматологическоеСредство] PRIMARY KEY CLUSTERED 
(
	[id_ДерматологическогоСредства] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Инфраструктура]    Script Date: 25.05.2025 21:20:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Инфраструктура](
	[id_Инфраструктуры] [int] IDENTITY(1,1) NOT NULL,
	[Наименование] [nvarchar](100) NOT NULL,
	[Описание] [nvarchar](3000) NULL,
 CONSTRAINT [PK_Инфраструктура] PRIMARY KEY CLUSTERED 
(
	[id_Инфраструктуры] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ИсторияВхода]    Script Date: 25.05.2025 21:20:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ИсторияВхода](
	[id_Записи] [int] IDENTITY(1,1) NOT NULL,
	[id_пользователя] [int] NULL,
	[Время_входа_в_систему] [datetime] NOT NULL,
	[Система] [nvarchar](max) NULL,
	[IP_adress] [nvarchar](45) NOT NULL,
	[Успех] [bit] NOT NULL,
	[Причина_отказа] [nvarchar](255) NULL,
 CONSTRAINT [PK_ИсторияВхода] PRIMARY KEY CLUSTERED 
(
	[id_Записи] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[НормаВыдачи]    Script Date: 25.05.2025 21:20:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[НормаВыдачи](
	[id_Нормы] [int] IDENTITY(1,1) NOT NULL,
	[id_профессии] [int] NOT NULL,
	[id_сиз] [int] NOT NULL,
	[Норма_в_единицах_измерения] [varchar](80) NOT NULL,
	[Период] [varchar](50) NOT NULL,
	[Сезон] [int] NOT NULL,
	[Основание_назначения] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK_НормаВыдачи] PRIMARY KEY CLUSTERED 
(
	[id_Нормы] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Пользователи]    Script Date: 25.05.2025 21:20:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Пользователи](
	[id_Пользователя] [int] IDENTITY(1,1) NOT NULL,
	[Логин] [nvarchar](80) NOT NULL,
	[Пароль] [nvarchar](40) NOT NULL,
	[id_роли] [int] NOT NULL,
	[Фамилия_сотрудника] [nvarchar](100) NULL,
	[Имя_сотрудника] [nvarchar](100) NULL,
	[Отчество_сотрудника] [nvarchar](100) NULL,
	[Дата_создания] [datetime] NULL,
	[Дата_изменения] [datetime] NULL,
	[Дата_последнего_входа] [datetime] NULL,
 CONSTRAINT [PK_Пользователи] PRIMARY KEY CLUSTERED 
(
	[id_Пользователя] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Профессия]    Script Date: 25.05.2025 21:20:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Профессия](
	[id_Профессии_или_должности] [int] IDENTITY(1,1) NOT NULL,
	[Наименование] [nvarchar](200) NOT NULL,
	[Код_по_нормативу] [nvarchar](100) NULL,
	[id_инфраструктуры_или_отдела] [int] NOT NULL,
 CONSTRAINT [PK_Профессия] PRIMARY KEY CLUSTERED 
(
	[id_Профессии_или_должности] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Роль]    Script Date: 25.05.2025 21:20:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Роль](
	[id_Роли] [int] IDENTITY(1,1) NOT NULL,
	[Наименование] [nvarchar](300) NOT NULL,
	[Описание] [nvarchar](3000) NULL,
 CONSTRAINT [PK_Роли] PRIMARY KEY CLUSTERED 
(
	[id_Роли] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Сезон]    Script Date: 25.05.2025 21:20:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Сезон](
	[id_Сезона] [int] IDENTITY(1,1) NOT NULL,
	[Наименование] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Сезон] PRIMARY KEY CLUSTERED 
(
	[id_Сезона] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[СИЗ]    Script Date: 25.05.2025 21:20:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[СИЗ](
	[id_СИЗ] [int] IDENTITY(1,1) NOT NULL,
	[Наименование] [nvarchar](200) NOT NULL,
	[id_типаСИЗ] [int] NOT NULL,
	[Единица_измерения] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_СИЗ] PRIMARY KEY CLUSTERED 
(
	[id_СИЗ] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Сотрудник]    Script Date: 25.05.2025 21:20:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Сотрудник](
	[id_Сотрудника] [int] IDENTITY(1,1) NOT NULL,
	[id_профессии] [int] NOT NULL,
	[Фамилия] [nvarchar](100) NOT NULL,
	[Имя] [nvarchar](100) NOT NULL,
	[Отчество] [nvarchar](100) NULL,
 CONSTRAINT [PK_Сотрудник] PRIMARY KEY CLUSTERED 
(
	[id_Сотрудника] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ТипСИЗ]    Script Date: 25.05.2025 21:20:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ТипСИЗ](
	[id_Типа] [int] IDENTITY(1,1) NOT NULL,
	[Наименование] [nvarchar](100) NOT NULL,
	[Описание] [nvarchar](3000) NULL,
 CONSTRAINT [PK_ТипыСИЗ] PRIMARY KEY CLUSTERED 
(
	[id_Типа] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Выдача]  WITH NOCHECK ADD  CONSTRAINT [FK_Выдача_Пользователи] FOREIGN KEY([Кем_создана])
REFERENCES [dbo].[Пользователи] ([id_Пользователя])
GO
ALTER TABLE [dbo].[Выдача] CHECK CONSTRAINT [FK_Выдача_Пользователи]
GO
ALTER TABLE [dbo].[Выдача]  WITH NOCHECK ADD  CONSTRAINT [FK_Выдача_СИЗ] FOREIGN KEY([id_сиз])
REFERENCES [dbo].[СИЗ] ([id_СИЗ])
GO
ALTER TABLE [dbo].[Выдача] CHECK CONSTRAINT [FK_Выдача_СИЗ]
GO
ALTER TABLE [dbo].[Выдача]  WITH NOCHECK ADD  CONSTRAINT [FK_Выдача_Сотрудник] FOREIGN KEY([id_сотрудника])
REFERENCES [dbo].[Сотрудник] ([id_Сотрудника])
GO
ALTER TABLE [dbo].[Выдача] CHECK CONSTRAINT [FK_Выдача_Сотрудник]
GO
ALTER TABLE [dbo].[ДерматологическоеСредство]  WITH NOCHECK ADD  CONSTRAINT [FK_ДерматологическоеСредство_Профессия] FOREIGN KEY([id_профессии])
REFERENCES [dbo].[Профессия] ([id_Профессии_или_должности])
GO
ALTER TABLE [dbo].[ДерматологическоеСредство] CHECK CONSTRAINT [FK_ДерматологическоеСредство_Профессия]
GO
ALTER TABLE [dbo].[ИсторияВхода]  WITH CHECK ADD  CONSTRAINT [FK_ИсторияВхода_Пользователи] FOREIGN KEY([id_пользователя])
REFERENCES [dbo].[Пользователи] ([id_Пользователя])
GO
ALTER TABLE [dbo].[ИсторияВхода] CHECK CONSTRAINT [FK_ИсторияВхода_Пользователи]
GO
ALTER TABLE [dbo].[НормаВыдачи]  WITH NOCHECK ADD  CONSTRAINT [FK_НормаВыдачи_Профессия] FOREIGN KEY([id_профессии])
REFERENCES [dbo].[Профессия] ([id_Профессии_или_должности])
GO
ALTER TABLE [dbo].[НормаВыдачи] CHECK CONSTRAINT [FK_НормаВыдачи_Профессия]
GO
ALTER TABLE [dbo].[НормаВыдачи]  WITH NOCHECK ADD  CONSTRAINT [FK_НормаВыдачи_Сезон] FOREIGN KEY([Сезон])
REFERENCES [dbo].[Сезон] ([id_Сезона])
GO
ALTER TABLE [dbo].[НормаВыдачи] CHECK CONSTRAINT [FK_НормаВыдачи_Сезон]
GO
ALTER TABLE [dbo].[НормаВыдачи]  WITH NOCHECK ADD  CONSTRAINT [FK_НормаВыдачи_СИЗ] FOREIGN KEY([id_сиз])
REFERENCES [dbo].[СИЗ] ([id_СИЗ])
GO
ALTER TABLE [dbo].[НормаВыдачи] CHECK CONSTRAINT [FK_НормаВыдачи_СИЗ]
GO
ALTER TABLE [dbo].[Пользователи]  WITH NOCHECK ADD  CONSTRAINT [FK_Пользователи_Роль] FOREIGN KEY([id_роли])
REFERENCES [dbo].[Роль] ([id_Роли])
GO
ALTER TABLE [dbo].[Пользователи] CHECK CONSTRAINT [FK_Пользователи_Роль]
GO
ALTER TABLE [dbo].[Профессия]  WITH NOCHECK ADD  CONSTRAINT [FK_Профессия_Инфраструктура] FOREIGN KEY([id_инфраструктуры_или_отдела])
REFERENCES [dbo].[Инфраструктура] ([id_Инфраструктуры])
GO
ALTER TABLE [dbo].[Профессия] CHECK CONSTRAINT [FK_Профессия_Инфраструктура]
GO
ALTER TABLE [dbo].[СИЗ]  WITH NOCHECK ADD  CONSTRAINT [FK_СИЗ_ТипСИЗ] FOREIGN KEY([id_типаСИЗ])
REFERENCES [dbo].[ТипСИЗ] ([id_Типа])
GO
ALTER TABLE [dbo].[СИЗ] CHECK CONSTRAINT [FK_СИЗ_ТипСИЗ]
GO
ALTER TABLE [dbo].[Сотрудник]  WITH NOCHECK ADD  CONSTRAINT [FK_Сотрудник_Профессия] FOREIGN KEY([id_профессии])
REFERENCES [dbo].[Профессия] ([id_Профессии_или_должности])
GO
ALTER TABLE [dbo].[Сотрудник] CHECK CONSTRAINT [FK_Сотрудник_Профессия]
GO
ALTER TABLE [dbo].[Выдача]  WITH NOCHECK ADD  CONSTRAINT [CHK_ДатыВыдачи] CHECK  (([Срок_износа] IS NULL OR [Срок_износа]>=[Дата_выдачи]))
GO
ALTER TABLE [dbo].[Выдача] CHECK CONSTRAINT [CHK_ДатыВыдачи]
GO
ALTER TABLE [dbo].[Выдача]  WITH NOCHECK ADD  CONSTRAINT [CHK_Количество] CHECK  (([количество]>(0)))
GO
ALTER TABLE [dbo].[Выдача] CHECK CONSTRAINT [CHK_Количество]
GO
/****** Object:  StoredProcedure [dbo].[sp_AddДерматологическоеСредство]    Script Date: 25.05.2025 21:20:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_AddДерматологическоеСредство]
    @Наименование NVARCHAR(100),
    @Норма NVARCHAR(70),
    @id_профессии INT
AS
BEGIN
    INSERT INTO ДерматологическоеСредство (Наименование, Норма, id_профессии) 
    VALUES (@Наименование, @Норма, @id_профессии);
END

GO
/****** Object:  StoredProcedure [dbo].[sp_AddИнфраструктура]    Script Date: 25.05.2025 21:20:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--Добавление записи
CREATE PROCEDURE [dbo].[sp_AddИнфраструктура]
    @Наименование NVARCHAR(100),
    @Описание NVARCHAR(3000) = NULL
AS
BEGIN
    INSERT INTO Инфраструктура (Наименование, Описание) 
    VALUES (@Наименование, @Описание);
END

GO
/****** Object:  StoredProcedure [dbo].[sp_AddНормаВыдачи]    Script Date: 25.05.2025 21:20:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_AddНормаВыдачи]
    @id_профессии INT,
    @id_сиз INT,
    @Норма_в_единицах_измерения VARCHAR(80),
    @Период VARCHAR(50),
    @Сезон INT,
    @Основание_назначения NVARCHAR(200)
AS
BEGIN
    INSERT INTO НормаВыдачи (id_профессии, id_сиз, Норма_в_единицах_измерения, Период, Сезон, Основание_назначения)
    VALUES (@id_профессии, @id_сиз, @Норма_в_единицах_измерения, @Период, @Сезон, @Основание_назначения);
END

GO
/****** Object:  StoredProcedure [dbo].[sp_AddПрофессия]    Script Date: 25.05.2025 21:20:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_AddПрофессия]
    @Наименование NVARCHAR(200),
    @Код_по_нормативу NVARCHAR(100),
    @id_инфраструктуры_или_отдела INT
AS
BEGIN
    INSERT INTO Профессия (Наименование, Код_по_нормативу, id_инфраструктуры_или_отдела) 
    VALUES (@Наименование, @Код_по_нормативу, @id_инфраструктуры_или_отдела);
END

GO
/****** Object:  StoredProcedure [dbo].[sp_AddСезон]    Script Date: 25.05.2025 21:20:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_AddСезон]
    @Наименование NVARCHAR(50)
AS
BEGIN
    INSERT INTO Сезон (Наименование) VALUES (@Наименование);
END

GO
/****** Object:  StoredProcedure [dbo].[sp_AddСИЗ]    Script Date: 25.05.2025 21:20:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_AddСИЗ]
    @Наименование NVARCHAR(200),
    @Единица_измерения NVARCHAR(50),
    @id_типаСИЗ INT
AS
BEGIN
    INSERT INTO СИЗ (Наименование, Единица_измерения, id_типаСИЗ) 
    VALUES (@Наименование, @Единица_измерения, @id_типаСИЗ);
END

GO
/****** Object:  StoredProcedure [dbo].[sp_AddСотрудник]    Script Date: 25.05.2025 21:20:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_AddСотрудник]
    @Фамилия NVARCHAR(100),
    @Имя NVARCHAR(100),
    @Отчество NVARCHAR(100) = NULL,
    @id_профессии INT
AS
BEGIN
    INSERT INTO Сотрудник (Фамилия, Имя, Отчество, id_профессии) 
    VALUES (@Фамилия, @Имя, @Отчество, @id_профессии);
END

GO
/****** Object:  StoredProcedure [dbo].[sp_AddТипСИЗ]    Script Date: 25.05.2025 21:20:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_AddТипСИЗ]
    @Наименование NVARCHAR(100),
    @Описание NVARCHAR(3000) = NULL
AS
BEGIN
    INSERT INTO ТипСИЗ (Наименование, Описание) VALUES (@Наименование, @Описание);
END

GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteВыдача]    Script Date: 25.05.2025 21:20:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_DeleteВыдача]
    @id_Выдачи INT
AS
BEGIN
    DELETE FROM Выдача WHERE id_Выдачи = @id_Выдачи;
END

GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteДерматологическоеСредство]    Script Date: 25.05.2025 21:20:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_DeleteДерматологическоеСредство]
    @id_ДерматологическогоСредства INT
AS
BEGIN
    DELETE FROM ДерматологическоеСредство WHERE id_ДерматологическогоСредства = @id_ДерматологическогоСредства;
END

GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteИнфраструктура]    Script Date: 25.05.2025 21:20:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--Удаление записи
CREATE PROCEDURE [dbo].[sp_DeleteИнфраструктура]
    @id_Инфраструктуры INT
AS
BEGIN
    DELETE FROM Инфраструктура WHERE id_Инфраструктуры = @id_Инфраструктуры;
END

GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteНормаВыдачи]    Script Date: 25.05.2025 21:20:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_DeleteНормаВыдачи]
    @id_Нормы INT
AS
BEGIN
    DELETE FROM НормаВыдачи WHERE id_Нормы = @id_Нормы;
END

GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteПрофессия]    Script Date: 25.05.2025 21:20:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_DeleteПрофессия]
    @id_Профессии_или_должности INT
AS
BEGIN
    DELETE FROM Профессия WHERE id_Профессии_или_должности = @id_Профессии_или_должности;
END

GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteСезон]    Script Date: 25.05.2025 21:20:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_DeleteСезон]
    @id_Сезона INT
AS
BEGIN
    DELETE FROM Сезон WHERE id_Сезона = @id_Сезона;
END

GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteСИЗ]    Script Date: 25.05.2025 21:20:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_DeleteСИЗ]
    @id_СИЗ INT
AS
BEGIN
    DELETE FROM СИЗ WHERE id_СИЗ = @id_СИЗ;
END

GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteСотрудник]    Script Date: 25.05.2025 21:20:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_DeleteСотрудник]
    @id_Сотрудника INT
AS
BEGIN
    DELETE FROM Сотрудник WHERE id_Сотрудника = @id_Сотрудника;
END

GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteТипСИЗ]    Script Date: 25.05.2025 21:20:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_DeleteТипСИЗ]
    @id_Типа INT
AS
BEGIN
    DELETE FROM ТипСИЗ WHERE id_Типа = @id_Типа;
END

GO
/****** Object:  StoredProcedure [dbo].[sp_GetВыдача]    Script Date: 25.05.2025 21:20:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_GetВыдача]
    @filter NVARCHAR(100) = NULL
AS
BEGIN
    SELECT
        v.id_Выдачи,
        v.id_сотрудника,
        s.Фамилия + ' ' + s.Имя AS EmployeeName,
        v.id_сиз,
        sz.Наименование AS SIZName,
        v.Дата_выдачи,
        v.количество,
        v.Срок_износа,
        v.Кем_создана
    FROM Выдача v
    JOIN Сотрудник s ON v.id_сотрудника = s.id_Сотрудника
    JOIN СИЗ sz ON v.id_сиз = sz.id_СИЗ
    WHERE @filter IS NULL 
        OR s.Фамилия LIKE '%' + @filter + '%'
        OR s.Имя LIKE '%' + @filter + '%'
        OR sz.Наименование LIKE '%' + @filter + '%';
END

GO
/****** Object:  StoredProcedure [dbo].[sp_GetДерматологическоеСредство]    Script Date: 25.05.2025 21:20:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


--Процедуры для таблицы "ДерматологическоеСредство"

CREATE PROCEDURE [dbo].[sp_GetДерматологическоеСредство]
    @filter NVARCHAR(100) = NULL
AS
BEGIN
    SELECT 
        d.id_ДерматологическогоСредства, 
        d.Наименование, 
        d.Норма, 
        d.id_профессии,
        p.Наименование AS ProfessionName
    FROM ДерматологическоеСредство d
    JOIN Профессия p ON d.id_профессии = p.id_Профессии_или_должности
    WHERE @filter IS NULL OR d.Наименование LIKE '%' + @filter + '%' OR p.Наименование LIKE '%' + @filter + '%';
END

GO
/****** Object:  StoredProcedure [dbo].[sp_GetИнфраструктура]    Script Date: 25.05.2025 21:20:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Процедуры для таблицы "Инфраструктура"

--Получение данных с фильтрацией
CREATE PROCEDURE [dbo].[sp_GetИнфраструктура]
    @filter NVARCHAR(100) = NULL
AS
BEGIN
    SELECT 
        id_Инфраструктуры, 
        Наименование, 
        Описание 
    FROM Инфраструктура
    WHERE @filter IS NULL OR Наименование LIKE '%' + @filter + '%' OR Описание LIKE '%' + @filter + '%';
END

GO
/****** Object:  StoredProcedure [dbo].[sp_GetНормаВыдачи]    Script Date: 25.05.2025 21:20:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


--Процедуры для таблицы "НормаВыдачи"

CREATE PROCEDURE [dbo].[sp_GetНормаВыдачи]
    @filter NVARCHAR(100) = NULL
AS
BEGIN
    SELECT 
        n.id_Нормы,
        n.id_профессии,
        p.Наименование AS ProfessionName,
        n.id_сиз,
        s.Наименование AS SIZName,
        n.Норма_в_единицах_измерения,
        n.Период,
        n.Сезон AS id_Сезона,
        sz.Наименование AS SeasonName,
        n.Основание_назначения
    FROM НормаВыдачи n
    JOIN Профессия p ON n.id_профессии = p.id_Профессии_или_должности
    JOIN СИЗ s ON n.id_сиз = s.id_СИЗ
    JOIN Сезон sz ON n.Сезон = sz.id_Сезона
    WHERE @filter IS NULL OR p.Наименование LIKE '%' + @filter + '%' OR s.Наименование LIKE '%' + @filter + '%';
END

GO
/****** Object:  StoredProcedure [dbo].[sp_GetПрофессия]    Script Date: 25.05.2025 21:20:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


--Процедуры для таблицы "Профессия"

CREATE PROCEDURE [dbo].[sp_GetПрофессия]
    @filter NVARCHAR(100) = NULL
AS
BEGIN
    SELECT 
        p.id_Профессии_или_должности, 
        p.Наименование, 
        p.Код_по_нормативу, 
        p.id_инфраструктуры_или_отдела,
        i.Наименование AS InfrastructureName
    FROM Профессия p
    JOIN Инфраструктура i ON p.id_инфраструктуры_или_отдела = i.id_Инфраструктуры
    WHERE @filter IS NULL OR p.Наименование LIKE '%' + @filter + '%' OR i.Наименование LIKE '%' + @filter + '%';
END

GO
/****** Object:  StoredProcedure [dbo].[sp_GetСезон]    Script Date: 25.05.2025 21:20:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


--Процедуры для таблицы "Сезон"

CREATE PROCEDURE [dbo].[sp_GetСезон]
    @filter NVARCHAR(50) = NULL
AS
BEGIN
    SELECT id_Сезона, Наименование FROM Сезон
    WHERE @filter IS NULL OR Наименование LIKE '%' + @filter + '%';
END

GO
/****** Object:  StoredProcedure [dbo].[sp_GetСИЗ]    Script Date: 25.05.2025 21:20:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


--Процедуры для таблицы "СИЗ"

CREATE PROCEDURE [dbo].[sp_GetСИЗ]
    @filter NVARCHAR(100) = NULL
AS
BEGIN
    SELECT 
        s.id_СИЗ, 
        s.Наименование, 
        s.Единица_измерения, 
        s.id_типаСИЗ,
        ts.Наименование AS TypeName
    FROM СИЗ s
    JOIN ТипСИЗ ts ON s.id_типаСИЗ = ts.id_Типа
    WHERE @filter IS NULL OR s.Наименование LIKE '%' + @filter + '%' OR ts.Наименование LIKE '%' + @filter + '%';
END

GO
/****** Object:  StoredProcedure [dbo].[sp_GetСотрудник]    Script Date: 25.05.2025 21:20:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


--Процедуры для таблицы "Сотрудник"

CREATE PROCEDURE [dbo].[sp_GetСотрудник]
    @filter NVARCHAR(100) = NULL
AS
BEGIN
    SELECT 
        s.id_Сотрудника, 
        s.Фамилия, 
        s.Имя, 
        s.Отчество, 
        s.id_профессии,
        p.Наименование AS ProfessionName
    FROM Сотрудник s
    JOIN Профессия p ON s.id_профессии = p.id_Профессии_или_должности
    WHERE @filter IS NULL 
        OR s.Фамилия LIKE '%' + @filter + '%'
        OR s.Имя LIKE '%' + @filter + '%'
        OR s.Отчество LIKE '%' + @filter + '%'
        OR p.Наименование LIKE '%' + @filter + '%';
END

GO
/****** Object:  StoredProcedure [dbo].[sp_GetТипСИЗ]    Script Date: 25.05.2025 21:20:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


--Процедуры для таблицы "ТипСИЗ"

CREATE PROCEDURE [dbo].[sp_GetТипСИЗ]
    @filter NVARCHAR(100) = NULL
AS
BEGIN
    SELECT id_Типа, Наименование, Описание 
    FROM ТипСИЗ
    WHERE @filter IS NULL OR Наименование LIKE '%' + @filter + '%';
END

GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateВыдача]    Script Date: 25.05.2025 21:20:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_UpdateВыдача]
    @id_Выдачи INT,
    @id_сотрудника INT,
    @id_сиз INT,
    @количество INT,
    @Срок_износа DATE = NULL,
    @Кем_создана INT
AS
BEGIN
    UPDATE Выдача SET
        id_сотрудника = @id_сотрудника,
        id_сиз = @id_сиз,
        количество = @количество,
        Срок_износа = @Срок_износа,
        Дата_изменения = GETDATE(),
        Кем_создана = @Кем_создана
    WHERE id_Выдачи = @id_Выдачи;
END

GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateДерматологическоеСредство]    Script Date: 25.05.2025 21:20:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_UpdateДерматологическоеСредство]
    @id_ДерматологическогоСредства INT,
    @Наименование NVARCHAR(100),
    @Норма NVARCHAR(70),
    @id_профессии INT
AS
BEGIN
    UPDATE ДерматологическоеСредство SET 
        Наименование = @Наименование, 
        Норма = @Норма, 
        id_профессии = @id_профессии
    WHERE id_ДерматологическогоСредства = @id_ДерматологическогоСредства;
END

GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateИнфраструктура]    Script Date: 25.05.2025 21:20:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--Обновление записи
CREATE PROCEDURE [dbo].[sp_UpdateИнфраструктура]
    @id_Инфраструктуры INT,
    @Наименование NVARCHAR(100),
    @Описание NVARCHAR(3000) = NULL
AS
BEGIN
    UPDATE Инфраструктура SET 
        Наименование = @Наименование, 
        Описание = @Описание
    WHERE id_Инфраструктуры = @id_Инфраструктуры;
END

GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateНормаВыдачи]    Script Date: 25.05.2025 21:20:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_UpdateНормаВыдачи]
    @id_Нормы INT,
    @id_профессии INT,
    @id_сиз INT,
    @Норма_в_единицах_измерения VARCHAR(80),
    @Период VARCHAR(50),
    @Сезон INT,
    @Основание_назначения NVARCHAR(200)
AS
BEGIN
    UPDATE НормаВыдачи SET
        id_профессии = @id_профессии,
        id_сиз = @id_сиз,
        Норма_в_единицах_измерения = @Норма_в_единицах_измерения,
        Период = @Период,
        Сезон = @Сезон,
        Основание_назначения = @Основание_назначения
    WHERE id_Нормы = @id_Нормы;
END

GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateПрофессия]    Script Date: 25.05.2025 21:20:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_UpdateПрофессия]
    @id_Профессии_или_должности INT,
    @Наименование NVARCHAR(200),
    @Код_по_нормативу NVARCHAR(100),
    @id_инфраструктуры_или_отдела INT
AS
BEGIN
    UPDATE Профессия SET 
        Наименование = @Наименование, 
        Код_по_нормативу = @Код_по_нормативу, 
        id_инфраструктуры_или_отдела = @id_инфраструктуры_или_отдела
    WHERE id_Профессии_или_должности = @id_Профессии_или_должности;
END

GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateСезон]    Script Date: 25.05.2025 21:20:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_UpdateСезон]
    @id_Сезона INT,
    @Наименование NVARCHAR(50)
AS
BEGIN
    UPDATE Сезон SET Наименование = @Наименование WHERE id_Сезона = @id_Сезона;
END

GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateСИЗ]    Script Date: 25.05.2025 21:20:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_UpdateСИЗ]
    @id_СИЗ INT,
    @Наименование NVARCHAR(200),
    @Единица_измерения NVARCHAR(50),
    @id_типаСИЗ INT
AS
BEGIN
    UPDATE СИЗ SET 
        Наименование = @Наименование, 
        Единица_измерения = @Единица_измерения, 
        id_типаСИЗ = @id_типаСИЗ
    WHERE id_СИЗ = @id_СИЗ;
END

GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateСотрудник]    Script Date: 25.05.2025 21:20:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_UpdateСотрудник]
    @id_Сотрудника INT,
    @Фамилия NVARCHAR(100),
    @Имя NVARCHAR(100),
    @Отчество NVARCHAR(100) = NULL,
    @id_профессии INT
AS
BEGIN
    UPDATE Сотрудник SET 
        Фамилия = @Фамилия, 
        Имя = @Имя, 
        Отчество = @Отчество, 
        id_профессии = @id_профессии
    WHERE id_Сотрудника = @id_Сотрудника;
END

GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateТипСИЗ]    Script Date: 25.05.2025 21:20:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_UpdateТипСИЗ]
    @id_Типа INT,
    @Наименование NVARCHAR(100),
    @Описание NVARCHAR(3000) = NULL
AS
BEGIN
    UPDATE ТипСИЗ SET Наименование = @Наименование, Описание = @Описание WHERE id_Типа = @id_Типа;
END

GO
/****** Object:  StoredProcedure [dbo].[sp_ДобавитьВыдачу]    Script Date: 25.05.2025 21:20:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


--Процедуры для таблицы "Выдача"
CREATE PROCEDURE [dbo].[sp_ДобавитьВыдачу]
    @id_сотрудника INT,
    @id_сиз INT,
    @количество INT,
    @Срок_износа DATE = NULL,
    @Кем_создана INT
AS
BEGIN
    INSERT INTO [Выдача] ([id_сотрудника], [id_сиз], [Дата_выдачи], [количество], [Срок_износа], [Дата_создания], [Дата_изменения], [Кем_создана])
    VALUES (@id_сотрудника, @id_сиз, GETDATE(), @количество, @Срок_износа, GETDATE(), GETDATE(), @Кем_создана);
END

GO
/****** Object:  StoredProcedure [dbo].[sp_ДобавитьПользователя]    Script Date: 25.05.2025 21:20:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_ДобавитьПользователя]
    @Логин NVARCHAR(80),
    @Пароль NVARCHAR(40),
    @id_роли INT,
    @Фамилия_сотрудника NVARCHAR(100) = NULL,
    @Имя_сотрудника NVARCHAR(100) = NULL,
    @Отчество_сотрудника NVARCHAR(100) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    
    INSERT INTO [Пользователи] (
        [Логин],
        [Пароль],
        [id_роли],
        [Фамилия_сотрудника],
        [Имя_сотрудника],
        [Отчество_сотрудника],
        [Дата_создания],
        [Дата_изменения]
    )
    VALUES (
        @Логин,
        @Пароль,
        @id_роли,
        @Фамилия_сотрудника,
        @Имя_сотрудника,
        @Отчество_сотрудника,
        GETDATE(), -- Явно устанавливаем дату создания
        GETDATE()  -- И дату изменения
    );
    
    SELECT SCOPE_IDENTITY() AS [id_Пользователя];
END
GO
/****** Object:  StoredProcedure [dbo].[sp_ОбновитьПользователя]    Script Date: 25.05.2025 21:20:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_ОбновитьПользователя]
    @id_Пользователя INT,
    @Логин NVARCHAR(80),
    @Пароль NVARCHAR(40),
    @id_роли INT,
    @Фамилия_сотрудника NVARCHAR(100) = NULL,
    @Имя_сотрудника NVARCHAR(100) = NULL,
    @Отчество_сотрудника NVARCHAR(100) = NULL
AS
BEGIN
    UPDATE Пользователи SET
        Логин = @Логин,
        Пароль = @Пароль,
        id_роли = @id_роли,
        Фамилия_сотрудника = @Фамилия_сотрудника,
        Имя_сотрудника = @Имя_сотрудника,
        Отчество_сотрудника = @Отчество_сотрудника,
        Дата_изменения = GETDATE() -- Явно обновляем дату изменения
    WHERE id_Пользователя = @id_Пользователя
END
GO
USE [master]
GO
ALTER DATABASE [БелкаФаворитСпичечнаяФабрикаБазаДанных] SET  READ_WRITE 
GO
