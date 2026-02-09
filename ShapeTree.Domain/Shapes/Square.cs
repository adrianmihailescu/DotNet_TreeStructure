namespace ShapeTree.Domain;

public sealed class Square : Shape
{
    public Square(Color color) : base(color) { }
    public override string Name => "Square";
}