using JurosCompostos.Services;
using System;
using Xunit;

namespace JurosCompostos.UnitTesting
{
    public class ArredondamentoServiceTests
    {
        //Atenção: Todos os Asserts utilizam toString() devido a representação por ponto flutuante.

        [Fact]
        public void Arredondamento_SemCasasDecimais_DeveManterValor()
        {
            IArredondamentoService sut = new ArredondamentoTruncado();

            double valor = 10;

            double resultado = sut.Arredondar(valor);

            Assert.Equal(valor, resultado);
        }

        [Fact]
        public void Arredondamento_ComUmaCasasDecimal_DeveManterValor()
        {
            IArredondamentoService sut = new ArredondamentoTruncado();

            double taxaIncremento = 0.1;

            double incremento = 0;

            double valor = 10;

            for (int i = 0; i < 10; i++)
            {
                incremento += taxaIncremento;

                valor += incremento;

                double resultado = sut.Arredondar(valor);

                Assert.Equal(valor.ToString(), resultado.ToString());
            }            
        }

        [Fact]
        public void Arredondamento_ComDuasCasasDecimais_DeveManterValor()
        {
            IArredondamentoService sut = new ArredondamentoTruncado();

            double taxaIncremento = 0.15;

            double incremento = 0;

            double valor = 10;

            for (int i = 0; i < 10; i++)
            {
                incremento += taxaIncremento;

                valor += incremento;

                double resultado = sut.Arredondar(valor);

                Assert.Equal(valor.ToString(), resultado.ToString());
            }
        }

        [Fact]
        public void Arredondamento_ComMaisDeDuasCasasDecimais_DeveManterApenasDuasCasas()
        {
            IArredondamentoService sut = new ArredondamentoTruncado();

            double valor = 10.351;
            double valorEsperado = 10.35;

            double resultado = sut.Arredondar(valor);

            Assert.Equal(valorEsperado.ToString(), resultado.ToString());

            valor = 10.551;
            valorEsperado = 10.55;

            resultado = sut.Arredondar(valor);

            Assert.Equal(valorEsperado.ToString(), resultado.ToString());

            valor = 10.321 + 5.123;
            valorEsperado = 15.44;

            resultado = sut.Arredondar(valor);

            Assert.Equal(valorEsperado.ToString(), resultado.ToString());


            valor = 1.987654321 + 1.120;
            valorEsperado = 3.1;

            resultado = sut.Arredondar(valor);

            Assert.Equal(valorEsperado.ToString(), resultado.ToString());
        }
    }
}
