CREATE TABLE [Grocery].[Items] (
    [ItemID]  INT           IDENTITY (1, 1) NOT NULL,
    [Name]    NVARCHAR (50) NULL,
    [Deleted] BIT           CONSTRAINT [DF_Items_Deleted] DEFAULT ((0)) NULL,
    CONSTRAINT [PK_Items] PRIMARY KEY CLUSTERED ([ItemID] ASC)
);

