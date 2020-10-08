CREATE TABLE [dbo].[BowDictionary]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Word] VARCHAR(512) NOT NULL, 
    [DateImported] DATETIME2(3) NOT NULL DEFAULT SYSUTCDATETIME(), 
    [DateUpdated] DATETIME2(3) NULL
)
GO

CREATE TRIGGER trg_SetUpdatedTime_Dictionary
ON dbo.BowDictionary
AFTER UPDATE
AS
    UPDATE dbo.BowDictionary
    SET DateImported = SYSUTCDATETIME()
    FROM dbo.BowDictionary d
    JOIN inserted i
        ON d.Id = i.Id
