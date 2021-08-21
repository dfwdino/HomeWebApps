CREATE TABLE [MateTracker].[Genders] (
    [GenderID]  INT           IDENTITY (1, 1) NOT NULL,
    [Gender]    NVARCHAR (50) NOT NULL,
    [IsDeleted] BIT           CONSTRAINT [DF_Genders_IsDeleted] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_Genders] PRIMARY KEY CLUSTERED ([GenderID] ASC)
);

