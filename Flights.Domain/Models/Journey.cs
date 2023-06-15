namespace Flights.Domain.Models
{
    public partial class Journey
    {
        public int JourneyId { get; set; }
        public int FlightId { get; set; }
        public string Origin { get; set; } = null!;
        public string Destination { get; set; } = null!;
        public decimal Price { get; set; }

        public virtual Flight Flight { get; set; } = null!;
    }
}
