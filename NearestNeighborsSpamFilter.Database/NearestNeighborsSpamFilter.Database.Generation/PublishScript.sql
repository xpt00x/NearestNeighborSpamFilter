﻿/*
Deployment script for NNSPAMFILTER

This code was generated by a tool.
Changes to this file may cause incorrect behavior and will be lost if
the code is regenerated.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "NNSPAMFILTER"
:setvar DefaultFilePrefix "NNSPAMFILTER"
:setvar DefaultDataPath "B:\DB\MSSQL15.NNSPAMFILTER\MSSQL\DATA\"
:setvar DefaultLogPath "B:\DB\MSSQL15.NNSPAMFILTER\MSSQL\DATA\"

GO
:on error exit
GO
/*
Detect SQLCMD mode and disable script execution if SQLCMD mode is not supported.
To re-enable the script after enabling SQLCMD mode, execute the following:
SET NOEXEC OFF; 
*/
:setvar __IsSqlCmdEnabled "True"
GO
IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
    BEGIN
        PRINT N'SQLCMD mode must be enabled to successfully execute this script.';
        SET NOEXEC ON;
    END


GO
USE [$(DatabaseName)];


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET ANSI_NULLS ON,
                ANSI_PADDING ON,
                ANSI_WARNINGS ON,
                ARITHABORT ON,
                CONCAT_NULL_YIELDS_NULL ON,
                QUOTED_IDENTIFIER ON,
                ANSI_NULL_DEFAULT ON,
                CURSOR_DEFAULT LOCAL,
                RECOVERY FULL 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET PAGE_VERIFY NONE 
            WITH ROLLBACK IMMEDIATE;
    END


GO
ALTER DATABASE [$(DatabaseName)]
    SET TARGET_RECOVERY_TIME = 0 SECONDS 
    WITH ROLLBACK IMMEDIATE;


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET QUERY_STORE (QUERY_CAPTURE_MODE = ALL, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 367), MAX_STORAGE_SIZE_MB = 100) 
            WITH ROLLBACK IMMEDIATE;
    END


GO
PRINT N'Rename refactoring operation with key 26e9e030-084b-4320-904f-8ae924040ea6 is skipped, element [dbo].[Emails].[DateUpdatd] (SqlSimpleColumn) will not be renamed to DateUpdated';


GO
PRINT N'Creating [dbo].[Dictionary]...';


GO
CREATE TABLE [dbo].[Dictionary] (
    [Id]           INT           IDENTITY (1, 1) NOT NULL,
    [Word]         VARCHAR (512) NOT NULL,
    [DateImported] DATETIME2 (3) NOT NULL,
    [DateUpdated]  DATETIME2 (3) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating [dbo].[Emails]...';


GO
CREATE TABLE [dbo].[Emails] (
    [Id]             INT           IDENTITY (1, 1) NOT NULL,
    [DateImported]   DATETIME2 (3) NOT NULL,
    [DateUpdated]    DATETIME2 (3) NULL,
    [Classification] BIT           NOT NULL,
    [Body]           VARCHAR (MAX) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating [dbo].[ModelDataPoints]...';


GO
CREATE TABLE [dbo].[ModelDataPoints] (
    [Id]             INT IDENTITY (1, 1) NOT NULL,
    [IdWord]         INT NOT NULL,
    [Frequency]      INT NOT NULL,
    [Classification] BIT NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating [dbo].[TrainingPoints]...';


GO
CREATE TABLE [dbo].[TrainingPoints] (
    [Id]             INT IDENTITY (1, 1) NOT NULL,
    [IdWord]         INT NOT NULL,
    [Frequency]      INT NOT NULL,
    [Classification] BIT NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating unnamed constraint on [dbo].[Dictionary]...';


GO
ALTER TABLE [dbo].[Dictionary]
    ADD DEFAULT SYSUTCDATETIME() FOR [DateImported];


GO
PRINT N'Creating unnamed constraint on [dbo].[Emails]...';


GO
ALTER TABLE [dbo].[Emails]
    ADD DEFAULT SYSUTCDATETIME() FOR [DateImported];


GO
PRINT N'Creating [dbo].[FK_ModelDataPoints_Dictionary]...';


GO
ALTER TABLE [dbo].[ModelDataPoints] WITH NOCHECK
    ADD CONSTRAINT [FK_ModelDataPoints_Dictionary] FOREIGN KEY ([IdWord]) REFERENCES [dbo].[Dictionary] ([Id]) ON DELETE CASCADE;


GO
PRINT N'Creating [dbo].[FK_TrainingPoints_Dictionary]...';


GO
ALTER TABLE [dbo].[TrainingPoints] WITH NOCHECK
    ADD CONSTRAINT [FK_TrainingPoints_Dictionary] FOREIGN KEY ([IdWord]) REFERENCES [dbo].[Dictionary] ([Id]) ON DELETE CASCADE;


GO
PRINT N'Creating [dbo].[trg_SetUpdatedTime_Dictionary]...';


GO

CREATE TRIGGER trg_SetUpdatedTime_Dictionary
ON dbo.Dictionary
AFTER UPDATE
AS
    UPDATE dbo.Dictionary
    SET DateImported = SYSUTCDATETIME()
    FROM dbo.Dictionary d
    JOIN inserted i
        ON d.Id = i.Id
GO
PRINT N'Creating [dbo].[trg_SetUpdatedTime_Emails]...';


GO

CREATE TRIGGER trg_SetUpdatedTime_Emails
ON dbo.Dictionary
AFTER UPDATE
AS
    UPDATE dbo.Dictionary
    SET DateImported = SYSUTCDATETIME()
    FROM dbo.Dictionary d
    JOIN inserted i
        ON d.Id = i.Id
GO
-- Refactoring step to update target server with deployed transaction logs

IF OBJECT_ID(N'dbo.__RefactorLog') IS NULL
BEGIN
    CREATE TABLE [dbo].[__RefactorLog] (OperationKey UNIQUEIDENTIFIER NOT NULL PRIMARY KEY)
    EXEC sp_addextendedproperty N'microsoft_database_tools_support', N'refactoring log', N'schema', N'dbo', N'table', N'__RefactorLog'
END
GO
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '26e9e030-084b-4320-904f-8ae924040ea6')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('26e9e030-084b-4320-904f-8ae924040ea6')

GO

GO
PRINT N'Checking existing data against newly created constraints';


GO
USE [$(DatabaseName)];


GO
ALTER TABLE [dbo].[ModelDataPoints] WITH CHECK CHECK CONSTRAINT [FK_ModelDataPoints_Dictionary];

ALTER TABLE [dbo].[TrainingPoints] WITH CHECK CHECK CONSTRAINT [FK_TrainingPoints_Dictionary];


GO
PRINT N'Update complete.';


GO
