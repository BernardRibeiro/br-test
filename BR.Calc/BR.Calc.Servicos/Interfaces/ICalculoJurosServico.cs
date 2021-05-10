using System.Threading.Tasks;

namespace BR.Calc.Servicos.Interfaces
{
    public interface ICalculoJurosServico
    {
        Task<double> CalculeTaxaDeJurosCompostos(double valorInicial, int meses);
    }
}
