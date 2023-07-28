CREATE TABLE [dbo].[CarImages]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [CarId] INT NULL, 
    [ImagePath] VARCHAR(MAX) NULL, 
    [Date] DATETIME2 NULL, 
    CONSTRAINT [FK_CarImages_Cars] FOREIGN KEY ([CarId]) REFERENCES dbo.[Cars]([CarId])
)
