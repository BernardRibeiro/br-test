using BR.Taxas.Servicos.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BR.Taxas.Api.Controllers
{
    [ApiController]
    [Route("taxaJuros")]
    public class TaxaJurosController : ControllerBase
    {
        private ITaxaJurosServico _taxaJurosServico;

        public TaxaJurosController(ITaxaJurosServico taxaJurosServico)
        {
            _taxaJurosServico = taxaJurosServico;
        }

        [HttpGet("")]
        public double Get()
        {
            return _taxaJurosServico.RetorneTaxaJuros();
        }
    }
}
