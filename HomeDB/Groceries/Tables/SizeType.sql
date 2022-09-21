CREATE TABLE [Groceries].[SizeType] (
    [SizeTypeID]   INT           IDENTITY (1, 1) NOT NULL,
    [SizeTypeName] NVARCHAR (50) NOT NULL,
    [IsDeleted]    BIT           CONSTRAINT [DF_SizeType_IsDeleted] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_SizeType] PRIMARY KEY CLUSTERED ([SizeTypeID] ASC)
);

