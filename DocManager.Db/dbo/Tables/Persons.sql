CREATE TABLE [dbo].[Persons]
(
    [Id]               INT IDENTITY    NOT NULL,
    [SubscriptionId]   INT             NOT NULL,
    [FirstName]        NVARCHAR(256)   NOT NULL,
    [LastName]         NVARCHAR(256)   NOT NULL,
    [Patronymic]       NVARCHAR(256)   NOT NULL,
    [LoginId]          INT             NOT NULL,
    [PositionId]       INT             NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY ([Id], [SubscriptionId] ASC),
    CONSTRAINT [FK_Persons_Logins] FOREIGN KEY ([LoginId]) REFERENCES Logins ([Id]),
    CONSTRAINT [FK_Persons_Positions] FOREIGN KEY ([PositionId], [SubscriptionId]) REFERENCES Positions ([Id], [SubscriptionId]),
)
