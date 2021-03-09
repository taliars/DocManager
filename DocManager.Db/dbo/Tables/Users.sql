CREATE TABLE [dbo].[Users]
(
    [Id]               INT IDENTITY    NOT NULL,
    [SubscriptionId]   INT             NOT NULL,
    [FirstName]        NVARCHAR(256)   NOT NULL,
    [LastName]         NVARCHAR(256)   NOT NULL,
    [Patronymic]       NVARCHAR(256)   NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY ([Id], [SubscriptionId] ASC),
)
