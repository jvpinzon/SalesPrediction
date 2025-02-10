public class OrdersService
{
    private readonly IOrdersRepository _ordersRepository;

    public OrdersService(IOrdersRepository ordersRepository)
    {
        _ordersRepository = ordersRepository;
    }

    public async Task<int> AddOrderAsync(NewOrderRequest newOrder)
    {
        return await _ordersRepository.AddOrderAsync(newOrder);
    }

    public async Task<IEnumerable<Order>> GetClientOrdersAsync(int clientId)
    {
        return await _ordersRepository.GetClientOrdersAsync(clientId);
    }
}
