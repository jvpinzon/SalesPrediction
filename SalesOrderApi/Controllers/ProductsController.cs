using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly ProductsService _productsService;

    public ProductsController(ProductsService productsService)
    {
        _productsService = productsService;
    }

    [HttpGet]
    public async Task<IActionResult> GetProductsAsync()
    {
        var products = await _productsService.GetProductsAsync();
        if (products == null || !products.Any())
        {
            return NotFound();
        }

        return Ok(products);
    }
}
