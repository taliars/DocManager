CREATE TABLE [dbo].[Role]
(
    [Id]              INT IDENTITY    NOT NULL,
    [SubsriptionId]   INT             NOT NULL,
    [Name]            NVARCHAR(256)   NOT NULL,
    CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED ([Id] ASC)
)
