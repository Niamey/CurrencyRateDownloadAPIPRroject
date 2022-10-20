using CurrencyRateApiApplication.Common.Abstraction;
using CurrencyRateAPiApplication.Core.Clients.RestApiClient.CurrencyRateApiClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyRateApiApplication.Common.APIServices
{
    public class CurrencyRateDownloadService : ICurrencyRateDownloadService
    {
        private readonly CurrencyRateApiClient _apiClient;
        private readonly string url = "https://www.cnb.cz/cs/financni-trhy/devizovy-trh/kurzy-devizoveho-trhu/kurzy-devizoveho-trhu/denni_kurz.txt";
       
        public CurrencyRateDownloadService(CurrencyRateApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<string> GetCurrencyAsync( CancellationToken cancellationToken) 
        {
            var result = await _apiClient.GetTryAsync(new Uri(url), cancellationToken);
            var res = result.Response;
            return res;
        }
    }
}
