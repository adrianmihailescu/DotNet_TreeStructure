namespace ShapeTree.Application;

using ShapeTree.Domain;

public sealed class ShapeTreeDrawer
{
    private readonly IDrawOutput _output;

    public ShapeTreeDrawer(IDrawOutput output)
    {
        _output = output;
    }

    public void Draw(IShape root)
    {
        DrawRecursive(root, "", isRoot: true, isLast: true);
    }

    private void DrawRecursive(
        IShape shape,
        string indent,
        bool isRoot,
        bool isLast)
    {
        if (isRoot)
        {
            _output.Write(shape.Draw());
        }
        else
        {
            var prefix = indent + (isLast ? "└── " : "├── ");
            _output.Write(prefix + shape.Draw());
        }

        var children = shape.Children.ToList();
        var newIndent = isRoot
            ? ""
            : indent + (isLast ? "    " : "│   ");

        for (int i = 0; i < children.Count; i++)
        {
            DrawRecursive(
                children[i],
                newIndent,
                isRoot: false,
                isLast: i == children.Count - 1
            );
        }
    }
}

