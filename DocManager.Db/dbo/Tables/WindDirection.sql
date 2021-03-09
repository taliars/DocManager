CREATE TABLE [dbo].[WindDirection] (
    [Id]     INT IDENTITY     NOT NULL,
    [Name]   NVARCHAR (256)   COLLATE Latin1_General_CI_AI NOT NULL,
    CONSTRAINT [PK_tbl_WindDirection] PRIMARY KEY CLUSTERED ([Id] ASC)
);