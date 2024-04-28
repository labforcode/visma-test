using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Visma.HR.Api;

namespace Visma.Api.Tests.Base.Servers
{
    public abstract class FactoryServer
    {
        private static TestServer? _testServer;

        public static TestServer GetServer()
        {
            if (_testServer == null) GetInstance();

            return _testServer;
        }

        private static void GetInstance()
        {
            _testServer = new TestServer(new WebHostBuilder()
                                                .ConfigureAppConfiguration((context, config) =>
                                                {
                                                    config.AddJsonFile("appsettings.Tests.json", optional: false, reloadOnChange: true);
                                                })
                                                .UseStartup<Startup>()
                                                .UseEnvironment("Tests"));
        }
    }
}
