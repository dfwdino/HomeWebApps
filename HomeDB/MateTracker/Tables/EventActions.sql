CREATE TABLE [MateTracker].[EventActions] (
    [ActionEventID] INT IDENTITY (1, 1) NOT NULL,
    [EventID]       INT NOT NULL,
    [EntryPersonID] INT NOT NULL,
    [EventPersonID] INT NOT NULL,
    [ActionID]      INT NOT NULL,
    [IsDeleted]     BIT CONSTRAINT [DF_EventActions_IsDeleted] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_EventActions] PRIMARY KEY CLUSTERED ([ActionEventID] ASC),
    CONSTRAINT [FK_EventActions_Actions] FOREIGN KEY ([ActionID]) REFERENCES [MateTracker].[Actions] ([ActionID]),
    CONSTRAINT [FK_EventActions_Events] FOREIGN KEY ([EventID]) REFERENCES [MateTracker].[Events] ([EventID]),
    CONSTRAINT [FK_EventActions_PartyPeople] FOREIGN KEY ([EventPersonID]) REFERENCES [MateTracker].[EventPeople] ([PartyPersonID]),
    CONSTRAINT [FK_EventActions_Users] FOREIGN KEY ([EntryPersonID]) REFERENCES [HomeApp].[Users] ([UserID])
);

