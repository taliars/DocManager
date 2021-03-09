CREATE TABLE [dbo].[Subscription]
(
    [Id]     INT IDENTITY   NOT NULL,
    [Name]   NVARCHAR(256)  NOT NULL,
    CONSTRAINT [PK_Suscription] PRIMARY KEY CLUSTERED ([Id] ASC),
)
