USE [ITech]
GO

/****** Object:  UserDefinedFunction [dbo].[GetDokumentSize]    Script Date: 2015-06-25 17:36:47 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [dbo].[GetDokumentSize] 
(
	@IdD int
)
RETURNS BigInt
AS
BEGIN
	-- Declare the return variable here
	DECLARE @ret BigInt;

	-- Add the T-SQL statements to compute the return value here
	Select @ret=len(Content) from FileContent where Dokument_Id=@IdD;

	-- Return the result of the function
	RETURN @ret

END

GO


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
ALTER TABLE dbo.Dokument ADD
	Size  AS ([dbo].[GetDokumentSize]([id]))
GO
ALTER TABLE dbo.Dokument SET (LOCK_ESCALATION = TABLE)
GO
COMMIT


