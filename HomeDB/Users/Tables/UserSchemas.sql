CREATE TABLE [Users].[UserSchemas] (
    [UserSchemaID] INT IDENTITY (1, 1) NOT NULL,
    [Deleted]      BIT CONSTRAINT [DF_Table_1_Deleted] DEFAULT ((0)) NOT NULL,
    [ModfiyID]     INT NOT NULL,
    [UsersID]      INT NOT NULL,
    [SchemaID]     INT NOT NULL,
    CONSTRAINT [PK_UserSchemas] PRIMARY KEY CLUSTERED ([UserSchemaID] ASC),
    CONSTRAINT [FK_UserSchemas_CreateModifyLog1] FOREIGN KEY ([UserSchemaID]) REFERENCES [HomeApp].[Schemas] ([SchemaID]),
    CONSTRAINT [FK_UserSchemas_Users] FOREIGN KEY ([UsersID]) REFERENCES [HomeApp].[Users] ([UserID])
);



