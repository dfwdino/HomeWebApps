CREATE TABLE [HomeApp].[Schemas] (
    [SchemaID] INT IDENTITY (1, 1) NOT NULL,
    [Deleted]  BIT CONSTRAINT [DF_Schemas_Deleted] DEFAULT ((0)) NOT NULL,
    [ModfiyID] INT NOT NULL
);

