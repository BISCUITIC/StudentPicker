using Microsoft.Extensions.Configuration;

namespace Data;

public class ConnectionStringProvider : IConnectionStringProvider
{
    private readonly ConfigurationBuilder _builder;
    private readonly IConfigurationRoot _config;

    private const string PATH_JSON_CONFIG = "appsettings.json";
    
    public ConnectionStringProvider()
    {
        _builder = new ConfigurationBuilder();
        _config = _builder.AddJsonFile(PATH_JSON_CONFIG)
                          .SetBasePath(Directory.GetCurrentDirectory())
                          .Build();
    }

    public string? GetConnectionString(string connectionType)
    {        
        return _config.GetConnectionString(connectionType);
    }
}
