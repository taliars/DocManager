CREATE TABLE [dbo].[Document]
(
    [Id]               INT IDENTITY     NOT NULL,
    [SubscriptionId]   INT              NOT NULL,
    [Species]          NVARCHAR(256)    NULL,
    [Name]             NVARCHAR (256)   NOT NULL,
    [Date]             DATETIME2 (7)    NULL,
    [PerfomerId]       INT              NOT NULL,
    CONSTRAINT [PK_Document] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Document_Perfomer] FOREIGN KEY ([PerfomerId], [SubscriptionId]) REFERENCES [User] ([Id], [SubscriptionId])
)
