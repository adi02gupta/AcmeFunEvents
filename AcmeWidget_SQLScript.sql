-- Author : Aditya Gupta

USE [master]
GO

/****** Object:  Database [AcmeWidget]    Script Date: 19-11-2021 18:21:14 ******/
CREATE DATABASE [AcmeWidget]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'AcmeWidget', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\AcmeWidget.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'AcmeWidget_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\AcmeWidget_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [AcmeWidget].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [AcmeWidget] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [AcmeWidget] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [AcmeWidget] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [AcmeWidget] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [AcmeWidget] SET ARITHABORT OFF 
GO

ALTER DATABASE [AcmeWidget] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [AcmeWidget] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [AcmeWidget] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [AcmeWidget] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [AcmeWidget] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [AcmeWidget] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [AcmeWidget] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [AcmeWidget] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [AcmeWidget] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [AcmeWidget] SET  DISABLE_BROKER 
GO

ALTER DATABASE [AcmeWidget] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [AcmeWidget] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [AcmeWidget] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [AcmeWidget] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [AcmeWidget] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [AcmeWidget] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [AcmeWidget] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [AcmeWidget] SET RECOVERY FULL 
GO

ALTER DATABASE [AcmeWidget] SET  MULTI_USER 
GO

ALTER DATABASE [AcmeWidget] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [AcmeWidget] SET DB_CHAINING OFF 
GO

ALTER DATABASE [AcmeWidget] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [AcmeWidget] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO

ALTER DATABASE [AcmeWidget] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [AcmeWidget] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO

ALTER DATABASE [AcmeWidget] SET QUERY_STORE = OFF
GO

ALTER DATABASE [AcmeWidget] SET  READ_WRITE 
GO


USE [AcmeWidget]
GO

/****** Object:  Table [dbo].[Activity]    Script Date: 19-11-2021 18:22:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Activity](
	[ActivityID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[FitnessLevel] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[ActivityID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

Insert into [AcmeWidget].[dbo].[Activity] ([Name],FitnessLevel) values('Football','Medium')
Insert into [AcmeWidget].[dbo].[Activity] ([Name],FitnessLevel) values('Cricket','Low')
Insert into [AcmeWidget].[dbo].[Activity] ([Name],FitnessLevel) values('Foosball','Low')

SET ANSI_PADDING ON
GO

USE [AcmeWidget]
GO

/****** Object:  Table [dbo].[UserActivity]    Script Date: 19-11-2021 18:24:13 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[UserActivity](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](50) NULL,
	[LastName] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
	[Phone] [varchar](50) NULL,
	[ActivityID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[UserActivity]  WITH CHECK ADD FOREIGN KEY([ActivityID])
REFERENCES [dbo].[Activity] ([ActivityID])
GO

Insert into [AcmeWidget].[dbo].[UserActivity] (FirstName,LastName,Email,Phone,ActivityId) values('Aditya','Gupta','aditya.gupta02@outlook.com','519-588-9600',1)

GO
USE [master]
GO
ALTER DATABASE [Cooking] SET  READ_WRITE 
GO
