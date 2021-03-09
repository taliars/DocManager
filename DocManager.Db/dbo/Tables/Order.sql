CREATE TABLE [dbo].[Order]
(
	[Id]               INT IDENTITY   NOT NULL,
	[SubscriptionId]   INT            NOT NULL,
	[ObjectDataId]     INT            NOT NULL,
	[CustomerId]       INT            NOT NULL,
	CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED ([Id], [SubscriptionId] ASC),
	CONSTRAINT [FK_Order_ObjectData] FOREIGN KEY ([ObjectDataId], [SubscriptionId]) REFERENCES [ObjectData] ([Id], [SubscriptionId]),
	CONSTRAINT [FK_Order_Customer] FOREIGN KEY ([CustomerId], [SubscriptionId]) REFERENCES [Customer] ([Id], [SubscriptionId])
)
