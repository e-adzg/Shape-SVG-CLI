public class User
{
    private Stack<Command> undo;
    private Stack<Command> redo;

    public int UndoCount { get => undo.Count; }
    public int RedoCount { get => redo.Count; }
    public User()
    {
        Reset();
    }
    public void Reset()
    {
        undo = new Stack<Command>();
        redo = new Stack<Command>();
    }

    public void Action(Command command)
    {
        undo.Push(command);  // save the command to the undo command
        redo.Clear();        // once a new command is issued, the redo stack clears

        // next determine  action from the Command object type
        // this is going to be AddShapeCommand or DeleteShapeCommand
        Type t = command.GetType();
        if (t.Equals(typeof(AddShapeCommand)))
        {
            command.Do();
        }
        if (t.Equals(typeof(DeleteShapeCommand)))
        {
            command.Do();
        }
    }

    public void Undo()
    {
        if (undo.Count > 0)
        {
            Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("\nUndo Complete!"); Console.ResetColor();
            Command c = undo.Pop();
            c.Undo();
            redo.Push(c);
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("\nERROR: Cannot Undo!\n"); Console.ResetColor();
        }
    }

    public void Redo()
    {
        if (redo.Count > 0)
        {
            Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("\nRedo Complete!"); Console.ResetColor();
            Command c = redo.Pop();
            c.Do();
            undo.Push(c);
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("\nERROR: Cannot Redo!\n"); Console.ResetColor();
        }
    }

}