CREATE TABLE [dbo].[WeatherDays]
(
    [Id]                INT IDENTITY   NOT NULL,
    [Date]              DATETIME2(7)   NOT NULL,
    [Temperature]       NVARCHAR(3)    NOT NULL,
    [WindDirectionId]   INT            NOT NULL,
    [WindSpeed]         INT            NULL,
    [Cloudness]         INT            NULL,
    [Pressure]          INT            NULL,
    [Moisture]          INT            NULL,
    CONSTRAINT [PK_WeatherDays] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_WeatherDays_WindDirections] FOREIGN KEY ([WindDirectionId]) REFERENCES [WindDirections] ([Id])
)
