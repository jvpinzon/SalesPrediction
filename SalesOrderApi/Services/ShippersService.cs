public class ShippersService
{
    private readonly IShippersRepository _shippersRepository;

    public ShippersService(IShippersRepository shippersRepository)
    {
        _shippersRepository = shippersRepository;
    }

    public async Task<IEnumerable<Shipper>> GetShippersAsync()
    {
        return await _shippersRepository.GetShippersAsync();
    }
}
