CREATE TABLE [dbo].[UserOperationClaims]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [UserId] INT NOT NULL, 
    [OperationClaimId] INT NOT NULL, 
    CONSTRAINT [FK_UserOperationClaims_Users] FOREIGN KEY ([UserId]) REFERENCES [Users]([Id]), 
    CONSTRAINT [FK_UserOperationClaims_OperationClaims] FOREIGN KEY ([OperationClaimId]) REFERENCES [OperationClaims]([Id])
)
