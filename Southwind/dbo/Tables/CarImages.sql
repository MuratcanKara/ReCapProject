CREATE TABLE [dbo].[CarImages]
(
	[Id] INT NOT NULL IDENTITY, 
    [CarId] INT NULL, 
    [ImagePath] VARCHAR(MAX) NULL, 
    [Date] DATETIME2 NULL, 
    CONSTRAINT [PK_CarImages] PRIMARY KEY ([Id]), 
    CONSTRAINT [FK_CarImages_Cars] FOREIGN KEY (CarId) REFERENCES [Cars](CarId) 
)
