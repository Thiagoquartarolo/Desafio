using AppFeriados.Domain.Models;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AppFeriadosTest
{
    public class AppFeriadosTest
    {
        [Fact]
        public async Task Test_Get()
        {
            using (var client = new ClientProvider().Client)
            {
                var response = await client.GetAsync("/v1/Feriado");
                response.EnsureSuccessStatusCode();

                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
        }

        [Fact]
        public async Task Test_Post()
        {
            using (var client = new ClientProvider().Client)
            {
                var response = await client.PostAsync("/v1/Feriado", new StringContent(
                   JsonConvert.SerializeObject(new Feriado()
                   {
                       FeriadoId = 0,
                       FeriadoNome = "Teste Feriado",
                       DataFeriado = DateTime.Now,
                       TipoFeriadoId = 2
                   })
                   , Encoding.UTF8, "application/json"));
                response.EnsureSuccessStatusCode();

                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
        }
    }
}
