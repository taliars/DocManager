CREATE TABLE [dbo].[Subscriptions]
(
    [Id]     INT IDENTITY   NOT NULL,
    [Name]   NVARCHAR(256)  NOT NULL,
    CONSTRAINT [PK_Suscriptions] PRIMARY KEY CLUSTERED ([Id] ASC),
)
