namespace Flights.Application.Dtos
{
    public class FlightDto
    {
        public string Origin { get; set; }
        public string Destination { get; set; }
        public decimal Price { get; set; }
        public TransportDto Transport { get; set; }
    }
}
