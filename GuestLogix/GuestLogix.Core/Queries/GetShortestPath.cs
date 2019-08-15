using System.Linq;
using GuestLogix.Core.DataAccess;

namespace GuestLogix.Core.Queries
{
    public class GetShortestPath
    {
        private readonly IDbContext dbContext;

        public GetShortestPath(IDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public string[] Handle(Request request)
        {
            return dbContext.RoutesGraph.BFS(request.Source, request.Destination).ToArray();
        }
       
        public class Request
        {
            public Request(string source, string destination)
            {
                this.Source = source;
                this.Destination = destination;
            }
            public string Source { get; set; }
            public string Destination { get; set; }
        }
    }
}