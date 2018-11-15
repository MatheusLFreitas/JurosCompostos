using System;
using System.Collections.Generic;
using System.Text;

namespace JurosCompostos.Services
{
    public class ArredondamentoTruncado : IArredondamentoService
    {
        /// <summary>
        /// Trunca o valor considerando apenas duas casas decimais.
        /// </summary>
        /// <param name="valor"></param>
        /// <returns></returns>
        public double Arredondar(double valor)
        {
            return Math.Truncate(valor * 100) / 100;
        }
    }
}
