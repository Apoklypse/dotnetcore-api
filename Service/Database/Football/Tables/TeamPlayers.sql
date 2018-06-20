CREATE TABLE [dbo].[TeamPlayers]
(
        [Id] INT NOT NULL IDENTITY(1, 1), 
        [PlayerId] INT NOT NULL,
        [TeamId] INT NOT NULL, 
        PRIMARY KEY ([Id]),
        FOREIGN KEY ([PlayerId]) REFERENCES [dbo].[Player]([Id]),
        FOREIGN KEY ([TeamId]) REFERENCES [dbo].[Team]([Id])
)
