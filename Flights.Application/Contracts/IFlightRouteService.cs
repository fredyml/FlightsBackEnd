using Flights.Application.Dtos;

namespace Flights.Application.Contracts
{
    public interface IFlightRouteService
    {
        Task<JourneyDto> CalculateRoute(string origin, string destination);
    }
}
