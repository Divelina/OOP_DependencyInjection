
public interface IWeaponFactory
{
    IWeapon CreateWeapon(string weaponType, string name, Rarity rarity);
}

