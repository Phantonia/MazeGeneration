using System.Collections.ObjectModel;

namespace Phantonia.Structures;

public sealed class GraphVertex<T>
{
    public GraphVertex() { }

    public Collection<GraphVertex<T>> Neighbors { get; } = new();

    public T? Value { get; set; }
}
