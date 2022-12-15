CREATE TABLE [ChoreList].[Chores] (
    [ChoreID]   INT           IDENTITY (1, 1) NOT NULL,
    [ChoreName] NVARCHAR (50) NOT NULL,
    [IsDeleted] BIT           CONSTRAINT [DF_Chores_IsDeleted] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_Chores] PRIMARY KEY CLUSTERED ([ChoreID] ASC)
);

