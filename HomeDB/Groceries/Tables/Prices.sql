CREATE TABLE [Groceries].[Prices] (
    [PriceID]   INT   IDENTITY (1, 1) NOT NULL,
    [ItemPrice] MONEY NULL,
    [PriceDate] DATE  NULL,
    [IsDeleted] BIT   CONSTRAINT [DF_Prices_IsDeleted] DEFAULT ((0)) NULL,
    CONSTRAINT [PK_Prices] PRIMARY KEY CLUSTERED ([PriceID] ASC)
);

