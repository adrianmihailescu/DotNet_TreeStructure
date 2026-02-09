using Microsoft.Extensions.DependencyInjection;
using ShapeTree.Application;
using ShapeTree.Domain;

var services = new ServiceCollection();

// Output strategy switch
// dotnet run        -> console
// dotnet run -- file -> file

var userWantsFileOutput = args.Length > 0 &&
                    args[0].Equals("file", StringComparison.OrdinalIgnoreCase);

if (userWantsFileOutput)
{
    services.AddSingleton<IDrawOutput>(_ =>
        new FileDrawOutput("shapes.txt"));

    Console.WriteLine("The results have been written to the file shapes.txt");
}
else
{
    services.AddSingleton<IDrawOutput, ConsoleDrawOutput>();
    Console.WriteLine("The results have been written here");
}

services.AddSingleton<ShapeTreeDrawer>();

using var provider = services.BuildServiceProvider();


// ==========================
// tree structure
// ==========================

// Root
var redSquare = new Square(Color.Red);

// Level 1
var blueCircle = new Circle(Color.Blue);
var yellowTriangle = new Triangle(Color.Yellow);

// Level 2
var greenCircle = new Circle(Color.Green);
var redTriangle = new Triangle(Color.Red);

var blueSquare = new Square(Color.Blue);
var greenTriangle = new Triangle(Color.Green);

// Wire tree
blueCircle.AddChild(greenCircle);
blueCircle.AddChild(redTriangle);

yellowTriangle.AddChild(blueSquare);
yellowTriangle.AddChild(greenTriangle);

redSquare.AddChild(blueCircle);
redSquare.AddChild(yellowTriangle);


// ==========================
// Draw
// ==========================
var drawer = provider.GetRequiredService<ShapeTreeDrawer>();
drawer.Draw(redSquare);
