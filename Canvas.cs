public class Canvas //class that holds the shapes
{
    private Stack<Shape> canvas = new Stack<Shape>();

    public void Add(Shape shape) //adds shape
    {
        canvas.Push(shape);
        Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("\nAdded Shape:\n" + shape + "\n"); Console.ResetColor();
    }
    public Shape Remove() //removes shape
    {
        Shape shape = canvas.Pop();
        Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("\nRemoved Shape:\n" + shape + "\n"); Console.ResetColor();
        return shape;
    }

    public Canvas() //message for creating the canvas
    {
        Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("\nCanvas Created - use commands to add shapes to the canvas!\n"); Console.ResetColor();
    }

    public override string ToString() //override ToString so I can print all shapes in canvas stack
    {
        String allShapes = "";
        foreach (Shape shape in canvas)
        {
            allShapes += shape + Environment.NewLine;
        }
        return allShapes;
    }
}