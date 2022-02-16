using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Phantonia.Structures;

[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
public sealed class GraphVertex<T>
{
    public GraphVertex() { }

    public Collection<GraphVertex<T>> Neighbors { get; } = new();

    public T? Value { get; set; }

    private string GetDebuggerDisplay() => $"Vertex: Value = {Value}; {Neighbors.Count} neighbors";
}
