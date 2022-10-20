using CurrencyRateAPiApplication.Clients.RestApiClient.Abstraction;
using CurrencyRateAPiApplication.Clients.RestApiClient.Base;
using CurrencyRateAPiApplication.Clients.RestApiClient.Enum;
using CurrencyRateAPiApplication.Clients.RestApiClient.Models;
using CurrencyRateAPiApplication.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyRateAPiApplication.Clients.RestApiClient.Default
{
        public abstract class DefaultApiClient : RestAPiBaseClient
        {
            public override async Task<RestApiClientResponse> PostAsync(Uri requestUri, string data, RestApiClientHeaderCollection headers, RestApiMediaContentTypeEnum mediaType, int timeoutSeconds, CancellationToken cancellationToken)
            {
                using var httpClientHandler = new HttpClientHandler()
                {
                    ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
                };

                using var client = CreateInstance(httpClientHandler, headers, timeoutSeconds);

                using var content = new StringContent(data, Encoding.UTF8, mediaType.GetDescription());
                using var response = await client.PostAsync(requestUri, content, cancellationToken);

                return await CheckResponseAsync<RestApiClientResponse>(response);
            }

            public override async Task<RestApiClientResponse> GetAsync(Uri requestUri, RestApiClientHeaderCollection headers, int timeoutSeconds, CancellationToken cancellationToken)
            {
                using var httpClientHandler = new HttpClientHandler()
                {
                    ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
                };

                using var client = CreateInstance(httpClientHandler, headers, timeoutSeconds);

                using var response = await client.GetAsync(requestUri, cancellationToken);

                return await CheckResponseAsync<RestApiClientResponse>(response);
            }

            public override async Task<RestApiClientResponse> PutAsync(Uri requestUri, string data, RestApiClientHeaderCollection headers, RestApiMediaContentTypeEnum mediaType, int timeoutSeconds, CancellationToken cancellationToken)
            {
                using var httpClientHandler = new HttpClientHandler()
                {
                    ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
                };

                using var client = CreateInstance(httpClientHandler, headers, timeoutSeconds);

                using var content = new StringContent(data, Encoding.UTF8, mediaType.GetDescription());
                using var response = await client.PutAsync(requestUri, content, cancellationToken);

                return await CheckResponseAsync<RestApiClientResponse>(response);
            }
        }
    }
