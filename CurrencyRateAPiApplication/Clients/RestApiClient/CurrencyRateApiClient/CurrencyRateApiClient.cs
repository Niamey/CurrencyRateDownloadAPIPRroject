using CurrencyRateAPiApplication.Clients.RestApiClient.Abstraction;
using CurrencyRateAPiApplication.Clients.RestApiClient.Default;
using CurrencyRateAPiApplication.Clients.RestApiClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyRateAPiApplication.Core.Clients.RestApiClient.CurrencyRateApiClient
{
    public class CurrencyRateApiClient : DefaultApiClient
    {
        protected override HttpClient CreateInstance(HttpClientHandler httpClientHandler, RestApiClientHeaderCollection headers, int timeoutSeconds)
        {
            var httpClient = new HttpClient(httpClientHandler)
            {
                Timeout = TimeSpan.FromSeconds(timeoutSeconds),
            };

            if (headers?.Count > 0)
            {
                foreach (var header in headers)
                {
                    httpClient.DefaultRequestHeaders.Add(header.Name, header.Value);
                }
            }

            return httpClient;
        }

        protected override void ThrowException(RestApiExceptionModel restApiException)
        {
           // throw new DistanceMeasurementExeption(restApiException);
        }
    }
}
