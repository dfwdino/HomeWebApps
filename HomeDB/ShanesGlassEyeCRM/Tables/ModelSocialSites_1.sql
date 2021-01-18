CREATE TABLE [ShanesGlassEyeCRM].[ModelSocialSites] (
    [ModelSocialID] INT           IDENTITY (1, 1) NOT NULL,
    [SocialSiteID]  INT           NOT NULL,
    [ModelID]       INT           NOT NULL,
    [Deleted]       BIT           CONSTRAINT [DF_ModelSocialSites_Deleted] DEFAULT ((0)) NOT NULL,
    [ModfiyID]      INT           NULL,
    [URL]           NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_ModelSocialSites] PRIMARY KEY CLUSTERED ([ModelSocialID] ASC),
    CONSTRAINT [FK_ModelSocialSites_Models] FOREIGN KEY ([ModelID]) REFERENCES [ShanesGlassEyeCRM].[Models] ([ModelID]),
    CONSTRAINT [FK_ModelSocialSites_SocalSites] FOREIGN KEY ([SocialSiteID]) REFERENCES [ShanesGlassEyeCRM].[SocialSites] ([SocalTypeID])
);

