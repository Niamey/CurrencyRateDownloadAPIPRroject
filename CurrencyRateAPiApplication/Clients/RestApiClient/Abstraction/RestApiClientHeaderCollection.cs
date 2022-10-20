using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyRateAPiApplication.Clients.RestApiClient.Abstraction
{
        public class RestApiClientHeaderCollection : List<RestApiClientHeader>
        {
            public void Add(string name, string value)
            {

                this.Add(new RestApiClientHeader
                {
                    Name = name,
                    Value = value
                });
            }
        }
}
