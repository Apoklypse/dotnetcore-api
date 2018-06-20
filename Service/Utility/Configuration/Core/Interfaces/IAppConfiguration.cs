namespace Configuration.Core.Interfaces
{
    public interface IAppConfiguration
    {
        ILoggingConfiguration Logging { get; }

        ISwaggerConfiguration Swagger { get; }

        ISqlConfiguration Sql { get; }
    }
}