
public abstract class Gem : IGem
{
    private int strength;
    private int agility;
    private int vitality;
    private Clarity clarity;

    public Gem(int strength, int agility, int vitality, Clarity clarity)
    {
        this.Strength = strength;
        this.Agility = agility;
        this.Vitality = vitality;
        this.Clarity = clarity;
    }

    public int Strength
    {
        get => this.strength + (int)this.Clarity;
        private set { this.strength = value; }
    }

    public int Agility
    {
        get => this.agility + (int)this.Clarity;
        private set { this.agility = value; }
    }

    public int Vitality
    {
        get => this.vitality + (int)this.Clarity;
        private set { this.vitality = value; }
    }

    public Clarity Clarity
    {
        get { return this.clarity; }
        private set { this.clarity = value; }
    }
}

