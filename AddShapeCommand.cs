public class AddShapeCommand : Command //interface from command class
{
    Shape shape;
    Canvas canvas;

    public AddShapeCommand(Shape s, Canvas c) //method to get the shape and which canvas to store or undo
    {
        shape = s;
        canvas = c;
    }
    public override void Do() //overrides the do method to add shape
    {
        canvas.Add(shape);
    }
    public override void Undo() //overrides the undo method to undo
    {
        shape = canvas.Remove();
    }

}