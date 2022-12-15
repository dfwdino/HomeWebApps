CREATE TABLE [ChoreList].[ChoreDayTimeType] (
    [ChoreDayTimeTypeID] INT           IDENTITY (1, 1) NOT NULL,
    [DayTimeType]        NVARCHAR (50) NOT NULL,
    [IsDeleted]          BIT           CONSTRAINT [DF_ChoreDayTimeType_IsDeleted] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_ChoreDayTimeType] PRIMARY KEY CLUSTERED ([ChoreDayTimeTypeID] ASC)
);

