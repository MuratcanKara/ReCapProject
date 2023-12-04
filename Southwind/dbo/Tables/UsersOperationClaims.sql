CREATE TABLE [dbo].[UsersOperationClaims]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [UserId] INT NOT NULL, 
    [OperationClaimId] INT NOT NULL, 
    CONSTRAINT [FK_UsersOperationClaims_Users] FOREIGN KEY ([UserId]) REFERENCES [Users]([Id]), 
    CONSTRAINT [FK_UsersOperationClaims_OperationClaims] FOREIGN KEY ([OperationClaimId]) REFERENCES [OperationClaims]([Id]) 
)
