CREATE TABLE [Gym].[Machines] (
    [MachineID]       INT           IDENTITY (1, 1) NOT NULL,
    [MachineName]     NVARCHAR (50) NULL,
    [Time]            INT           NULL,
    [Reps]            INT           NULL,
    [Weight]          INT           NULL,
    [ResistanceLevel] INT           NULL,
    [WorkedOutDate]   DATE          CONSTRAINT [DF_Machines_WorkedOutDate] DEFAULT (getdate()) NOT NULL,
    [IsDeleted]       BIT           CONSTRAINT [DF_Machines_IsDeleted] DEFAULT ((0)) NOT NULL,
    [UserID]          INT           NOT NULL,
    CONSTRAINT [PK_Machines] PRIMARY KEY CLUSTERED ([MachineID] ASC),
    CONSTRAINT [FK_Machines_Users] FOREIGN KEY ([UserID]) REFERENCES [HomeApp].[Users] ([UserID])
);



