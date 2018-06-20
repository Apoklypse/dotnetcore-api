CREATE TABLE [dbo].[Goal]
(
        [Id] INT NOT NULL, 
        [Time] INT NOT NULL,
        [MatchId] INT NOT NULL, 
        [PlayerId] INT NOT NULL,
        PRIMARY KEY ([Id]),
        FOREIGN KEY ([MatchId]) REFERENCES [dbo].[Match]([Id]),
        FOREIGN KEY ([PlayerId]) REFERENCES [dbo].[Player]([Id])
)
