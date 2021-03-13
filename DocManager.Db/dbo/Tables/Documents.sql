CREATE TABLE [dbo].[Documents]
(
    [Id]               INT IDENTITY     NOT NULL,
    [SubscriptionId]   INT              NOT NULL,
    [Species]          NVARCHAR(256)    NULL,
    [Name]             NVARCHAR (256)   NOT NULL,
    [Date]             DATETIME2 (7)    NULL,
    [PerfomerId]       INT              NOT NULL,
    CONSTRAINT [PK_Documents] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Documents_Perfomers] FOREIGN KEY ([PerfomerId], [SubscriptionId]) REFERENCES [Persons] ([Id], [SubscriptionId])
)
