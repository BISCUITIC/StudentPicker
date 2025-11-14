namespace Data.ConnectionConfig;

internal interface IConnectionStringProvider
{
    string? GetConnectionString(string connectionType);
}