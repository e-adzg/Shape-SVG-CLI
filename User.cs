public class User //user class
{
    private Stack<Command> undo; //creates undo stack
    private Stack<Command> redo; //creates redo stack

    public int UndoCount { get => undo.Count; } //gets the length of undo stack
    public int RedoCount { get => redo.Count; } //gets the length of redo stack
    public User()
    {
        Reset(); //resets all stacks to brand new
    }
    public void Reset()
    {
        undo = new Stack<Command>();
        redo = new Stack<Command>();
    }
    public void Action(Command command)
    {
        undo.Push(command); //save the command to undo stack
        redo.Clear(); //clears redo stack when new command is added

        Type t = command.GetType(); //figure out what type of command we are dealing with
        if (t.Equals(typeof(AddShapeCommand)))
        {
            command.Do();
        }
        if (t.Equals(typeof(DeleteShapeCommand)))
        {
            command.Do();
        }
    }
    public void Undo() //undo method
    {
        if (undo.Count > 0) //if there is more than 0
        {
            Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("\nUndo Complete!"); Console.ResetColor();
            Command c = undo.Pop(); //get latest command and pop it
            c.Undo(); //undo the command
            redo.Push(c); //push the command to redo stack
        }
        else //or else it is empty and error
        {
            Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("\nERROR: Cannot Undo!\n"); Console.ResetColor();
        }
    }

    public void Redo()
    {
        if (redo.Count > 0) //if there is more than 0
        {
            Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("\nRedo Complete!"); Console.ResetColor();
            Command c = redo.Pop(); //get latest command and pop it
            c.Do(); //do the command from redo stack
            undo.Push(c); //push the command to undo stack
        }
        else //or else the redo stack is empty and error
        {
            Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("\nERROR: Cannot Redo!\n"); Console.ResetColor();
        }
    }

}