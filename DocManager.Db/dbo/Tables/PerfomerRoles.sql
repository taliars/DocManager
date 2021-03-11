CREATE TABLE [dbo].[PerfomerRoles]
(
    [Id]              INT IDENTITY   NOT NULL,
    [SubscriptionId]  INT            NOT NULL,
    [Name]            NVARCHAR(16)   NOT NULL,
    CONSTRAINT [PK_PerfomerRoles] PRIMARY KEY CLUSTERED ([Id] ASC)
)
