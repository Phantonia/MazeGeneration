using Phantonia.Structures;
using System.Collections.Immutable;
using System.Diagnostics;

namespace Phantonia.MazeGeneration;

public sealed class MazeGenerator
{
    private static readonly Random StaticRng = new();

    public MazeGenerator(int width, int height)
    {
        Width = width;
        Height = height;
        rng = StaticRng;
    }

    public MazeGenerator(int width, int height, int seed)
    {
        Width = width;
        Height = height;
        rng = new Random(seed);
    }

    private readonly Random rng;

    public int Height { get; }

    public int Width { get; }

    public Graph<int> GenerateMazeAsGraph()
    {
        RectangularGraphProvider provider = new(Width, Height);
        Graph<int> graph = provider.GenerateGraph();

        Debug.Assert(graph.Vertices[0].Edges.Count == 2); // this is actually a corner

        Progress(graph.Vertices[0]);

        return graph;
    }

    public ImmutableArray<Wall> GenerateMazeAsWalls()
    {
        Graph<int> graph = GenerateMazeAsGraph();

        Debug.WriteLine("Edges:");
        foreach (GraphEdge<int> edge in graph.Edges)
        {
            Debug.WriteLine($"{edge.VertexA.Value} to {edge.VertexB.Value}");
        }
        Debug.WriteLine("");

        ImmutableArray<Wall> walls =  graph.Edges
                                           .Select(e => new Wall(Math.Min(e.VertexA.Value, e.VertexB.Value), Math.Max(e.VertexA.Value, e.VertexB.Value)))
                                           .ToImmutableArray();

        Debug.WriteLine("Walls:");
        foreach (Wall wall in walls)
        {
            Debug.WriteLine($"{wall.LowerCellIndex} to {wall.HigherCellIndex}");
        }
        Debug.WriteLine("");

        return walls;
    }

    private void Progress(GraphVertex<int> vertex)
    {
        Debug.Assert(vertex.Graph is not null);

        vertex.Marked = true;

        while (true)
        {
            List<GraphVertex<int>> suitableNeighbors = vertex.Neighbors.Where(n => !n.Marked).ToList();

            if (suitableNeighbors.Count == 0)
            {
                return;
            }

            GraphVertex<int> randomNeighbor = suitableNeighbors[rng.Next(suitableNeighbors.Count)];

            Progress(randomNeighbor);

            GraphEdge<int>? edgeToRemove = null;

            foreach (GraphEdge<int> edge in vertex.Edges)
            {
                if (edge.VertexA == randomNeighbor || edge.VertexB == randomNeighbor)
                {
                    edgeToRemove = edge;
                    break;
                }
            }

            Debug.Assert(edgeToRemove is not null);

            vertex.Graph.RemoveEdge(edgeToRemove);
        }
    }
}
