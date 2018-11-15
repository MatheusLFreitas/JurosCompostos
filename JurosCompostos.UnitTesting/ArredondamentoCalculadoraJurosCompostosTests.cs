using JurosCompostos.Services;
using JurosCompostos.Services.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace JurosCompostos.UnitTesting
{
    public class ArredondamentoCalculadoraJurosCompostosTests
    {
        [Fact]
        public void JurosCompostos_NaoDeveAceitarTempoZero()
        {
            Assert.Throws<ValorZeradoException>(() =>
            {
                IJurosCompostosService sut = new CalculadoraJurosCompostos(new ArredondamentoTruncado());

                sut.Calcular(1, 0);
            });
        }

        [Fact]
        public void JurosCompostos_NaoDeveAceitarTempoNegativo()
        {
            Assert.Throws<ValorNegativoException>(() =>
            {
                IJurosCompostosService sut = new CalculadoraJurosCompostos(new ArredondamentoTruncado());

                sut.Calcular(1, -1);
            });
        }

        [Fact]
        public void JurosCompostos_NaoDeveAceitarValorInicialNegativo()
        {
            Assert.Throws<ValorNegativoException>(() =>
            {
                IJurosCompostosService sut = new CalculadoraJurosCompostos(new ArredondamentoTruncado());

                sut.Calcular(-1, 1);
            });
        }

        [Fact]
        public void JurosCompostos_NaoDeveAceitarValorInicialZero()
        {
            Assert.Throws<ValorZeradoException>(() =>
            {
                IJurosCompostosService sut = new CalculadoraJurosCompostos(new ArredondamentoTruncado());

                sut.Calcular(0, 1);
            });
        }

        [Fact]
        public void JurosCompostos_AoReceberValoresPositivos_DeveComputarValor()
        {
            IJurosCompostosService sut = new CalculadoraJurosCompostos(new ArredondamentoTruncado());

            double resultado;

            resultado = sut.Calcular(10, 2);

            Assert.Equal("12.1", resultado.ToString());
        }
    }
}
