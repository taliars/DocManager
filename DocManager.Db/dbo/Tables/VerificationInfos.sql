CREATE TABLE [dbo].[VerificationInfos]
(
    [Id]               INT IDENTITY    NOT NULL,
    [SubscriptionId]   INT             NOT NULL,
    [Number]           NVARCHAR(256)   NOT NULL,
    [Organization]     NVARCHAR(256)   NOT NULL,
    [Expiration]       DATETIME2(7)    NOT NULL,
    CONSTRAINT [PK_VerificationInfos] PRIMARY KEY CLUSTERED ([Id], [SubscriptionId] ASC),
)
