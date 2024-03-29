﻿CREATE TABLE [MateTracker].[EventActions] (
    [EventActionsID]    INT IDENTITY (1, 1) NOT NULL,
    [GivingPersonID]    INT NOT NULL,
    [ReveivingPersonID] INT NOT NULL,
    [ActionID]          INT NOT NULL,
    [OwnerID]           INT NOT NULL,
    [EventID]           INT NOT NULL,
    CONSTRAINT [PK_EventActions] PRIMARY KEY CLUSTERED ([EventActionsID] ASC),
    CONSTRAINT [FK_EventActions_Actions] FOREIGN KEY ([ActionID]) REFERENCES [MateTracker].[Actions] ([ActionID]),
    CONSTRAINT [FK_EventActions_TheEvent] FOREIGN KEY ([EventID]) REFERENCES [MateTracker].[TheEvent] ([EventID]),
    CONSTRAINT [FK_EventActions_Users] FOREIGN KEY ([OwnerID]) REFERENCES [HomeApp].[Users] ([UserID]),
    CONSTRAINT [FK_EventActions_UsersPeople] FOREIGN KEY ([GivingPersonID]) REFERENCES [MateTracker].[UsersPeople] ([UsersPersonID]),
    CONSTRAINT [FK_EventActions_UsersPeople1] FOREIGN KEY ([ReveivingPersonID]) REFERENCES [MateTracker].[UsersPeople] ([UsersPersonID])
);







