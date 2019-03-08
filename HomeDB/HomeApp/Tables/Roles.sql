CREATE TABLE [HomeApp].[Roles] (
    [RoleID]   INT           NOT NULL,
    [Deleted]  BIT           CONSTRAINT [DF_Roles_Deleted] DEFAULT ((0)) NOT NULL,
    [ModfiyID] INT           NOT NULL,
    [RoleName] NVARCHAR (25) NOT NULL,
    CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED ([RoleID] ASC),
    CONSTRAINT [FK_Roles_CreateModifyLog] FOREIGN KEY ([ModfiyID]) REFERENCES [HomeApp].[CreateModifyLog] ([CreateModifyID])
);

