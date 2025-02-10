using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ShippersController : ControllerBase
{
    private readonly ShippersService _shippersService;

    public ShippersController(ShippersService shippersService)
    {
        _shippersService = shippersService;
    }

    [HttpGet]
    public async Task<IActionResult> GetShippersAsync()
    {
        var shippers = await _shippersService.GetShippersAsync();
        if (shippers == null || !shippers.Any())
        {
            return NotFound();
        }

        return Ok(shippers);
    }
}
