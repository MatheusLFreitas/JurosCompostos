using System;
using System.Collections.Generic;
using System.Text;

namespace JurosCompostos.Services
{
    public interface IJurosCompostosService
    {
        IArredondamentoService EstrategiaArredondamento { get; }
        double Calcular(double valorInicial, int tempo);
    }
}
