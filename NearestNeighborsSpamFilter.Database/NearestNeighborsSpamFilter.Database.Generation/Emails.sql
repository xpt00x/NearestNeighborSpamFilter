CREATE TABLE [dbo].[Emails]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [DateImported] DATETIME2(3) NOT NULL DEFAULT SYSUTCDATETIME(), 
    [DateUpdated] DATETIME2(3) NULL, 
    [Classification] BIT NOT NULL, 
    [Body] VARCHAR(MAX) NULL
)

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
