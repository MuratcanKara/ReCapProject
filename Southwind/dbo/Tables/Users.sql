CREATE TABLE [dbo].[Users]
(
	[UserId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [FirstName] NVARCHAR(10) NULL, 
    [LastName] NVARCHAR(10) NULL, 
    [Email] NVARCHAR(50) NULL, 
    [Password] VARCHAR(60) NULL
)
