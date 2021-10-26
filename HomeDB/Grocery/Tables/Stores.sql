CREATE TABLE [Grocery].[Stores] (
    [StoreID] INT           IDENTITY (1, 1) NOT NULL,
    [Name]    NVARCHAR (50) NOT NULL,
    [Deleted] BIT           CONSTRAINT [DF_Strores_Deleted] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_Strores] PRIMARY KEY CLUSTERED ([StoreID] ASC)
);

