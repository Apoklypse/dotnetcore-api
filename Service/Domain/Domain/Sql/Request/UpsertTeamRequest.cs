namespace Domain.Sql
{
    public class UpsertTeamRequest : IRequest
    {
        public string Name { get; set; }
    }
}
