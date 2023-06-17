namespace Flights.Application.Dtos
{
    public class FlightDto
    {
        public string Origin { get; set; } = string.Empty;
        public string Destination { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public TransportDto Transport { get; set; }
    }
}
