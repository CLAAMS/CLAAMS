USE [master]
GO
/****** Object:  Database [claams]    Script Date: 1/26/2015 8:40:55 AM ******/
CREATE DATABASE [claams]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'claams', FILENAME = N'T:\Microsoft SQL Server\MSSQL11.CLAAMS\MSSQL\DATA\claams.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'claams_log', FILENAME = N'T:\Microsoft SQL Server\MSSQL11.CLAAMS\MSSQL\DATA\claams_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [claams] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [claams].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [claams] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [claams] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [claams] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [claams] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [claams] SET ARITHABORT OFF 
GO
ALTER DATABASE [claams] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [claams] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [claams] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [claams] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [claams] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [claams] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [claams] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [claams] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [claams] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [claams] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [claams] SET  DISABLE_BROKER 
GO
ALTER DATABASE [claams] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [claams] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [claams] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [claams] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [claams] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [claams] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [claams] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [claams] SET RECOVERY FULL 
GO
ALTER DATABASE [claams] SET  MULTI_USER 
GO
ALTER DATABASE [claams] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [claams] SET DB_CHAINING OFF 
GO
ALTER DATABASE [claams] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [claams] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'claams', N'ON'
GO
USE [claams]
GO
/****** Object:  Table [dbo].[Asset]    Script Date: 1/26/2015 8:40:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Asset](
	[assetID] [int] IDENTITY(1,1) NOT NULL,
	[CLATag] [varchar](max) NOT NULL,
	[Make] [varchar](max) NULL,
	[Model] [varchar](max) NULL,
	[Description] [varchar](max) NOT NULL,
	[SerialNumber] [varchar](max) NULL,
	[Status] [varchar](max) NOT NULL,
	[Notes] [varchar](max) NULL,
	[recordCreated] [datetime] NOT NULL,
	[recordModified] [datetime] NOT NULL,
 CONSTRAINT [PK_Asset] PRIMARY KEY CLUSTERED 
(
	[assetID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Asset_History]    Script Date: 1/26/2015 8:40:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Asset_History](
	[assetID] [int] NOT NULL,
	[CLATag] [varchar](max) NOT NULL,
	[Make] [varchar](max) NULL,
	[Model] [varchar](max) NULL,
	[Description] [varchar](max) NOT NULL,
	[SerialNumber] [varchar](max) NULL,
	[Status] [varchar](max) NOT NULL,
	[Notes] [varchar](max) NULL,
	[recordCreated] [datetime] NOT NULL,
	[recordModified] [datetime] NOT NULL,
	[assetHistoryID] [int] IDENTITY(1,1) NOT NULL,
	[ChangeTimeStamp] [datetime] NOT NULL,
 CONSTRAINT [PK_Asset_History] PRIMARY KEY CLUSTERED 
(
	[assetHistoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Asset_Recipient]    Script Date: 1/26/2015 8:40:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Asset_Recipient](
	[arID] [nchar](8) NOT NULL,
	[Title] [varchar](max) NOT NULL,
	[FirstName] [varchar](max) NOT NULL,
	[LastName] [varchar](max) NOT NULL,
	[EmailAddress] [varchar](max) NOT NULL,
	[Location] [varchar](max) NOT NULL,
	[Division] [varchar](max) NOT NULL,
	[PrimaryDeptAffiliation] [varchar](max) NOT NULL,
	[SecondaryDeptAffiliation] [varchar](max) NOT NULL,
	[PhoneNumber] [varchar](max) NOT NULL,
	[recordCreated] [datetime] NOT NULL,
	[recordModified] [datetime] NOT NULL,
 CONSTRAINT [PK_Asset_Recipient] PRIMARY KEY CLUSTERED 
(
	[arID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Asset_Template]    Script Date: 1/26/2015 8:40:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Asset_Template](
	[assetTemplateID] [int] IDENTITY(1,1) NOT NULL,
	[Make] [varchar](max) NULL,
	[Model] [varchar](max) NULL,
	[Description] [varchar](max) NULL,
	[recordModified] [datetime] NOT NULL,
	[recordCreated] [datetime] NOT NULL,
 CONSTRAINT [PK_Asset_Template] PRIMARY KEY CLUSTERED 
(
	[assetTemplateID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CLA_IT_Member]    Script Date: 1/26/2015 8:40:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CLA_IT_Member](
	[claID] [nchar](8) NOT NULL,
	[FirstName] [varchar](max) NOT NULL,
	[LastName] [varchar](max) NOT NULL,
	[OfficeLocation] [varchar](max) NOT NULL,
	[UserStatus] [varchar](max) NOT NULL,
	[EmailAddress] [varchar](max) NOT NULL,
	[recordCreated] [datetime] NOT NULL,
	[recordModified] [datetime] NOT NULL,
 CONSTRAINT [PK_CLA_IT_Member] PRIMARY KEY CLUSTERED 
(
	[claID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Email_Template]    Script Date: 1/26/2015 8:40:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Email_Template](
	[EmailCopy] [varchar](max) NOT NULL,
	[recordCreated] [datetime] NOT NULL,
	[recordModified] [datetime] NOT NULL,
	[EmailTemplateID] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_Email_Template] PRIMARY KEY CLUSTERED 
(
	[EmailTemplateID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SoS]    Script Date: 1/26/2015 8:40:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SoS](
	[sosID] [int] IDENTITY(1,1) NOT NULL,
	[assetID] [int] NOT NULL,
	[claID] [nchar](8) NOT NULL,
	[arID] [nchar](8) NOT NULL,
	[AssignmentPeriod] [varchar](max) NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[DateModified] [datetime] NOT NULL,
	[DateDue] [date] NOT NULL,
	[Status] [varchar](max) NOT NULL,
	[ImageFileName] [varchar](max) NOT NULL,
	[recordModified] [datetime] NOT NULL,
	[recordCreated] [datetime] NOT NULL,
 CONSTRAINT [PK_SoS] PRIMARY KEY CLUSTERED 
(
	[sosID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SoS_History]    Script Date: 1/26/2015 8:40:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SoS_History](
	[sosID] [int] NOT NULL,
	[sosHistoryID] [int] IDENTITY(1,1) NOT NULL,
	[assetID] [int] NOT NULL,
	[claID] [nchar](8) NOT NULL,
	[arID] [nchar](8) NOT NULL,
	[AssignmentPeriod] [varchar](max) NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[DateModified] [datetime] NOT NULL,
	[DateDue] [date] NOT NULL,
	[Status] [varchar](max) NOT NULL,
	[ImageFileName] [varchar](max) NOT NULL,
	[recordModified] [datetime] NOT NULL,
	[recordCreated] [datetime] NOT NULL,
 CONSTRAINT [PK_SoS_History] PRIMARY KEY CLUSTERED 
(
	[sosHistoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SoS_Template]    Script Date: 1/26/2015 8:40:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SoS_Template](
	[SoSCopy] [varchar](max) NOT NULL,
	[recordCreated] [datetime] NOT NULL,
	[recordModified] [datetime] NOT NULL,
	[SoSTemplateID] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_SoS_Template] PRIMARY KEY CLUSTERED 
(
	[SoSTemplateID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[Asset]  WITH CHECK ADD  CONSTRAINT [FK_Asset_Asset] FOREIGN KEY([assetID])
REFERENCES [dbo].[Asset] ([assetID])
GO
ALTER TABLE [dbo].[Asset] CHECK CONSTRAINT [FK_Asset_Asset]
GO
ALTER TABLE [dbo].[Asset_History]  WITH CHECK ADD  CONSTRAINT [FK_Asset_History_Asset] FOREIGN KEY([assetID])
REFERENCES [dbo].[Asset] ([assetID])
GO
ALTER TABLE [dbo].[Asset_History] CHECK CONSTRAINT [FK_Asset_History_Asset]
GO
ALTER TABLE [dbo].[SoS]  WITH CHECK ADD  CONSTRAINT [FK_SoS_Asset] FOREIGN KEY([assetID])
REFERENCES [dbo].[Asset] ([assetID])
GO
ALTER TABLE [dbo].[SoS] CHECK CONSTRAINT [FK_SoS_Asset]
GO
ALTER TABLE [dbo].[SoS]  WITH CHECK ADD  CONSTRAINT [FK_SoS_Asset_Recipient] FOREIGN KEY([arID])
REFERENCES [dbo].[Asset_Recipient] ([arID])
GO
ALTER TABLE [dbo].[SoS] CHECK CONSTRAINT [FK_SoS_Asset_Recipient]
GO
ALTER TABLE [dbo].[SoS]  WITH CHECK ADD  CONSTRAINT [FK_SoS_CLA_IT_Member] FOREIGN KEY([claID])
REFERENCES [dbo].[CLA_IT_Member] ([claID])
GO
ALTER TABLE [dbo].[SoS] CHECK CONSTRAINT [FK_SoS_CLA_IT_Member]
GO
ALTER TABLE [dbo].[SoS_History]  WITH CHECK ADD  CONSTRAINT [FK_SoS_History_SoS] FOREIGN KEY([sosID])
REFERENCES [dbo].[SoS] ([sosID])
GO
ALTER TABLE [dbo].[SoS_History] CHECK CONSTRAINT [FK_SoS_History_SoS]
GO
USE [master]
GO
ALTER DATABASE [claams] SET  READ_WRITE 
GO
