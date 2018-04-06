
public interface IWeapon
{
    string Name { get; }

    int MinDamage { get; }
    int MaxDamage { get; }
    int SocketNumber { get; }
    Rarity Rarity { get; }

    IGem[] Gems { get; }

    int Strength { get; }
    int Agility { get; }
    int Vitality { get; }

    string AddGemToSocket(Gem gem, int socketIndex);

    string RemoveGemFromSocket(int socketIndex);
}

