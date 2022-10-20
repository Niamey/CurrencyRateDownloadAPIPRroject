using CurrencyRateAPiApplication.Clients.RestApiClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyRateAPiApplication.Clients.RestApiClient.Exceptions
{
    public class RestApiFailedRequestException : CoreException
    {
        public virtual RestApiExceptionModel RestApiException { get; init; }
        public RestApiFailedRequestException(RestApiExceptionModel restApiException)
            : this("Http request error", restApiException)
        {
        }

        public RestApiFailedRequestException(string message, RestApiExceptionModel restApiException)
            : base(message, restApiException.Exception)
        {
            RestApiException = restApiException;
        }

    }
}
