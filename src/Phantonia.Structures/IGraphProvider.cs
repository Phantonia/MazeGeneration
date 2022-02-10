namespace Phantonia.Structures;

public interface IGraphProvider
{
    public abstract GraphVertex<T> GenerateGraph<T>(T? defaultValue = default);
}
