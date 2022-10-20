using CurrencyRateApiApplication.Common.APIServices;
using CurrencyRateApiApplication.Common.Helpers;
using CurrencyRateAPiApplication.Core.Clients.RestApiClient.CurrencyRateApiClient;
using System.Configuration;
using System.Net;

namespace CurrencyRateApiApplication.Common.Manager
{
    public class CurrencyRateAPIManager
    {
        private readonly CurrencyRateApiClient _apiClient;
        private readonly CurrencyRateDownloadService _currencyRateDownloadService;
        private CancellationToken _cancellationToken;
        public CurrencyRateAPIManager(CurrencyRateApiClient apiClient, CurrencyRateDownloadService currencyRateDownloadService)
        {
            _apiClient = apiClient;
            _currencyRateDownloadService = currencyRateDownloadService;
        }
        public async Task DownloadCurrencyRate()
        {

            FileTool.CreateNewDirectory(ConfigurationManager.AppSettings["Path"]);
            FileTool.ReplaceIllegalFilenameCharacters("");
            try
            {
                var data = await _currencyRateDownloadService.GetCurrencyAsync(_cancellationToken);

                FileTool.WriteTextToFile(ConfigurationManager.AppSettings["Path"], data);
                FileTool.CheckIfFileExists(ConfigurationManager.AppSettings["Path"]);
            }
            catch (WebException ex)
            {
                Console.WriteLine(ex.Message);
            }
            FileTool.DeleteDirectory(ConfigurationManager.AppSettings["Path"]);
        }
    }
}
