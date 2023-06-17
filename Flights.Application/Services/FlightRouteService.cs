using Flights.Application.Contracts;
using Flights.Application.Dtos;

namespace Flights.Application.Services
{
    public class FlightRouteService : IFlightRouteService
    {
        private readonly IFlightDataService _flightDataService;
        public int MaxFlightCount { get; set; }

        public FlightRouteService(IFlightDataService flightDataService)
        {
            _flightDataService = flightDataService;
            MaxFlightCount = Convert.ToInt32(Environment.GetEnvironmentVariable("MAX_FLIGHT_COUNT"));
        }

        public async Task<JourneyDto> CalculateRoute(string origin, string destination)
        {
            var flights = await _flightDataService.GetAllFlightsAsync();
            var route = FindRoute(origin, destination, flights);

            if (route == null)
            {
                throw new InvalidOperationException("Su consulta no puede ser procesada");
            }

            if (route.Count > MaxFlightCount)
            {
                throw new InvalidOperationException("El número de vuelos en la ruta excede el límite permitido");
            }

            return BuildJourney(route);
        }

        private List<NewShoreResponseDto> FindRoute(string origin, string destination, List<NewShoreResponseDto> flights)
        {
            var route = new List<NewShoreResponseDto>();
            var currentLocation = origin;

            while (currentLocation != destination)
            {
                var nextFlight = flights.FirstOrDefault(f => f.DepartureStation == currentLocation && !route.Contains(f));
                if (nextFlight == null)
                {
                    throw new InvalidOperationException("Su consulta no puede ser procesada");
                }

                route.Add(nextFlight);
                currentLocation = nextFlight.ArrivalStation;
            }

            return route;
        }

        private JourneyDto BuildJourney(List<NewShoreResponseDto> routeFlights)
        {
            var price = routeFlights.Sum(flight => flight.Price);

            var flights = routeFlights.Select(flight => new FlightDto
            {
                Origin = flight.DepartureStation,
                Destination = flight.ArrivalStation,
                Price = flight.Price,
                Transport = new TransportDto
                {
                    FlightCarrier = flight.FlightCarrier,
                    FlightNumber = flight.FlightNumber
                }
            }).ToList();

            return new JourneyDto
            {
                Origin = routeFlights.First().DepartureStation,
                Destination = routeFlights.Last().ArrivalStation,
                Price = price,
                Flights = flights
            };
        }
    }
}
