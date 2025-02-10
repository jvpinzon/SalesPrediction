public interface IShippersRepository
{
    Task<IEnumerable<Shipper>> GetShippersAsync();
}