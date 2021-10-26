CREATE TABLE [Grocery].[Lists] (
    [ListID]         INT IDENTITY (1, 1) NOT NULL,
    [FoodItemID]     INT NOT NULL,
    [UserID]         INT NOT NULL,
    [StoreID]        INT NOT NULL,
    [GotItem]        BIT CONSTRAINT [DF_Lists_GotItem] DEFAULT ((0)) NOT NULL,
    [ShowOnAllLists] BIT CONSTRAINT [DF_Lists_ShowAll] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_Lists] PRIMARY KEY CLUSTERED ([ListID] ASC),
    CONSTRAINT [FK_Lists_Items] FOREIGN KEY ([FoodItemID]) REFERENCES [Grocery].[Items] ([ItemID]),
    CONSTRAINT [FK_Lists_Strores] FOREIGN KEY ([StoreID]) REFERENCES [Grocery].[Stores] ([StoreID]),
    CONSTRAINT [FK_Lists_Users] FOREIGN KEY ([UserID]) REFERENCES [HomeApp].[Users] ([UserID])
);

