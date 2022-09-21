CREATE TABLE [Personal].[WeightTracker] (
    [WeightID]    INT             IDENTITY (1, 1) NOT NULL,
    [WeightAmout] DECIMAL (18, 1) NULL,
    [WeightData]  DATETIME        CONSTRAINT [DF_WeightTracker_WeightData] DEFAULT (getdate()) NULL,
    [UserID]      INT             NULL,
    [Deleted]     BIT             CONSTRAINT [DF_WeightTracker_Deleted] DEFAULT ((0)) NULL,
    [Notes]       NVARCHAR (MAX)  NULL,
    CONSTRAINT [PK_WeightTracker] PRIMARY KEY CLUSTERED ([WeightID] ASC),
    CONSTRAINT [FK_WeightTracker_Users] FOREIGN KEY ([UserID]) REFERENCES [HomeApp].[Users] ([UserID])
);



