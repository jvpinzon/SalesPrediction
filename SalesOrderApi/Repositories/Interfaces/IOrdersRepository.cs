public interface IOrdersRepository
{
    Task<int> AddOrderAsync(NewOrderRequest newOrder);
    Task<IEnumerable<Order>> GetClientOrdersAsync(int clientId);
}