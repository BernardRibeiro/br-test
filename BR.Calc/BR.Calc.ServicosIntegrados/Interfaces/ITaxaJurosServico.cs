using System.Threading.Tasks;

namespace BR.Calc.ServicosIntegrados.Interfaces
{
    public interface ITaxaJurosServico
    {
        Task<double> RetorneTaxaJuros();
    }
}
