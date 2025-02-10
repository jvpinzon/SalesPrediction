using Dapper;
using SalesOrderApi.Repositories.Resources;

public class ProductsRepository : IProductsRepository
{
    private readonly DbConnectionFactory _dbConnectionFactory;

    public ProductsRepository(DbConnectionFactory dbConnectionFactory)
    {
        _dbConnectionFactory = dbConnectionFactory;
    }

    public async Task<IEnumerable<Product>> GetProductsAsync()
    {
        using var connection = _dbConnectionFactory.CreateConnection();
        return await connection.QueryAsync<Product>(Resource.Products_Get);
    }
}