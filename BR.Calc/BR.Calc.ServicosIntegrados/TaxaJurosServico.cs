using BR.Calc.ServicosIntegrados.Interfaces;
using System;
using System.Globalization;
using System.Net.Http;
using System.Threading.Tasks;

namespace BR.Calc.ServicosIntegrados
{
    public class TaxaJurosServico: ITaxaJurosServico
    {
        private const string ApiUrl = "https://localhost:44335/taxaJuros";

        private static HttpClient _client;

        public TaxaJurosServico(HttpClient httpClient = null)
        {
            _client = httpClient ?? new HttpClient();
        }

        public async Task<double> RetorneTaxaJuros()
        {
            HttpResponseMessage response = await _client.GetAsync(ApiUrl);

            if (response.IsSuccessStatusCode)
            {
                var taxaJuros = await response.Content.ReadAsStringAsync();

                return FormateTaxaJuros(taxaJuros);
            }

            return 0;
        }

        private double FormateTaxaJuros(string taxaJuros)
        {
            var provider = new NumberFormatInfo();
            provider.NumberDecimalSeparator = ".";

            return Convert.ToDouble(taxaJuros, provider);
        }
    }
}
