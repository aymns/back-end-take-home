namespace GuestLogix.Core.Models
{
    public class Airline
    {
        public Airline(string name, string twoDigitCode, string threeDigitCode, string country)
        {
            Name = name;
            TwoDigitCode = twoDigitCode;
            ThreeDigitCode = threeDigitCode;
            Country = country;
        }

        private Airline()
        {
        }


        public string Name { get; }
        public string TwoDigitCode { get; }
        public string ThreeDigitCode { get; }
        public string Country { get; }
    }
}