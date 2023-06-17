namespace Flights.Application.Dtos
{
    public class JourneyDto
    {
        public string Origin { get; set; } = string.Empty;
        public string Destination { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public List<FlightDto> Flights { get; set; }
    }
}
