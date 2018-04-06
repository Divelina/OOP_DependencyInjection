
public class Emerald : Gem
{
    private const int DefaultStrength = 1;
    private const int DefaultAgility = 4;
    private const int DefaultVitality = 9;

    public Emerald(Clarity clarity) :
        base(DefaultStrength,DefaultAgility, DefaultVitality, clarity)
    {
    }
}

