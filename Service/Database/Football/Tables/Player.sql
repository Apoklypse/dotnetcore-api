CREATE TABLE [dbo].[Player]
(
        [Id] INT NOT NULL IDENTITY(1, 1), 
        [Name] VARCHAR(100) NOT NULL, 
        [Position] VARCHAR(100) NOT NULL,
        PRIMARY KEY ([Id])
)
