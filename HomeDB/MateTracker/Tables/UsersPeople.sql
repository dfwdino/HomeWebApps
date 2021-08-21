CREATE TABLE [MateTracker].[UsersPeople] (
    [UsersPersonID]  INT            IDENTITY (1, 1) NOT NULL,
    [PersonName]     NVARCHAR (50)  NOT NULL,
    [PersonGenderID] INT            NOT NULL,
    [UserID]         INT            NOT NULL,
    [Notes]          NVARCHAR (255) NULL,
    CONSTRAINT [PK_UsersPeople] PRIMARY KEY CLUSTERED ([UsersPersonID] ASC),
    CONSTRAINT [FK_UsersPeople_Genders] FOREIGN KEY ([PersonGenderID]) REFERENCES [MateTracker].[Genders] ([GenderID]),
    CONSTRAINT [FK_UsersPeople_Users] FOREIGN KEY ([UserID]) REFERENCES [HomeApp].[Users] ([UserID])
);

