namespace ShapeTree.Domain;

public abstract class Shape : IShape
{
    private readonly List<IShape> _children = new();

    protected Shape(Color color)
    {
        Color = color;
    }

    public Color Color { get; }
    public abstract string Name { get; }
    public IReadOnlyCollection<IShape> Children => _children;

    public void AddChild(IShape shape)
    {
        if (shape is null)
        {
            throw new ArgumentNullException(nameof(shape));
        }

        _children.Add(shape);
    }

    public string Draw()
    {
        return $"{Color} {Name}";
    }
}
