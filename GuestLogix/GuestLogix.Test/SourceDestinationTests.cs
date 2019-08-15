using System;
using System.IO;
using GuestLogix.Core.DataAccess;
using GuestLogix.Core.Exceptions;
using GuestLogix.Core.Queries;
using Xunit;

namespace GuestLogix.Test
{
    public class SourceDestinationTests
    {
        private readonly IDbContext dbContext;
        public SourceDestinationTests()
        {
            var dataPath = new DirectoryInfo(Environment.CurrentDirectory).Parent?.Parent?.Parent?.Parent.FullName + "\\data\\test\\";
            dbContext = new CsvDbContext(dataPath);
        }


        [Fact]
        public void FromNowhereToOHareAirport_ShouldThrowExceptionInvalidOrigin()
        {

            Assert.Throws<BusinessException>(() =>
                {
                    try
                    {
                        new GetShortestPath(dbContext).Handle(new GetShortestPath.Request("xxx", "ORD"));
                    }
                    catch(Exception exception)
                    {
                        Assert.True(exception is BusinessException && exception.Equals(BusinessException.INVALID_ORIGIN));
                        throw;
                    }
                });
        }


        [Fact]
        public void FromOHareAirportToNowhere_ShouldThrowExceptionInvalidDestination()
        {
            Assert.Throws<BusinessException>(() =>
            {
                try
                {
                    new GetShortestPath(dbContext).Handle(new GetShortestPath.Request("ORD", "xxx"));
                }
                catch (Exception exception)
                {
                    Assert.True(exception is BusinessException && exception.Equals(BusinessException.INVALID_DESTINATION));
                    throw;
                }
            });
        }

        [Fact]
        public void FromTorontoPearsonAirportToJohnKennedyAirport()
        {
            var result = new GetShortestPath(dbContext).Handle(new GetShortestPath.Request("YYZ", "JFK"));
            Assert.Equal("YYZ -> JFK",string.Join(" -> ", result));
        }


        [Fact]
        public void FromTorontoPearsonAirportToOHareAirport_ShouldThrowExceptionNoRoute()
        {

            Assert.Throws<BusinessException>(() =>
            {
                try
                {
                    var result = new GetShortestPath(dbContext).Handle(new GetShortestPath.Request("YYZ", "ORD"));
                }
                catch (Exception exception)
                {
                    Assert.True(exception is BusinessException && exception.Equals(BusinessException.NO_ROUTE));
                    throw;
                }
            });
        }


        [Fact]
        public void FromTorontoPearsonAirportToVancouverAirportTo()
        {
            var result = new GetShortestPath(dbContext).Handle(new GetShortestPath.Request("YYZ", "YVR"));

            Assert.Equal("YYZ -> JFK -> LAX -> YVR", string.Join(" -> ", result));
        }
    }
}