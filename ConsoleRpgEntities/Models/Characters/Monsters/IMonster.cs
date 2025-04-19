using ConsoleRpgEntities.Models.Attributes;
using ConsoleRpgEntities.Models.Equipment;

namespace ConsoleRpgEntities.Models.Characters.Monsters;

public interface IMonster
{
    int Id { get; set; }
    string Name { get; set; }
    IEnumerable<Item> Inventory { get; set; }


    void Attack(ITargetable target);
}