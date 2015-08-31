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
	PasswordFormat int NULL,
	LastTestKompetencjiDtm datetime NULL,
	LastTestKompetencjiResult int NULL
GO
ALTER TABLE dbo.ItechUsers ADD CONSTRAINT
	DF_ItechUsers_PasswordFormat DEFAULT 0 FOR PasswordFormat
GO
ALTER TABLE dbo.ItechUsers SET (LOCK_ESCALATION = TABLE)
GO
COMMIT