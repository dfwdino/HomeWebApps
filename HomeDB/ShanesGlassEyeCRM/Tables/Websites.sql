CREATE TABLE [ShanesGlassEyeCRM].[Websites] (
    [WebsitesID]  INT           IDENTITY (1, 1) NOT NULL,
    [WebsiteName] NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_Websites] PRIMARY KEY CLUSTERED ([WebsitesID] ASC)
);

