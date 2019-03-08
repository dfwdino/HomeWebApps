CREATE TABLE [dbo].[Template] (
    [ID]       INT IDENTITY (1, 1) NOT NULL,
    [Deleted]  BIT CONSTRAINT [DF_Table_1_Deleted] DEFAULT ((0)) NOT NULL,
    [ModfiyID] INT NOT NULL,
    CONSTRAINT [PK_Template] PRIMARY KEY CLUSTERED ([ID] ASC)
);



