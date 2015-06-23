USE [ITech]
GO
/****** Object:  Table [dbo].[ResourceType]    Script Date: 2015-06-23 10:10:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ResourceType](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Type] [nvarchar](50) NULL,
 CONSTRAINT [PK_ResourceType] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SimaticCpuType]    Script Date: 2015-06-23 10:10:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SimaticCpuType](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[CpuType] [nvarchar](50) NULL,
 CONSTRAINT [PK_SimaticCpuType] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[ResourceType] ON 

INSERT [dbo].[ResourceType] ([id], [Type]) VALUES (1, N'Stanowisko')
INSERT [dbo].[ResourceType] ([id], [Type]) VALUES (2, N'Model')
SET IDENTITY_INSERT [dbo].[ResourceType] OFF
SET IDENTITY_INSERT [dbo].[SimaticCpuType] ON 

INSERT [dbo].[SimaticCpuType] ([id], [CpuType]) VALUES (1, N'S7200')
INSERT [dbo].[SimaticCpuType] ([id], [CpuType]) VALUES (2, N'S7300')
INSERT [dbo].[SimaticCpuType] ([id], [CpuType]) VALUES (3, N'S7400')
INSERT [dbo].[SimaticCpuType] ([id], [CpuType]) VALUES (4, N'S71200')
INSERT [dbo].[SimaticCpuType] ([id], [CpuType]) VALUES (5, N'S71500')
SET IDENTITY_INSERT [dbo].[SimaticCpuType] OFF



/****** Object:  Table [dbo].[News]    Script Date: 2015-06-23 14:29:22 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[News](
	[id] [int] NOT NULL,
	[News] [nvarchar](max) NOT NULL,
	[ValidEnd] [datetime] NULL,
 CONSTRAINT [PK_News] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

ALTER TABLE [dbo].[News]  WITH CHECK ADD  CONSTRAINT [FK_News_Resource] FOREIGN KEY([id])
REFERENCES [dbo].[Resource] ([Id])
GO

ALTER TABLE [dbo].[News] CHECK CONSTRAINT [FK_News_Resource]
GO


