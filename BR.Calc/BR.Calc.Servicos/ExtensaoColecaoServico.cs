using BR.Calc.Servicos.Interfaces;
using BR.Calc.ServicosIntegrados;
using BR.Calc.ServicosIntegrados.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace BR.Calc.Servicos
{
    public static class ExtensaoColecaoServico
    {
        public static IServiceCollection AddInjecaoDependencia(this IServiceCollection services, string baseUrlApi)
        {
            services.AddScoped<ICalculoJurosServico, CalculoJurosServico>();
            services.AddScoped<ITaxaJurosServico, TaxaJurosServico>(o => new TaxaJurosServico(baseUrlApi));

            return services;
        }
    }
}
