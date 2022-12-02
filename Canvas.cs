using static System.Console;

public class Canvas //class that holds the shapes
{
    private Stack<Shape> canvas = new Stack<Shape>();

    public void Add(Shape shape) //adds shape
    {
        canvas.Push(shape);
        ForegroundColor = ConsoleColor.Green; WriteLine("\nAdded Shape:\n" + shape + "\n"); ResetColor();
    }
    public Shape Remove() //removes shape
    {
        Shape shape = canvas.Pop();
        ForegroundColor = ConsoleColor.Green; WriteLine("\nRemoved Shape:\n" + shape + "\n"); ResetColor();
        return shape;
    }

    public Canvas() //message for creating the canvas
    {
        ForegroundColor = ConsoleColor.Green; WriteLine("\nCanvas Created - use commands to add shapes to the canvas!\n"); ResetColor();
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