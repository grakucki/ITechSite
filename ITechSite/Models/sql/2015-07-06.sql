﻿/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/

USE [ITech]
GO

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
ALTER TABLE dbo.Workstation ADD
	AllowIp nvarchar(15) NULL
GO
ALTER TABLE dbo.SimaticCpuType ADD
	Enabled bit NOT NULL CONSTRAINT DF_SimaticCpuType_Enabled DEFAULT 1
GO
CREATE TABLE dbo.ItechUsers
	(
	id int NOT NULL IDENTITY (1, 1),
	UserId nvarchar(128) NOT NULL,
	UserName nvarchar(256) NOT NULL,
	CardNo nvarchar(256) NOT NULL,
	Password nvarchar(256) NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.ItechUsers ADD CONSTRAINT
	PK_ItechUsers PRIMARY KEY CLUSTERED 
	(
	id
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO


CREATE TABLE [dbo].[ItechUsersRoles](
	[ItechUserId] id NOT NULL,
	[RoleId] [nvarchar](128) NOT NULL,
	[WorkstationId] [int] NULL,
 CONSTRAINT [PK_ItechUsersRoles] PRIMARY KEY CLUSTERED 
(
	[ItechUserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'F383EAB9-B4DD-42A0-B586-E0573CFC404B', N'admin')
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'2B7F16BF-CDB4-455C-96DE-C63F6DA90DEE', N'kierownik')
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'773D87A7-61D0-4E21-B04C-B670C9A2A7DC', N'pracownik')

GO
ALTER TABLE dbo.ItechUsers ADD CONSTRAINT
	IX_ItechUsers UNIQUE NONCLUSTERED 
	(
	UserId
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO

ALTER TABLE dbo.ItechUsersRoles ADD CONSTRAINT
	FK_ItechUsersRoles_ItechUsers FOREIGN KEY
	(
	ItechUserId
	) REFERENCES dbo.ItechUsers
	(
	UserId
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.ItechUsersRoles ADD CONSTRAINT
	FK_ItechUsersRoles_AspNetRoles FOREIGN KEY
	(
	RoleId
	) REFERENCES dbo.AspNetRoles
	(
	Id
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 	
GO
COMMIT
