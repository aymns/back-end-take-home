namespace GuestLogix.Core.Models
{
    public class Route
    {
        public Route(string airlineId, string origin, string destination)
        {
            AirlineId = airlineId;
            Origin = origin;
            Destination = destination;
        }

        private Route()
        {
        }

        public string AirlineId { get; }
        public string Origin { get; }
        public string Destination { get; }
    }
}