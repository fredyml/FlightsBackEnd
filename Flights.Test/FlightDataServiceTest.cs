using Flights.Application.Contracts;
using Flights.Application.Dtos;
using Moq;

namespace Flights.Application.Services.Tests
{
    public class FlightDataServiceTests
    {
        private Mock<IHttpClientService<List<NewShoreResponseDto>>> _httpClientServiceMock;
        private FlightDataService _flightDataService;

        public FlightDataServiceTests()
        {
            _httpClientServiceMock = new Mock<IHttpClientService<List<NewShoreResponseDto>>>();
            _flightDataService = new FlightDataService(_httpClientServiceMock.Object);
        }

        [Fact]
        public async Task GetAllFlightsAsync_ShouldReturnFlights()
        {
            // Arrange
            var expectedFlights = new List<NewShoreResponseDto>
            {
                new NewShoreResponseDto { DepartureStation = "MED", ArrivalStation = "BEF", FlightCarrier = "Avianca", FlightNumber = "XYZ123", Price = 500 },
                new NewShoreResponseDto { DepartureStation = "BCN", ArrivalStation = "CLA", FlightCarrier = "Latam", FlightNumber = "ABC789", Price = 200 }
            };

            _httpClientServiceMock.Setup(mock => mock.GetAsync(It.IsAny<string>()))
                .ReturnsAsync(expectedFlights);

            // Act
            var result = await _flightDataService.GetAllFlightsAsync();

            // Assert
            Assert.Equal(expectedFlights, result);
        }
    }
}
