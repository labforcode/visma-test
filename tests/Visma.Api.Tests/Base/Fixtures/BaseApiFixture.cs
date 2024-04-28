using Newtonsoft.Json;
using System.Text;
using Visma.Api.Tests.Base.DTOs;
using Visma.Api.Tests.Base.Enums;
using Visma.Api.Tests.Base.Servers;
using Visma.Api.Tests.Base.Views;

namespace Visma.Api.Tests.Base.Fixtures
{
    public abstract class BaseApiFixture
    {
        protected async Task<ResponseJsonView> HandleRequestAsync(RequestDto request)
        {
            var content = GetHttpContentAsync(request.Payload);
            var response = await RequestAsync(request, content);

            return await ReadResponseAsync(response);
        }

        protected T Deserialize<T>(dynamic response) => JsonConvert.DeserializeObject<T>(response.Data.ToString());

        private static StringContent GetHttpContentAsync(dynamic payload)
        {
            if (payload == null) return null;

            var json = JsonConvert.SerializeObject(payload);
            return new StringContent(json, Encoding.UTF8, "application/json");
        }

        private async Task<HttpResponseMessage> RequestAsync(RequestDto request, StringContent content)
        {
            var httpClient = GetHttpClient();
            return request.Type switch
            {
                RequestType.HttpPost => await httpClient.PostAsync(request.Uri, content),
                RequestType.HttpPut => await httpClient.PutAsync(request.Uri, content),
                RequestType.HttpPatch => await httpClient.PatchAsync(request.Uri, content),
                RequestType.HttpDelete => await httpClient.DeleteAsync(request.Uri),
                _ => await httpClient.GetAsync(request.Uri)
            };
        }

        private async Task<ResponseJsonView> ReadResponseAsync(HttpResponseMessage response)
        {
            var content = response.Content;
            var json = await content.ReadAsStringAsync();

            return string.IsNullOrEmpty(json) ? null : Deserialize<ResponseJsonView>(json);
        }

        private static HttpClient GetHttpClient()
        {
            var server = FactoryServer.GetServer();
            var httpClient = server.CreateClient();

            return httpClient;
        }

        //private static void LoadSettings() => AppSettingsDto.ParseAppSettings(GetSettings());

        //private static IConfigurationRoot GetSettings()
        //{
        //    var path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.Parent.FullName;
        //    return new ConfigurationBuilder().SetBasePath($"{path}/src/Visma.Api/")
        //                                     .AddJsonFile("appsettings.Tests.json")
        //                                     .Build();
        //}
    }
}
