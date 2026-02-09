namespace ShapeTree.Application;

public sealed class ConsoleDrawOutput : IDrawOutput
{
    public void Write(string value)
    {
        Console.WriteLine(value);
    }
}
