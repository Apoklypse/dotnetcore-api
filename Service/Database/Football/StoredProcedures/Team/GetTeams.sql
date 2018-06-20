CREATE PROCEDURE dbo.GetTeams
AS

        SELECT Id, [Name]
        FROM dbo.Team;

RETURN 0;
