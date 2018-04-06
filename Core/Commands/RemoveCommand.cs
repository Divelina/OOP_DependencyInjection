using System;

public class RemoveCommand : Command
{
    [Inject]
    private IRepository<IWeapon> weaponRepository;

    public RemoveCommand(IRepository<IWeapon> weaponRepository, string[] arguments)
        : base(arguments)
    {
        this.weaponRepository = weaponRepository;
    }

    public override string Execute()
    {
        var weaponName = Arguments[0];
        var socketIndex = int.Parse(Arguments[1]);

        var weapon = (Weapon)this.weaponRepository.GetByName(weaponName);

        var result = weapon.RemoveGemFromSocket(socketIndex);

        return result;
    }
}

