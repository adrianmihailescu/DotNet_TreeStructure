namespace ShapeTree.Domain;

public sealed class Circle : Shape
{
    public Circle(Color color) : base(color) { }
    public override string Name => "Circle";
}
