using System;
using System.Linq;

//[CustomAttribute("Pesho", 3, "Used for C# OOP Advanced Course - Enumerations and Attributes.",
//    new string[] { "Pesho", "Svetlio" })]

public abstract class Weapon : IWeapon
{
    private string name;
    private int minDamage;
    private int maxDamage;
    private int socketNumber;
    private Rarity rarity;
    private IGem[] gems;

    public Weapon(string name, Rarity rarity, int minDamage, int maxDamage, int socketNumber)
    {
        this.Name = name;
        this.Rarity = rarity;
        this.MinDamage = minDamage;
        this.MaxDamage = maxDamage;
        this.gems = new IGem[socketNumber];
    }

    public string Name
    {
        get { return this.name; }
        private set { this.name = value; }
    }

    public int MinDamage
    {
        get
        {
            this.minDamage *= (int)this.Rarity;

            foreach (var gem in gems.Where(g => g != null))
            {
                this.minDamage += gem.Strength * 2;
                this.minDamage += gem.Agility;
            }

            return this.minDamage;
        }
        private set { this.minDamage = value; }
    }

    public int MaxDamage
    {
        get
        {
            this.maxDamage *= (int)this.Rarity;

            foreach (var gem in gems.Where(g => g != null))
            {
                this.maxDamage += gem.Strength * 3;
                this.maxDamage += gem.Agility * 4;
            }

            return this.maxDamage;
        }
        private set { this.maxDamage = value; }
    }

    public int SocketNumber
    {
        get { return this.socketNumber; }
        private set { this.socketNumber = value; }
    }

    public Rarity Rarity
    {
        get { return this.rarity; }
        private set { this.rarity = value; }
    }

    public IGem[] Gems => this.gems;

    public int Strength => gems.Where(g => g != null).Sum(g => g.Strength);

    public int Agility => gems.Where(g => g != null).Sum(g => g.Agility);

    public int Vitality => gems.Where(g => g != null).Sum(g => g.Vitality);

    public string AddGemToSocket(Gem gem, int socketIndex)
    {
        if (socketIndex < 0 || socketIndex >= gems.Length)
        {
            throw new InvalidOperationException($"Invalid socket");
        }
            gems[socketIndex] = gem;

        return $"Gem {gem.GetType().Name} successfully added to socket {socketIndex}!";
    }

    public string RemoveGemFromSocket(int socketIndex)
    {
        if (socketIndex >= gems.Length || socketIndex < 0 || gems[socketIndex] == null)
        {
            throw new InvalidOperationException("Invalid or empty socketIndex.");
        }

        var removedGem = gems[socketIndex];

        gems[socketIndex] = null;

        return $"Gem {removedGem.GetType().Name} successfully removed from socket {socketIndex}!";
    }

    public override string ToString()
    {
        var output = $"{this.Name}: {this.MinDamage}-{this.MaxDamage} Damage, " +
            $"+{this.Strength} Strength, +{this.Agility} Agility, +{this.Vitality} Vitality";

        return output;
    }
}

