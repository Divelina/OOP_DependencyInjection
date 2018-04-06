using System;
using System.Linq;

public class Engine : IRunnable
{
    private ICommandInterpreter commandInterpreter;
    private readonly IReader reader;
    private readonly IWriter writer;


    public Engine(ICommandInterpreter commandInterpreter, IReader reader, IWriter writer)
    {
        this.commandInterpreter = commandInterpreter;
        this.reader = reader;
        this.writer = writer;
    }

    public void Run()
    {
        string command;

        while ((command = this.reader.ReadLine()) != "END")
        {
            var commandTokens = command.Split(';');

            var commandName = commandTokens[0];
            var commandArgs = commandTokens.ToList().Skip(1).ToArray();

            try
            {
                var commandInstance = commandInterpreter.InterpretCommand(commandName, commandArgs);

                var result = commandInstance.Execute();

                this.writer.WriteLine(result);
            }
            catch (InvalidOperationException ioe)
            {
                this.writer.WriteLine(ioe.Message);
            }
        }
    }
}

