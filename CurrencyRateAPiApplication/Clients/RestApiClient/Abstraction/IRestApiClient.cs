using CurrencyRateAPiApplication.Clients.RestApiClient.Enum;
using CurrencyRateAPiApplication.Clients.RestApiClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyRateAPiApplication.Clients.RestApiClient.Abstraction
{
    public interface IRestApiClient
    {
        Task<RestApiClientResponse> GetAsync(Uri requestUri, RestApiClientHeaderCollection headers, int timeoutSeconds, CancellationToken cancellationToken);
        Task<RestApiClientResponse> PostAsync(Uri requestUri, string data, RestApiClientHeaderCollection headers, RestApiMediaContentTypeEnum mediaType, int timeoutSeconds, CancellationToken cancellationToken);
        Task<RestApiClientResponse> PutAsync(Uri requestUri, string data, RestApiClientHeaderCollection headers, RestApiMediaContentTypeEnum mediaType, int timeoutSeconds, CancellationToken cancellationToken);
    }
}
