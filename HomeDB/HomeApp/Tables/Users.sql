CREATE TABLE [HomeApp].[Users] (
    [UserID]         INT           IDENTITY (1, 1) NOT NULL,
    [Deleted]        BIT           CONSTRAINT [DF_Users_Deleted] DEFAULT ((0)) NOT NULL,
    [FirstName]      NVARCHAR (50) NOT NULL,
    [LastName]       NVARCHAR (50) NULL,
    [CreateModifyID] INT           NOT NULL,
    [RoleID]         INT           NOT NULL,
    [Password]       NVARCHAR (50) NOT NULL,
    [UserName]       NVARCHAR (25) NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED ([UserID] ASC),
    CONSTRAINT [FK_Users_CreateModifyLog] FOREIGN KEY ([CreateModifyID]) REFERENCES [HomeApp].[CreateModifyLog] ([CreateModifyID]),
    CONSTRAINT [FK_Users_Roles] FOREIGN KEY ([RoleID]) REFERENCES [HomeApp].[Roles] ([RoleID])
);





