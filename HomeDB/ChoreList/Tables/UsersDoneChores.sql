CREATE TABLE [ChoreList].[UsersDoneChores] (
    [UsersDoneChoresID] INT  IDENTITY (1, 1) NOT NULL,
    [IsDeleted]         BIT  CONSTRAINT [DF_UsersDoneChores_IsDeleted] DEFAULT ((0)) NULL,
    [DateDone]          DATE CONSTRAINT [DF_UsersDoneChores_DateDone] DEFAULT (getdate()) NOT NULL,
    [UserChoreID]       INT  NOT NULL,
    CONSTRAINT [PK_UsersDoneChores] PRIMARY KEY CLUSTERED ([UsersDoneChoresID] ASC),
    CONSTRAINT [FK_UsersDoneChores_UsersChores] FOREIGN KEY ([UserChoreID]) REFERENCES [ChoreList].[UsersChores] ([UserChoreID])
);

