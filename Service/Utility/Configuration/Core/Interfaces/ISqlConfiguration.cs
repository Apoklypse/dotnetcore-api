namespace Configuration.Core.Interfaces
{
    public interface ISqlConfiguration
    {
        string Server { get; }

        string InitialCatalog { get; }

        string IntegratedSecurity { get; }

        string MultipleActiveResultSets { get; }
    }
}