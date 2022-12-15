CREATE TABLE [dbo].[UsersCLs] (
    [UserCLID]  INT            IDENTITY (1, 1) NOT NULL,
    [Name]      NVARCHAR (MAX) NULL,
    [IsDeleted] BIT            NOT NULL,
    CONSTRAINT [PK_dbo.UsersCLs] PRIMARY KEY CLUSTERED ([UserCLID] ASC)
);

