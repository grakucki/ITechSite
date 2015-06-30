USE [ITech]
GO

/****** Object:  UserDefinedFunction [dbo].[GetDokumentSize]    Script Date: 2015-06-30 13:26:42 ******/
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

