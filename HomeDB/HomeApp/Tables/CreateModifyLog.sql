CREATE TABLE [HomeApp].[CreateModifyLog] (
    [CreateModifyID] INT  IDENTITY (1, 1) NOT NULL,
    [CreatedBy]      INT  NOT NULL,
    [CreatedOn]      DATE CONSTRAINT [DF_CreateModifyLog_CreatedDate] DEFAULT (getdate()) NOT NULL,
    [ModifyOn]       DATE NULL,
    [ModifyBy]       INT  NULL,
    [Deleted]        BIT  CONSTRAINT [DF_CreateModifyLog_Deleted] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_CreateModifyLog] PRIMARY KEY CLUSTERED ([CreateModifyID] ASC)
);

