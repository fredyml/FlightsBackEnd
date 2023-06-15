using Flights.Application.Contracts;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace Flights.Infrastructure.Services
{
    public class HttpClientService<T> : IHttpClientService<T>
    {
        private readonly HttpClient httpClient;

        public HttpClientService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<T> GetAsync(string url)
        {
            using (var response = await httpClient.GetAsync(url))
            {
                response.EnsureSuccessStatusCode();
                var responseContent = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(responseContent);
            }
        }

        public async Task<TResponse> PostAsync<TRequest, TResponse>(string url, TRequest requestData)
        {
            var requestContent = JsonContent.Create(requestData);

            using (var response = await httpClient.PostAsync(url, requestContent))
            {
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<TResponse>();
            }
        }
    }
}
