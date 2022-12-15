CREATE TABLE [ChoreList].[Users] (
    [UserID]    INT           IDENTITY (1, 1) NOT NULL,
    [Name]      NVARCHAR (50) NOT NULL,
    [IsDeleted] BIT           CONSTRAINT [DF_Users_IsDeleted] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_Users_1] PRIMARY KEY CLUSTERED ([UserID] ASC)
);

