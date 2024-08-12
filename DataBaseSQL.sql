USE [master]
GO
/****** Object:  Database [CommunityAdministration]    Script Date: 21/07/2023 10:13:03 ******/
CREATE DATABASE [CommunityAdministration]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CommunityAdministration', FILENAME = N'D:\SqlData\MSSQL15.PUPILS\MSSQL\DATA\CommunityAdministration.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'CommunityAdministration_log', FILENAME = N'D:\SqlData\MSSQL15.PUPILS\MSSQL\DATA\CommunityAdministration_log.ldf' , SIZE = 73728KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [CommunityAdministration] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CommunityAdministration].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CommunityAdministration] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CommunityAdministration] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CommunityAdministration] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CommunityAdministration] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CommunityAdministration] SET ARITHABORT OFF 
GO
ALTER DATABASE [CommunityAdministration] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CommunityAdministration] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CommunityAdministration] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CommunityAdministration] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CommunityAdministration] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CommunityAdministration] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CommunityAdministration] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CommunityAdministration] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CommunityAdministration] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CommunityAdministration] SET  ENABLE_BROKER 
GO
ALTER DATABASE [CommunityAdministration] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CommunityAdministration] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CommunityAdministration] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CommunityAdministration] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CommunityAdministration] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CommunityAdministration] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CommunityAdministration] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CommunityAdministration] SET RECOVERY FULL 
GO
ALTER DATABASE [CommunityAdministration] SET  MULTI_USER 
GO
ALTER DATABASE [CommunityAdministration] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CommunityAdministration] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CommunityAdministration] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CommunityAdministration] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [CommunityAdministration] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'CommunityAdministration', N'ON'
GO
ALTER DATABASE [CommunityAdministration] SET QUERY_STORE = OFF
GO
USE [CommunityAdministration]
GO
/****** Object:  Table [dbo].[Activity]    Script Date: 21/07/2023 10:13:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Activity](
	[ActivityId] [int] IDENTITY(1,1) NOT NULL,
	[CommunityAdministrationId] [nvarchar](15) NOT NULL,
	[ActivityName] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](200) NOT NULL,
	[Cost] [int] NULL,
	[TargetAudience] [nvarchar](50) NOT NULL,
	[EndTimeOfPreview] [date] NOT NULL,
	[maxParticipants] [int] NOT NULL,
	[Logo] [nvarchar](200) NULL,
	[Color] [nvarchar](10) NULL,
	[Day] [nchar](10) NULL,
	[BeginngTime] [nchar](5) NULL,
	[EndTime] [nchar](5) NULL,
	[Date] [nchar](10) NULL,
 CONSTRAINT [PK_Activity] PRIMARY KEY CLUSTERED 
(
	[ActivityId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CommunityAdministration]    Script Date: 21/07/2023 10:13:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CommunityAdministration](
	[CommunityAdministrationId] [nvarchar](15) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Address] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Phone] [nvarchar](20) NOT NULL,
	[Logo] [nvarchar](1000) NULL,
	[Color] [nchar](10) NULL,
 CONSTRAINT [PK_CommunityAdministration] PRIMARY KEY CLUSTERED 
(
	[CommunityAdministrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Course]    Script Date: 21/07/2023 10:13:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Course](
	[CourseId] [int] IDENTITY(1,1) NOT NULL,
	[CommunityAdministrationId] [nvarchar](15) NOT NULL,
	[courseName] [nvarchar](100) NOT NULL,
	[TargetAudience] [nvarchar](50) NOT NULL,
	[CostForLesson] [int] NOT NULL,
	[OperatorName] [nvarchar](50) NOT NULL,
	[MaxParticipants] [int] NOT NULL,
	[Remarks] [nvarchar](200) NULL,
	[EndTimeOfPreview] [date] NOT NULL,
	[EndTimeOfRegister] [date] NOT NULL,
	[Logo] [nvarchar](200) NULL,
	[Color] [nvarchar](10) NULL,
	[Day] [nchar](10) NULL,
	[BeginngTime] [nchar](5) NULL,
	[EndTime] [nchar](5) NULL,
	[CountOfRegistereds] [int] NULL,
 CONSTRAINT [PK_Course] PRIMARY KEY CLUSTERED 
(
	[CourseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CourseRegistered]    Script Date: 21/07/2023 10:13:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CourseRegistered](
	[CourseRegisteredId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](9) NOT NULL,
	[CourseId] [int] NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Age] [int] NOT NULL,
	[Phone] [nvarchar](20) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Paid] [bit] NULL,
 CONSTRAINT [PK_Courseregistered] PRIMARY KEY CLUSTERED 
(
	[CourseRegisteredId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Image]    Script Date: 21/07/2023 10:13:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Image](
	[FileName] [nvarchar](500) NULL,
	[FilePath] [nvarchar](500) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Library]    Script Date: 21/07/2023 10:13:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Library](
	[LibraryId] [int] IDENTITY(1,1) NOT NULL,
	[CommunityAdministrationId] [nvarchar](15) NOT NULL,
 CONSTRAINT [PK_Library] PRIMARY KEY CLUSTERED 
(
	[LibraryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Message]    Script Date: 21/07/2023 10:13:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Message](
	[MessageId] [int] IDENTITY(1,1) NOT NULL,
	[CourseId] [int] NULL,
	[ActivityId] [int] NULL,
	[LibraryId] [int] NULL,
	[PlayingCenterId] [int] NULL,
	[CommunityAdministrationId] [nvarchar](50) NULL,
	[MessageContent] [nvarchar](500) NOT NULL,
	[EndTimeOfMessage] [date] NOT NULL,
	[CreationDateOfMessage] [date] NULL,
 CONSTRAINT [PK_Message] PRIMARY KEY CLUSTERED 
(
	[MessageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ParticipantInActivity]    Script Date: 21/07/2023 10:13:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ParticipantInActivity](
	[ParticipantId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](9) NOT NULL,
	[ActivityId] [int] NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Phone] [nvarchar](20) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_ParticipantInActivity] PRIMARY KEY CLUSTERED 
(
	[ParticipantId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PlayingCenter]    Script Date: 21/07/2023 10:13:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PlayingCenter](
	[PlayingCenterId] [int] IDENTITY(1,1) NOT NULL,
	[CommunityAdministrationId] [nvarchar](15) NOT NULL,
 CONSTRAINT [PK_PlayingCenter] PRIMARY KEY CLUSTERED 
(
	[PlayingCenterId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UnitTimeOfLibrary]    Script Date: 21/07/2023 10:13:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UnitTimeOfLibrary](
	[UnitTimeId] [int] IDENTITY(1,1) NOT NULL,
	[LibraryId] [int] NOT NULL,
	[targetAudience] [nvarchar](50) NOT NULL,
	[Day] [nchar](10) NOT NULL,
	[BeginngTime] [nvarchar](5) NOT NULL,
	[EndTime] [nvarchar](5) NOT NULL,
 CONSTRAINT [PK_UnitTimeOfLibrary] PRIMARY KEY CLUSTERED 
(
	[UnitTimeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UnitTimeOfPlayingCenter]    Script Date: 21/07/2023 10:13:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UnitTimeOfPlayingCenter](
	[UnitTimeId] [int] IDENTITY(1,1) NOT NULL,
	[PlayingCenterId] [int] NOT NULL,
	[OperatorName] [nvarchar](50) NOT NULL,
	[Day] [nchar](10) NOT NULL,
	[BeginningTime] [nvarchar](5) NOT NULL,
	[EndTime] [nvarchar](5) NOT NULL,
 CONSTRAINT [PK_UnitTimeOfPlayingCenter] PRIMARY KEY CLUSTERED 
(
	[UnitTimeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 21/07/2023 10:13:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[UserId] [nvarchar](9) NOT NULL,
	[Password] [nvarchar](16) NOT NULL,
	[CommunityAdministrationId] [nvarchar](15) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Phone] [nvarchar](50) NOT NULL,
	[IsManager] [bit] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Activity] ON 

INSERT [dbo].[Activity] ([ActivityId], [CommunityAdministrationId], [ActivityName], [Description], [Cost], [TargetAudience], [EndTimeOfPreview], [maxParticipants], [Logo], [Color], [Day], [BeginngTime], [EndTime], [Date]) VALUES (1, N'1', N'f', N'f', 0, N'g', CAST(N'2023-03-05' AS Date), 50, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Activity] ([ActivityId], [CommunityAdministrationId], [ActivityName], [Description], [Cost], [TargetAudience], [EndTimeOfPreview], [maxParticipants], [Logo], [Color], [Day], [BeginngTime], [EndTime], [Date]) VALUES (2, N'1', N'string', N'string', 0, N'string', CAST(N'2023-03-01' AS Date), 0, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Activity] ([ActivityId], [CommunityAdministrationId], [ActivityName], [Description], [Cost], [TargetAudience], [EndTimeOfPreview], [maxParticipants], [Logo], [Color], [Day], [BeginngTime], [EndTime], [Date]) VALUES (3, N'1', N'string', N'string', 0, N'string', CAST(N'2023-03-03' AS Date), 0, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Activity] ([ActivityId], [CommunityAdministrationId], [ActivityName], [Description], [Cost], [TargetAudience], [EndTimeOfPreview], [maxParticipants], [Logo], [Color], [Day], [BeginngTime], [EndTime], [Date]) VALUES (6, N'1', N'ערב שירה', N'ערב שירה לנשים בהשתתפות טובהל''ה אלימלך והכנריות הקטנות', 0, N'נשים', CAST(N'2023-10-10' AS Date), 150, NULL, NULL, N'שלישי     ', N'20:00', N'22:30', NULL)
INSERT [dbo].[Activity] ([ActivityId], [CommunityAdministrationId], [ActivityName], [Description], [Cost], [TargetAudience], [EndTimeOfPreview], [maxParticipants], [Logo], [Color], [Day], [BeginngTime], [EndTime], [Date]) VALUES (7, N'1', N'סרט', N'עלה קטן - טלי אברהמי', 25, N'נערות', CAST(N'2023-12-12' AS Date), 150, NULL, NULL, N'רביעי     ', N'20:30', N'22:45', NULL)
INSERT [dbo].[Activity] ([ActivityId], [CommunityAdministrationId], [ActivityName], [Description], [Cost], [TargetAudience], [EndTimeOfPreview], [maxParticipants], [Logo], [Color], [Day], [BeginngTime], [EndTime], [Date]) VALUES (8, N'1', N'111', N'11', 11, N'נשים', CAST(N'2023-07-03' AS Date), 10, N'11111', N'111', N'1111      ', N'1111 ', N'1111 ', NULL)
INSERT [dbo].[Activity] ([ActivityId], [CommunityAdministrationId], [ActivityName], [Description], [Cost], [TargetAudience], [EndTimeOfPreview], [maxParticipants], [Logo], [Color], [Day], [BeginngTime], [EndTime], [Date]) VALUES (10, N'1', N'נסיעה למקומות הקדושים', N'יום שכולו תפילה בקבר הרשב"י במירון', 50, N'נשים', CAST(N'2023-07-23' AS Date), 100, NULL, NULL, N'ראשון     ', N'12:30', N'20:30', NULL)
INSERT [dbo].[Activity] ([ActivityId], [CommunityAdministrationId], [ActivityName], [Description], [Cost], [TargetAudience], [EndTimeOfPreview], [maxParticipants], [Logo], [Color], [Day], [BeginngTime], [EndTime], [Date]) VALUES (12, N'1', N'הרצאה', N'הרב צביאלי בן צור בנושאים אקטואליים', 0, N'נשים', CAST(N'2023-07-09' AS Date), 100, NULL, NULL, N'שני       ', N'20:00', N'22:00', N'כא'' בתמוז ')
INSERT [dbo].[Activity] ([ActivityId], [CommunityAdministrationId], [ActivityName], [Description], [Cost], [TargetAudience], [EndTimeOfPreview], [maxParticipants], [Logo], [Color], [Day], [BeginngTime], [EndTime], [Date]) VALUES (13, N'1', N'מתנפחים', N'יום אטרקטיבי במיוחד לקראת החופשה הגדולה', 0, N'בנים', CAST(N'2023-07-31' AS Date), 100, NULL, NULL, N'שני       ', N'16:00', N'19:00', N'י"ג באב   ')
SET IDENTITY_INSERT [dbo].[Activity] OFF
GO
INSERT [dbo].[CommunityAdministration] ([CommunityAdministrationId], [Name], [Address], [Email], [Phone], [Logo], [Color]) VALUES (N'', N'רמות א''', N'רביבים 10', N'k025796460@gmail.com', N'0527157342', NULL, NULL)
INSERT [dbo].[CommunityAdministration] ([CommunityAdministrationId], [Name], [Address], [Email], [Phone], [Logo], [Color]) VALUES (N'0088', N'הבוכרים', N'הבוכרים 12 ירושלים', N'habucharim10@gmail.com', N'026518597', NULL, NULL)
INSERT [dbo].[CommunityAdministration] ([CommunityAdministrationId], [Name], [Address], [Email], [Phone], [Logo], [Color]) VALUES (N'1', N'רמת שלמה', N'ברכת אברהם 15', N'mysecondhome@gmail.com', N'025337689', NULL, NULL)
INSERT [dbo].[CommunityAdministration] ([CommunityAdministrationId], [Name], [Address], [Email], [Phone], [Logo], [Color]) VALUES (N'1515', N'פסיפס', N'הזית 5', N'psifas@gmail.com', N'025332854', NULL, NULL)
INSERT [dbo].[CommunityAdministration] ([CommunityAdministrationId], [Name], [Address], [Email], [Phone], [Logo], [Color]) VALUES (N'2', N'רמות ג''', N'הרב אדלשטיין 13', N'mysecondHome@gmail.com', N'025337689', NULL, NULL)
INSERT [dbo].[CommunityAdministration] ([CommunityAdministrationId], [Name], [Address], [Email], [Phone], [Logo], [Color]) VALUES (N'4488', N'בית יערים', N'אזניים לתורה 5 קרית יערים', N'yahad@yearim.co.il', N'025338940', NULL, NULL)
INSERT [dbo].[CommunityAdministration] ([CommunityAdministrationId], [Name], [Address], [Email], [Phone], [Logo], [Color]) VALUES (N'452863120', N'אשכולות', N'מבוא חצרות 5 רמת אשכול', N'36214128290@mby.co.il', N'0527157342', N'ngull', N'אדום      ')
INSERT [dbo].[CommunityAdministration] ([CommunityAdministrationId], [Name], [Address], [Email], [Phone], [Logo], [Color]) VALUES (N'4775', N'חוויה-לי', N'חפץ חיים 4 קרית ספר', N'chavayali@gmail.com', N'089485672', NULL, NULL)
INSERT [dbo].[CommunityAdministration] ([CommunityAdministrationId], [Name], [Address], [Email], [Phone], [Logo], [Color]) VALUES (N'708090', N'נווה יעקב', N'כפר עברי 38', N'minalneve@gmail.com', N'026518930', NULL, NULL)
INSERT [dbo].[CommunityAdministration] ([CommunityAdministrationId], [Name], [Address], [Email], [Phone], [Logo], [Color]) VALUES (N'c', N'בית וגן', N'הפסגה', N'baitvagan678@gmail.com', N'026785421', NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[Course] ON 

INSERT [dbo].[Course] ([CourseId], [CommunityAdministrationId], [courseName], [TargetAudience], [CostForLesson], [OperatorName], [MaxParticipants], [Remarks], [EndTimeOfPreview], [EndTimeOfRegister], [Logo], [Color], [Day], [BeginngTime], [EndTime], [CountOfRegistereds]) VALUES (4, N'1', N'חלילית', N'נערות', 50, N'רבקה לוינסון', 5, N'מותנה במספר הנרשמות', CAST(N'2024-10-10' AS Date), CAST(N'2023-10-10' AS Date), NULL, NULL, N'ראשון     ', N'15:30', N'16:30', NULL)
INSERT [dbo].[Course] ([CourseId], [CommunityAdministrationId], [courseName], [TargetAudience], [CostForLesson], [OperatorName], [MaxParticipants], [Remarks], [EndTimeOfPreview], [EndTimeOfRegister], [Logo], [Color], [Day], [BeginngTime], [EndTime], [CountOfRegistereds]) VALUES (6, N'1', N'גיטרה', N'נערות', 45, N'יעל', 5, N'', CAST(N'2023-10-12' AS Date), CAST(N'2023-10-10' AS Date), NULL, NULL, N'שני       ', N'15:30', N'16:30', NULL)
INSERT [dbo].[Course] ([CourseId], [CommunityAdministrationId], [courseName], [TargetAudience], [CostForLesson], [OperatorName], [MaxParticipants], [Remarks], [EndTimeOfPreview], [EndTimeOfRegister], [Logo], [Color], [Day], [BeginngTime], [EndTime], [CountOfRegistereds]) VALUES (7, N'1', N'אומנות הבישול', N'נשים', 450, N'אביטל רוזובסקי', 10, N'העלות כוללת חומרים ', CAST(N'0001-01-01' AS Date), CAST(N'2023-10-10' AS Date), NULL, NULL, N'שלישי     ', N'15:30', N'16:30', NULL)
INSERT [dbo].[Course] ([CourseId], [CommunityAdministrationId], [courseName], [TargetAudience], [CostForLesson], [OperatorName], [MaxParticipants], [Remarks], [EndTimeOfPreview], [EndTimeOfRegister], [Logo], [Color], [Day], [BeginngTime], [EndTime], [CountOfRegistereds]) VALUES (12, N'1', N'התעמלות בריאותית', N'גיל הזהב', 35, N'זהבה גולדשטיין', 12, N'מותנה במספר הנרשמים', CAST(N'2023-07-03' AS Date), CAST(N'2023-06-25' AS Date), NULL, NULL, N'רביעי     ', N'15:30', N'16:30', NULL)
INSERT [dbo].[Course] ([CourseId], [CommunityAdministrationId], [courseName], [TargetAudience], [CostForLesson], [OperatorName], [MaxParticipants], [Remarks], [EndTimeOfPreview], [EndTimeOfRegister], [Logo], [Color], [Day], [BeginngTime], [EndTime], [CountOfRegistereds]) VALUES (13, N'1', N'יצירה', N'גיל הזהב', 45, N'חדוה פריד', 10, N'', CAST(N'2023-11-01' AS Date), CAST(N'2023-10-10' AS Date), NULL, NULL, N'חמישי     ', N'15:30', N'16:30', NULL)
INSERT [dbo].[Course] ([CourseId], [CommunityAdministrationId], [courseName], [TargetAudience], [CostForLesson], [OperatorName], [MaxParticipants], [Remarks], [EndTimeOfPreview], [EndTimeOfRegister], [Logo], [Color], [Day], [BeginngTime], [EndTime], [CountOfRegistereds]) VALUES (15, N'1', N'אלקטרוניקה', N'בנים', 250, N'משה לוי', 15, N'', CAST(N'2023-11-01' AS Date), CAST(N'2023-10-10' AS Date), NULL, NULL, N'חמישי     ', N'15:30', N'16:30', NULL)
INSERT [dbo].[Course] ([CourseId], [CommunityAdministrationId], [courseName], [TargetAudience], [CostForLesson], [OperatorName], [MaxParticipants], [Remarks], [EndTimeOfPreview], [EndTimeOfRegister], [Logo], [Color], [Day], [BeginngTime], [EndTime], [CountOfRegistereds]) VALUES (16, N'1', N'ריקוד', N'בנות', 50, N'אפרת נעימי', 10, N'הופעה בסוף שנה', CAST(N'2023-12-01' AS Date), CAST(N'2023-10-10' AS Date), NULL, NULL, N'ראשון     ', N'15:30', N'16:30', NULL)
INSERT [dbo].[Course] ([CourseId], [CommunityAdministrationId], [courseName], [TargetAudience], [CostForLesson], [OperatorName], [MaxParticipants], [Remarks], [EndTimeOfPreview], [EndTimeOfRegister], [Logo], [Color], [Day], [BeginngTime], [EndTime], [CountOfRegistereds]) VALUES (18, N'1', N'מחול עם מיכל', N'בנות', 45, N'מיכל סבג', 15, NULL, CAST(N'2023-12-01' AS Date), CAST(N'2023-10-10' AS Date), NULL, NULL, N'ראשון     ', N'15:30', N'16:30', NULL)
INSERT [dbo].[Course] ([CourseId], [CommunityAdministrationId], [courseName], [TargetAudience], [CostForLesson], [OperatorName], [MaxParticipants], [Remarks], [EndTimeOfPreview], [EndTimeOfRegister], [Logo], [Color], [Day], [BeginngTime], [EndTime], [CountOfRegistereds]) VALUES (69, N'1', N'התעמלות', N'נשים', 280, N'ניצה ולוסקי', 15, N'', CAST(N'2023-07-16' AS Date), CAST(N'2023-07-30' AS Date), NULL, NULL, N'רביעי     ', N'20:00', N'22:00', NULL)
INSERT [dbo].[Course] ([CourseId], [CommunityAdministrationId], [courseName], [TargetAudience], [CostForLesson], [OperatorName], [MaxParticipants], [Remarks], [EndTimeOfPreview], [EndTimeOfRegister], [Logo], [Color], [Day], [BeginngTime], [EndTime], [CountOfRegistereds]) VALUES (70, N'1', N'תפירה מקצועית', N'נשים', 500, N'זהבית שטרן', 8, N'יש להצטייד בבדים', CAST(N'2023-07-09' AS Date), CAST(N'2023-07-16' AS Date), NULL, NULL, N'שלישי     ', N'18:00', N'20:30', NULL)
INSERT [dbo].[Course] ([CourseId], [CommunityAdministrationId], [courseName], [TargetAudience], [CostForLesson], [OperatorName], [MaxParticipants], [Remarks], [EndTimeOfPreview], [EndTimeOfRegister], [Logo], [Color], [Day], [BeginngTime], [EndTime], [CountOfRegistereds]) VALUES (73, N'1', N'בישול', N'גיל הזהב', 450, N'שירה מצליח', 12, N'', CAST(N'2023-07-16' AS Date), CAST(N'2023-07-23' AS Date), NULL, NULL, N'רביעי     ', N'11:30', N'13:00', NULL)
INSERT [dbo].[Course] ([CourseId], [CommunityAdministrationId], [courseName], [TargetAudience], [CostForLesson], [OperatorName], [MaxParticipants], [Remarks], [EndTimeOfPreview], [EndTimeOfRegister], [Logo], [Color], [Day], [BeginngTime], [EndTime], [CountOfRegistereds]) VALUES (74, N'1', N'גינון', N'בנים', 340, N'קובי יצחקי', 8, N'', CAST(N'2023-07-23' AS Date), CAST(N'2023-07-31' AS Date), NULL, NULL, N'שלישי     ', N'17:30', N'18:30', 0)
INSERT [dbo].[Course] ([CourseId], [CommunityAdministrationId], [courseName], [TargetAudience], [CostForLesson], [OperatorName], [MaxParticipants], [Remarks], [EndTimeOfPreview], [EndTimeOfRegister], [Logo], [Color], [Day], [BeginngTime], [EndTime], [CountOfRegistereds]) VALUES (78, N'2', N'דרמה', N'בנות', 320, N'יונית צדוק', 25, N'לבעלות רקע קודם בתחום', CAST(N'2023-12-12' AS Date), CAST(N'2023-12-30' AS Date), NULL, NULL, N'רביעי     ', N'17:00', N'18:45', NULL)
SET IDENTITY_INSERT [dbo].[Course] OFF
GO
SET IDENTITY_INSERT [dbo].[CourseRegistered] ON 

INSERT [dbo].[CourseRegistered] ([CourseRegisteredId], [UserId], [CourseId], [FirstName], [LastName], [Age], [Phone], [Email], [Paid]) VALUES (22, N'213869407', 4, N'אביגיל', N'הריס', 35, N'0527157441', N'k@gmail.com', 1)
INSERT [dbo].[CourseRegistered] ([CourseRegisteredId], [UserId], [CourseId], [FirstName], [LastName], [Age], [Phone], [Email], [Paid]) VALUES (23, N'043464031', 4, N'חוי', N'מיאסניק', 32, N'025796460', N'k@gmail.com', 1)
INSERT [dbo].[CourseRegistered] ([CourseRegisteredId], [UserId], [CourseId], [FirstName], [LastName], [Age], [Phone], [Email], [Paid]) VALUES (25, N'213869407', 4, N'אביגיל', N'רוזובסקי', 20, N'0583225548', N'a@gmail.com', 1)
INSERT [dbo].[CourseRegistered] ([CourseRegisteredId], [UserId], [CourseId], [FirstName], [LastName], [Age], [Phone], [Email], [Paid]) VALUES (26, N'214128290', 4, N'מירי', N'קליינמן', 20, N'0527157441', N'K@gmail.com', 1)
INSERT [dbo].[CourseRegistered] ([CourseRegisteredId], [UserId], [CourseId], [FirstName], [LastName], [Age], [Phone], [Email], [Paid]) VALUES (27, N'043464031', 4, N'אלישבע', N'מיאסניק', 28, N'025796460', N'k@gmail.com', 1)
INSERT [dbo].[CourseRegistered] ([CourseRegisteredId], [UserId], [CourseId], [FirstName], [LastName], [Age], [Phone], [Email], [Paid]) VALUES (28, N'214128290', 6, N'אלישבע', N'יוגב', 21, N'0583240977', N'e0583240977@gmail.com', NULL)
INSERT [dbo].[CourseRegistered] ([CourseRegisteredId], [UserId], [CourseId], [FirstName], [LastName], [Age], [Phone], [Email], [Paid]) VALUES (29, N'043464031', 6, N'מיכל', N'כהן', 20, N'0534110618', N'michal@gmail.com', NULL)
INSERT [dbo].[CourseRegistered] ([CourseRegisteredId], [UserId], [CourseId], [FirstName], [LastName], [Age], [Phone], [Email], [Paid]) VALUES (31, N'043464031', 15, N'שייקי', N'קליינמן', 3, N'0527157342', N'k025796460@gmail.com', NULL)
INSERT [dbo].[CourseRegistered] ([CourseRegisteredId], [UserId], [CourseId], [FirstName], [LastName], [Age], [Phone], [Email], [Paid]) VALUES (32, N'043464031', 15, N'דניאל', N'רוזובסקי', 5, N'0583281453', N'y0527148057@gmail.com', NULL)
INSERT [dbo].[CourseRegistered] ([CourseRegisteredId], [UserId], [CourseId], [FirstName], [LastName], [Age], [Phone], [Email], [Paid]) VALUES (33, N'043464031', 7, N'ליבי', N'ולדן', 46, N'0533141477', N'l@gmail.com', 1)
INSERT [dbo].[CourseRegistered] ([CourseRegisteredId], [UserId], [CourseId], [FirstName], [LastName], [Age], [Phone], [Email], [Paid]) VALUES (34, N'043464031', 7, N'הדס', N'גרינהויז', 43, N'0523393100', N'H@gmail.com', 1)
INSERT [dbo].[CourseRegistered] ([CourseRegisteredId], [UserId], [CourseId], [FirstName], [LastName], [Age], [Phone], [Email], [Paid]) VALUES (35, N'043464031', 7, N'אפרת', N'רוזובסקי', 42, N'0527164162', N'5879552@gmail.com', 1)
INSERT [dbo].[CourseRegistered] ([CourseRegisteredId], [UserId], [CourseId], [FirstName], [LastName], [Age], [Phone], [Email], [Paid]) VALUES (36, N'043464031', 7, N'הינדי', N'מיאסניק', 42, N'0548465304', N'hindi@gmail.com', 1)
INSERT [dbo].[CourseRegistered] ([CourseRegisteredId], [UserId], [CourseId], [FirstName], [LastName], [Age], [Phone], [Email], [Paid]) VALUES (37, N'043464031', 7, N'רותי', N'הורביץ', 24, N'0556789646', N'RUTI@gmail.com', 1)
INSERT [dbo].[CourseRegistered] ([CourseRegisteredId], [UserId], [CourseId], [FirstName], [LastName], [Age], [Phone], [Email], [Paid]) VALUES (38, N'043464031', 7, N'שולמית', N'סומפולינסקי', 32, N'0548464638', N'Sulamit@gmail.com', 1)
INSERT [dbo].[CourseRegistered] ([CourseRegisteredId], [UserId], [CourseId], [FirstName], [LastName], [Age], [Phone], [Email], [Paid]) VALUES (39, N'043464031', 6, N'מלי', N'קליינמן', 14, N'0527157342', N'k025796460@gmail.com', NULL)
INSERT [dbo].[CourseRegistered] ([CourseRegisteredId], [UserId], [CourseId], [FirstName], [LastName], [Age], [Phone], [Email], [Paid]) VALUES (40, N'043464031', 6, N'רבקי', N'קליינמן', 12, N'0527157342', N'k025796460@gmail.com', NULL)
INSERT [dbo].[CourseRegistered] ([CourseRegisteredId], [UserId], [CourseId], [FirstName], [LastName], [Age], [Phone], [Email], [Paid]) VALUES (41, N'043464031', 6, N'תמר', N'ולדן', 20, N'0527149764', N't0527149764@mby.co.il', NULL)
INSERT [dbo].[CourseRegistered] ([CourseRegisteredId], [UserId], [CourseId], [FirstName], [LastName], [Age], [Phone], [Email], [Paid]) VALUES (42, N'043464031', 6, N'יעל', N'קליינמן', 19, N'0527528963', N'l@gmail.com', NULL)
INSERT [dbo].[CourseRegistered] ([CourseRegisteredId], [UserId], [CourseId], [FirstName], [LastName], [Age], [Phone], [Email], [Paid]) VALUES (43, N'043464031', 4, N'נועה', N'רוזובסקי', 15, N'0535566061', N'noa0535566061@gmail.com', 1)
INSERT [dbo].[CourseRegistered] ([CourseRegisteredId], [UserId], [CourseId], [FirstName], [LastName], [Age], [Phone], [Email], [Paid]) VALUES (44, N'043464031', 12, N'שרה', N'מיאסניק', 70, N'0527102779', N'S0527102779@gmail.com', NULL)
INSERT [dbo].[CourseRegistered] ([CourseRegisteredId], [UserId], [CourseId], [FirstName], [LastName], [Age], [Phone], [Email], [Paid]) VALUES (45, N'043464031', 18, N'אסתי', N'קליינמן', 5, N'0527157342', N'k025796460@gmail.com', NULL)
INSERT [dbo].[CourseRegistered] ([CourseRegisteredId], [UserId], [CourseId], [FirstName], [LastName], [Age], [Phone], [Email], [Paid]) VALUES (46, N'043464031', 15, N'ישראל', N'קליינמן', 10, N'0527157342', N'k025796460@gmail.com', NULL)
INSERT [dbo].[CourseRegistered] ([CourseRegisteredId], [UserId], [CourseId], [FirstName], [LastName], [Age], [Phone], [Email], [Paid]) VALUES (47, N'043464031', 15, N'יונתן', N'קליינמן', 8, N'0527157342', N'k025796460@gmail.com', NULL)
INSERT [dbo].[CourseRegistered] ([CourseRegisteredId], [UserId], [CourseId], [FirstName], [LastName], [Age], [Phone], [Email], [Paid]) VALUES (48, N'043464031', 16, N'רחל', N'קליינמן', 8, N'0527157342', N'k025796460@gmail.com', 1)
INSERT [dbo].[CourseRegistered] ([CourseRegisteredId], [UserId], [CourseId], [FirstName], [LastName], [Age], [Phone], [Email], [Paid]) VALUES (49, N'043464031', 16, N'אסתר', N'קליינמן', 5, N'0527157342', N'k025796460@gmail.com', 1)
INSERT [dbo].[CourseRegistered] ([CourseRegisteredId], [UserId], [CourseId], [FirstName], [LastName], [Age], [Phone], [Email], [Paid]) VALUES (50, N'043464031', 18, N'מיכל', N'פרובר', 8, N'0527157894', N'36214128290@mby.co.il', NULL)
INSERT [dbo].[CourseRegistered] ([CourseRegisteredId], [UserId], [CourseId], [FirstName], [LastName], [Age], [Phone], [Email], [Paid]) VALUES (51, N'043464031', 18, N'יעל', N'רוזובסקי', 9, N'0583281453', N'5879552@gmail.com', NULL)
INSERT [dbo].[CourseRegistered] ([CourseRegisteredId], [UserId], [CourseId], [FirstName], [LastName], [Age], [Phone], [Email], [Paid]) VALUES (52, N'043464031', 18, N'יעל', N'וינטרוב', 8, N'0534110618', N'l@gmail.com', NULL)
INSERT [dbo].[CourseRegistered] ([CourseRegisteredId], [UserId], [CourseId], [FirstName], [LastName], [Age], [Phone], [Email], [Paid]) VALUES (53, N'043464031', 18, N'שרי', N'מיאסניק', 13, N'0527157894', N'36214128290@mby.co.il', NULL)
INSERT [dbo].[CourseRegistered] ([CourseRegisteredId], [UserId], [CourseId], [FirstName], [LastName], [Age], [Phone], [Email], [Paid]) VALUES (57, N'214128290', 4, N'צילה', N'מיאסניק', 38, N'5796460', N'miri57441@gmail.com', 1)
INSERT [dbo].[CourseRegistered] ([CourseRegisteredId], [UserId], [CourseId], [FirstName], [LastName], [Age], [Phone], [Email], [Paid]) VALUES (58, N'987654321', 15, N'יעל', N'דומב', 41, N'0534110618', N'k025796460@gmail.com', NULL)
INSERT [dbo].[CourseRegistered] ([CourseRegisteredId], [UserId], [CourseId], [FirstName], [LastName], [Age], [Phone], [Email], [Paid]) VALUES (64, N'987654321', 15, N'נעמי', N'ברונר', 28, N'0527109119', N'nomimias@gmail.com', NULL)
INSERT [dbo].[CourseRegistered] ([CourseRegisteredId], [UserId], [CourseId], [FirstName], [LastName], [Age], [Phone], [Email], [Paid]) VALUES (66, N'987654321', 4, N'חיה', N'מיאסניק', 22, N'0533192141', N'C0533192141@gmail.com', 1)
INSERT [dbo].[CourseRegistered] ([CourseRegisteredId], [UserId], [CourseId], [FirstName], [LastName], [Age], [Phone], [Email], [Paid]) VALUES (67, N'987654321', 18, N'שושי', N'מנקס', 50, N'0527169455', N's0527169455@gmail.com', NULL)
INSERT [dbo].[CourseRegistered] ([CourseRegisteredId], [UserId], [CourseId], [FirstName], [LastName], [Age], [Phone], [Email], [Paid]) VALUES (68, N'987654321', 18, N'חיה', N'רוזובסקי', 44, N'0528778794', N'c0528778794@gmail.com', NULL)
INSERT [dbo].[CourseRegistered] ([CourseRegisteredId], [UserId], [CourseId], [FirstName], [LastName], [Age], [Phone], [Email], [Paid]) VALUES (70, N'987654321', 18, N'פניני', N'שכטר', 40, N'0587633838', N'p0587633838@gmail.com', NULL)
INSERT [dbo].[CourseRegistered] ([CourseRegisteredId], [UserId], [CourseId], [FirstName], [LastName], [Age], [Phone], [Email], [Paid]) VALUES (72, N'987654321', 13, N'חיה', N'דונט', 120, N'0556769322', N'chaya9322@gmail.com', NULL)
INSERT [dbo].[CourseRegistered] ([CourseRegisteredId], [UserId], [CourseId], [FirstName], [LastName], [Age], [Phone], [Email], [Paid]) VALUES (73, N'214128290', 6, N'ציבי', N'בירנבוים', 20, N'0527143238', N'tzivi238@gmail.com', NULL)
INSERT [dbo].[CourseRegistered] ([CourseRegisteredId], [UserId], [CourseId], [FirstName], [LastName], [Age], [Phone], [Email], [Paid]) VALUES (74, N'214128290', 16, N'יהודית', N'כנרי', 3, N'0527157441', N'dvora@gmail.com', NULL)
INSERT [dbo].[CourseRegistered] ([CourseRegisteredId], [UserId], [CourseId], [FirstName], [LastName], [Age], [Phone], [Email], [Paid]) VALUES (76, N'214128290', 16, N'שירה', N'אלבוגן', 10, N'0527157441', N'miri57441@gmail.com', 0)
INSERT [dbo].[CourseRegistered] ([CourseRegisteredId], [UserId], [CourseId], [FirstName], [LastName], [Age], [Phone], [Email], [Paid]) VALUES (77, N'214128290', 16, N'מיכל', N'פרובר', 8, N'0527157441', N'miri57441@gmail.com', 1)
INSERT [dbo].[CourseRegistered] ([CourseRegisteredId], [UserId], [CourseId], [FirstName], [LastName], [Age], [Phone], [Email], [Paid]) VALUES (78, N'043464031', 7, N'יהודית', N'קליינמן', 41, N'0527157342', N'k025796460@gmail.com', 0)
INSERT [dbo].[CourseRegistered] ([CourseRegisteredId], [UserId], [CourseId], [FirstName], [LastName], [Age], [Phone], [Email], [Paid]) VALUES (79, N'112211221', 7, N'רבקי', N'קוט', 45, N'089496460', N'rkot@gmail.com', 0)
INSERT [dbo].[CourseRegistered] ([CourseRegisteredId], [UserId], [CourseId], [FirstName], [LastName], [Age], [Phone], [Email], [Paid]) VALUES (86, N'043464031', 7, N'נעמי', N'מנת', 30, N'0504169852', N'neomimenat@gmail.com', 1)
INSERT [dbo].[CourseRegistered] ([CourseRegisteredId], [UserId], [CourseId], [FirstName], [LastName], [Age], [Phone], [Email], [Paid]) VALUES (87, N'043464031', 7, N'אפרת', N'ברון', 26, N'0504145775', N'erb5775@gmail.com', 1)
INSERT [dbo].[CourseRegistered] ([CourseRegisteredId], [UserId], [CourseId], [FirstName], [LastName], [Age], [Phone], [Email], [Paid]) VALUES (88, N'123456789', 12, N'חנה', N'אלבוגן', 64, N'0504126467', N'chani.elbogen@gmail.com', 1)
INSERT [dbo].[CourseRegistered] ([CourseRegisteredId], [UserId], [CourseId], [FirstName], [LastName], [Age], [Phone], [Email], [Paid]) VALUES (90, N'043464031', 12, N'נחמה', N'קליינמן', 76, N'025332446', N'k025796460@gmail.com', 1)
INSERT [dbo].[CourseRegistered] ([CourseRegisteredId], [UserId], [CourseId], [FirstName], [LastName], [Age], [Phone], [Email], [Paid]) VALUES (91, N'043464031', 12, N'רונית', N'מלאכי', 65, N'0527157895', N'ronit@gmail.com', 0)
INSERT [dbo].[CourseRegistered] ([CourseRegisteredId], [UserId], [CourseId], [FirstName], [LastName], [Age], [Phone], [Email], [Paid]) VALUES (92, N'987654321', 12, N'אסתר', N'כהנא', 67, N'0527186920', N'esti@gmail.com', 0)
INSERT [dbo].[CourseRegistered] ([CourseRegisteredId], [UserId], [CourseId], [FirstName], [LastName], [Age], [Phone], [Email], [Paid]) VALUES (93, N'987654321', 70, N'לאה', N'גרין', 35, N'0527157894', N'l@gmail.com', 1)
INSERT [dbo].[CourseRegistered] ([CourseRegisteredId], [UserId], [CourseId], [FirstName], [LastName], [Age], [Phone], [Email], [Paid]) VALUES (94, N'987654321', 15, N'שימי', N'לוונטל', 11, N'0527157441', N'levental@gmail.com', 1)
INSERT [dbo].[CourseRegistered] ([CourseRegisteredId], [UserId], [CourseId], [FirstName], [LastName], [Age], [Phone], [Email], [Paid]) VALUES (95, N'987654321', 15, N'אלעזר', N'ברנשטיין', 10, N'0527186974', N'ber@gmail.com', 1)
INSERT [dbo].[CourseRegistered] ([CourseRegisteredId], [UserId], [CourseId], [FirstName], [LastName], [Age], [Phone], [Email], [Paid]) VALUES (96, N'214128290', 74, N'יאיר ', N'אלבוגן', 8, N'0548415907', N'hadassa@gmail.com', 1)
INSERT [dbo].[CourseRegistered] ([CourseRegisteredId], [UserId], [CourseId], [FirstName], [LastName], [Age], [Phone], [Email], [Paid]) VALUES (97, N'214128290', 74, N'רפאל', N'אלבוגן', 9, N'0527102305', N'estielbogen@gmail.com', 0)
INSERT [dbo].[CourseRegistered] ([CourseRegisteredId], [UserId], [CourseId], [FirstName], [LastName], [Age], [Phone], [Email], [Paid]) VALUES (98, N'987654321', 74, N'איציק', N'פלונצק', 9, N'0504104399', N'bina@gmail.com', 1)
INSERT [dbo].[CourseRegistered] ([CourseRegisteredId], [UserId], [CourseId], [FirstName], [LastName], [Age], [Phone], [Email], [Paid]) VALUES (99, N'987654321', 15, N'יהודית', N'קליינמן', 10, N'0527157342', N'36214128290@mby.co.il', 1)
INSERT [dbo].[CourseRegistered] ([CourseRegisteredId], [UserId], [CourseId], [FirstName], [LastName], [Age], [Phone], [Email], [Paid]) VALUES (100, N'987654321', 74, N'יהודית', N'קליינמן', 10, N'0527157342', N'k025796460@gmail.com', 1)
INSERT [dbo].[CourseRegistered] ([CourseRegisteredId], [UserId], [CourseId], [FirstName], [LastName], [Age], [Phone], [Email], [Paid]) VALUES (101, N'987654321', 74, N'אבי', N'מנת', 9, N'0504129382', N'neomimenat@gmail.com', 0)
INSERT [dbo].[CourseRegistered] ([CourseRegisteredId], [UserId], [CourseId], [FirstName], [LastName], [Age], [Phone], [Email], [Paid]) VALUES (102, N'214128290', 78, N'יהודית', N'פלונצק', 10, N'0504104399', N'bina@gmail.com', 1)
INSERT [dbo].[CourseRegistered] ([CourseRegisteredId], [UserId], [CourseId], [FirstName], [LastName], [Age], [Phone], [Email], [Paid]) VALUES (107, N'987654321', 70, N'רחלי', N'סרדס', 20, N'0527157894', N'36214128290@mby.co.il', 1)
INSERT [dbo].[CourseRegistered] ([CourseRegisteredId], [UserId], [CourseId], [FirstName], [LastName], [Age], [Phone], [Email], [Paid]) VALUES (108, N'987654321', 13, N'שרה', N'כהן', 75, N'0534110618', N'michal@gmail.com', 1)
INSERT [dbo].[CourseRegistered] ([CourseRegisteredId], [UserId], [CourseId], [FirstName], [LastName], [Age], [Phone], [Email], [Paid]) VALUES (109, N'123456789', 13, N'יעל', N'לוין', 69, N'0527157441', N'l@gmail.com', 1)
SET IDENTITY_INSERT [dbo].[CourseRegistered] OFF
GO
SET IDENTITY_INSERT [dbo].[Library] ON 

INSERT [dbo].[Library] ([LibraryId], [CommunityAdministrationId]) VALUES (1, N'1')
INSERT [dbo].[Library] ([LibraryId], [CommunityAdministrationId]) VALUES (2, N'2')
INSERT [dbo].[Library] ([LibraryId], [CommunityAdministrationId]) VALUES (3, N'1')
INSERT [dbo].[Library] ([LibraryId], [CommunityAdministrationId]) VALUES (4, N'1')
INSERT [dbo].[Library] ([LibraryId], [CommunityAdministrationId]) VALUES (5, N'2')
SET IDENTITY_INSERT [dbo].[Library] OFF
GO
SET IDENTITY_INSERT [dbo].[Message] ON 

INSERT [dbo].[Message] ([MessageId], [CourseId], [ActivityId], [LibraryId], [PlayingCenterId], [CommunityAdministrationId], [MessageContent], [EndTimeOfMessage], [CreationDateOfMessage]) VALUES (12, 12, 0, 0, 0, N'0', N'ביום ראשון הקרוב לא יתקיים חוג עקב מזג האויר הסוער הצפוי', CAST(N'2023-10-12' AS Date), NULL)
INSERT [dbo].[Message] ([MessageId], [CourseId], [ActivityId], [LibraryId], [PlayingCenterId], [CommunityAdministrationId], [MessageContent], [EndTimeOfMessage], [CreationDateOfMessage]) VALUES (14, 0, 6, 0, 0, N'0', N'ערב השירה יתחיל בשעה 20:30 ולא כפי שפורסם', CAST(N'2023-12-20' AS Date), NULL)
INSERT [dbo].[Message] ([MessageId], [CourseId], [ActivityId], [LibraryId], [PlayingCenterId], [CommunityAdministrationId], [MessageContent], [EndTimeOfMessage], [CreationDateOfMessage]) VALUES (17, 4, 0, 0, 0, N'', N'ביום ראשון הקרוב לא יתקיים חוג. עמכן הסליחה.', CAST(N'2023-10-20' AS Date), NULL)
INSERT [dbo].[Message] ([MessageId], [CourseId], [ActivityId], [LibraryId], [PlayingCenterId], [CommunityAdministrationId], [MessageContent], [EndTimeOfMessage], [CreationDateOfMessage]) VALUES (24, 7, 0, 0, 0, N'0', N'ביום רביעי י"ז בתמוז לא יתקיים חוג', CAST(N'2023-10-07' AS Date), NULL)
INSERT [dbo].[Message] ([MessageId], [CourseId], [ActivityId], [LibraryId], [PlayingCenterId], [CommunityAdministrationId], [MessageContent], [EndTimeOfMessage], [CreationDateOfMessage]) VALUES (26, 7, 0, 0, 0, N'0', N'ביום ראשון כ'' בתמוז החוג יתחיל בשעה 16:00 ', CAST(N'2023-12-12' AS Date), NULL)
INSERT [dbo].[Message] ([MessageId], [CourseId], [ActivityId], [LibraryId], [PlayingCenterId], [CommunityAdministrationId], [MessageContent], [EndTimeOfMessage], [CreationDateOfMessage]) VALUES (34, 7, 0, 0, 0, N'', N'לצערנו, לאחרונה התקבלו תלונות על השארת החדר בבלגן ובחוסר ניקיון. על כן, אנו מעוררים שנית על החובה המוטלת על משתתפות החוג לנקות ולארגן את החדר בסיום החוג. במידה ולא נראה שיפור בענין, נאלץ לנקוט בצעדים חריפים יותר. בתקווה להבנה ושיתוף פעולה.', CAST(N'2023-07-24' AS Date), NULL)
INSERT [dbo].[Message] ([MessageId], [CourseId], [ActivityId], [LibraryId], [PlayingCenterId], [CommunityAdministrationId], [MessageContent], [EndTimeOfMessage], [CreationDateOfMessage]) VALUES (39, 12, 0, 0, 0, N'', N'משתתפות יקרות שמנה לב, החוג עומד להסתיים בקרוב. תיתכן אפשרות להאריך את פעילותו לחודש נוסף. המעונינות תפנינה לורדית במזכירות, או למייל של המינהל.', CAST(N'2023-07-23' AS Date), CAST(N'2023-07-09' AS Date))
INSERT [dbo].[Message] ([MessageId], [CourseId], [ActivityId], [LibraryId], [PlayingCenterId], [CommunityAdministrationId], [MessageContent], [EndTimeOfMessage], [CreationDateOfMessage]) VALUES (40, 6, 0, 0, 0, N'', N'עקב השיפוצים הצפויים באגף החדש, החוג יתקיים החל מהשבוע הבא בחדר 21 באגף הישן.', CAST(N'2023-07-23' AS Date), CAST(N'2023-07-09' AS Date))
INSERT [dbo].[Message] ([MessageId], [CourseId], [ActivityId], [LibraryId], [PlayingCenterId], [CommunityAdministrationId], [MessageContent], [EndTimeOfMessage], [CreationDateOfMessage]) VALUES (46, 7, 0, 0, 0, N'', N'בתשעת הימים לא יתקיימו חוגים.', CAST(N'2023-07-23' AS Date), CAST(N'2023-07-12' AS Date))
SET IDENTITY_INSERT [dbo].[Message] OFF
GO
SET IDENTITY_INSERT [dbo].[ParticipantInActivity] ON 

INSERT [dbo].[ParticipantInActivity] ([ParticipantId], [UserId], [ActivityId], [FirstName], [LastName], [Phone], [Email]) VALUES (11, N'214128290', 1, N'd', N'd', N'd', N'd')
INSERT [dbo].[ParticipantInActivity] ([ParticipantId], [UserId], [ActivityId], [FirstName], [LastName], [Phone], [Email]) VALUES (12, N'043464031', 6, N'מרים', N'קליינמן', N'0527157441', N'm7157441@gmail.com')
INSERT [dbo].[ParticipantInActivity] ([ParticipantId], [UserId], [ActivityId], [FirstName], [LastName], [Phone], [Email]) VALUES (13, N'987654321', 1, N'שרה', N'כהן', N'0583204192', N'avigail@gmail.com')
INSERT [dbo].[ParticipantInActivity] ([ParticipantId], [UserId], [ActivityId], [FirstName], [LastName], [Phone], [Email]) VALUES (14, N'121412829', 7, N'מיכל', N'מיאסניק', N'2222222', N'k025796460@gmail.com')
INSERT [dbo].[ParticipantInActivity] ([ParticipantId], [UserId], [ActivityId], [FirstName], [LastName], [Phone], [Email]) VALUES (15, N'214128290', 6, N'יהודית', N'מיאסניק', N'0534110618', N'36214128290@mby.co.il')
INSERT [dbo].[ParticipantInActivity] ([ParticipantId], [UserId], [ActivityId], [FirstName], [LastName], [Phone], [Email]) VALUES (16, N'987654321', 6, N'יהודית', N'כהן', N'0527157342', N'k025796460@gmail.com')
INSERT [dbo].[ParticipantInActivity] ([ParticipantId], [UserId], [ActivityId], [FirstName], [LastName], [Phone], [Email]) VALUES (17, N'987654321', 6, N'מיכל', N'כהן', N'0527157894', N'michal@gmail.com')
INSERT [dbo].[ParticipantInActivity] ([ParticipantId], [UserId], [ActivityId], [FirstName], [LastName], [Phone], [Email]) VALUES (18, N'987654321', 6, N'מיכל', N'מיאסניק', N'0527528963', N'36214128290@mby.co.il')
INSERT [dbo].[ParticipantInActivity] ([ParticipantId], [UserId], [ActivityId], [FirstName], [LastName], [Phone], [Email]) VALUES (19, N'987654321', 13, N'ישראל', N'קליינמן', N'0527157342', N'k025796460@gmail.com')
INSERT [dbo].[ParticipantInActivity] ([ParticipantId], [UserId], [ActivityId], [FirstName], [LastName], [Phone], [Email]) VALUES (20, N'987654321', 13, N'שייקי', N'קליינמן', N'0527157342', N'k025796460@gmail.com')
INSERT [dbo].[ParticipantInActivity] ([ParticipantId], [UserId], [ActivityId], [FirstName], [LastName], [Phone], [Email]) VALUES (21, N'987654321', 13, N'יונתן', N'קליינמן', N'0527157342', N'k025796460@gmail.com')
SET IDENTITY_INSERT [dbo].[ParticipantInActivity] OFF
GO
SET IDENTITY_INSERT [dbo].[PlayingCenter] ON 

INSERT [dbo].[PlayingCenter] ([PlayingCenterId], [CommunityAdministrationId]) VALUES (1, N'1')
INSERT [dbo].[PlayingCenter] ([PlayingCenterId], [CommunityAdministrationId]) VALUES (2, N'2')
INSERT [dbo].[PlayingCenter] ([PlayingCenterId], [CommunityAdministrationId]) VALUES (3, N'1')
INSERT [dbo].[PlayingCenter] ([PlayingCenterId], [CommunityAdministrationId]) VALUES (4, N'1')
INSERT [dbo].[PlayingCenter] ([PlayingCenterId], [CommunityAdministrationId]) VALUES (5, N'1')
INSERT [dbo].[PlayingCenter] ([PlayingCenterId], [CommunityAdministrationId]) VALUES (6, N'2')
INSERT [dbo].[PlayingCenter] ([PlayingCenterId], [CommunityAdministrationId]) VALUES (7, N'2')
INSERT [dbo].[PlayingCenter] ([PlayingCenterId], [CommunityAdministrationId]) VALUES (8, N'1')
SET IDENTITY_INSERT [dbo].[PlayingCenter] OFF
GO
SET IDENTITY_INSERT [dbo].[UnitTimeOfLibrary] ON 

INSERT [dbo].[UnitTimeOfLibrary] ([UnitTimeId], [LibraryId], [targetAudience], [Day], [BeginngTime], [EndTime]) VALUES (3, 5, N'h', N'0         ', N'h', N'h')
INSERT [dbo].[UnitTimeOfLibrary] ([UnitTimeId], [LibraryId], [targetAudience], [Day], [BeginngTime], [EndTime]) VALUES (25, 1, N'בנות', N'שלישי     ', N'16:00', N'18:30')
INSERT [dbo].[UnitTimeOfLibrary] ([UnitTimeId], [LibraryId], [targetAudience], [Day], [BeginngTime], [EndTime]) VALUES (26, 1, N'נשים', N'שני       ', N'20:00', N'22:00')
INSERT [dbo].[UnitTimeOfLibrary] ([UnitTimeId], [LibraryId], [targetAudience], [Day], [BeginngTime], [EndTime]) VALUES (27, 2, N'נשים', N'ראשון     ', N'16:00', N'18:00')
SET IDENTITY_INSERT [dbo].[UnitTimeOfLibrary] OFF
GO
SET IDENTITY_INSERT [dbo].[UnitTimeOfPlayingCenter] ON 

INSERT [dbo].[UnitTimeOfPlayingCenter] ([UnitTimeId], [PlayingCenterId], [OperatorName], [Day], [BeginningTime], [EndTime]) VALUES (2, 1, N'שרה קרישבסקי', N'חמישי     ', N'16:00', N'18:00')
INSERT [dbo].[UnitTimeOfPlayingCenter] ([UnitTimeId], [PlayingCenterId], [OperatorName], [Day], [BeginningTime], [EndTime]) VALUES (3, 1, N'מרים קליינמן', N'שני       ', N'16:00', N'18:30')
INSERT [dbo].[UnitTimeOfPlayingCenter] ([UnitTimeId], [PlayingCenterId], [OperatorName], [Day], [BeginningTime], [EndTime]) VALUES (5, 1, N'אלישבע בנדל', N'שני       ', N'14:00', N'19:00')
SET IDENTITY_INSERT [dbo].[UnitTimeOfPlayingCenter] OFF
GO
INSERT [dbo].[User] ([UserId], [Password], [CommunityAdministrationId], [FirstName], [LastName], [Email], [Phone], [IsManager]) VALUES (N'036499234', N'1234', N'1', N'יוסף', N'קליינמן', N'k025796460@gmail.com', N'0527157341', 0)
INSERT [dbo].[User] ([UserId], [Password], [CommunityAdministrationId], [FirstName], [LastName], [Email], [Phone], [IsManager]) VALUES (N'039687452', N'4567', N'0088', N'לאה', N'קובלסקי', N'habucharim10@gmail.com', N'026518597', 1)
INSERT [dbo].[User] ([UserId], [Password], [CommunityAdministrationId], [FirstName], [LastName], [Email], [Phone], [IsManager]) VALUES (N'043464031', N'1122', N'1', N'יהודית', N'קליינמן', N'k025796460@gmail.com', N'0527157342', 0)
INSERT [dbo].[User] ([UserId], [Password], [CommunityAdministrationId], [FirstName], [LastName], [Email], [Phone], [IsManager]) VALUES (N'052715744', N'9865', N'', N'יהודית', N'dfh', N'k025796460@gmail.com', N'0527157342', 1)
INSERT [dbo].[User] ([UserId], [Password], [CommunityAdministrationId], [FirstName], [LastName], [Email], [Phone], [IsManager]) VALUES (N'1', N'f', N'1', N'f', N'f', N'f', N'f', 0)
INSERT [dbo].[User] ([UserId], [Password], [CommunityAdministrationId], [FirstName], [LastName], [Email], [Phone], [IsManager]) VALUES (N'111111111', N'7395', N'1', N'fhfxch', N'dfh', N'k025796460@gmail.com', N'0527157342', 0)
INSERT [dbo].[User] ([UserId], [Password], [CommunityAdministrationId], [FirstName], [LastName], [Email], [Phone], [IsManager]) VALUES (N'112211221', N'8520', N'452863120', N'יהודית', N'רוזובסקי', N'36214128290@mby.co.il', N'0527157342', 1)
INSERT [dbo].[User] ([UserId], [Password], [CommunityAdministrationId], [FirstName], [LastName], [Email], [Phone], [IsManager]) VALUES (N'121412829', N'7395', N'1', N'fg', N'df', N'df@gmail.com', N'025789695', 0)
INSERT [dbo].[User] ([UserId], [Password], [CommunityAdministrationId], [FirstName], [LastName], [Email], [Phone], [IsManager]) VALUES (N'123456789', N'1234', N'1', N'kkk', N'llll', N'l@gmail.com', N'0527157894', 0)
INSERT [dbo].[User] ([UserId], [Password], [CommunityAdministrationId], [FirstName], [LastName], [Email], [Phone], [IsManager]) VALUES (N'2', N'2', N'1', N'e', N'e', N'e', N'e', 0)
INSERT [dbo].[User] ([UserId], [Password], [CommunityAdministrationId], [FirstName], [LastName], [Email], [Phone], [IsManager]) VALUES (N'213869407', N'7554', N'2', N'אביגיל', N'רוזובסקי', N'5879552@gmail.com', N'0583204192', 1)
INSERT [dbo].[User] ([UserId], [Password], [CommunityAdministrationId], [FirstName], [LastName], [Email], [Phone], [IsManager]) VALUES (N'214128200', N'7500', N'1515', N'חנה', N'בוריסלובסקי', N'psifas@gmail.com', N'025332854', 1)
INSERT [dbo].[User] ([UserId], [Password], [CommunityAdministrationId], [FirstName], [LastName], [Email], [Phone], [IsManager]) VALUES (N'214128290', N'7526', N'1', N'מרים', N'קליינמן', N'mk7157441@gmail.com', N'0527157441', 1)
INSERT [dbo].[User] ([UserId], [Password], [CommunityAdministrationId], [FirstName], [LastName], [Email], [Phone], [IsManager]) VALUES (N'214387995', N'7395', N'1', N'מיכל', N'כהן', N'michal@gmail.com', N'0534110618', 0)
INSERT [dbo].[User] ([UserId], [Password], [CommunityAdministrationId], [FirstName], [LastName], [Email], [Phone], [IsManager]) VALUES (N'2323446', N'1122', N'1', N'fhfxch', N'dfh', N'fd', N'fhfh', 0)
INSERT [dbo].[User] ([UserId], [Password], [CommunityAdministrationId], [FirstName], [LastName], [Email], [Phone], [IsManager]) VALUES (N'333', N'1', N'1', N'f', N'f', N'f', N'f', 0)
INSERT [dbo].[User] ([UserId], [Password], [CommunityAdministrationId], [FirstName], [LastName], [Email], [Phone], [IsManager]) VALUES (N'456789123', N'4444', N'1', N'klj', N'uji', N'36214128290@mby.co.il', N'0527157342', 0)
INSERT [dbo].[User] ([UserId], [Password], [CommunityAdministrationId], [FirstName], [LastName], [Email], [Phone], [IsManager]) VALUES (N'528639047', N'3399', N'708090', N'דסי', N'גורדון', N'minalneve@gmail.com', N'026518930', 1)
INSERT [dbo].[User] ([UserId], [Password], [CommunityAdministrationId], [FirstName], [LastName], [Email], [Phone], [IsManager]) VALUES (N'852963741', N'8855', N'4775', N'חדוה', N'ברזל', N'chavayali@gmail.com', N'089485672', 1)
INSERT [dbo].[User] ([UserId], [Password], [CommunityAdministrationId], [FirstName], [LastName], [Email], [Phone], [IsManager]) VALUES (N'987654321', N'1234', N'1', N'שרה', N'כהן', N'sara@gmail.com', N'025339864', 0)
INSERT [dbo].[User] ([UserId], [Password], [CommunityAdministrationId], [FirstName], [LastName], [Email], [Phone], [IsManager]) VALUES (N'd', N'd', N'c', N'd', N'd', N'd', N'd', 1)
INSERT [dbo].[User] ([UserId], [Password], [CommunityAdministrationId], [FirstName], [LastName], [Email], [Phone], [IsManager]) VALUES (N'string', N'string', N'1', N'string', N'string', N'string', N'string', 0)
GO
ALTER TABLE [dbo].[Message] ADD  CONSTRAINT [DF_Message_CourseId]  DEFAULT ((0)) FOR [CourseId]
GO
ALTER TABLE [dbo].[Message] ADD  CONSTRAINT [DF_Message_ActivityId]  DEFAULT ((0)) FOR [ActivityId]
GO
ALTER TABLE [dbo].[Message] ADD  CONSTRAINT [DF_Message_LibraryId]  DEFAULT ((0)) FOR [LibraryId]
GO
ALTER TABLE [dbo].[Message] ADD  CONSTRAINT [DF_Message_PlayingCenterId]  DEFAULT ((0)) FOR [PlayingCenterId]
GO
ALTER TABLE [dbo].[Message] ADD  CONSTRAINT [DF_Message_CommunityAdministrationId]  DEFAULT ((0)) FOR [CommunityAdministrationId]
GO
ALTER TABLE [dbo].[Activity]  WITH CHECK ADD  CONSTRAINT [FK_Activity_CommunityAdministration] FOREIGN KEY([CommunityAdministrationId])
REFERENCES [dbo].[CommunityAdministration] ([CommunityAdministrationId])
GO
ALTER TABLE [dbo].[Activity] CHECK CONSTRAINT [FK_Activity_CommunityAdministration]
GO
ALTER TABLE [dbo].[Course]  WITH CHECK ADD  CONSTRAINT [FK_Course_CommunityAdministration] FOREIGN KEY([CommunityAdministrationId])
REFERENCES [dbo].[CommunityAdministration] ([CommunityAdministrationId])
GO
ALTER TABLE [dbo].[Course] CHECK CONSTRAINT [FK_Course_CommunityAdministration]
GO
ALTER TABLE [dbo].[CourseRegistered]  WITH CHECK ADD  CONSTRAINT [FK_CourseRegistered_Course] FOREIGN KEY([CourseId])
REFERENCES [dbo].[Course] ([CourseId])
GO
ALTER TABLE [dbo].[CourseRegistered] CHECK CONSTRAINT [FK_CourseRegistered_Course]
GO
ALTER TABLE [dbo].[CourseRegistered]  WITH CHECK ADD  CONSTRAINT [FK_CourseRegistered_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[CourseRegistered] CHECK CONSTRAINT [FK_CourseRegistered_User]
GO
ALTER TABLE [dbo].[Library]  WITH CHECK ADD  CONSTRAINT [FK_Library_CommunityAdministration] FOREIGN KEY([CommunityAdministrationId])
REFERENCES [dbo].[CommunityAdministration] ([CommunityAdministrationId])
GO
ALTER TABLE [dbo].[Library] CHECK CONSTRAINT [FK_Library_CommunityAdministration]
GO
ALTER TABLE [dbo].[ParticipantInActivity]  WITH CHECK ADD  CONSTRAINT [FK_ParticipantInActivity_Activity] FOREIGN KEY([ActivityId])
REFERENCES [dbo].[Activity] ([ActivityId])
GO
ALTER TABLE [dbo].[ParticipantInActivity] CHECK CONSTRAINT [FK_ParticipantInActivity_Activity]
GO
ALTER TABLE [dbo].[ParticipantInActivity]  WITH CHECK ADD  CONSTRAINT [FK_ParticipantInActivity_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[ParticipantInActivity] CHECK CONSTRAINT [FK_ParticipantInActivity_User]
GO
ALTER TABLE [dbo].[PlayingCenter]  WITH CHECK ADD  CONSTRAINT [FK_PlayingCenter_CommunityAdministration] FOREIGN KEY([CommunityAdministrationId])
REFERENCES [dbo].[CommunityAdministration] ([CommunityAdministrationId])
GO
ALTER TABLE [dbo].[PlayingCenter] CHECK CONSTRAINT [FK_PlayingCenter_CommunityAdministration]
GO
ALTER TABLE [dbo].[UnitTimeOfLibrary]  WITH CHECK ADD  CONSTRAINT [FK_UnitTimeOfLibrary_Library] FOREIGN KEY([LibraryId])
REFERENCES [dbo].[Library] ([LibraryId])
GO
ALTER TABLE [dbo].[UnitTimeOfLibrary] CHECK CONSTRAINT [FK_UnitTimeOfLibrary_Library]
GO
ALTER TABLE [dbo].[UnitTimeOfPlayingCenter]  WITH CHECK ADD  CONSTRAINT [FK_UnitTimeOfPlayingCenter_PlayingCenter] FOREIGN KEY([PlayingCenterId])
REFERENCES [dbo].[PlayingCenter] ([PlayingCenterId])
GO
ALTER TABLE [dbo].[UnitTimeOfPlayingCenter] CHECK CONSTRAINT [FK_UnitTimeOfPlayingCenter_PlayingCenter]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_CommunityAdministration] FOREIGN KEY([CommunityAdministrationId])
REFERENCES [dbo].[CommunityAdministration] ([CommunityAdministrationId])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_CommunityAdministration]
GO
USE [master]
GO
ALTER DATABASE [CommunityAdministration] SET  READ_WRITE 
GO
