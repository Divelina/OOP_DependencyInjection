
public abstract class Command : ICommand
{
    private string[] arguments;

    public Command(string[] arguments)
    {
        this.Arguments = arguments;
    }

    public string[] Arguments
    {
        get { return this.arguments; }
        private set
        {
            if (value != null)
            {
                this.arguments = value;
            }
        }
    }

    public abstract string Execute();
}

