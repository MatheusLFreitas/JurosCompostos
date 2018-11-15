using System;
using System.Collections.Generic;
using System.Text;

namespace JurosCompostos.Services.Exceptions
{
    public class ValorNegativoException : ArgumentException
    {
        public ValorNegativoException(string paramName) : base("Negative", paramName)
        {

        }
    }
}
