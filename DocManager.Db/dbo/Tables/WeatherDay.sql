CREATE TABLE [dbo].[WeatherDay]
(
    [Id]                INT IDENTITY   NOT NULL,
    [Date]              DATETIME2(7)   NOT NULL,
    [Temperature]       NVARCHAR(3)    NOT NULL,
    [WindDirectionId]   INT            NOT NULL,
    [WindSpeed]         INT            NULL,
    [Cloudness]         INT            NULL,
    [Pressure]          INT            NULL,
    [Moisture]          INT            NULL,
    CONSTRAINT [PK_WeatherDay] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_WeatherDay_WindDirection] FOREIGN KEY ([WindDirectionId]) REFERENCES [WindDirection] ([Id])
)
