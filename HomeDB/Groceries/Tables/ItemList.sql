CREATE TABLE [Groceries].[ItemList] (
    [ItemListID]    INT            IDENTITY (1, 1) NOT NULL,
    [ItemID]        INT            NOT NULL,
    [StoreID]       INT            NULL,
    [GotItem]       BIT            CONSTRAINT [DF_ItemList_GotItem] DEFAULT ((0)) NOT NULL,
    [NumberOfItems] INT            NULL,
    [SizeTypeID]    INT            NULL,
    [DateAdded]     DATE           NOT NULL,
    [DateGot]       DATE           NULL,
    [Notes]         NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_ItemList] PRIMARY KEY CLUSTERED ([ItemListID] ASC),
    CONSTRAINT [FK_ItemList_Items] FOREIGN KEY ([ItemID]) REFERENCES [Groceries].[Items] ([ItemID]),
    CONSTRAINT [FK_ItemList_SizeType] FOREIGN KEY ([SizeTypeID]) REFERENCES [Groceries].[SizeType] ([SizeTypeID]),
    CONSTRAINT [FK_ItemList_Stores] FOREIGN KEY ([StoreID]) REFERENCES [Groceries].[Stores] ([StoreID])
);

