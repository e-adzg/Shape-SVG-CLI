public class DeleteShapeCommand : Command
{

    Shape shape;
    Canvas canvas;

    public DeleteShapeCommand(Canvas c)
    {
        canvas = c;
    }

    // Removes a shape from the canvas as "Do" action
    public override void Do()
    {
        shape = canvas.Remove();
    }

    // Restores a shape to the canvas as an "Undo" action
    public override void Undo()
    {
        canvas.Add(shape);
    }
}