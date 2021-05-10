using BR.Calc.Servicos.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Threading.Tasks;

namespace BR.Calc.Api.Controllers
{
    [ApiController]
    [Route("CalculaJuros")]
    public class CalculaJurosController : ControllerBase
    {
        private ICalculoJurosServico _calculoJurosServico;

        public CalculaJurosController(ICalculoJurosServico calculoJurosServico)
        {
            _calculoJurosServico = calculoJurosServico;
        }

        [HttpGet("")]
        public async Task<double> Get([BindRequired, FromQuery] double valorInicial, [BindRequired, FromQuery] int meses)
        {
            return await _calculoJurosServico.CalculeTaxaDeJurosCompostos(valorInicial, meses);
        }
    }
}
