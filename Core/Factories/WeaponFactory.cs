using System;
using System.Linq;
using System.Reflection;

public class WeaponFactory : IWeaponFactory
{
    public IWeapon CreateWeapon(string weaponType, string name, Rarity rarity)
    {
        var weaponClass = Assembly.GetExecutingAssembly()
            .GetTypes()
            .FirstOrDefault(t => t.Name == weaponType);

        if (weaponClass == null)
        {
            throw new InvalidOperationException("Invalid weapon type");
        }

        var arguments = new object[] { name, rarity };

        var weapon = (IWeapon) Activator.CreateInstance(weaponClass, arguments);

        return weapon;
    }
}

