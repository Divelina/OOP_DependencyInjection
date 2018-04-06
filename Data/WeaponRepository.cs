using System;
using System.Linq;
using System.Collections.Generic;

public class WeaponRepository : IRepository<IWeapon>
{
    private Dictionary<string, IWeapon> elements;

    public WeaponRepository()
    {
        this.elements = new Dictionary<string, IWeapon>();
    }

    public IReadOnlyDictionary <string, IWeapon> Elements
    {
        get { return this.elements; }
    }

    public void Add(IWeapon element)
    {
        elements[element.Name] = element;
    }

    public IWeapon GetByName(string name)
    {
        if (!this.elements.Any(el => el.Key == name))
        {
            throw new InvalidOperationException("Invalid weapon name!");
        }

        var weapon = this.Elements[name];

        return weapon;
    }
}

