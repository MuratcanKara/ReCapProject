﻿CREATE TABLE [dbo].[Rentals]
(
	[RentalId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [CarId] INT NOT NULL, 
    [CustomerId] INT NOT NULL, 
    [RentDate] DATETIME2 NULL, 
    [ReturnDate] DATETIME2 NULL
)
