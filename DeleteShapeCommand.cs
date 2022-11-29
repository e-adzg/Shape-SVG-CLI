public class DeleteShapeCommand : Command //inherits from command class
{
    Shape shape;
    Canvas canvas;

    public DeleteShapeCommand(Canvas c) //method to get the canvas in which to delete the shape
    {
        canvas = c;
    }
    public override void Do() //overrides the do method to remove shape
    {
        shape = canvas.Remove();
    }
    public override void Undo() //overrides the undo method to undo
    {
        canvas.Add(shape);
    }
}