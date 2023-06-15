using Flights.Application.Contracts;
using Flights.Application.Dtos;

namespace Flights.Application.Services
{
    public class FlightManagerService : IFlightManagerService
    {
        private readonly IHttpClientService<List<NewShoreResponseDto>> _httpClientService;

        public FlightManagerService(IHttpClientService<List<NewShoreResponseDto>> httpClientService)
        {
            _httpClientService = httpClientService;
        }

        public void CalculateRoute()
        {

        }
    }
}
