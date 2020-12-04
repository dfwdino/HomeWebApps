CREATE TABLE [Gas].[Autos] (
    [AutoID]   INT           IDENTITY (1, 1) NOT NULL,
    [Deleted]  BIT           CONSTRAINT [DF_Table_1_Deleted] DEFAULT ((0)) NOT NULL,
    [ModfiyID] INT           NOT NULL,
    [AutoName] NVARCHAR (50) NOT NULL,
    [UserID]   INT           NOT NULL,
    CONSTRAINT [PK_Auto] PRIMARY KEY CLUSTERED ([AutoID] ASC),
    CONSTRAINT [FK_Auto_CreateModifyLog] FOREIGN KEY ([ModfiyID]) REFERENCES [HomeApp].[CreateModifyLog] ([CreateModifyID]),
    CONSTRAINT [FK_Auto_Users] FOREIGN KEY ([UserID]) REFERENCES [HomeApp].[Users] ([UserID])
);

