CREATE TABLE [dbo].[Cars]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [BrandId] INT NULL, 
    [ColorId] INT NULL, 
    [ModelYear] DATETIME NULL, 
    [DailyPrice] MONEY NULL, 
    [Description] NVARCHAR(50) NULL
)
