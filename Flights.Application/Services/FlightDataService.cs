using Flights.Application.Contracts;
using Flights.Application.Dtos;

namespace Flights.Application.Services
{
    public class FlightDataService : IFlightDataService
    {
        private readonly IHttpClientService<List<NewShoreResponseDto>> _httpClientService;

        public FlightDataService(IHttpClientService<List<NewShoreResponseDto>> httpClientService)
        {
            _httpClientService = httpClientService;
        }

        public async Task<List<NewShoreResponseDto>> GetAllFlightsAsync()
        {
            return await _httpClientService.GetAsync(Environment.GetEnvironmentVariable("MULTIPLE_RETURN_ROUTES_URL"));
        }
    }
}
