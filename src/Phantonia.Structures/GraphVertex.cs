using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Phantonia.Structures;

[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
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

    public ReadOnlyCollection<GraphEdge<T>> Edges { get; }

    public Graph<T>? Graph { get; internal set; }

    public bool Marked { get; set; }

    internal List<GraphEdge<T>> MutableEdges { get; }

    internal List<GraphVertex<T>> MutableNeighbors { get; }

    public ReadOnlyCollection<GraphVertex<T>> Neighbors { get; }

    public T Value { get; }

    private string GetDebuggerDisplay() => $"Graph vertex with {Neighbors.Count} neighbors";
}
