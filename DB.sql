USE [master]
GO
/****** Object:  Database [EventSchedule]    Script Date: 8/1/2023 11:48:31 AM ******/
CREATE DATABASE [EventSchedule]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'EventSchedule', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQL2022\MSSQL\DATA\EventSchedule.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'EventSchedule_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQL2022\MSSQL\DATA\EventSchedule_log.LDF' , SIZE = 20096KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [EventSchedule] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [EventSchedule].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [EventSchedule] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [EventSchedule] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [EventSchedule] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [EventSchedule] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [EventSchedule] SET ARITHABORT OFF 
GO
ALTER DATABASE [EventSchedule] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [EventSchedule] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [EventSchedule] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [EventSchedule] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [EventSchedule] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [EventSchedule] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [EventSchedule] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [EventSchedule] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [EventSchedule] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [EventSchedule] SET  ENABLE_BROKER 
GO
ALTER DATABASE [EventSchedule] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [EventSchedule] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [EventSchedule] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [EventSchedule] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [EventSchedule] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [EventSchedule] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [EventSchedule] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [EventSchedule] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [EventSchedule] SET  MULTI_USER 
GO
ALTER DATABASE [EventSchedule] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [EventSchedule] SET DB_CHAINING OFF 
GO
ALTER DATABASE [EventSchedule] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [EventSchedule] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [EventSchedule] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [EventSchedule] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [EventSchedule] SET QUERY_STORE = OFF
GO
USE [EventSchedule]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 8/1/2023 11:48:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblAdmin]    Script Date: 8/1/2023 11:48:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblAdmin](
	[admin_id] [int] IDENTITY(1,1) NOT NULL,
	[admin_name] [nvarchar](100) NULL,
	[admin_phone] [nvarchar](10) NULL,
	[admin_email] [nvarchar](100) NULL,
	[admin_password] [nvarchar](100) NULL,
	[admin_role] [nvarchar](50) NULL,
	[admin_status] [bit] NULL,
	[image_url] [nvarchar](max) NULL,
 CONSTRAINT [PK__tblClub__BCAD3DD90EA330E9] PRIMARY KEY CLUSTERED 
(
	[admin_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblCategory]    Script Date: 8/1/2023 11:48:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblCategory](
	[category_id] [int] IDENTITY(1,1) NOT NULL,
	[category_name] [nvarchar](50) NULL,
 CONSTRAINT [PK__tblCateg__D54EE9B4014935CB] PRIMARY KEY CLUSTERED 
(
	[category_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblEvent]    Script Date: 8/1/2023 11:48:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblEvent](
	[event_id] [int] IDENTITY(1,1) NOT NULL,
	[event_name] [nvarchar](50) NULL,
	[event_content] [nvarchar](max) NULL,
	[event_start] [datetime] NULL,
	[event_status] [bit] NULL,
	[category_id] [int] NULL,
	[location_id] [int] NULL,
	[admin_id] [int] NULL,
	[event_end] [datetime] NULL,
 CONSTRAINT [PK__tblEvent__2370F7270519C6AF] PRIMARY KEY CLUSTERED 
(
	[event_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblEventParticipated]    Script Date: 8/1/2023 11:48:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblEventParticipated](
	[event_id] [int] NOT NULL,
	[users_id] [int] NOT NULL,
	[date_participated] [datetime] NULL,
	[payment_status] [bit] NULL,
	[users_status] [bit] NULL,
 CONSTRAINT [PK__tblEvent__8DDA8A3308EA5793] PRIMARY KEY CLUSTERED 
(
	[event_id] ASC,
	[users_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblFeedback]    Script Date: 8/1/2023 11:48:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblFeedback](
	[feedback_id] [int] IDENTITY(1,1) NOT NULL,
	[comment] [nvarchar](max) NULL,
	[rating] [int] NULL,
	[created_time] [date] NULL,
	[event_id] [int] NULL,
	[users_id] [int] NULL,
 CONSTRAINT [PK__tblFeedb__7A6B2B8C0CBAE877] PRIMARY KEY CLUSTERED 
(
	[feedback_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblImage]    Script Date: 8/1/2023 11:48:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblImage](
	[image_id] [int] IDENTITY(1,1) NOT NULL,
	[image_url] [nvarchar](max) NULL,
	[event_id] [int] NULL,
	[image_name] [nvarchar](50) NULL,
 CONSTRAINT [PK__tblImage__DC9AC955108B795B] PRIMARY KEY CLUSTERED 
(
	[image_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblLocation]    Script Date: 8/1/2023 11:48:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblLocation](
	[location_id] [int] IDENTITY(1,1) NOT NULL,
	[location_detail] [nvarchar](max) NULL,
	[location_status] [char](10) NULL,
 CONSTRAINT [PK__tblLocat__771831EA145C0A3F] PRIMARY KEY CLUSTERED 
(
	[location_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblUser]    Script Date: 8/1/2023 11:48:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblUser](
	[users_id] [int] IDENTITY(1,1) NOT NULL,
	[users_name] [nvarchar](50) NULL,
	[users_email] [nvarchar](100) NULL,
	[users_phone] [nchar](10) NULL,
	[users_address] [nchar](100) NULL,
	[users_password] [nvarchar](50) NULL,
 CONSTRAINT [PK__tblUser__EAA7D14B1BFD2C07] PRIMARY KEY CLUSTERED 
(
	[users_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblVideo]    Script Date: 8/1/2023 11:48:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblVideo](
	[video_id] [int] IDENTITY(1,1) NOT NULL,
	[video_url] [nvarchar](max) NULL,
	[event_id] [int] NULL,
	[video_name] [nvarchar](50) NULL,
 CONSTRAINT [PK__tblVideo__E8F11E1007020F21] PRIMARY KEY CLUSTERED 
(
	[video_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tblAdmin] ON 

INSERT [dbo].[tblAdmin] ([admin_id], [admin_name], [admin_phone], [admin_email], [admin_password], [admin_role], [admin_status], [image_url]) VALUES (1, N'long', N'0818712174', N'thoanglong94@gmail.com ', N'123', N'admin', 1, N'1')
INSERT [dbo].[tblAdmin] ([admin_id], [admin_name], [admin_phone], [admin_email], [admin_password], [admin_role], [admin_status], [image_url]) VALUES (2, N'tan', N'0127372811', N'tan@gmail.com', N'123', N'club', 1, N'1')
SET IDENTITY_INSERT [dbo].[tblAdmin] OFF
GO
SET IDENTITY_INSERT [dbo].[tblCategory] ON 

INSERT [dbo].[tblCategory] ([category_id], [category_name]) VALUES (1, N'football')
INSERT [dbo].[tblCategory] ([category_id], [category_name]) VALUES (2, N'musical')
SET IDENTITY_INSERT [dbo].[tblCategory] OFF
GO
SET IDENTITY_INSERT [dbo].[tblEvent] ON 

INSERT [dbo].[tblEvent] ([event_id], [event_name], [event_content], [event_start], [event_status], [category_id], [location_id], [admin_id], [event_end]) VALUES (1, N'FootBall', N'this is football', CAST(N'2001-12-12T00:00:00.000' AS DateTime), 1, 1, 1, 1, CAST(N'2002-12-12T00:00:00.000' AS DateTime))
INSERT [dbo].[tblEvent] ([event_id], [event_name], [event_content], [event_start], [event_status], [category_id], [location_id], [admin_id], [event_end]) VALUES (2, N'this is not football', N'not real football', CAST(N'2023-01-01T22:24:00.000' AS DateTime), 1, 1, 1, 1, CAST(N'2023-03-02T22:24:00.000' AS DateTime))
INSERT [dbo].[tblEvent] ([event_id], [event_name], [event_content], [event_start], [event_status], [category_id], [location_id], [admin_id], [event_end]) VALUES (6, N'dancing', N'do you love dancing? Then you have come to the right place, join in our dancing event start this year', CAST(N'2023-01-01T22:24:00.000' AS DateTime), 1, 1, 1, 1, CAST(N'2023-03-02T22:24:00.000' AS DateTime))
INSERT [dbo].[tblEvent] ([event_id], [event_name], [event_content], [event_start], [event_status], [category_id], [location_id], [admin_id], [event_end]) VALUES (7, N'book selling', N'i love book, we all love book', CAST(N'2023-01-01T22:24:00.000' AS DateTime), 1, 2, 2, 2, CAST(N'2023-03-02T22:24:00.000' AS DateTime))
INSERT [dbo].[tblEvent] ([event_id], [event_name], [event_content], [event_start], [event_status], [category_id], [location_id], [admin_id], [event_end]) VALUES (8, N'laptop convention', N'laptop', CAST(N'2023-01-01T22:24:00.000' AS DateTime), 1, 2, 2, 2, CAST(N'2023-03-02T22:24:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[tblEvent] OFF
GO
INSERT [dbo].[tblEventParticipated] ([event_id], [users_id], [date_participated], [payment_status], [users_status]) VALUES (1, 1, CAST(N'2023-09-03T00:00:00.000' AS DateTime), 0, 1)
INSERT [dbo].[tblEventParticipated] ([event_id], [users_id], [date_participated], [payment_status], [users_status]) VALUES (1, 3, CAST(N'2023-03-11T22:32:08.863' AS DateTime), 0, 0)
INSERT [dbo].[tblEventParticipated] ([event_id], [users_id], [date_participated], [payment_status], [users_status]) VALUES (1, 6, CAST(N'2023-03-13T16:05:27.927' AS DateTime), 0, 0)
INSERT [dbo].[tblEventParticipated] ([event_id], [users_id], [date_participated], [payment_status], [users_status]) VALUES (2, 1, CAST(N'2023-03-11T22:36:48.160' AS DateTime), 0, 0)
INSERT [dbo].[tblEventParticipated] ([event_id], [users_id], [date_participated], [payment_status], [users_status]) VALUES (2, 3, CAST(N'2023-03-11T22:32:13.440' AS DateTime), 0, 0)
INSERT [dbo].[tblEventParticipated] ([event_id], [users_id], [date_participated], [payment_status], [users_status]) VALUES (6, 1, CAST(N'2023-03-11T23:31:27.800' AS DateTime), 0, 0)
INSERT [dbo].[tblEventParticipated] ([event_id], [users_id], [date_participated], [payment_status], [users_status]) VALUES (6, 3, CAST(N'2023-03-11T22:32:16.843' AS DateTime), 0, 0)
INSERT [dbo].[tblEventParticipated] ([event_id], [users_id], [date_participated], [payment_status], [users_status]) VALUES (7, 1, CAST(N'2023-03-11T23:31:32.527' AS DateTime), 0, 0)
INSERT [dbo].[tblEventParticipated] ([event_id], [users_id], [date_participated], [payment_status], [users_status]) VALUES (7, 3, CAST(N'2023-03-11T22:32:20.090' AS DateTime), 0, 0)
GO
SET IDENTITY_INSERT [dbo].[tblLocation] ON 

INSERT [dbo].[tblLocation] ([location_id], [location_detail], [location_status]) VALUES (1, N'this is a park', N'open      ')
INSERT [dbo].[tblLocation] ([location_id], [location_detail], [location_status]) VALUES (2, N'school floor 3', N'open      ')
SET IDENTITY_INSERT [dbo].[tblLocation] OFF
GO
SET IDENTITY_INSERT [dbo].[tblUser] ON 

INSERT [dbo].[tblUser] ([users_id], [users_name], [users_email], [users_phone], [users_address], [users_password]) VALUES (1, N'truong hoang long', N'some@gmail.com', N'123       ', N'123                                                                                                 ', N'1')
INSERT [dbo].[tblUser] ([users_id], [users_name], [users_email], [users_phone], [users_address], [users_password]) VALUES (3, N'truong Xuan Phu', N'phuxp1@gmail.com', N'0546345   ', N'dien bien phu                                                                                       ', N'1')
INSERT [dbo].[tblUser] ([users_id], [users_name], [users_email], [users_phone], [users_address], [users_password]) VALUES (4, N'tran minh duc', N'duc@gmail.com', N'123       ', N'123                                                                                                 ', N'1')
INSERT [dbo].[tblUser] ([users_id], [users_name], [users_email], [users_phone], [users_address], [users_password]) VALUES (6, N'bui the hien', N'hien@gmail.com', N'123       ', N'123                                                                                                 ', N'1')
SET IDENTITY_INSERT [dbo].[tblUser] OFF
GO
ALTER TABLE [dbo].[tblEvent]  WITH CHECK ADD  CONSTRAINT [FK_tblEvent_tblAdmin] FOREIGN KEY([admin_id])
REFERENCES [dbo].[tblAdmin] ([admin_id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tblEvent] CHECK CONSTRAINT [FK_tblEvent_tblAdmin]
GO
ALTER TABLE [dbo].[tblEvent]  WITH CHECK ADD  CONSTRAINT [FK_tblEvent_tblCategory] FOREIGN KEY([category_id])
REFERENCES [dbo].[tblCategory] ([category_id])
GO
ALTER TABLE [dbo].[tblEvent] CHECK CONSTRAINT [FK_tblEvent_tblCategory]
GO
ALTER TABLE [dbo].[tblEvent]  WITH CHECK ADD  CONSTRAINT [FK_tblEvent_tblLocation] FOREIGN KEY([location_id])
REFERENCES [dbo].[tblLocation] ([location_id])
GO
ALTER TABLE [dbo].[tblEvent] CHECK CONSTRAINT [FK_tblEvent_tblLocation]
GO
ALTER TABLE [dbo].[tblEventParticipated]  WITH CHECK ADD  CONSTRAINT [FK_tblEventParticipated_tblEvent] FOREIGN KEY([event_id])
REFERENCES [dbo].[tblEvent] ([event_id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tblEventParticipated] CHECK CONSTRAINT [FK_tblEventParticipated_tblEvent]
GO
ALTER TABLE [dbo].[tblEventParticipated]  WITH CHECK ADD  CONSTRAINT [FK_tblEventParticipated_tblUser] FOREIGN KEY([users_id])
REFERENCES [dbo].[tblUser] ([users_id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tblEventParticipated] CHECK CONSTRAINT [FK_tblEventParticipated_tblUser]
GO
ALTER TABLE [dbo].[tblFeedback]  WITH CHECK ADD  CONSTRAINT [FK_tblFeedback_tblEventParticipated] FOREIGN KEY([event_id], [users_id])
REFERENCES [dbo].[tblEventParticipated] ([event_id], [users_id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tblFeedback] CHECK CONSTRAINT [FK_tblFeedback_tblEventParticipated]
GO
ALTER TABLE [dbo].[tblImage]  WITH CHECK ADD  CONSTRAINT [FK_tblImage_tblEvent] FOREIGN KEY([event_id])
REFERENCES [dbo].[tblEvent] ([event_id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tblImage] CHECK CONSTRAINT [FK_tblImage_tblEvent]
GO
ALTER TABLE [dbo].[tblVideo]  WITH CHECK ADD  CONSTRAINT [FK_tblVideo_tblEvent] FOREIGN KEY([event_id])
REFERENCES [dbo].[tblEvent] ([event_id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tblVideo] CHECK CONSTRAINT [FK_tblVideo_tblEvent]
GO
USE [master]
GO
ALTER DATABASE [EventSchedule] SET  READ_WRITE 
GO
