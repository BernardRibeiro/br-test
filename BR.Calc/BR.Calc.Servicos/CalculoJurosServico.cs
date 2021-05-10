using BR.Calc.Servicos.Interfaces;
using BR.Calc.ServicosIntegrados.Interfaces;
using System;
using System.Threading.Tasks;

namespace BR.Calc.Servicos
{
    public class CalculoJurosServico : ICalculoJurosServico
    {
        private ITaxaJurosServico _taxaJurosServico;

        public CalculoJurosServico(ITaxaJurosServico taxaJurosServico)
        {
            _taxaJurosServico = taxaJurosServico;
        }

        public async Task<double> CalculeTaxaDeJurosCompostos(double valorInicial, int meses)
        {
            var tavaJuros = await _taxaJurosServico.RetorneTaxaJuros();

            var calculoInicial = Math.Pow((1 + tavaJuros), meses);
            var resultadoCalculo = valorInicial * calculoInicial;

            return Math.Truncate(100 * resultadoCalculo) / 100;
        }
    }
}
