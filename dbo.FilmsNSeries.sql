CREATE TABLE [dbo].[FilmsNSeries] (
    [Id]                INT        NOT NULL,
    [Title]             NCHAR (20) NULL,
    [Budget]            INT        NULL,
    [ProductionCountry] NCHAR (10) NULL,
    [Description]       NCHAR (50) NULL,
    [Duration]          INT        NULL,
    [SeasonNumber]      INT        NULL,
    [EpisodesNumber]    INT        NULL,
    [Rating]            INT        NULL,
    [Exclusivity]       INT        NULL,
    [ViewsNumber]       INT        NULL,
    [Genre]             INT        NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([Exclusivity]) REFERENCES [dbo].[Companies] ([Id]),
    FOREIGN KEY ([Genre]) REFERENCES [dbo].[Genres] ([Id])
);

