CREATE TABLE [Users].[UserSchemas] (
    [ID]         INT           IDENTITY (1, 1) NOT NULL,
    [Deleted]    BIT           CONSTRAINT [DF_Table_1_Deleted] DEFAULT ((0)) NOT NULL,
    [ModfiyID]   INT           NOT NULL,
    [UsersID]    INT           NOT NULL,
    [SchemaName] NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_UserSchemas] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_UserSchemas_CreateModifyLog1] FOREIGN KEY ([ModfiyID]) REFERENCES [HomeApp].[CreateModifyLog] ([CreateModifyID]),
    CONSTRAINT [FK_UserSchemas_Users] FOREIGN KEY ([UsersID]) REFERENCES [HomeApp].[Users] ([UserID])
);

