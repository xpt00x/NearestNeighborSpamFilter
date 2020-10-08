CREATE TABLE [dbo].[DataPoints]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [IdWord] INT NOT NULL, 
    [Frequency] INT NOT NULL, 
    [Classification] BIT NOT NULL, 
    CONSTRAINT [FK_ModelDataPoints_Dictionary] FOREIGN KEY (IdWord) REFERENCES BowDictionary(Id) ON DELETE CASCADE
)
