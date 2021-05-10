using BR.Taxas.Servicos.Interfaces;

namespace BR.Taxas.Servicos
{
    public class TaxaJurosServico : ITaxaJurosServico
    {
        private const double TaxaJurosPadrao = 0.01;

        public double RetorneTaxaJuros()
        {
            return TaxaJurosPadrao;
        }
    }
}
