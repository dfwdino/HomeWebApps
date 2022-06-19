CREATE TABLE [ShanesGlassEyeCRM].[CameraModels] (
    [CameraModelID]     INT            IDENTITY (1, 1) NOT NULL,
    [CameraModelName]   NVARCHAR (250) NOT NULL,
    [CameraModelGender] INT            NOT NULL,
    [Deleted]           BIT            CONSTRAINT [DF_CameraModels_Deleted] DEFAULT ((0)) NOT NULL,
    [AllNudes]          BIT            NULL,
    [AllBonjour]        BIT            NULL,
    [AllTFP]            BIT            NULL,
    CONSTRAINT [PK_CameraModels] PRIMARY KEY CLUSTERED ([CameraModelID] ASC),
    CONSTRAINT [FK_CameraModels_GenderTypes] FOREIGN KEY ([CameraModelGender]) REFERENCES [ShanesGlassEyeCRM].[GenderTypes] ([GenderID])
);

