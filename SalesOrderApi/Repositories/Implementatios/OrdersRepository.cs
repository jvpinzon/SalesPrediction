using Dapper;
using SalesOrderApi.Repositories.Resources;

public class OrdersRepository : IOrdersRepository
{
    private readonly DbConnectionFactory _dbConnectionFactory;

    public OrdersRepository(DbConnectionFactory dbConnectionFactory)
    {
        _dbConnectionFactory = dbConnectionFactory;
    }

    public async Task<int> AddOrderAsync(NewOrderRequest newOrder)
    {
        using var connection = _dbConnectionFactory.CreateConnection();
        await connection.OpenAsync();
        using var transaction = connection.BeginTransaction();

        try
        {
            int orderId = await connection.ExecuteScalarAsync<int>(Resource.Orders_Create, newOrder, transaction);

            if (newOrder.OrderDetails?.Any() == true)
            {
                var orderDetailsParams = newOrder.OrderDetails.Select(detail => new
                {
                    OrderId = orderId,
                    detail.ProductId,
                    detail.UnitPrice,
                    detail.Qty,
                    detail.Discount
                });

                await connection.ExecuteAsync(Resource.Orders_CreateDetails, orderDetailsParams, transaction);
            }

            transaction.Commit();
            return orderId;
        }
        catch (Exception ex)
        {
            transaction.Rollback();
            throw new InvalidOperationException("No se pudo guardar la orden. Verifique los datos e intente nuevamente.", ex);
        }
    }

    public async Task<IEnumerable<Order>> GetClientOrdersAsync(int clientId)
    {
        using var connection = _dbConnectionFactory.CreateConnection();
        return await connection.QueryAsync<Order>(Resource.Orders_Get, new { ClientId = clientId });
    }
}
