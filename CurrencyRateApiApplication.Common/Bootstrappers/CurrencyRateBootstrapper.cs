using CurrencyRateApiApplication.Common.APIServices;
using CurrencyRateAPiApplication.Core.Clients.RestApiClient.CurrencyRateApiClient;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyRateApiApplication.Common.Bootstrappers
{
    public static class CurrencyRateBootstrapper
    {
            public static void AddCurrencyRates(this IServiceCollection services)
            {
                services.AddTransient<CurrencyRateDownloadService>();
                services.AddTransient<CurrencyRateApiClient>();
            }
        }
}
