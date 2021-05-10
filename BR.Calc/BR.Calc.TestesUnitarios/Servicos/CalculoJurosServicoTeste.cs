using BR.Calc.Servicos;
using BR.Calc.ServicosIntegrados.Interfaces;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BR.Calc.TestesUnitarios.Servicos
{
    public class CalculoJurosServicoTeste
    {
        private Mock<ITaxaJurosServico> _mockTaxaJurosServico;
        private CalculoJurosServico _calculoJurosServico;

        [SetUp]
        public void Setup()
        {
            _mockTaxaJurosServico = new Mock<ITaxaJurosServico>();
            _calculoJurosServico = new CalculoJurosServico(_mockTaxaJurosServico.Object);
        }

        [Test]
        public async Task DeveRecuperarTaxaJuro()
        {
            var taxaJuros = 9.9;

            _mockTaxaJurosServico
                .Setup(o => o.RetorneTaxaJuros())
                .ReturnsAsync(() => taxaJuros);

            await _calculoJurosServico.CalculeTaxaDeJurosCompostos(It.IsAny<double>(), It.IsAny<int>());

            _mockTaxaJurosServico
                .Verify(o => o.RetorneTaxaJuros(), Times.Once());
        }

        [Test]
        public async Task DeveRetornarCalculo()
        {
            var taxaJuros = 0.01;
            var valorInicial = 65;
            var meses = 5;

            var expectativa = Math.Truncate(valorInicial * Math.Pow((1 + taxaJuros), meses) * 100) / 100;

            _mockTaxaJurosServico
                .Setup(o => o.RetorneTaxaJuros())
                .ReturnsAsync(() => taxaJuros);

            var resultado = await _calculoJurosServico.CalculeTaxaDeJurosCompostos(valorInicial, meses);

            Assert.AreEqual(expectativa, resultado);
        }

        [Test]
        public void DeveRetornarException()
        {
            var exceptionMessage = "error";

            _mockTaxaJurosServico
                   .Setup(s => s.RetorneTaxaJuros())
                   .Throws(new Exception(exceptionMessage));

            var exception = Assert.ThrowsAsync<Exception>(() => _calculoJurosServico.CalculeTaxaDeJurosCompostos(It.IsAny<double>(), It.IsAny<int>()));
            Assert.That(exception.Message, Is.EqualTo(exceptionMessage));
        }
    }
}
