CREATE TABLE [Gas].[Types] (
    [GasTypeID] INT           IDENTITY (1, 1) NOT NULL,
    [Deleted]   BIT           CONSTRAINT [DF_Types_Deleted] DEFAULT ((0)) NOT NULL,
    [ModfiyID]  INT           NULL,
    [TypeName]  NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_Types] PRIMARY KEY CLUSTERED ([GasTypeID] ASC)
);

