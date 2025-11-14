namespace Data.ConnectionConfig;

public interface IConnectionStringProvider
{
    string? GetConnectionString(string connectionType);
}