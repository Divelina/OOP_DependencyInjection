using System;

public class AddCommand : Command
{
    [Inject]
    private IGemFactory gemFactory;

    [Inject]
    private IRepository<IWeapon> weaponRepository;

    public AddCommand(IGemFactory gemFactory,
        IRepository<IWeapon> weaponRepository, string[] arguments)
        : base(arguments)
    {
        this.gemFactory = gemFactory;
        this.weaponRepository = weaponRepository;
    }

    public override string Execute()
    {
        var weaponName = this.Arguments[0];
        var socketIndex = int.Parse(this.Arguments[1]);
        var gemInfo = this.Arguments[2];

        var weapon = (Weapon) weaponRepository.GetByName(weaponName);

        var gem = CreateGem(gemInfo, this.gemFactory);

        var result = weapon.AddGemToSocket(gem, socketIndex);

        return result;
    }

    private static Gem CreateGem(string gemInfo, IGemFactory gemFactory)
    {
        var gemTokens = gemInfo.Split();

        var clarity = Enum.Parse<Clarity>(gemTokens[0]);
        var gemType = gemTokens[1];

        var gem = (Gem)gemFactory.CreateGem(gemType, clarity);

        return gem;
    }
}

