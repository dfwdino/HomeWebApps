CREATE TABLE [MateTracker].[Events] (
    [EventID]           INT                IDENTITY (1, 1) NOT NULL,
    [DateOfEvent]       DATE               CONSTRAINT [DF_Events_DateOfEvent] DEFAULT (getdate()) NOT NULL,
    [DateOfEventOffSet] DATETIMEOFFSET (7) NULL,
    [EventName]         NVARCHAR (50)      NULL,
    [IsDeleted]         BIT                CONSTRAINT [DF_Events_IsDeleted] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_Events] PRIMARY KEY CLUSTERED ([EventID] ASC)
);

