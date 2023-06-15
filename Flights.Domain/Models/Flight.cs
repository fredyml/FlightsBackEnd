namespace Flights.Domain.Models
{
    public partial class Flight
    {
        public Flight()
        {
            Journeys = new HashSet<Journey>();
        }

        public int FlightId { get; set; }
        public int TransportId { get; set; }
        public string Origin { get; set; } = null!;
        public string Destination { get; set; } = null!;
        public decimal Price { get; set; }

        public virtual Transport Transport { get; set; } = null!;
        public virtual ICollection<Journey> Journeys { get; set; }
    }
}
