CREATE TABLE [dbo].[ObjectData]
(
    [Id]               INT IDENTITY    NOT NULL,
    [SubscriptionId]   INT             NOT NULL,
    [OrderId]          INT             NOT NULL,
    [Name]             NVARCHAR(256)   NOT NULL,
    [Address]          NVARCHAR(256)   NOT NULL,
    [Measurement]      NVARCHAR(256)   NOT NULL,
    [Purpose]          NVARCHAR(256)   NOT NULL,
    [Comment]          NVARCHAR(MAX)   NOT NULL,
    CONSTRAINT [PK_ObjectData] PRIMARY KEY CLUSTERED ([Id], [SubscriptionId] ASC),
    CONSTRAINT [FK_ObjectData_Order] FOREIGN KEY ([OrderId], [SubscriptionId]) REFERENCES [Order] ([Id], [SubscriptionId])
)
