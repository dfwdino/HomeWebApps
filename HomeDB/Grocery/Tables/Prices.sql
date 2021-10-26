CREATE TABLE [Grocery].[Prices] (
    [PriceID]    INT            NOT NULL,
    [Price]      DECIMAL (8, 2) NOT NULL,
    [StoreID]    INT            NOT NULL,
    [FoodItemID] INT            NOT NULL,
    [PriceDate]  DATE           CONSTRAINT [DF_Prices_PriceDate] DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK_Prices] PRIMARY KEY CLUSTERED ([PriceID] ASC),
    CONSTRAINT [FK_Prices_Items] FOREIGN KEY ([FoodItemID]) REFERENCES [Grocery].[Items] ([ItemID]),
    CONSTRAINT [FK_Prices_Strores] FOREIGN KEY ([StoreID]) REFERENCES [Grocery].[Stores] ([StoreID])
);

