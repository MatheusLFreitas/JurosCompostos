using System;
using System.Collections.Generic;
using System.Text;

namespace JurosCompostos.Services.Exceptions
{
    public class ValorZeradoException: ArgumentException
    {
        public ValorZeradoException(string paramName) : base("Zero", paramName)
        {

        }
    }
}
