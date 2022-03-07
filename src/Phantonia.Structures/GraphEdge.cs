namespace Phantonia.Structures;

public sealed class GraphEdge<T>
{
    internal GraphEdge(Graph<T> graph, GraphVertex<T> vertexA, GraphVertex<T> vertexB)
    {
        Graph = graph;
        VertexA = vertexA;
        VertexB = vertexB;
    }

    public Graph<T>? Graph { get; internal set; }

    public GraphVertex<T> VertexA { get; }

    public GraphVertex<T> VertexB { get; }
}
