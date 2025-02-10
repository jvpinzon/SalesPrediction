using Microsoft.Data.SqlClient;

public class DbConnectionFactory
{
    private readonly string _connectionString;
    private string? v;

    public DbConnectionFactory(string connection)
    {
        _connectionString = connection;
    }

    public SqlConnection CreateConnection() => new SqlConnection(_connectionString);

}