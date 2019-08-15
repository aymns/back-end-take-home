using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GuestLogix.Core.DataAccess;
using GuestLogix.Core.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GuestLogix.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RouteController : ControllerBase
    {
        private readonly IDbContext dbContext;

        public RouteController(IDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public string[] Get(string source, string destination)
        {
            var request = new GetShortestPath.Request(source, destination);

            var shortestPath = new GetShortestPath(dbContext).Handle(request);
            return shortestPath;
        }
    }
}