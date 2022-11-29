public class Canvas
{
    private Stack<Shape> canvas = new Stack<Shape>();

    public void Add(Shape shape)
    {
        canvas.Push(shape);
        Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("\nAdded Shape:\n" + shape + "\n"); Console.ResetColor();
    }
    public Shape Remove()
    {
        Shape shape = canvas.Pop();
        Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("\nRemoved Shape:\n" + shape + "\n"); Console.ResetColor();
        return shape;
    }

    public Canvas()
    {
        Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("\nCanvas Created - use commands to add shapes to the canvas!\n"); Console.ResetColor();
    }

    public override string ToString()
    {
        String allShapes = "";
        foreach (Shape shape in canvas)
        {
            allShapes += shape + Environment.NewLine;
        }
        return allShapes;
    }
}