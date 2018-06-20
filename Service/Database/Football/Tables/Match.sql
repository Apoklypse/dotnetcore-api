CREATE TABLE [dbo].[Match]
(
        [Id] INT NOT NULL, 
        [StartDate] DATETIME2 NOT NULL, 
        [EndDate] DATETIME2 NOT NULL,
        [AwayTeamId] INT NOT NULL,
        [HomeTeamId] INT NOT NULL, 
        PRIMARY KEY ([Id]),
        FOREIGN KEY ([AwayTeamId]) REFERENCES [dbo].[Team]([Id]),
        FOREIGN KEY ([HomeTeamId]) REFERENCES [dbo].[Team]([Id])
)
