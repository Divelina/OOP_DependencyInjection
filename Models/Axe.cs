
public class Axe : Weapon
{
    private const int DefaultMinDamage = 5;
    private const int DefaultMaxDamange = 10;
    private const int DefaultSocketNumber = 4;

    public Axe(string name, Rarity rarity)
        : base(name, rarity, DefaultMinDamage, DefaultMaxDamange, DefaultSocketNumber)
    {
    }
}

