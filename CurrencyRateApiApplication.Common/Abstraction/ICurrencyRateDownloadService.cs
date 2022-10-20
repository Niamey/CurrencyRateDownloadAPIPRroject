
namespace CurrencyRateApiApplication.Common.Abstraction
{
    public interface ICurrencyRateDownloadService
    {
        Task<string> GetCurrencyAsync(CancellationToken cancellationToken);
    }
}
