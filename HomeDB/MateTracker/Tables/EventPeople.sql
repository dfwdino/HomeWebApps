CREATE TABLE [MateTracker].[EventPeople] (
    [PartyPersonID]   INT           NOT NULL,
    [EntryUserID]     INT           NOT NULL,
    [PartyPersonName] NVARCHAR (50) NOT NULL,
    [IsDeleted]       BIT           CONSTRAINT [DF_PartyPeople_IsDeleted] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_PartyPeople] PRIMARY KEY CLUSTERED ([PartyPersonID] ASC),
    CONSTRAINT [FK_PartyPeople_Users] FOREIGN KEY ([EntryUserID]) REFERENCES [HomeApp].[Users] ([UserID])
);

