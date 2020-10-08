CREATE TABLE [dbo].[Dictionary]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Word] VARCHAR(512) NOT NULL, 
    [DateImported] DATETIME2(3) NOT NULL DEFAULT SYSUTCDATETIME(), 
    [DateUpdated] DATETIME2(3) NULL
)
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
