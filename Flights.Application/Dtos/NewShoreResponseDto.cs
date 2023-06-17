namespace Flights.Application.Dtos
{
    public class NewShoreResponseDto
    {
        public string DepartureStation { get; set; } = string.Empty;
        public string ArrivalStation { get; set; } = string.Empty;
        public string FlightCarrier { get; set; } = string.Empty;
        public string FlightNumber { get; set; } = string.Empty;
        public decimal Price { get; set; }
    }
}
