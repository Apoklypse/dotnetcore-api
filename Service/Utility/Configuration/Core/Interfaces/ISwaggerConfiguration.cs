namespace Configuration.Core.Interfaces
{
    public interface ISwaggerConfiguration
    {
        string DocTitle { get; }

        string Version { get; }

        string EndpointName { get; }

        string EndpointUrl { get; }
    }
}
