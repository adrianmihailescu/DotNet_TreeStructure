namespace ShapeTree.Domain;

public interface IShape
{
    Color Color { get; }
    string Name { get; }
    IReadOnlyCollection<IShape> Children { get; }

    void AddChild(IShape shape);
    string Draw();
}
