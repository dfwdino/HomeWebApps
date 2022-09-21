CREATE TABLE [ShanesGlassEyeCRM].[GenderTypes] (
    [GenderID]   INT           IDENTITY (1, 1) NOT NULL,
    [GenderType] NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_GenderTypes] PRIMARY KEY CLUSTERED ([GenderID] ASC)
);



