
using System;
using System.Linq;
using System.Reflection;

public class CommandInterpreter : ICommandInterpreter
{
    private IServiceProvider serviceProvider;

    public CommandInterpreter(IServiceProvider serviceProvider)
    {
        this.serviceProvider = serviceProvider;
    }

    public ICommand InterpretCommand(string commandName, string[] argugments)
    {
        var commandFullName = commandName + "Command";

        var commandClass = Assembly.GetExecutingAssembly()
            .GetTypes()
            .FirstOrDefault(t => t.Name == commandFullName);

        if (commandClass == null)
        {
            throw new InvalidOperationException("Invalid command");
        }

        //Testing alternative solution without "InjectAttribute" - see bellow
        //var fields = commandClass.GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
        //    .Where(f => f.CustomAttributes.Any(a => a.AttributeType == typeof(InjectAttribute)))
        //    .ToArray();

        //object[] fieldsToInject = fields
        //    .Select(f => this.serviceProvider.GetService(f.FieldType)).ToArray();

        //object[] commandArguments = fieldsToInject.Concat(new object[] { argugments }).ToArray();

        //alternative solutioin
        var constructorParams = commandClass.GetConstructors().First().GetParameters();

        var constructorParamsType = constructorParams.Select(p => p.ParameterType).ToArray();

        var serviceParams = constructorParamsType
            .Select(serviceProvider.GetService).Where(sp => sp != null).ToArray();

        object[] commandArguments = serviceParams.Concat(new object[] { argugments }).ToArray();

        var command = (ICommand) Activator.CreateInstance(commandClass, commandArguments);

        return command;
    }
}

