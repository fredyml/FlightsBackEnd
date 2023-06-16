using Flights.Application.Dtos;

namespace Flights.Application.Contracts
{
    public interface IFlightDataService
    {
        Task<List<NewShoreResponseDto>> GetAllFlightsAsync();
    }
}
