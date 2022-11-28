// Abstract Command (Command) class - commands can do something and also undo
public abstract class Command
{
    public abstract void Do();     // what happens when we execute (do)
    public abstract void Undo();   // what happens when we unexecute (undo)
}