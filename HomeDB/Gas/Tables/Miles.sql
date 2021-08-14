CREATE TABLE [Gas].[Miles] (
    [MilesID]          INT             IDENTITY (1, 1) NOT NULL,
    [Deleted]          BIT             CONSTRAINT [DF_Miles_Deleted] DEFAULT ((0)) NOT NULL,
    [ModfiyID]         INT             NOT NULL,
    [AutoID]           INT             NOT NULL,
    [GasDate]          DATETIME        NOT NULL,
    [TotalGallons]     DECIMAL (18, 3) NOT NULL,
    [TotalPrice]       DECIMAL (6, 2)  NULL,
    [TotalMilesDriven] DECIMAL (11, 1) NOT NULL,
    [EngineRunTime]    TIME (7)        NULL,
    [StationID]        INT             NOT NULL,
    [GasTypeID]        INT             NULL,
    CONSTRAINT [PK_Miles] PRIMARY KEY CLUSTERED ([MilesID] ASC),
    CONSTRAINT [FK_Miles_Auto] FOREIGN KEY ([AutoID]) REFERENCES [Gas].[Autos] ([AutoID]),
    CONSTRAINT [FK_Miles_CreateModifyLog] FOREIGN KEY ([ModfiyID]) REFERENCES [HomeApp].[CreateModifyLog] ([CreateModifyID]),
    CONSTRAINT [FK_Miles_Stations] FOREIGN KEY ([StationID]) REFERENCES [Gas].[Stations] ([StationID]),
    CONSTRAINT [FK_Miles_Types] FOREIGN KEY ([GasTypeID]) REFERENCES [Gas].[Types] ([GasTypeID])
);









