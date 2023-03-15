CREATE TABLE [LastPersonPicked].[WhoPicked] (
    [WhoPickedAppID] INT      IDENTITY (1, 1) NOT NULL,
    [PlacePickedID]  INT      NOT NULL,
    [PersonPickedID] INT      NOT NULL,
    [CreatedDate]    DATETIME CONSTRAINT [DF_WhoPicked_CreatedDate] DEFAULT (getdate()) NOT NULL,
    [IsDeleted]      BIT      CONSTRAINT [DF_WhoPicked_IsDeleted] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_WhoPicked] PRIMARY KEY CLUSTERED ([WhoPickedAppID] ASC),
    CONSTRAINT [FK_WhoPicked_PlacesToGo] FOREIGN KEY ([PlacePickedID]) REFERENCES [LastPersonPicked].[PlacesToGo] ([PlacesToGoID]),
    CONSTRAINT [FK_WhoPicked_Users] FOREIGN KEY ([PersonPickedID]) REFERENCES [HomeApp].[Users] ([UserID])
);

