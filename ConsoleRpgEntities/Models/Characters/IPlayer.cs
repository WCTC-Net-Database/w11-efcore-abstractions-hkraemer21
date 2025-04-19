using ConsoleRpgEntities.Models.Abilities.PlayerAbilities;
using ConsoleRpgEntities.Models.Attributes;
using ConsoleRpgEntities.Models.Equipment;

namespace ConsoleRpgEntities.Models.Characters;

public interface IPlayer
{
    int Id { get; set; }
    string Name { get; set; }

    IEnumerable<Ability> Abilities { get; set; }
    IEnumerable<Item> Inventory { get; set; }


    void Attack(ITargetable target);
    void UseAbility(IAbility ability, ITargetable target);


}
