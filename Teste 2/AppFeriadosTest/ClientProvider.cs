using AppFeriados;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace AppFeriadosTest
{
    public class ClientProvider : IDisposable
    {
        private TestServer Server;

        public HttpClient Client { get; set; }

        public ClientProvider()
        {
            Server = new TestServer(new WebHostBuilder().UseStartup<Startup>());

            Client = Server.CreateClient();
        }

        public void Dispose()
        {
            //Recursos não gerenciados
            Server?.Dispose();
            Client?.Dispose();
        }
    }
}
