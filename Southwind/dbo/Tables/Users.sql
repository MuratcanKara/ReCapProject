CREATE TABLE [dbo].[Users]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [FirstName] NVARCHAR(10) NOT NULL, 
    [LastName] NVARCHAR(10) NOT NULL, 
    [Email] NVARCHAR(50) NOT NULL, 
    [PasswordHash] VARBINARY(500) NOT NULL, 
    [PasswordSalt] VARBINARY(500) NOT NULL, 
    [Status] BIT NOT NULL
)
