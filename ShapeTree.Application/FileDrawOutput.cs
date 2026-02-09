namespace ShapeTree.Application;

public sealed class FileDrawOutput : IDrawOutput
{
    private readonly string _filePath;

    public FileDrawOutput(string filePath)
    {
        _filePath = filePath;
    }

    public void Write(string value)
    {
        File.AppendAllText(_filePath, value + Environment.NewLine);
    }
}
