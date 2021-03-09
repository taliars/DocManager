CREATE TABLE [dbo].[WindDirections] (
    [Id]     INT IDENTITY     NOT NULL,
    [Name]   NVARCHAR (256)   COLLATE Latin1_General_CI_AI NOT NULL,
    CONSTRAINT [PK_tbl_WindDirections] PRIMARY KEY CLUSTERED ([Id] ASC)
);