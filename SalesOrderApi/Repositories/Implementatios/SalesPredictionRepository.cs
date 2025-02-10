using Dapper;
using SalesOrderApi.Repositories.Resources;

public class SalesPredictionRepository : ISalesPredictionRepository
{
    private readonly DbConnectionFactory _dbConnectionFactory;

    public SalesPredictionRepository(DbConnectionFactory dbConnectionFactory)
    {
        _dbConnectionFactory = dbConnectionFactory;
    }

    public async Task<IEnumerable<SalesPrediction>> GetSalesPredictionsAsync()
    {
        using var connection = _dbConnectionFactory.CreateConnection();
        return await connection.QueryAsync<SalesPrediction>(Resource.SalesPrediction_Get);
    }
}
