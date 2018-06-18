namespace Configuration.Core.Interfaces
{
    public interface ISwaggerConfiguration
    {
        string DocTitle { get; }

        string EndpointName { get; }
        string EndpointUrl { get; }
        string Version { get; }
    }
}