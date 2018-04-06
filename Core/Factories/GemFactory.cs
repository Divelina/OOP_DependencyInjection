
using System;
using System.Linq;
using System.Reflection;

public class GemFactory : IGemFactory
{

    public IGem CreateGem(string gemType, Clarity clarity)
    {
        var gemClass = Assembly.GetExecutingAssembly()
            .GetTypes()
            .FirstOrDefault(t => t.Name == gemType);

       if (gemClass == null)
        {
            throw new InvalidOperationException("Invalid type of gem");
        }

        var gem = (IGem) Activator.CreateInstance(gemClass, new object[] {clarity});

        return gem;
    }
}

