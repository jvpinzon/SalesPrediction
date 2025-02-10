using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class OrdersController : ControllerBase
{
    private readonly OrdersService _ordersService;

    public OrdersController(OrdersService ordersService)
    {
        _ordersService = ordersService;
    }

    [HttpPost]
    public async Task<IActionResult> AddOrderAsync([FromBody] NewOrderRequest newOrder)
    {
        var orderId = await _ordersService.AddOrderAsync(newOrder);
        if (orderId <= 0)
        {
            return BadRequest("Could not create order");
        }

        return Ok(orderId);
    }

    [HttpGet("{clientId}")]
    public async Task<IActionResult> GetClientOrdersAsync(int clientId)
    {
        var orders = await _ordersService.GetClientOrdersAsync(clientId);
        if (orders == null || !orders.Any())
        {
            return NotFound();
        }

        return Ok(orders);
    }
}
