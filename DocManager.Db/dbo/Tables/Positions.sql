CREATE TABLE [dbo].[Positions]
(
    [Id]               INT IDENTITY   NOT NULL,
    [SubscriptionId]   INT            NOT NULL,
    [Name]             NVARCHAR(16)   NOT NULL,
    CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED ([Id], [SubscriptionId] ASC)
)
