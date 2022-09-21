CREATE TABLE [MateTracker].[TheEvent] (
    [EventID]           INT                IDENTITY (1, 1) NOT NULL,
    [DateOfEvent]       DATE               NOT NULL,
    [DateofEventOffSet] DATETIMEOFFSET (7) NULL,
    [IsDeleted]         BIT                CONSTRAINT [DF_TheEvent_IsDeleted] DEFAULT ((0)) NOT NULL,
    [EventName]         NVARCHAR (50)      NULL,
    [Notes]             NVARCHAR (MAX)     NULL,
    CONSTRAINT [PK_TheEvent] PRIMARY KEY CLUSTERED ([EventID] ASC)
);



