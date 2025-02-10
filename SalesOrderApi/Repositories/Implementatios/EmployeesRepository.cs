using Dapper;
using SalesOrderApi.Repositories.Resources;

public class EmployeesRepository : IEmployeesRepository
{
    private readonly DbConnectionFactory _dbConnectionFactory;

    public EmployeesRepository(DbConnectionFactory dbConnectionFactory)
    {
        _dbConnectionFactory = dbConnectionFactory;
    }

    public async Task<IEnumerable<Employee>> GetEmployeesAsync()
    {
        using var connection = _dbConnectionFactory.CreateConnection();
        return await connection.QueryAsync<Employee>(Resource.Employees_Get);
    }
}
