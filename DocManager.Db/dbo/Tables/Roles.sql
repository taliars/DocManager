CREATE TABLE [dbo].[Roles]
(
    [Id]              INT IDENTITY    NOT NULL,
    [SubsriptionId]   INT             NOT NULL,
    [Name]            NVARCHAR(256)   NOT NULL,
    CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED ([Id] ASC)
)
