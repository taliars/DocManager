CREATE TABLE [dbo].[Device]
(
    [Id]                   INT IDENTITY    NOT NULL,
    [SubscriptionId]       INT             NOT NULL,
    [Name]                 NVARCHAR(256)   NOT NULL,
    [Use]                  NVARCHAR(256)   NULL,
    [Number]               NVARCHAR(13)    NULL,
    [Range]                NVARCHAR(256)   NULL,
    [Fault]                NVARCHAR(256)   NULL,
    [VerificationInfoId]   INT             NOT NULL
    CONSTRAINT [PK_Device] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Device_VerificationInfo] FOREIGN KEY ([VerificationInfoId], [SubscriptionId]) REFERENCES [VerificationInfo] ([Id], [SubscriptionId]),
)