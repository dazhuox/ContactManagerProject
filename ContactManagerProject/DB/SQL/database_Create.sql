﻿USE [master]
GO
/****** Object:  Database [dotNetProject]    Script Date: 2022-12-20 5:20:30 PM ******/
CREATE DATABASE [dotNetProject]

GO
ALTER DATABASE [dotNetProject] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [dotNetProject].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [dotNetProject] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [dotNetProject] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [dotNetProject] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [dotNetProject] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [dotNetProject] SET ARITHABORT OFF 
GO
ALTER DATABASE [dotNetProject] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [dotNetProject] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [dotNetProject] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [dotNetProject] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [dotNetProject] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [dotNetProject] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [dotNetProject] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [dotNetProject] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [dotNetProject] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [dotNetProject] SET  DISABLE_BROKER 
GO
ALTER DATABASE [dotNetProject] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [dotNetProject] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [dotNetProject] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [dotNetProject] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [dotNetProject] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [dotNetProject] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [dotNetProject] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [dotNetProject] SET RECOVERY FULL 
GO
ALTER DATABASE [dotNetProject] SET  MULTI_USER 
GO
ALTER DATABASE [dotNetProject] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [dotNetProject] SET DB_CHAINING OFF 
GO
ALTER DATABASE [dotNetProject] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [dotNetProject] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [dotNetProject] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [dotNetProject] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'dotNetProject', N'ON'
GO
ALTER DATABASE [dotNetProject] SET QUERY_STORE = OFF
GO
USE [dotNetProject]
GO
/****** Object:  Table [dbo].[Address]    Script Date: 2022-12-20 5:20:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Address](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Contact_ID] [int] NOT NULL,
	[Type] [char](1) NOT NULL,
	[Country] [nvarchar](50) NOT NULL,
	[City] [nvarchar](50) NOT NULL,
	[Street] [nvarchar](50) NOT NULL,
	[AddressNumber] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_Address] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Contact]    Script Date: 2022-12-20 5:20:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contact](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ContactImage_ID] [int] NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[MiddleName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Salutation] [nvarchar](10) NULL,
	[CreateDateTime] [datetime] NOT NULL,
	[UpdateDateTime] [datetime] NOT NULL,
 CONSTRAINT [PK_Contact] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ContactImage]    Script Date: 2022-12-20 5:20:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ContactImage](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Image] [varbinary](max) NOT NULL,
 CONSTRAINT [PK_ContactImage] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Email]    Script Date: 2022-12-20 5:20:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Email](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Contact_ID] [int] NULL,
	[Type] [char](1) NOT NULL,
	[EmailAddress] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Email] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Phone]    Script Date: 2022-12-20 5:20:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Phone](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Contact_ID] [int] NOT NULL,
	[Type] [char](1) NOT NULL,
	[Number] [char](10) NOT NULL,
	[CreationDateTime] [datetime] NOT NULL,
	[UpdateDateTime] [datetime] NOT NULL,
 CONSTRAINT [PK_Phone] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Type]    Script Date: 2022-12-20 5:20:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Type](
	[Code] [char](1) NOT NULL,
	[Description] [nvarchar](30) NOT NULL,
 CONSTRAINT [PK_TypeCode] PRIMARY KEY CLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Contact] ADD  CONSTRAINT [DF_Contact_CreateDateTime]  DEFAULT (getutcdate()) FOR [CreateDateTime]
GO
ALTER TABLE [dbo].[Contact] ADD  CONSTRAINT [DF_Contact_UpdateDateTime]  DEFAULT (getutcdate()) FOR [UpdateDateTime]
GO
ALTER TABLE [dbo].[Phone] ADD  CONSTRAINT [DF_Phone_CreationDateTime]  DEFAULT (getutcdate()) FOR [CreationDateTime]
GO
ALTER TABLE [dbo].[Phone] ADD  CONSTRAINT [DF_Phone_UpdateDateTime]  DEFAULT (getutcdate()) FOR [UpdateDateTime]
GO
ALTER TABLE [dbo].[Address]  WITH CHECK ADD  CONSTRAINT [FK_Address_Address] FOREIGN KEY([Contact_ID])
REFERENCES [dbo].[Contact] ([ID])
GO
ALTER TABLE [dbo].[Address] CHECK CONSTRAINT [FK_Address_Address] ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Address]  WITH CHECK ADD  CONSTRAINT [FK_Address_Type] FOREIGN KEY([Type])
REFERENCES [dbo].[Type] ([Code])
GO
ALTER TABLE [dbo].[Address] CHECK CONSTRAINT [FK_Address_Type]
GO
ALTER TABLE [dbo].[Contact]  WITH CHECK ADD  CONSTRAINT [FK_Contact_ContactImage] FOREIGN KEY([ContactImage_ID])
REFERENCES [dbo].[ContactImage] ([ID])
GO
ALTER TABLE [dbo].[Contact] CHECK CONSTRAINT [FK_Contact_ContactImage] ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Email]  WITH CHECK ADD  CONSTRAINT [FK_Email_Contact] FOREIGN KEY([Contact_ID])
REFERENCES [dbo].[Contact] ([ID])
GO
ALTER TABLE [dbo].[Email] CHECK CONSTRAINT [FK_Email_Contact]  ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Email]  WITH CHECK ADD  CONSTRAINT [FK_Email_Type] FOREIGN KEY([Type])
REFERENCES [dbo].[Type] ([Code])
GO
ALTER TABLE [dbo].[Email] CHECK CONSTRAINT [FK_Email_Type]
GO
ALTER TABLE [dbo].[Phone]  WITH CHECK ADD  CONSTRAINT [FK_Phone_Contact] FOREIGN KEY([Contact_ID])
REFERENCES [dbo].[Contact] ([ID])
GO
ALTER TABLE [dbo].[Phone] CHECK CONSTRAINT [FK_Phone_Contact] ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Phone]  WITH CHECK ADD  CONSTRAINT [FK_Phone_Type] FOREIGN KEY([Type])
REFERENCES [dbo].[Type] ([Code])
GO
ALTER TABLE [dbo].[Phone] CHECK CONSTRAINT [FK_Phone_Type]
GO
USE [master]
GO
ALTER DATABASE [dotNetProject] SET  READ_WRITE 
GO
