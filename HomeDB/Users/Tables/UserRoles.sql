CREATE TABLE [Users].[UserRoles] (
    [UserRoleID] INT IDENTITY (1, 1) NOT NULL,
    [Deleted]    BIT NOT NULL,
    [ModfiyID]   INT NOT NULL,
    [UsersID]    INT NOT NULL,
    [RoleID]     INT NOT NULL,
    CONSTRAINT [PK_UserRoles] PRIMARY KEY CLUSTERED ([UserRoleID] ASC),
    CONSTRAINT [FK_UserRoles_Users] FOREIGN KEY ([UsersID]) REFERENCES [HomeApp].[Users] ([UserID])
);

