CREATE TABLE [ShanesGlassEyeCRM].[ModelWebsites] (
    [ModelWebsitesID] INT NOT NULL,
    [WebsiteID]       INT NOT NULL,
    [CameraModelID]   INT NOT NULL,
    CONSTRAINT [PK_ModelWebsites] PRIMARY KEY CLUSTERED ([ModelWebsitesID] ASC),
    CONSTRAINT [FK_ModelWebsites_Websites] FOREIGN KEY ([WebsiteID]) REFERENCES [ShanesGlassEyeCRM].[Websites] ([WebsitesID])
);

