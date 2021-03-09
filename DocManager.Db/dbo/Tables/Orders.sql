CREATE TABLE [dbo].[Orders]
(
	[Id]               INT IDENTITY   NOT NULL,
	[SubscriptionId]   INT            NOT NULL,
	[ObjectDataId]     INT            NULL,
	[CustomerId]       INT            NULL,
	CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED ([Id], [SubscriptionId] ASC),
	CONSTRAINT [FK_Subscription] FOREIGN KEY ([SubscriptionId]) REFERENCES [Subscriptions] ([Id]),
	CONSTRAINT [FK_Orders_ObjectDatas] FOREIGN KEY ([ObjectDataId], [SubscriptionId]) REFERENCES [ObjectDatas] ([Id], [SubscriptionId]),
	CONSTRAINT [FK_Orders_Customers] FOREIGN KEY ([CustomerId], [SubscriptionId]) REFERENCES [Customers] ([Id], [SubscriptionId])
)
