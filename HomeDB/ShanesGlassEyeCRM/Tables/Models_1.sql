CREATE TABLE [ShanesGlassEyeCRM].[Models] (
    [ModelID]     INT            IDENTITY (1, 1) NOT NULL,
    [Deleted]     BIT            CONSTRAINT [DF_Models_Deleted] DEFAULT ((0)) NOT NULL,
    [ModfiyID]    INT            NULL,
    [FirstName]   NVARCHAR (50)  NOT NULL,
    [LastName]    NVARCHAR (50)  NULL,
    [Gender]      NVARCHAR (50)  NOT NULL,
    [AllNudes]    BIT            NULL,
    [AllBoudoir]  BIT            NULL,
    [AllErotica]  BIT            NULL,
    [Notes]       NVARCHAR (MAX) NULL,
    [PhoneNumber] NVARCHAR (25)  NULL,
    [Email]       NVARCHAR (50)  NULL,
    [FileName]    NVARCHAR (255) NULL,
    CONSTRAINT [PK_Models] PRIMARY KEY CLUSTERED ([ModelID] ASC)
);

