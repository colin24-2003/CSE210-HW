using System;

class Program
{
    public static List<Shape> shapes = new List<Shape>();  // Field of the class

    static void Main(string[] args)
    {
        Square square = new Square("White", 5.3);
        Rectangle rectangle = new Rectangle("Black", 10.5, 20.5);
        Circle circle = new Circle("Blue", 2.5);

        shapes.Add(square);
        shapes.Add(rectangle);
        shapes.Add(circle);

        foreach (Shape shape in shapes)
        {
            Console.WriteLine($"{shape.Color}, {shape.GetArea()}");
        }
    }
}