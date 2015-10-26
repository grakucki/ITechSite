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
	LastTestKompetencjiDtmSucces datetime NULL,
	ForceTestKompetencji bit NOT NULL CONSTRAINT DF_ItechUsers_ForceTestKompetencji DEFAULT 0
GO
ALTER TABLE dbo.ItechUsers SET (LOCK_ESCALATION = TABLE)
GO



ALTER TABLE dbo.TestSettings ADD
	Test_Run bit NOT NULL CONSTRAINT DF_Test_Run DEFAULT 0
GO

COMMIT



