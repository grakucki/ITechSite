
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 07/11/2015 16:54:47
-- Generated from EDMX file: d:\projekty\automotive\ITechSite\ITechSite\Areas\Testy\Models\TestModels.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [ITech];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_categoryId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AllowedCategories] DROP CONSTRAINT [FK_categoryId];
GO
IF OBJECT_ID(N'[dbo].[FK_kategoriaId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Pytania] DROP CONSTRAINT [FK_kategoriaId];
GO
IF OBJECT_ID(N'[dbo].[FK_PytanieId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Odpowiedzi] DROP CONSTRAINT [FK_PytanieId];
GO
IF OBJECT_ID(N'[dbo].[FK_resourceId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AllowedCategories] DROP CONSTRAINT [FK_resourceId];
GO
IF OBJECT_ID(N'[dbo].[FK_stateId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TestKompetencji] DROP CONSTRAINT [FK_stateId];
GO
IF OBJECT_ID(N'[dbo].[FK_TestKompetencjiId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TestKompetencjiLog] DROP CONSTRAINT [FK_TestKompetencjiId];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[AllowedCategories]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AllowedCategories];
GO
IF OBJECT_ID(N'[dbo].[Kategorie]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Kategorie];
GO
IF OBJECT_ID(N'[dbo].[Odpowiedzi]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Odpowiedzi];
GO
IF OBJECT_ID(N'[dbo].[Pytania]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Pytania];
GO
IF OBJECT_ID(N'[dbo].[RodzajOdpowiedzi]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RodzajOdpowiedzi];
GO
IF OBJECT_ID(N'[dbo].[StanTestu]', 'U') IS NOT NULL
    DROP TABLE [dbo].[StanTestu];
GO
IF OBJECT_ID(N'[TestyModelStoreContainer].[Table]', 'U') IS NOT NULL
    DROP TABLE [TestyModelStoreContainer].[Table];
GO
IF OBJECT_ID(N'[dbo].[TestKompetencji]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TestKompetencji];
GO
IF OBJECT_ID(N'[dbo].[TestKompetencjiLog]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TestKompetencjiLog];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Kategorie'
CREATE TABLE [dbo].[Kategorie] (
    [id] int IDENTITY(1,1) NOT NULL,
    [name] nvarchar(64)  NOT NULL
);
GO

-- Creating table 'Odpowiedzi'
CREATE TABLE [dbo].[Odpowiedzi] (
    [id] int IDENTITY(1,1) NOT NULL,
    [questionId] int  NOT NULL,
    [content] nvarchar(max)  NULL,
    [order] int  NULL,
    [is_correct] bit  NOT NULL
);
GO

-- Creating table 'Pytania'
CREATE TABLE [dbo].[Pytania] (
    [id] int IDENTITY(1,1) NOT NULL,
    [code] nvarchar(16)  NOT NULL,
    [content] nvarchar(max)  NOT NULL,
    [answer_type] int  NOT NULL,
    [categoryId] int  NOT NULL,
    [keywords] nvarchar(max)  NULL
);
GO

-- Creating table 'TestKompetencji'
CREATE TABLE [dbo].[TestKompetencji] (
    [id] int IDENTITY(1,1) NOT NULL,
    [createdAt] datetime  NOT NULL,
    [finishedAt] datetime  NULL,
    [UserId] int  NOT NULL,
    [xml] nvarchar(max)  NULL,
    [score] int  NULL,
    [accessionNumber] nvarchar(256)  NOT NULL,
    [stateId] int  NOT NULL
);
GO

-- Creating table 'TestKompetencjiLog'
CREATE TABLE [dbo].[TestKompetencjiLog] (
    [id] int IDENTITY(1,1) NOT NULL,
    [TestId] int  NOT NULL,
    [loggedAt] datetime  NOT NULL,
    [questionId] int  NOT NULL,
    [answers] varchar(max)  NOT NULL
);
GO


-- Creating table 'StanTestu'
CREATE TABLE [dbo].[StanTestu] (
    [id] int IDENTITY(1,1) NOT NULL,
    [name] nvarchar(128)  NOT NULL
);
GO

-- Creating table 'AllowedCategories'
CREATE TABLE [dbo].[AllowedCategories] (
    [id] int IDENTITY(1,1) NOT NULL,
    [resourceId] int  NOT NULL,
    [categoryId] int  NOT NULL
);
GO

-- Creating table 'RodzajOdpowiedzi'
CREATE TABLE [dbo].[RodzajOdpowiedzi] (
    [id] int IDENTITY(1,1) NOT NULL,
    [name] nvarchar(128)  NOT NULL
);
GO

-- Creating table 'Table'
CREATE TABLE [dbo].[Table] (
    [Kategorie_id] int  NOT NULL,
    [Resource_id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [id] in table 'Kategorie'
ALTER TABLE [dbo].[Kategorie]
ADD CONSTRAINT [PK_Kategorie]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Odpowiedzi'
ALTER TABLE [dbo].[Odpowiedzi]
ADD CONSTRAINT [PK_Odpowiedzi]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Pytania'
ALTER TABLE [dbo].[Pytania]
ADD CONSTRAINT [PK_Pytania]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'TestKompetencji'
ALTER TABLE [dbo].[TestKompetencji]
ADD CONSTRAINT [PK_TestKompetencji]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'TestKompetencjiLog'
ALTER TABLE [dbo].[TestKompetencjiLog]
ADD CONSTRAINT [PK_TestKompetencjiLog]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO


-- Creating primary key on [id] in table 'StanTestu'
ALTER TABLE [dbo].[StanTestu]
ADD CONSTRAINT [PK_StanTestu]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'AllowedCategories'
ALTER TABLE [dbo].[AllowedCategories]
ADD CONSTRAINT [PK_AllowedCategories]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'RodzajOdpowiedzi'
ALTER TABLE [dbo].[RodzajOdpowiedzi]
ADD CONSTRAINT [PK_RodzajOdpowiedzi]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [Kategorie_id], [Resource_id] in table 'Table'
ALTER TABLE [dbo].[Table]
ADD CONSTRAINT [PK_Table]
    PRIMARY KEY CLUSTERED ([Kategorie_id], [Resource_id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [categoryId] in table 'Pytania'
ALTER TABLE [dbo].[Pytania]
ADD CONSTRAINT [FK_kategoriaId]
    FOREIGN KEY ([categoryId])
    REFERENCES [dbo].[Kategorie]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_kategoriaId'
CREATE INDEX [IX_FK_kategoriaId]
ON [dbo].[Pytania]
    ([categoryId]);
GO

-- Creating foreign key on [questionId] in table 'Odpowiedzi'
ALTER TABLE [dbo].[Odpowiedzi]
ADD CONSTRAINT [FK_PytanieId]
    FOREIGN KEY ([questionId])
    REFERENCES [dbo].[Pytania]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PytanieId'
CREATE INDEX [IX_FK_PytanieId]
ON [dbo].[Odpowiedzi]
    ([questionId]);
GO

-- Creating foreign key on [TestId] in table 'TestKompetencjiLog'
ALTER TABLE [dbo].[TestKompetencjiLog]
ADD CONSTRAINT [FK_TestKompetencjiId]
    FOREIGN KEY ([TestId])
    REFERENCES [dbo].[TestKompetencji]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TestKompetencjiId'
CREATE INDEX [IX_FK_TestKompetencjiId]
ON [dbo].[TestKompetencjiLog]
    ([TestId]);
GO

-- Creating foreign key on [stateId] in table 'TestKompetencji'
ALTER TABLE [dbo].[TestKompetencji]
ADD CONSTRAINT [FK_stateId]
    FOREIGN KEY ([stateId])
    REFERENCES [dbo].[StanTestu]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_stateId'
CREATE INDEX [IX_FK_stateId]
ON [dbo].[TestKompetencji]
    ([stateId]);
GO

-- Creating foreign key on [Kategorie_id] in table 'Table'
ALTER TABLE [dbo].[Table]
ADD CONSTRAINT [FK_Table_Kategorie]
    FOREIGN KEY ([Kategorie_id])
    REFERENCES [dbo].[Kategorie]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO


-- Creating foreign key on [categoryId] in table 'AllowedCategories'
ALTER TABLE [dbo].[AllowedCategories]
ADD CONSTRAINT [FK_categoryId]
    FOREIGN KEY ([categoryId])
    REFERENCES [dbo].[Kategorie]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_categoryId'
CREATE INDEX [IX_FK_categoryId]
ON [dbo].[AllowedCategories]
    ([categoryId]);
GO

-- Creating foreign key on [resourceId] in table 'AllowedCategories'
ALTER TABLE [dbo].[AllowedCategories]
ADD CONSTRAINT [FK_resourceId]
    FOREIGN KEY ([resourceId])
    REFERENCES [dbo].[Resource]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_resourceId'
CREATE INDEX [IX_FK_resourceId]
ON [dbo].[AllowedCategories]
    ([resourceId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------

set identity_insert [dbo].[StanTestu] on;
insert into [dbo].[StanTestu] (id, name) values(1, 'Niezakończony');
insert into [dbo].[StanTestu] (id, name) values(2, 'Zdany');
insert into [dbo].[StanTestu] (id, name) values(3, 'Niezdany');
set identity_insert [dbo].[StanTestu] off;

SET IDENTITY_INSERT [dbo].[RodzajOdpowiedzi] ON
INSERT INTO [dbo].[RodzajOdpowiedzi] ([id], [name]) VALUES (1, 'Jedna poprawna');
INSERT INTO [dbo].[RodzajOdpowiedzi] ([id], [name]) VALUES (2, 'Kilka poprawnych');
SET IDENTITY_INSERT [dbo].[RodzajOdpowiedzi] OFF

ALTER TABLE dbo.Workstation ADD
	AllowIp nvarchar(15) NULL