CREATE TABLE [Groceries].[Prices] (
    [PriceID]   INT   IDENTITY (1, 1) NOT NULL,
    [ItemPrice] MONEY NOT NULL,
    [PriceDate] DATE  NOT NULL,
    [IsDeleted] BIT   CONSTRAINT [DF_Prices_IsDeleted] DEFAULT ((0)) NOT NULL,
    [ItemID]    INT   NOT NULL,
    [StoreID]   INT   NOT NULL,
    CONSTRAINT [PK_Prices] PRIMARY KEY CLUSTERED ([PriceID] ASC),
    CONSTRAINT [FK_Prices_Stores] FOREIGN KEY ([StoreID]) REFERENCES [Groceries].[Stores] ([StoreID])
);



