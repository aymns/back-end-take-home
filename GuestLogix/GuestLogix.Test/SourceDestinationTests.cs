using Xunit;

namespace GuestLogix.Test
{
    public class SourceDestinationTests
    {
        [Fact]
        public void FromNowhereToOHareAirport()
        {
            var result = "";
            Assert.Equal("Invalid Origin", result);
        }


        [Fact]
        public void FromOHareAirportToNowhere()
        {
            var result = "";
            Assert.Equal("Invalid Destination", result);
        }

        [Fact]
        public void FromTorontoPearsonAirportToJohnKennedyAirport()
        {
            var result = "";
            Assert.Equal("YYZ -> JFK", result);
        }


        [Fact]
        public void FromTorontoPearsonAirportToOHareAirport()
        {
            var result = "";
            Assert.Equal("No Route", result);
        }


        [Fact]
        public void FromTorontoPearsonAirportToVancouverAirportTo()
        {
            var result = "";
            Assert.Equal("YYZ -> JFK -> LAX -> YVR", result);
        }
    }
}