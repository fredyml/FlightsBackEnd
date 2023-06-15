namespace Flights.Application.Contracts
{
    public interface IHttpClientService<T>
    {
        Task<T> GetAsync(string url);
        Task<TResponse> PostAsync<TRequest, TResponse>(string url, TRequest requestData);
    }
}
