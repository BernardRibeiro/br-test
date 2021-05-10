using BR.Taxas.Api.Controllers;
using BR.Taxas.Servicos.Interfaces;
using Moq;
using NUnit.Framework;
using System;

namespace BR.Taxas.TestesUnitarios.Api
{
    public class TaxaJurosControllerTeste
    {
        private Mock<ITaxaJurosServico> _mockTaxaJurosService;
        private TaxaJurosController _taxaJurosController;

        [SetUp]
        public void Setup()
        {
            _mockTaxaJurosService = new Mock<ITaxaJurosServico>();
            _taxaJurosController = new TaxaJurosController(_mockTaxaJurosService.Object);
        }

        [Test]
        public void DeveRetornarParametro()
        {
            var random = new Random();
            var expectativa = random.NextDouble();

            _mockTaxaJurosService
                    .Setup(s => s.RetorneTaxaJuros())
                    .Returns(expectativa);

            var resultado = _taxaJurosController.Get();

            Assert.AreEqual(expectativa, resultado);
        }

        [Test]
        public void DeveRetornarException()
        {
            var exceptionMessage = "error";

            _mockTaxaJurosService
                    .Setup(s => s.RetorneTaxaJuros())
                    .Throws(new Exception(exceptionMessage));

            var exception = Assert.Throws<Exception>(() => _taxaJurosController.Get());
            Assert.That(exception.Message, Is.EqualTo(exceptionMessage));
        }
    }
}
