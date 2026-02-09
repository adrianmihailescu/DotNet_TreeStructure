namespace ShapeTree.Domain;

public sealed class Triangle : Shape
{
    public Triangle(Color color) : base(color) { }
    public override string Name => "Triangle";
}