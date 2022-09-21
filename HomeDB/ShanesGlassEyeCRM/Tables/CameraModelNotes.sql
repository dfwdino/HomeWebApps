CREATE TABLE [ShanesGlassEyeCRM].[CameraModelNotes] (
    [NotesID]       INT            IDENTITY (1, 1) NOT NULL,
    [DateOfNotes]   DATETIME       CONSTRAINT [DF_CameraModelNotes_DateOfNotes] DEFAULT (getdate()) NOT NULL,
    [CameraModelID] INT            NOT NULL,
    [Notes]         NVARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_CameraModelNotes] PRIMARY KEY CLUSTERED ([NotesID] ASC),
    CONSTRAINT [FK_CameraModelNotes_CameraModels] FOREIGN KEY ([CameraModelID]) REFERENCES [ShanesGlassEyeCRM].[CameraModels] ([CameraModelID])
);

