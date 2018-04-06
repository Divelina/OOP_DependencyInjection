
public class Sword : Weapon
{
    private const int DefaultMinDamage = 4;
    private const int DefaultMaxDamange = 6;
    private const int DefaultSocketNumber = 3;

    public Sword(string name, Rarity rarity)
        : base(name, rarity, DefaultMinDamage, DefaultMaxDamange, DefaultSocketNumber)
    {
    }
}

