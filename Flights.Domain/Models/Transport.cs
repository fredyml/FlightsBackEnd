namespace Flights.Domain.Models
{
    public partial class Transport
    {
        public Transport()
        {
            Flights = new HashSet<Flight>();
        }

        public int TransportId { get; set; }
        public string FlightCarrier { get; set; } = null!;
        public string FlightNumber { get; set; } = null!;

        public virtual ICollection<Flight> Flights { get; set; }
    }
}
