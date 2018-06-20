CREATE PROCEDURE dbo.UpsertTeam
        @Name VARCHAR(100)
AS
        DECLARE @entryId INT

        INSERT INTO dbo.Team (Name)
        VALUES (@Name);

        SET @entryId = SCOPE_IDENTITY();

        SELECT @entryId AS [Id]

RETURN 0;
