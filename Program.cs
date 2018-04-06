using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;

public class Program
{
    public static void Main()
    {
        IServiceProvider serviceProvider = ConfigureService();
        ICommandInterpreter commandInterpreter = new CommandInterpreter(serviceProvider);

        IReader reader = new ConsoleReader();
        IWriter writer = new ConsoleWriter();
        IRunnable engine = new Engine(commandInterpreter, reader, writer);

        engine.Run();
    }

    private static IServiceProvider ConfigureService()
    {
        IServiceCollection services = new ServiceCollection();

        services.AddTransient<IWeaponFactory, WeaponFactory>();
        services.AddSingleton<IGemFactory, GemFactory>();
        services.AddSingleton<IRepository<IWeapon>, WeaponRepository>();

        var serviceProvider = services.BuildServiceProvider();

        return serviceProvider;
    }



    //private static object GetAttributeValue(string propertyName)
    //{
    //    var attributeType = Assembly
    //        .GetExecutingAssembly()
    //        .GetType("Weapon")
    //        .GetCustomAttribute(typeof(CustomAttribute));

    //    var propertyValue = attributeType.GetType()
    //        .GetProperty(propertyName).GetValue(attributeType);

    //    return propertyValue;
    //}

}

