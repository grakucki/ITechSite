USE [ITech]
GO

/****** Object:  Table [dbo].[Department]    Script Date: 2015-08-15 23:32:56 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Department](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


/****** Object:  Table [dbo].[Factory]    Script Date: 2015-08-15 23:33:18 ******/


CREATE TABLE [dbo].[Factory](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


USE [ITech]
GO


CREATE TABLE [dbo].[FactoryDepartment](
	[FactoryId] [int] NOT NULL,
	[DepartmentId] [int] NOT NULL,
 CONSTRAINT [PK_FactoryDepartment] PRIMARY KEY CLUSTERED 
(
	[FactoryId] ASC,
	[DepartmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[FactoryDepartment]  WITH CHECK ADD  CONSTRAINT [FK_FactoryDepartment_Department] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Department] ([Id])
GO

ALTER TABLE [dbo].[FactoryDepartment] CHECK CONSTRAINT [FK_FactoryDepartment_Department]
GO

ALTER TABLE [dbo].[FactoryDepartment]  WITH CHECK ADD  CONSTRAINT [FK_FactoryDepartment_Factory] FOREIGN KEY([FactoryId])
REFERENCES [dbo].[Factory] ([Id])
GO

ALTER TABLE [dbo].[FactoryDepartment] CHECK CONSTRAINT [FK_FactoryDepartment_Factory]
GO

BEGIN TRANSACTION
GO
ALTER TABLE dbo.WorkProcess ADD
	DepartamentId int NULL
GO
ALTER TABLE dbo.WorkProcess SET (LOCK_ESCALATION = TABLE)
GO
COMMIT

BEGIN TRANSACTION
GO
ALTER TABLE dbo.Resource ADD
	Factory nvarchar(50) NULL
GO
ALTER TABLE dbo.Resource SET (LOCK_ESCALATION = TABLE)
GO
COMMIT


USE [ITech]
GO
SET IDENTITY_INSERT [dbo].[Factory] ON 

GO
INSERT [dbo].[Factory] ([Id], [Name]) VALUES (1, N'DGL G³ogów')
GO
INSERT [dbo].[Factory] ([Id], [Name]) VALUES (2, N'DPL Polkowice')
GO
SET IDENTITY_INSERT [dbo].[Factory] OFF
GO
SET IDENTITY_INSERT [dbo].[Department] ON 

GO
INSERT [dbo].[Department] ([Id], [Name]) VALUES (1, N'Zgrzewanie G')
GO
INSERT [dbo].[Department] ([Id], [Name]) VALUES (3, N'Buksowanie G')
GO
INSERT [dbo].[Department] ([Id], [Name]) VALUES (4, N'Spawanie G')
GO
INSERT [dbo].[Department] ([Id], [Name]) VALUES (5, N'Monta¿')
GO
INSERT [dbo].[Department] ([Id], [Name]) VALUES (6, N'Klejenie P')
GO
INSERT [dbo].[Department] ([Id], [Name]) VALUES (7, N'Klejenie P')
GO
INSERT [dbo].[Department] ([Id], [Name]) VALUES (8, N'DP4')
GO
SET IDENTITY_INSERT [dbo].[Department] OFF
GO
INSERT [dbo].[FactoryDepartment] ([FactoryId], [DepartmentId]) VALUES (1, 1)
GO
INSERT [dbo].[FactoryDepartment] ([FactoryId], [DepartmentId]) VALUES (1, 3)
GO
INSERT [dbo].[FactoryDepartment] ([FactoryId], [DepartmentId]) VALUES (1, 4)
GO
INSERT [dbo].[FactoryDepartment] ([FactoryId], [DepartmentId]) VALUES (1, 5)
GO
INSERT [dbo].[FactoryDepartment] ([FactoryId], [DepartmentId]) VALUES (2, 5)
GO
INSERT [dbo].[FactoryDepartment] ([FactoryId], [DepartmentId]) VALUES (2, 6)
--GO
--SET IDENTITY_INSERT [dbo].[WorkProcess] ON 

--GO
--INSERT [dbo].[WorkProcess] ([Id], [DepartamentId], [Name]) VALUES (1, 1, N'Zgrzewanie')
--GO
--INSERT [dbo].[WorkProcess] ([Id], [DepartamentId], [Name]) VALUES (2, 3, N'Buksowanie')
--GO
--INSERT [dbo].[WorkProcess] ([Id], [DepartamentId], [Name]) VALUES (3, 4, N'Spawanie CMT')
--GO
--INSERT [dbo].[WorkProcess] ([Id], [DepartamentId], [Name]) VALUES (4, 4, N'Spawanie MAG')
--GO
--INSERT [dbo].[WorkProcess] ([Id], [DepartamentId], [Name]) VALUES (5, 4, N'Spawanie Laserowe')
--GO
--INSERT [dbo].[WorkProcess] ([Id], [DepartamentId], [Name]) VALUES (6, 5, N'Monta¿')
--GO
--INSERT [dbo].[WorkProcess] ([Id], [DepartamentId], [Name]) VALUES (7, 6, N'Klejenie')
--GO
--SET IDENTITY_INSERT [dbo].[WorkProcess] OFF
--GO
update [dbo].[WorkProcess] set DepartamentId=1 where Id=1;
update [dbo].[WorkProcess] set DepartamentId=3 where Id=2;
update [dbo].[WorkProcess] set DepartamentId=4 where Id=3;
update [dbo].[WorkProcess] set DepartamentId=4 where Id=4;
update [dbo].[WorkProcess] set DepartamentId=4 where Id=5;
update [dbo].[WorkProcess] set DepartamentId=5 where Id=6;
update [dbo].[WorkProcess] set DepartamentId=6 where Id=7;
