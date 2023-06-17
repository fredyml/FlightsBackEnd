using Flights.Application.Contracts;
using Flights.Application.Dtos;
using Moq;

namespace Flights.Application.Services.Tests
{
    public class FlightRouteServiceTests
    {
        private Mock<IFlightDataService> _flightDataServiceMock;
        private FlightRouteService _flightRouteService;

        public FlightRouteServiceTests()
        {
            _flightDataServiceMock = new Mock<IFlightDataService>();
            _flightRouteService = new FlightRouteService(_flightDataServiceMock.Object);
        }

        [Fact]
        public async Task CalculateRoute_ValidOriginAndDestination_ShouldReturnJourneyDto()
        {
            // Arrange
            var origin = "A";
            var destination = "B";

            var flights = new List<NewShoreResponseDto>
            {
                new NewShoreResponseDto { DepartureStation = "A", ArrivalStation = "B", FlightCarrier = "XYZ Airlines", FlightNumber = "XYZ123", Price = 100.50m },
                new NewShoreResponseDto { DepartureStation = "B", ArrivalStation = "C", FlightCarrier = "ABC Airlines", FlightNumber = "ABC789", Price = 200.75m }
            };

            _flightDataServiceMock.Setup(mock => mock.GetAllFlightsAsync())
                .ReturnsAsync(flights);

            _flightRouteService.MaxFlightCount = 2;

            // Act
            var result = await _flightRouteService.CalculateRoute(origin, destination);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(origin, result.Origin);
            Assert.Equal(destination, result.Destination);
            Assert.NotEmpty(result.Flights);
        }

        [Fact]
        public async Task CalculateRoute_InvalidOriginOrDestination_ShouldThrowInvalidOperationException()
        {
            // Arrange
            var origin = "A";
            var destination = "C";

            var flights = new List<NewShoreResponseDto>
            {
                new NewShoreResponseDto { DepartureStation = "A", ArrivalStation = "B", FlightCarrier = "XYZ Airlines", FlightNumber = "XYZ123", Price = 100.50m },
                new NewShoreResponseDto { DepartureStation = "B", ArrivalStation = "C", FlightCarrier = "ABC Airlines", FlightNumber = "ABC789", Price = 200.75m }
            };

            _flightDataServiceMock.Setup(mock => mock.GetAllFlightsAsync())
                .ReturnsAsync(flights);

            // Act & Assert
            await Assert.ThrowsAsync<InvalidOperationException>(() => _flightRouteService.CalculateRoute(origin, destination));
        }

        [Fact]
        public async Task CalculateRoute_ExceedMaxFlightCount_ShouldThrowInvalidOperationException()
        {
            // Arrange
            var origin = "A";
            var destination = "C";

            var flights = new List<NewShoreResponseDto>
            {
                new NewShoreResponseDto { DepartureStation = "A", ArrivalStation = "B", FlightCarrier = "XYZ Airlines", FlightNumber = "XYZ123", Price = 100.50m },
                new NewShoreResponseDto { DepartureStation = "B", ArrivalStation = "C", FlightCarrier = "ABC Airlines", FlightNumber = "ABC789", Price = 200.75m },
                new NewShoreResponseDto { DepartureStation = "C", ArrivalStation = "D", FlightCarrier = "DEF Airlines", FlightNumber = "DEF456", Price = 150.25m }
            };

            _flightDataServiceMock.Setup(mock => mock.GetAllFlightsAsync())
                .ReturnsAsync(flights);

           
            _flightRouteService.MaxFlightCount = 1;

            // Act & Assert
            await Assert.ThrowsAsync<InvalidOperationException>(() => _flightRouteService.CalculateRoute(origin, destination));
        }
    }
}
