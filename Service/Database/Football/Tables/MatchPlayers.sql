﻿CREATE TABLE [dbo].[MatchPlayers]
(
        [Id] INT NOT NULL IDENTITY(1, 1), 
        [MatchId] INT NOT NULL,
        [PlayerId] INT NOT NULL, 
        PRIMARY KEY ([Id]),
        FOREIGN KEY ([MatchId]) REFERENCES [dbo].[Match]([Id]),
        FOREIGN KEY ([PlayerId]) REFERENCES [dbo].[Player]([Id])
)
