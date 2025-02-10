public class ProductsService
{
    private readonly IProductsRepository _productsRepository;

    public ProductsService(IProductsRepository productsRepository)
    {
        _productsRepository = productsRepository;
    }

    public async Task<IEnumerable<Product>> GetProductsAsync()
    {
        return await _productsRepository.GetProductsAsync();
    }
}
