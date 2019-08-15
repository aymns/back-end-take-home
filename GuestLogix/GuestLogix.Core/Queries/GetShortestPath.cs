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
            return null;
        }
       
        public class Request
        {
            public string Source { get; set; }
            public string Destination { get; set; }
        }
    }
}