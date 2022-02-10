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

    public GraphVertex<T> GenerateGraph<T>(T? defaultValue = default)
    {
        // algorithm: see https://phantonia.notion.site/phantonia/Maze-generation-7e941990f6164380b68c98166ca658eb

        List<GraphVertex<T>> vertices = new(capacity: Width * Height);

        for (int i = 0; i < Width * Height; i++)
        {
            vertices.Add(new GraphVertex<T> { Value = defaultValue });
        }

        for (int i = 0; i < Width * Height; i++)
        {
            if (i % Width != 0)
            {
                vertices[i].Neighbors.Add(vertices[i - 1]);
            }

            if (i % Width != Width - 1)
            {
                vertices[i].Neighbors.Add(vertices[i + 1]);
            }

            if (i >= Width)
            {
                vertices[i].Neighbors.Add(vertices[i - Width]);
            }

            if (i < (Height - 1) * Width)
            {
                vertices[i].Neighbors.Add(vertices[i + Width]);
            }
        }

        return vertices[0];
    }
}
