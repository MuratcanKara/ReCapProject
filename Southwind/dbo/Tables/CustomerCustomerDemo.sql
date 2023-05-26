CREATE TABLE [dbo].[CustomerCustomerDemo] (
    [CustomerId]     INT  NOT NULL,
    [CustomerTypeID] NCHAR (10) NOT NULL,
    CONSTRAINT [PK_CustomerCustomerDemo] PRIMARY KEY NONCLUSTERED ([CustomerId] ASC, [CustomerTypeID] ASC),
    CONSTRAINT [FK_CustomerCustomerDemo] FOREIGN KEY ([CustomerTypeID]) REFERENCES [dbo].[CustomerDemographics] ([CustomerTypeID]),
    CONSTRAINT [FK_CustomerCustomerDemo_Customers] FOREIGN KEY ([CustomerId]) REFERENCES [dbo].[Customers] ([CustomerId])
);

