using Dapper;
using SalesOrderApi.Repositories.Resources;

public class ShippersRepository : IShippersRepository
{
    private readonly DbConnectionFactory _dbConnectionFactory;

    public ShippersRepository(DbConnectionFactory dbConnectionFactory)
    {
        _dbConnectionFactory = dbConnectionFactory;
    }

    public async Task<IEnumerable<Shipper>> GetShippersAsync()
    {
        using var connection = _dbConnectionFactory.CreateConnection();
        return await connection.QueryAsync<Shipper>(Resource.Shippers_Get);
    }
}