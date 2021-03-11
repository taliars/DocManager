CREATE TABLE [dbo].[Logins]
(
    [Id]         INT             NOT NULL,
    [UserName]   NVARCHAR(256)   NOT NULL,
    [Password]   NVARCHAR(256)   NOT NULL,
    [Role]       NVARCHAR(16)    NOT NULL,
    CONSTRAINT [PK_Logins] PRIMARY KEY ([Id] ASC)
)
