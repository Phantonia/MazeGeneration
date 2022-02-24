using System.Collections.ObjectModel;

namespace Phantonia.Structures;

public sealed class Graph<T>
{
    public Graph(GraphVertex<T> startVertex)
    {
        HashSet<GraphVertex<T>> allVertices = new() { startVertex };
        List<GraphVertex<T>> relevantVertices = new() { startVertex };

        while (relevantVertices.Count > 0)
        {
            GraphVertex<T> currentVertex = relevantVertices[0];

            foreach (GraphVertex<T> vertex in currentVertex.Neighbors)
            {
                bool isNew = allVertices.Add(vertex);

                if (isNew)
                {
                    relevantVertices.Add(vertex);
                }
            }

            relevantVertices.RemoveAt(0);
        }

        Vertices = allVertices.ToList().AsReadOnly();
    }

    internal Graph(IList<GraphVertex<T>> vertices)
    {
        Vertices = new ReadOnlyCollection<GraphVertex<T>>(vertices);
    }

    public ReadOnlyCollection<GraphVertex<T>> Vertices { get; }
}
