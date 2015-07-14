USE [ITech]
GO
/****** Object:  Table [dbo].[Odpowiedzi]    Script Date: 2015-07-14 22:37:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Odpowiedzi](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[questionId] [int] NOT NULL,
	[content] [nvarchar](max) NULL,
	[order] [int] NULL,
	[is_correct] [bit] NOT NULL,
 CONSTRAINT [PK_Odpowiedzi] PRIMARY KEY CLUSTERED
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Pytania]    Script Date: 2015-07-14 22:37:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pytania](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[code] [nvarchar](16) NOT NULL,
	[content] [nvarchar](max) NOT NULL,
	[answer_type] [int] NOT NULL,
	[categoryId] [int] NOT NULL,
	[keywords] [nvarchar](max) NULL,
 CONSTRAINT [PK_Pytania] PRIMARY KEY CLUSTERED
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
ALTER TABLE [dbo].[Odpowiedzi]  WITH CHECK ADD  CONSTRAINT [FK_PytanieId] FOREIGN KEY([questionId])
REFERENCES [dbo].[Pytania] ([id])
GO
ALTER TABLE [dbo].[Odpowiedzi] CHECK CONSTRAINT [FK_PytanieId]
GO
ALTER TABLE [dbo].[Pytania]  WITH CHECK ADD  CONSTRAINT [FK_kategoriaId] FOREIGN KEY([categoryId])
REFERENCES [dbo].[Kategorie] ([id])
GO
ALTER TABLE [dbo].[Pytania] CHECK CONSTRAINT [FK_kategoriaId]
GO
