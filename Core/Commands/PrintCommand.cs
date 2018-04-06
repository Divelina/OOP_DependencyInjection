using System;

public class PrintCommand : Command
{
    [Inject]
    private IRepository<IWeapon> weaponRepository;

    public PrintCommand(IRepository<IWeapon> weaponRepository, string[] arguments)
        : base(arguments)
    {
        this.weaponRepository = weaponRepository;
    }

    public override string Execute()
    {
        var weaponName = Arguments[0];

        var weapon = (Weapon) this.weaponRepository.GetByName(weaponName);

        var result = weapon.ToString();

        return result;
    }
}

