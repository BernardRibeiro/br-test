using BR.Calc.Api.Controllers;
using BR.Calc.Servicos.Interfaces;
using Moq;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace BR.Calc.TestesUnitarios.Api
{
    public class CalculaJurosControllerTeste
    {
        private Mock<ICalculoJurosServico> _mockCalculoJurosService;
        private CalculaJurosController _calculaJurosController;

        [SetUp]
        public void Setup()
        {
            _mockCalculoJurosService = new Mock<ICalculoJurosServico>();
            _calculaJurosController = new CalculaJurosController(_mockCalculoJurosService.Object);
        }

        [Test]
        public void DeveConterParametros()
        {
            var valorInicial = 0.8;
            var meses = 7;

            _mockCalculoJurosService
                   .Setup(s => s.CalculeTaxaDeJurosCompostos(It.IsAny<double>(), It.IsAny<int>()))
                   .Returns(It.IsAny<Task<double>>());

            var result = _calculaJurosController.Get(valorInicial, meses);

            _mockCalculoJurosService
                .Verify(controller =>
                    controller.CalculeTaxaDeJurosCompostos(
                        It.Is<double>(value => value.Equals(valorInicial)), It.Is<int>(value => value.Equals(meses))),
                        Times.Once()
                    );
        }

        [Test]
        public async Task DeveRetornarCalculo()
        {
            var resultado = 0.8;

            _mockCalculoJurosService
                   .Setup(s => s.CalculeTaxaDeJurosCompostos(It.IsAny<double>(), It.IsAny<int>()))
                   .ReturnsAsync(() => resultado);

            var retornoCalculo = await _calculaJurosController.Get(It.IsAny<double>(), It.IsAny<int>());

            Assert.AreEqual(resultado, retornoCalculo);
        }

        [Test]
        public void DeveRetornarException()
        {
            var exceptionMessage = "error";

            _mockCalculoJurosService
                   .Setup(s => s.CalculeTaxaDeJurosCompostos(It.IsAny<double>(), It.IsAny<int>()))
                   .Throws(new Exception(exceptionMessage));

            var exception = Assert.ThrowsAsync<Exception>(() => _calculaJurosController.Get(It.IsAny<double>(), It.IsAny<int>()));
            Assert.That(exception.Message, Is.EqualTo(exceptionMessage));
        }
    }
}
