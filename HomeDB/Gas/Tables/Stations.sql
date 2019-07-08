CREATE TABLE [Gas].[Stations] (
    [StationID] INT           IDENTITY (1, 1) NOT NULL,
    [Deleted]   BIT           NOT NULL,
    [ModfiyID]  INT           NOT NULL,
    [Name]      NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_Station] PRIMARY KEY CLUSTERED ([StationID] ASC),
    CONSTRAINT [FK_Stations_CreateModifyLog] FOREIGN KEY ([ModfiyID]) REFERENCES [HomeApp].[CreateModifyLog] ([CreateModifyID])
);

