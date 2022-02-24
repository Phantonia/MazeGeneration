namespace Phantonia.Structures;

public sealed class RectangularGraphProvider : IGraphProvider
{
    public RectangularGraphProvider(int width, int height)
    {
        if (width <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(width));
        }

        if (height <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(height));
        }

        Width = width;
        Height = height;
    }

    public int Height { get; }

    public int Width { get; }

    public Graph<int> GenerateGraph()
    {
        // algorithm: see https://phantonia.notion.site/phantonia/Maze-generation-7e941990f6164380b68c98166ca658eb

        Graph<int> graph = new();
        List<GraphVertex<int>> vertices = new(capacity: Width * Height);

        for (int i = 0; i < Width * Height; i++)
        {
            GraphVertex<int> vertex = graph.AddVertex(value: i);
            vertices.Add(vertex);
        }

        for (int i = 0; i < Width * Height; i++)
        {
            if (i % Width != 0)
            {
                _ = graph.AddEdge(vertices[i], vertices[i - 1]);
            }

            if (i % Width != Width - 1)
            {
                _ = graph.AddEdge(vertices[i], vertices[i + 1]);
            }

            if (i >= Width)
            {
                _ = graph.AddEdge(vertices[i], vertices[i - Width]);
            }

            if (i < (Height - 1) * Width)
            {
                _ = graph.AddEdge(vertices[i], vertices[i + Width]);
            }
        }

        return graph;
    }
}
