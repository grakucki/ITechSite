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
ALTER TABLE dbo.ItechUsers ADD
	Frozen bit NOT NULL CONSTRAINT DF_ItechUsers_Frozen DEFAULT 0

GO
ALTER TABLE dbo.ItechUsers ADD
	Enabled bit NOT NULL CONSTRAINT DF_ItechUsers_Enabled DEFAULT 1
GO
ALTER TABLE dbo.ItechUsers ADD
	[Desc] nvarchar(max)
GO
ALTER TABLE dbo.ItechUsers ADD
	[AccessProfile] [nvarchar](50)

GO

ALTER TABLE dbo.ItechUsers SET (LOCK_ESCALATION = TABLE)
GO

ALTER TABLE [dbo].[Dokument]  WITH CHECK ADD  CONSTRAINT [FK_Dokument_WorkProcess] FOREIGN KEY([WorkProcess_Id])
REFERENCES [dbo].[WorkProcess] ([Id])
GO
ALTER TABLE [dbo].[Dokument] CHECK CONSTRAINT [FK_Dokument_WorkProcess]
GO




ALTER TABLE [dbo].[News]  WITH CHECK ADD  CONSTRAINT [FK_News_NewsPriority] FOREIGN KEY([NewsPriorityId])
REFERENCES [dbo].[NewsPriority] ([id])
GO
ALTER TABLE [dbo].[News] CHECK CONSTRAINT [FK_News_NewsPriority]
GO




ALTER TABLE dbo.FactoryWorkProcess
	DROP CONSTRAINT FK_FactoryWorkProcess_WorkProcess

ALTER TABLE [dbo].[FactoryWorkProcess]  WITH CHECK ADD  CONSTRAINT [FK_FactoryWorkProcess_WorkProcess] FOREIGN KEY([WorkProcessId])
REFERENCES [dbo].[WorkProcess] ([Id])
GO



ALTER TABLE dbo.WorkProcess
	DROP CONSTRAINT FK_WorkProcess_Department
GO
ALTER TABLE dbo.WorkProcess
	DROP COLUMN DepartamentId
GO

COMMIT