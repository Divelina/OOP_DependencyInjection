
public class Knife : Weapon
{
    private const int DefaultMinDamage = 3;
    private const int DefaultMaxDamange = 4;
    private const int DefaultSocketNumber = 2;

    public Knife(string name, Rarity rarity)
        : base(name, rarity, DefaultMinDamage, DefaultMaxDamange, DefaultSocketNumber)
    {
    }
}

