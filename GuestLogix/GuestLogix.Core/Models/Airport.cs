namespace GuestLogix.Core.Models
{
    public class Airport
    {
        private  Airport()
        {
        }

        public Airport(string name, string city, string country, string iata3, Coordination coordination)
        {
            Name = name;
            City = city;
            Country = country;
            IATA3 = iata3;
            Coordination = coordination;
        }

        public string Name { get; }
        public string City { get; }
        public string Country { get; }

        public string IATA3 { get; }

        public Coordination Coordination { get; }
    }
}