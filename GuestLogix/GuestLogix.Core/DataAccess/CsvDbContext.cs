using System;
using System.IO;
using System.Linq;
using GuestLogix.Core.Helpers;
using GuestLogix.Core.Models;

namespace GuestLogix.Core.DataAccess
{
    public class CsvDbContext : IDbContext
    {
        public CsvDbContext()
        {
            LoadData();
        }

        public IQueryable<Route> Routes { get; set; }
        public IQueryable<Airline> Airlines { get; set; }
        public IQueryable<Airport> Airports { get; set; }

        private void LoadData()
        {
            LoadAirports();
            LoadAirlines();
            LoadRoutes();
        }

        private void LoadRoutes()
        {
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"data/routes.csv");

            Routes = (from line in File.ReadAllLines(path).Skip(1)
                let columns = line.Split(',')
                select new Route(columns[0], columns[1], columns[2])).AsQueryable();
        }

        private void LoadAirlines()
        {
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"data/airlines.csv");

            Airlines = (from line in File.ReadAllLines(path).Skip(1)
                let columns = line.Split(',')
                select new Airline(columns[0], columns[1], columns[2], columns[3])).AsQueryable();
        }

        private void LoadAirports()
        {
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"data/airports.csv");

            Airports = (from line in File.ReadAllLines(path).Skip(1)
                let columns = line.Split(',')
                select new Airport(columns[0], columns[1], columns[2], columns[3],
                    new Coordination(columns[4].SafeParseToDouble(), columns[5].SafeParseToDouble()))).AsQueryable();
        }

        public void Dispose()
        {
        }
    }
}