CREATE TABLE [ChoreList].[UsersChores] (
    [UserChoreID]        INT            IDENTITY (1, 1) NOT NULL,
    [UserID]             INT            NOT NULL,
    [ChoreID]            INT            NOT NULL,
    [IsDeleted]          BIT            CONSTRAINT [DF_UsersChores_IsDeleted] DEFAULT ((0)) NOT NULL,
    [ChoreTimeTypeID]    INT            NOT NULL,
    [StartDateChore]     DATE           NOT NULL,
    [IsDone]             BIT            CONSTRAINT [DF_UsersChores_IsDone] DEFAULT ((0)) NOT NULL,
    [EndDateChore]       DATE           NULL,
    [ChoreDayTimeTypeID] INT            NOT NULL,
    [AllowanceAmount]    DECIMAL (6, 2) CONSTRAINT [DF_UsersChores_AllowanceAmount] DEFAULT ((0.00)) NOT NULL,
    CONSTRAINT [PK_UsersChores] PRIMARY KEY CLUSTERED ([UserChoreID] ASC),
    CONSTRAINT [FK_UsersChores_ChoreDayTimeType] FOREIGN KEY ([ChoreDayTimeTypeID]) REFERENCES [ChoreList].[ChoreDayTimeType] ([ChoreDayTimeTypeID]),
    CONSTRAINT [FK_UsersChores_Chores] FOREIGN KEY ([ChoreID]) REFERENCES [ChoreList].[Chores] ([ChoreID]),
    CONSTRAINT [FK_UsersChores_ChoreTimeType] FOREIGN KEY ([ChoreTimeTypeID]) REFERENCES [ChoreList].[ChoreTimeType] ([ChoreTimeTypeID]),
    CONSTRAINT [FK_UsersChores_Users] FOREIGN KEY ([UserID]) REFERENCES [ChoreList].[Users] ([UserID])
);

