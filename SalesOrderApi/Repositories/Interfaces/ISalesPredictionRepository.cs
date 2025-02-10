public interface ISalesPredictionRepository
{
    Task<IEnumerable<SalesPrediction>> GetSalesPredictionsAsync();
}