using ShapeTree.Application;
using ShapeTree.Domain;
using Xunit;

public class ShapeDrawingTests
{
    [Fact]
    public void Draw_ReturnsCorrectShapeDescription()
    {
        var shape = new Circle(Color.Blue);

        var result = shape.Draw();

        Assert.Equal("Blue Circle", result);
    }
}
