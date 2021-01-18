CREATE TABLE [ShanesGlassEyeCRM].[ModelImages] (
    [ModelImage] INT            IDENTITY (1, 1) NOT NULL,
    [Title]      NVARCHAR (50)  NOT NULL,
    [ImageName]  NVARCHAR (100) NOT NULL,
    [ImageFile]  IMAGE          NOT NULL,
    [ModelID]    INT            NULL,
    CONSTRAINT [PK_ModelImages] PRIMARY KEY CLUSTERED ([ModelImage] ASC),
    CONSTRAINT [FK_ModelImages_Models] FOREIGN KEY ([ModelID]) REFERENCES [ShanesGlassEyeCRM].[Models] ([ModelID])
);

