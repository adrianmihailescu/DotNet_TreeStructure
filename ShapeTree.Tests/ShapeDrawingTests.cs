using ShapeTree.Application;
using ShapeTree.Domain;
using Xunit;

using ShapeTree.Application;

public class ShapeDrawingTests
{
    [Fact]
    public void Draw_ReturnsCorrectShapeDescription()
    {
        var shape = new Circle(Color.Blue);

        var result = shape.Draw();

        Assert.Equal("Blue Circle", result);
    }

    [Fact]
    public void ShapeTree_SupportsMultipleLevels()
    {
        var root = new Square(Color.Red);
        var level1 = new Circle(Color.Blue);
        var level2 = new Triangle(Color.Green);
        var level3 = new Square(Color.Yellow);

        level2.AddChild(level3);
        level1.AddChild(level2);
        root.AddChild(level1);

        Assert.Single(root.Children);
        Assert.Single(level1.Children);
        Assert.Single(level2.Children);
        Assert.Empty(level3.Children);
    }

    [Theory]
    [InlineData(Color.Red, "Red Circle")]
    [InlineData(Color.Blue, "Blue Square")]
    [InlineData(Color.Green, "Green Triangle")]
    public void Draw_Returns_Color_And_Shape_Name(Color color, string expected)
    {
        Shape shape = expected.Contains("Circle")
            ? new Circle(color)
            : expected.Contains("Square")
                ? new Square(color)
                : new Triangle(color);

        var result = shape.Draw();

        Assert.Equal(expected, result);
    }
}
