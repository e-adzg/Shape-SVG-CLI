public class Canvas
{
    private Stack<Shape> canvas = new Stack<Shape>();

    public void Add(Shape s)
    {
        canvas.Push(s);
        Console.WriteLine("\nAdded Shape: " + s + "\n");
    }
    public Shape Remove()
    {
        Shape s = canvas.Pop();
        Console.WriteLine("Removed Shape from canvas: {0}" + Environment.NewLine, s);
        return s;
    }

    public Canvas()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\nCanvas Created - use commands to add shapes to the canvas!\n");
        Console.ResetColor();
    }

    public override string ToString()
    {
        String str = "";
        foreach (Shape s in canvas)
        {
            // str += " " + s + Environment.NewLine;
            str += s + Environment.NewLine;
        }
        return str;
    }
}