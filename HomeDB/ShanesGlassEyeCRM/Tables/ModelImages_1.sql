CREATE TABLE [ShanesGlassEyeCRM].[ModelImages] (
    [ModelImageID]  INT            IDENTITY (1, 1) NOT NULL,
    [Title]         NVARCHAR (50)  NOT NULL,
    [ImageName]     NVARCHAR (100) NOT NULL,
    [ImageFile]     IMAGE          NOT NULL,
    [ModelPersonID] INT            NULL,
    CONSTRAINT [PK_ModelImages] PRIMARY KEY CLUSTERED ([ModelImageID] ASC),
    CONSTRAINT [FK_ModelImages_Models] FOREIGN KEY ([ModelPersonID]) REFERENCES [ShanesGlassEyeCRM].[ModelPeople] ([ModelPersonID])
);



