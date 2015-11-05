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
ALTER TABLE dbo.InformationPlan ADD
	OwnerId nvarchar(128) NULL
ALTER TABLE dbo.InformationPlan ADD
	CreateTime datetime NULL
GO
ALTER TABLE dbo.InformationPlan SET (LOCK_ESCALATION = TABLE)
GO
COMMIT

BEGIN TRANSACTION
GO
ALTER TABLE dbo.Dokument ADD
	LastWriteUserId nvarchar(128) NULL
GO
ALTER TABLE dbo.Dokument SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
