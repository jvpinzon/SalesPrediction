public class SalesPredictionService
{
    private readonly ISalesPredictionRepository _salesPredictionRepository;

    public SalesPredictionService(ISalesPredictionRepository salesPredictionRepository)
    {
        _salesPredictionRepository = salesPredictionRepository;
    }

    public async Task<IEnumerable<SalesPrediction>> GetSalesPredictionsAsync()
    {
        return await _salesPredictionRepository.GetSalesPredictionsAsync();
    }
}
