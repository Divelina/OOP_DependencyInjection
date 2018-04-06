
using System;

public class CreateCommand : Command
{
    [Inject]
    private IWeaponFactory weaponFactory;

    [Inject]
    private IRepository<IWeapon> weaponRepository;

    public CreateCommand(IWeaponFactory weaponFactory,
        IRepository<IWeapon> weaponRepository, string[] arguments)
        :base(arguments)
    {
        this.weaponFactory = weaponFactory;
        this.weaponRepository = weaponRepository;
    }

    public override string Execute()
    {
        var weaponType = this.Arguments[0].Split();
        var rarity = Enum.Parse<Rarity>(weaponType[0]);
        var type = weaponType[1];

        var name = this.Arguments[1];

        var weapon = (Weapon)this.weaponFactory.CreateWeapon(type, name, rarity);

        weaponRepository.Add(weapon);

        return $"Weapon {name} added successfully!";
    }
}

