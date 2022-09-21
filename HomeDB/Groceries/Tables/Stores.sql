CREATE TABLE [Groceries].[Stores] (
    [StoreID]      INT            IDENTITY (1, 1) NOT NULL,
    [StoreName]    NVARCHAR (50)  NOT NULL,
    [StoreAddress] NVARCHAR (255) NULL,
    [Deleted]      BIT            CONSTRAINT [DF_Stores_Deleted] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_Stores] PRIMARY KEY CLUSTERED ([StoreID] ASC)
);

