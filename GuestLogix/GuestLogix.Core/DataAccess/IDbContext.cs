using System;
using System.Linq;
using GuestLogix.Core.Models;

namespace GuestLogix.Core.DataAccess
{
    public interface IDbContext: IDisposable
    {
        IQueryable<Route> Routes { get; set; }
        IQueryable<Airline> Airlines { get; set; }
        IQueryable<Airport> Airports { get; set; }

        Graph RoutesGraph { get;}
    }
}