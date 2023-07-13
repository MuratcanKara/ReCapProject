CREATE TABLE [dbo].[Cars]
(
	[CarId] INT NOT NULL PRIMARY KEY, 
    [BrandId] INT NULL, 
    [ColorId] INT NULL, 
    [ModelYear] DATETIME2 NULL, 
    [DailyPrice] MONEY NOT NULL, 
    [Description] NVARCHAR(50) NULL, 
    [Name] NVARCHAR(10) NOT NULL, 
    CONSTRAINT [FK_Cars_Brands] FOREIGN KEY ([BrandId]) REFERENCES [Brands]([BrandId]), 
    CONSTRAINT [FK_Cars_Colors] FOREIGN KEY ([ColorId]) REFERENCES [Colors]([ColorId]) 
)
