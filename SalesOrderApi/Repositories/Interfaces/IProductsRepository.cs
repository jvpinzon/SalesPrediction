public interface IProductsRepository
{
    Task<IEnumerable<Product>> GetProductsAsync();
}