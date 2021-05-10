using BR.Taxas.Servicos;
using NUnit.Framework;

namespace BR.Taxas.TestesUnitarios.Servicos
{
    public class TaxaJurosServicoTeste
    {
        private TaxaJurosServico _taxaJurosServico;

        [SetUp]
        public void Setup()
        {
            _taxaJurosServico = new TaxaJurosServico();
        }

        [Test]
        public void DeveRetornarParametro()
        {
            var expectativa = 0.01;
            var resultado = _taxaJurosServico.RetorneTaxaJuros();

            Assert.AreEqual(expectativa, resultado);
        }
    }
}
