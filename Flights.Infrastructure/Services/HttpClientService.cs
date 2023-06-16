using Flights.Application.Contracts;
using System.Net.Http.Json;

namespace Flights.Infrastructure.Services
{
    public class HttpClientService<T> : IHttpClientService<T>
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public HttpClientService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
        }

        public async Task<T> GetAsync(string url)
        {
            var httpClient = _httpClientFactory.CreateClient();
            var response = await httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<T>();
            }

            throw new HttpRequestException($"Cannot GET from {url}. Status code: {response.StatusCode}");
        }

        public async Task<TResponse> PostAsync<TRequest, TResponse>(string url, TRequest requestData)
        {
            var httpClient = _httpClientFactory.CreateClient();
            var requestContent = JsonContent.Create(requestData);
            var response = await httpClient.PostAsync(url, requestContent);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<TResponse>();
            }

            throw new HttpRequestException($"Cannot POST to {url}. Status code: {response.StatusCode}");
        }
    }
}
