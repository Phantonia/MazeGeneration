using System.Collections.Immutable;

namespace Phantonia.Structures;

public sealed record TreeNode<T>
{
    public TreeNode(ImmutableArray<TreeNode<T>> children)
    {
        Children = children;
    }

    public ImmutableArray<TreeNode<T>> Children { get; init; }
}
