using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Phantonia.Structures;

public sealed class Graph<T>
{
    public Graph()
    {
        edges = new List<GraphEdge<T>>();
        Edges = new ReadOnlyCollection<GraphEdge<T>>(edges);

        vertices = new List<GraphVertex<T>>();
        Vertices = new ReadOnlyCollection<GraphVertex<T>>(vertices);
    }

    private readonly List<GraphEdge<T>> edges;
    private readonly List<GraphVertex<T>> vertices;

    public ReadOnlyCollection<GraphEdge<T>> Edges { get; }

    public ReadOnlyCollection<GraphVertex<T>> Vertices { get; }

    public GraphEdge<T> AddEdge(GraphVertex<T> vertexA, GraphVertex<T> vertexB)
    {
        if (vertexA.Graph != this)
        {
            throw new ArgumentException($"{nameof(vertexA)} is not a vertex of this graph.");
        }

        if (vertexB.Graph != this)
        {
            throw new ArgumentException($"{nameof(vertexB)} is not a vertex of this graph.");
        }

        foreach (GraphEdge<T> edge in edges)
        {
            if (edge.VertexA == vertexA && edge.VertexB == vertexB
             || edge.VertexB == vertexA && edge.VertexA == vertexB)
            {
                return edge;
            }
        }

        // we now know, that vertexA and vertexB are not connected by an edge already

        {
            GraphEdge<T> edge = new(this, vertexA, vertexB);

            vertexA.MutableEdges.Add(edge);
            vertexB.MutableEdges.Add(edge);

            vertexA.MutableNeighbors.Add(vertexB);
            vertexB.MutableNeighbors.Add(vertexA);

            return edge;
        }
    }

    public GraphVertex<T> AddVertex(T value)
    {
        GraphVertex<T> vertex = new(this, value);
        vertices.Add(vertex);
        return vertex;
    }

    public void RemoveEdge(GraphEdge<T> edge)
    {
        if (edge.Graph != this)
        {
            throw new ArgumentException($"{nameof(edge)} is not an edge of this graph.");
        }

        Debug.Assert(edges.Contains(edge));
        Debug.Assert(edge.VertexA.Edges.Contains(edge));
        Debug.Assert(edge.VertexB.Edges.Contains(edge));
        Debug.Assert(edge.VertexA.Neighbors.Contains(edge.VertexB));
        Debug.Assert(edge.VertexB.Neighbors.Contains(edge.VertexA));

        edge.Graph = null;
        edges.Remove(edge);
    }

    public void RemoveVertex(GraphVertex<T> vertex)
    {
        if (vertex.Graph != this)
        {
            throw new ArgumentException($"{nameof(vertex)} is not a vertex of this graph.");
        }

        Debug.Assert(vertices.Contains(vertex));

        foreach (GraphVertex<T> neighbor in vertex.Neighbors)
        {
            Debug.Assert(neighbor.Neighbors.Contains(vertex));
            neighbor.MutableNeighbors.Remove(vertex);

            neighbor.MutableEdges.RemoveAll(e => e.VertexA == vertex || e.VertexB == vertex);
        }

        for (int i = 0; i < edges.Count; i++)
        {
            if (edges[i].VertexA == vertex || edges[i].VertexB == vertex)
            {
                edges.RemoveAt(i);
            }
        }

        vertex.Graph = null;
        vertices.Remove(vertex);
    }
}

public sealed class GraphVertex<T>
{
    internal GraphVertex(Graph<T> graph, T value)
    {
        Graph = graph;
        Value = value;
        MutableNeighbors = new List<GraphVertex<T>>();
        Neighbors = new ReadOnlyCollection<GraphVertex<T>>(MutableNeighbors);
        MutableEdges = new List<GraphEdge<T>>();
        Edges = new ReadOnlyCollection<GraphEdge<T>>(MutableEdges);
    }

    public T Value { get; }

    public Graph<T>? Graph { get; internal set; }

    internal List<GraphVertex<T>> MutableNeighbors { get; }

    public ReadOnlyCollection<GraphVertex<T>> Neighbors { get; }

    internal List<GraphEdge<T>> MutableEdges { get; }

    public ReadOnlyCollection<GraphEdge<T>> Edges { get; }
}

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
