CREATE TABLE [ChoreList].[ChoreTimeType] (
    [ChoreTimeTypeID] INT           IDENTITY (1, 1) NOT NULL,
    [ChoreTime]       NVARCHAR (50) NOT NULL,
    [IsDeleted]       BIT           CONSTRAINT [DF_ChoreTimeType_IsDeleted] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_ChoreTimeType] PRIMARY KEY CLUSTERED ([ChoreTimeTypeID] ASC)
);

