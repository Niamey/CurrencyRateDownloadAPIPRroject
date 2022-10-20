using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyRateAPiApplication.Clients.RestApiClient.Models
{
    public class RestApiClientResponse
    {
        public Uri RequestUrl { get; init; }
        public object Request { get; init; }

        public string Response { get; init; }
        public byte[] ResponseRaw { get; init; }
        public HttpStatusCode StatusCode { get; init; }
        public bool IsSuccessStatusCode { get; init; }

        public List<Cookie> Cookies { get; init; }
    }
}
