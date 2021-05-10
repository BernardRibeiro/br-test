using BR.Taxas.Api;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Hosting;
using NUnit.Framework;
using System.Threading.Tasks;

namespace BR.Taxas.TestesIntegrados
{
    public class TaxaJurosControllerTeste
    {
        [Test]
        public async Task DeveComunicarApi()
        {
            var hostBuilder = new HostBuilder()
                .ConfigureWebHost(webHost =>
                {
                    webHost.UseTestServer();
                    webHost.UseEnvironment("Test");
                    webHost.UseStartup<Startup>();
                });

            var host = await hostBuilder.StartAsync();
            var client = host.GetTestClient();
            var response = await client.GetAsync("/taxajuros");

            var expectativa = "0.01";

            var responseString = await response.Content.ReadAsStringAsync();
            Assert.AreEqual(expectativa, responseString);
        }
    }
}