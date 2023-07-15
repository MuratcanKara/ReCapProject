CREATE TABLE [dbo].[Colors]
(
	[ColorId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(10) NULL, 
    [BrandId] INT NULL, 
    CONSTRAINT [FK_Colors_Brands] FOREIGN KEY ([BrandId]) REFERENCES [Brands]([BrandId])
)
