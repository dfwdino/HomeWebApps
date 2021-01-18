CREATE TABLE [HomeApp].[Logging] (
    [ID]               INT            IDENTITY (1, 1) NOT NULL,
    [Date]             DATETIME       CONSTRAINT [DF_Logging_Date] DEFAULT (getdate()) NOT NULL,
    [IPAddress]        NVARCHAR (20)  NULL,
    [ControllerName]   NVARCHAR (50)  NULL,
    [ActionName]       NVARCHAR (50)  NULL,
    [ActionParameters] NVARCHAR (MAX) NULL,
    [AbsoluteUri]      NVARCHAR (50)  NULL,
    [Notes]            NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_Logging] PRIMARY KEY CLUSTERED ([ID] ASC)
);

