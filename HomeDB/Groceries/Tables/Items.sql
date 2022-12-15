CREATE TABLE [Groceries].[Items] (
    [ItemID]    INT           IDENTITY (1, 1) NOT NULL,
    [ItemName]  NVARCHAR (50) NOT NULL,
    [IsDeleted] BIT           CONSTRAINT [DF_Items_IsDeleted] DEFAULT ((0)) NOT NULL,
    [IsMSGFree] BIT           CONSTRAINT [DF_Items_IsMSGFree] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_Items] PRIMARY KEY CLUSTERED ([ItemID] ASC)
);



