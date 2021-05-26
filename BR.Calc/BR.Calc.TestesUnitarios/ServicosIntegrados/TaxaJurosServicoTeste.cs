using BR.Calc.ServicosIntegrados;
using Moq;
using Moq.Protected;
using NUnit.Framework;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace BR.Calc.TestesUnitarios.ServicosIntegrados
{
    public class TaxaJurosServicoTeste
    {
        private Mock<HttpMessageHandler> _mockHttpMessageHandler;
        private TaxaJurosServico _taxaJurosServico;

        [SetUp]
        public void SetUp()
        {
            _mockHttpMessageHandler = new Mock<HttpMessageHandler>();
        }

        [Test]
        public async Task ShouldResult()
        {
            var response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent("9.9"),
            };

            _mockHttpMessageHandler
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
               .ReturnsAsync(response);

            var baseFakeUrl = "http://localhost";
            var httpClient = new HttpClient(_mockHttpMessageHandler.Object);

            _taxaJurosServico = new TaxaJurosServico(baseFakeUrl, httpClient);

            var resultado = await _taxaJurosServico.RetorneTaxaJuros();

            Assert.NotNull(resultado);

            _mockHttpMessageHandler
                .Protected()
                .Verify(
                    "SendAsync",
                    Times.Exactly(1),
                    ItExpr.Is<HttpRequestMessage>(req => req.Method == HttpMethod.Get),
                    ItExpr.IsAny<CancellationToken>());

        }
    }
}
