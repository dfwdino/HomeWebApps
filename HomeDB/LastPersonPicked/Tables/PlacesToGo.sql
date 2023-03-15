CREATE TABLE [LastPersonPicked].[PlacesToGo] (
    [PlacesToGoID] INT           IDENTITY (1, 1) NOT NULL,
    [Name]         NVARCHAR (50) NOT NULL,
    [IsDeleted]    BIT           CONSTRAINT [DF_PlacesToGo_IsDeleted] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_PlacesToGo] PRIMARY KEY CLUSTERED ([PlacesToGoID] ASC)
);

