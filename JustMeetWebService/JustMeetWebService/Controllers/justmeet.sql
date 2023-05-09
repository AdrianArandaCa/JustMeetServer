USE [Justmeet]
GO
/****** Object:  Table [dbo].[Answer]    Script Date: 09/05/2023 19:21:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Answer](
	[idAnswer] [int] IDENTITY(1,1) NOT NULL,
	[answer] [nvarchar](max) NULL,
	[selected] [bit] NULL,
 CONSTRAINT [PK_Answer] PRIMARY KEY CLUSTERED 
(
	[idAnswer] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Game]    Script Date: 09/05/2023 19:21:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Game](
	[idGame] [int] IDENTITY(1,1) NOT NULL,
	[registrationDate] [date] NULL,
	[match] [bit] NULL,
	[percentage] [float] NULL,
 CONSTRAINT [PK_Game] PRIMARY KEY CLUSTERED 
(
	[idGame] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Gametype]    Script Date: 09/05/2023 19:21:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Gametype](
	[idGametype] [int] IDENTITY(1,1) NOT NULL,
	[type] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Gametype] PRIMARY KEY CLUSTERED 
(
	[idGametype] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Location]    Script Date: 09/05/2023 19:21:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Location](
	[idLocation] [int] IDENTITY(1,1) NOT NULL,
	[longitud] [float] NULL,
	[latitud] [float] NULL,
	[idUser] [int] NOT NULL,
 CONSTRAINT [PK_Location] PRIMARY KEY CLUSTERED 
(
	[idLocation] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Question]    Script Date: 09/05/2023 19:21:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Question](
	[idQuestion] [int] IDENTITY(1,1) NOT NULL,
	[question] [nvarchar](max) NULL,
	[idGametype] [int] NULL,
 CONSTRAINT [PK_Question] PRIMARY KEY CLUSTERED 
(
	[idQuestion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[QuestionAnswer]    Script Date: 09/05/2023 19:21:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QuestionAnswer](
	[idQuestion] [int] NOT NULL,
	[idAnswer] [int] NOT NULL,
	[exist] [bit] NULL,
 CONSTRAINT [PK_QuestionAnswer] PRIMARY KEY CLUSTERED 
(
	[idQuestion] ASC,
	[idAnswer] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[QuestionGame]    Script Date: 09/05/2023 19:21:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QuestionGame](
	[idGame] [int] NOT NULL,
	[idQuestion] [int] NOT NULL,
 CONSTRAINT [PK_QuestionGame] PRIMARY KEY CLUSTERED 
(
	[idGame] ASC,
	[idQuestion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Setting]    Script Date: 09/05/2023 19:21:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Setting](
	[idSetting] [int] IDENTITY(1,1) NOT NULL,
	[maxDistance] [float] NULL,
	[minAge] [int] NULL,
	[maxAge] [int] NULL,
	[genre] [varchar](255) NULL,
	[idGametype] [int] NULL,
 CONSTRAINT [PK_Setting] PRIMARY KEY CLUSTERED 
(
	[idSetting] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 09/05/2023 19:21:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[idUser] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[password] [varchar](255) NULL,
	[email] [varchar](255) NULL,
	[genre] [varchar](255) NULL,
	[photo] [int] NULL,
	[description] [nvarchar](max) NULL,
	[premium] [bit] NULL,
	[idSetting] [int] NULL,
	[birthday] [int] NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[idUser] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[userAnswer]    Script Date: 09/05/2023 19:21:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[userAnswer](
	[idGame] [int] NOT NULL,
	[idUser] [int] NOT NULL,
	[idQuestion] [int] NOT NULL,
	[idAnswer] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[idGame] ASC,
	[idUser] ASC,
	[idQuestion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserGame]    Script Date: 09/05/2023 19:21:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserGame](
	[idGame] [int] NOT NULL,
	[idUser] [int] NOT NULL,
 CONSTRAINT [PK_UserGame] PRIMARY KEY CLUSTERED 
(
	[idGame] ASC,
	[idUser] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Answer] ADD  DEFAULT ((0)) FOR [selected]
GO
ALTER TABLE [dbo].[Game] ADD  CONSTRAINT [DF_Game_match]  DEFAULT ((0)) FOR [match]
GO
ALTER TABLE [dbo].[Game] ADD  DEFAULT ((0)) FOR [percentage]
GO
ALTER TABLE [dbo].[QuestionAnswer] ADD  DEFAULT ((0)) FOR [exist]
GO
ALTER TABLE [dbo].[Setting] ADD  CONSTRAINT [maxDistance]  DEFAULT ((0.0)) FOR [maxDistance]
GO
ALTER TABLE [dbo].[Setting] ADD  CONSTRAINT [minAge]  DEFAULT ((18)) FOR [minAge]
GO
ALTER TABLE [dbo].[Setting] ADD  CONSTRAINT [maxAge]  DEFAULT ((99)) FOR [maxAge]
GO
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_user_premium]  DEFAULT ('false') FOR [premium]
GO
ALTER TABLE [dbo].[User] ADD  DEFAULT ((18)) FOR [birthday]
GO
ALTER TABLE [dbo].[Location]  WITH CHECK ADD  CONSTRAINT [FK_Location_User] FOREIGN KEY([idUser])
REFERENCES [dbo].[User] ([idUser])
GO
ALTER TABLE [dbo].[Location] CHECK CONSTRAINT [FK_Location_User]
GO
ALTER TABLE [dbo].[Question]  WITH CHECK ADD  CONSTRAINT [FK_Question_Gametype] FOREIGN KEY([idGametype])
REFERENCES [dbo].[Gametype] ([idGametype])
GO
ALTER TABLE [dbo].[Question] CHECK CONSTRAINT [FK_Question_Gametype]
GO
ALTER TABLE [dbo].[QuestionAnswer]  WITH CHECK ADD  CONSTRAINT [FK_QuestionAnswer_Answer] FOREIGN KEY([idAnswer])
REFERENCES [dbo].[Answer] ([idAnswer])
GO
ALTER TABLE [dbo].[QuestionAnswer] CHECK CONSTRAINT [FK_QuestionAnswer_Answer]
GO
ALTER TABLE [dbo].[QuestionAnswer]  WITH CHECK ADD  CONSTRAINT [FK_QuestionAnswer_Question] FOREIGN KEY([idQuestion])
REFERENCES [dbo].[Question] ([idQuestion])
GO
ALTER TABLE [dbo].[QuestionAnswer] CHECK CONSTRAINT [FK_QuestionAnswer_Question]
GO
ALTER TABLE [dbo].[QuestionGame]  WITH CHECK ADD  CONSTRAINT [FK_QuestionGame_Game] FOREIGN KEY([idGame])
REFERENCES [dbo].[Game] ([idGame])
GO
ALTER TABLE [dbo].[QuestionGame] CHECK CONSTRAINT [FK_QuestionGame_Game]
GO
ALTER TABLE [dbo].[QuestionGame]  WITH CHECK ADD  CONSTRAINT [FK_QuestionGame_Question] FOREIGN KEY([idQuestion])
REFERENCES [dbo].[Question] ([idQuestion])
GO
ALTER TABLE [dbo].[QuestionGame] CHECK CONSTRAINT [FK_QuestionGame_Question]
GO
ALTER TABLE [dbo].[Setting]  WITH CHECK ADD  CONSTRAINT [FK_Setting_Gametype] FOREIGN KEY([idGametype])
REFERENCES [dbo].[Gametype] ([idGametype])
GO
ALTER TABLE [dbo].[Setting] CHECK CONSTRAINT [FK_Setting_Gametype]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Setting] FOREIGN KEY([idSetting])
REFERENCES [dbo].[Setting] ([idSetting])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Setting]
GO
ALTER TABLE [dbo].[userAnswer]  WITH CHECK ADD FOREIGN KEY([idAnswer])
REFERENCES [dbo].[Answer] ([idAnswer])
GO
ALTER TABLE [dbo].[userAnswer]  WITH CHECK ADD FOREIGN KEY([idAnswer])
REFERENCES [dbo].[Answer] ([idAnswer])
GO
ALTER TABLE [dbo].[userAnswer]  WITH CHECK ADD FOREIGN KEY([idAnswer])
REFERENCES [dbo].[Answer] ([idAnswer])
GO
ALTER TABLE [dbo].[userAnswer]  WITH CHECK ADD FOREIGN KEY([idQuestion])
REFERENCES [dbo].[Question] ([idQuestion])
GO
ALTER TABLE [dbo].[userAnswer]  WITH CHECK ADD FOREIGN KEY([idQuestion])
REFERENCES [dbo].[Question] ([idQuestion])
GO
ALTER TABLE [dbo].[userAnswer]  WITH CHECK ADD FOREIGN KEY([idQuestion])
REFERENCES [dbo].[Question] ([idQuestion])
GO
ALTER TABLE [dbo].[userAnswer]  WITH CHECK ADD  CONSTRAINT [FK_userAnswer_UserGame] FOREIGN KEY([idGame], [idUser])
REFERENCES [dbo].[UserGame] ([idGame], [idUser])
GO
ALTER TABLE [dbo].[userAnswer] CHECK CONSTRAINT [FK_userAnswer_UserGame]
GO
ALTER TABLE [dbo].[UserGame]  WITH CHECK ADD  CONSTRAINT [FK_UserGame_Game] FOREIGN KEY([idGame])
REFERENCES [dbo].[Game] ([idGame])
GO
ALTER TABLE [dbo].[UserGame] CHECK CONSTRAINT [FK_UserGame_Game]
GO
ALTER TABLE [dbo].[UserGame]  WITH CHECK ADD  CONSTRAINT [FK_UserGame_User] FOREIGN KEY([idUser])
REFERENCES [dbo].[User] ([idUser])
GO
ALTER TABLE [dbo].[UserGame] CHECK CONSTRAINT [FK_UserGame_User]
GO
