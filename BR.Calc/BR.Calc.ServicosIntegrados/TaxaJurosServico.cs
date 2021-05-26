using BR.Calc.ServicosIntegrados.Interfaces;
using System;
using System.Globalization;
using System.Net.Http;
using System.Threading.Tasks;

namespace BR.Calc.ServicosIntegrados
{
    public class TaxaJurosServico: ITaxaJurosServico
    {
        private string _baseUrlApi = string.Empty;

        private static HttpClient _client;

        public TaxaJurosServico(string baseUrlApi, HttpClient httpClient = null)
        {
            _baseUrlApi = baseUrlApi;
            _client = httpClient ?? new HttpClient();
        }

        public async Task<double> RetorneTaxaJuros()
        {
            HttpResponseMessage response = await _client.GetAsync($"{_baseUrlApi}/TaxaJuros");

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
