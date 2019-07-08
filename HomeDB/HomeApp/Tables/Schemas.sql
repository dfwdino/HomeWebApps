CREATE TABLE [HomeApp].[Schemas] (
    [SchemaID]   INT           IDENTITY (1, 1) NOT NULL,
    [Deleted]    BIT           CONSTRAINT [DF_Schemas_Deleted] DEFAULT ((0)) NOT NULL,
    [ModfiyID]   INT           NOT NULL,
    [SchemaName] NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_Schemas] PRIMARY KEY CLUSTERED ([SchemaID] ASC)
);



