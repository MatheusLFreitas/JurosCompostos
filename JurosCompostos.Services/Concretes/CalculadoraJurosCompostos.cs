using JurosCompostos.Services.Exceptions;
using System;

namespace JurosCompostos.Services
{
    public class CalculadoraJurosCompostos : IJurosCompostosService
    {
        private const double TaxaJuros = 0.01d;
        private const double MultiplicadorJuros = 1 + TaxaJuros;

        public IArredondamentoService EstrategiaArredondamento { get; private set; }

        public CalculadoraJurosCompostos(IArredondamentoService estrategiaArredondamento)
        {
            EstrategiaArredondamento = estrategiaArredondamento;
        }

        public double Calcular(double valorInicial, int tempo)
        {
            if (valorInicial < 0) throw new ValorNegativoException(nameof(valorInicial));
            if (valorInicial == 0) throw new ValorZeradoException(nameof(valorInicial));
            if (tempo < 0) throw new ValorNegativoException(nameof(tempo));
            if (tempo == 0) throw new ValorZeradoException(nameof(tempo));

            double valor = valorInicial * Math.Pow(MultiplicadorJuros, tempo);

            double result = EstrategiaArredondamento.Arredondar(valor);

            return result;
        }
    }
}
