/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Factory SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.WorkProcess SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
CREATE TABLE dbo.FactoryWorkProcess
	(
	FactoryId int NOT NULL,
	WorkProcessId int NOT NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.FactoryWorkProcess ADD CONSTRAINT
	FK_FactoryWorkProcess_Factory FOREIGN KEY
	(
	FactoryId
	) REFERENCES dbo.Factory
	(
	Id
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.FactoryWorkProcess ADD CONSTRAINT
	FK_FactoryWorkProcess_WorkProcess FOREIGN KEY
	(
	FactoryId
	) REFERENCES dbo.WorkProcess
	(
	Id
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.FactoryWorkProcess SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Dokument SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Resource SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.InformationPlan ADD CONSTRAINT
	FK_InformationPlan_Dokument FOREIGN KEY
	(
	IdD
	) REFERENCES dbo.Dokument
	(
	Id
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.InformationPlan ADD CONSTRAINT
	FK_InformationPlan_Resource FOREIGN KEY
	(
	idR
	) REFERENCES dbo.Resource
	(
	Id
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.InformationPlan SET (LOCK_ESCALATION = TABLE)
GO
COMMIT

/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.News ADD
	NewsPriorityId int NOT NULL CONSTRAINT DF_News_NewsPriorityId DEFAULT 1
GO
ALTER TABLE dbo.News SET (LOCK_ESCALATION = TABLE)
GO
COMMIT


USE [ITech]
GO

/****** Object:  Table [dbo].[NewsPriority]    Script Date: 2015-08-21 16:18:28 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[NewsPriority](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[CssName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_NewsPriority] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

USE [ITech]
GO
SET IDENTITY_INSERT [dbo].[NewsPriority] ON 

GO
INSERT [dbo].[NewsPriority] ([id], [Name], [CssName]) VALUES (1, N'pozytywne', N'text-Green')
GO
INSERT [dbo].[NewsPriority] ([id], [Name], [CssName]) VALUES (2, N'neutralny', N'text-Orange')
GO
INSERT [dbo].[NewsPriority] ([id], [Name], [CssName]) VALUES (3, N'ważny', N'text-Red')
GO
SET IDENTITY_INSERT [dbo].[NewsPriority] OFF
GO
