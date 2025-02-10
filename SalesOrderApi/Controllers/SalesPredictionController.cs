using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class SalesPredictionController : ControllerBase
{
    private readonly SalesPredictionService _salesPredictionService;

    public SalesPredictionController(SalesPredictionService salesPredictionService)
    {
        _salesPredictionService = salesPredictionService;
    }

    [HttpGet]
    public async Task<IActionResult> GetSalesPredictionsAsync()
    {
        var predictions = await _salesPredictionService.GetSalesPredictionsAsync();
        if (predictions == null || !predictions.Any())
        {
            return NotFound();
        }

        return Ok(predictions);
    }
}
