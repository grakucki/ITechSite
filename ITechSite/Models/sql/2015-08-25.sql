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
ALTER TABLE dbo.InformationPlan
	DROP CONSTRAINT FK_InformationPlan_Resource
GO
ALTER TABLE dbo.Resource SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.InformationPlan
	DROP CONSTRAINT FK_InformationPlan_Dokument
GO
ALTER TABLE dbo.Dokument SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.InformationPlan
	DROP CONSTRAINT DF_InformationPlan_Order
GO
ALTER TABLE dbo.InformationPlan
	DROP CONSTRAINT DF_InformationPlan_Enabled
GO
CREATE TABLE dbo.Tmp_InformationPlan
	(
	id int NOT NULL IDENTITY (1, 1),
	idR int NOT NULL,
	IdD int NOT NULL,
	IdM int NULL,
	[Order] int NULL,
	Enabled bit NOT NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Tmp_InformationPlan SET (LOCK_ESCALATION = TABLE)
GO
ALTER TABLE dbo.Tmp_InformationPlan ADD CONSTRAINT
	DF_InformationPlan_Order DEFAULT ((0)) FOR [Order]
GO
ALTER TABLE dbo.Tmp_InformationPlan ADD CONSTRAINT
	DF_InformationPlan_Enabled DEFAULT ((1)) FOR Enabled
GO
SET IDENTITY_INSERT dbo.Tmp_InformationPlan ON
GO
IF EXISTS(SELECT * FROM dbo.InformationPlan)
	 EXEC('INSERT INTO dbo.Tmp_InformationPlan (id, idR, IdD, [Order], Enabled)
		SELECT id, idR, IdD, [Order], Enabled FROM dbo.InformationPlan WITH (HOLDLOCK TABLOCKX)')
GO
SET IDENTITY_INSERT dbo.Tmp_InformationPlan OFF
GO
DROP TABLE dbo.InformationPlan
GO
EXECUTE sp_rename N'dbo.Tmp_InformationPlan', N'InformationPlan', 'OBJECT' 
GO
ALTER TABLE dbo.InformationPlan ADD CONSTRAINT
	PK_InformationPlan PRIMARY KEY CLUSTERED 
	(
	id
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

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
ALTER TABLE dbo.InformationPlan ADD CONSTRAINT
	FK_InformationPlan_Resource1 FOREIGN KEY
	(
	IdM
	) REFERENCES dbo.Resource
	(
	Id
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
COMMIT

/****** Script for SelectTopNRows command from SSMS  ******/
