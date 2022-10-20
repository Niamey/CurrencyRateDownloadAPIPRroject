﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyRateAPiApplication.Clients.RestApiClient.Exceptions
{
        public class CoreException : Exception
        {
            public CoreException(string? message, Exception? innerException)
                : base(message, innerException)
            {
            }
        }
}
