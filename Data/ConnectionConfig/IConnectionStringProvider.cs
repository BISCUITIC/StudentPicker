namespace Infrastructure.ConnectionConfig;

public interface IConnectionStringProvider
{
    string? GetConnectionString(string connectionType);
}