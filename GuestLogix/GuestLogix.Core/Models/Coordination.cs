namespace GuestLogix.Core.Models
{
    public class Coordination
    {
        public Coordination(double lon, double lat)
        {
            Longitude = lon;
            Latitude = lat;
        }

        private Coordination()
        {
        }

        public double Longitude { get; }
        public double Latitude { get; }
    }
}