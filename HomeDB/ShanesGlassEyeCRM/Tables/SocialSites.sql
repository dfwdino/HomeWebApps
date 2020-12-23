CREATE TABLE [ShanesGlassEyeCRM].[SocialSites] (
    [SocalTypeID]   INT           IDENTITY (1, 1) NOT NULL,
    [SocalSiteName] NVARCHAR (50) NULL,
    CONSTRAINT [PK_SocalSites] PRIMARY KEY CLUSTERED ([SocalTypeID] ASC)
);

