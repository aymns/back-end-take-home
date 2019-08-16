using System.Collections.Generic;
using System.Linq;
using GuestLogix.Core.Exceptions;

namespace GuestLogix.Core.Models
{
    public class Graph
    {
        public Graph()
        {
            Data = new Dictionary<string, LinkedList<GraphNode>>();
        }

        private Dictionary<string, LinkedList<GraphNode>> Data { get; }

        public void AddVertex(string vertex)
        {
            if (!Data.ContainsKey(vertex))
            {
                Data.Add(vertex, new LinkedList<GraphNode>());
            }
        }

        public void AddEdge(string source, string destination)
        {
            if (Data.ContainsKey(source))
            {
                Data[source].AddFirst(new GraphNode(destination));
            }
            else
            {
                var routes = new LinkedList<GraphNode>();
                routes.AddFirst(new GraphNode(destination));
                Data.Add(source, routes);
            }
        }

        public IEnumerable<string> ShortestPath(string source, string destination)
        {
            if (source == null || destination == null)
                throw BusinessException.INVALID_REQUEST;

            if (!Data.ContainsKey(source))
                throw BusinessException.INVALID_ORIGIN;

            if (!Data.ContainsKey(destination))
                throw BusinessException.INVALID_DESTINATION;

            var queue = new Queue<string>();
            var visited = new Dictionary<string, bool>
            {
                { source, true }
            };

            var predecessor = new Dictionary<string, string>();

            queue.Enqueue(source);

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();

                foreach (var route in Data[current])
                    if (!visited.ContainsKey(route.Vertex))
                    {
                        visited.Add(route.Vertex, true);
                        queue.Enqueue(route.Vertex);
                        predecessor.Add(route.Vertex, current);
                        if (destination == route.Vertex)
                        {
                            var path = GetPath(source, destination, predecessor);
                            return path.Reverse();
                        }
                    }
            }

            throw BusinessException.NO_ROUTE;
        }
        private IEnumerable<string> GetPath(string source, string destination, Dictionary<string, string> predecessor)
        {
            var queue = new Queue<string>();
            queue.Enqueue(destination);
            var temp = destination;
            while (queue.Count > 0 && predecessor.ContainsKey(temp))
            {
                temp = queue.Dequeue();
                yield return temp;
                temp = predecessor[temp];
                queue.Enqueue(temp);
            }

            yield return source;
        }
    }

    public class GraphNode
    {
        public GraphNode(string vertex)
        {
            Vertex = vertex;
        }

        public string Vertex { get; set; }
    }
}