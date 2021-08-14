CREATE TABLE [MateTracker].[Actions] (
    [ActionID]  INT           IDENTITY (1, 1) NOT NULL,
    [IsDeleted] BIT           CONSTRAINT [DF_Actions_IsDeleted] DEFAULT ((0)) NOT NULL,
    [Name]      NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_Actions] PRIMARY KEY CLUSTERED ([ActionID] ASC)
);

