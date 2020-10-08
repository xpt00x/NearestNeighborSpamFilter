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
ON dbo.Emails
AFTER UPDATE
AS
    UPDATE dbo.Emails
    SET DateImported = SYSUTCDATETIME()
    FROM dbo.Emails d
    JOIN inserted i
        ON d.Id = i.Id
