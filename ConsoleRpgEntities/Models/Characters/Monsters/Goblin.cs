using ConsoleRpgEntities.Models.Attributes;
using ConsoleRpgEntities.Models.Equipment;

namespace ConsoleRpgEntities.Models.Characters.Monsters
{
    public class Goblin : Monster
    {
        public int Sneakiness { get; set; }
        public virtual IEnumerable<Item> Inventory { get; set; }


        public override void Attack(ITargetable target)
        {
            // not flexible in terms of accounting for target's armor and updating their health after attack
            var weapon = Inventory.OfType<Weapon>().FirstOrDefault();

            if (weapon == null)
            {
                Console.WriteLine($"{Name} has no weapon equipped and cannot attack!");
                return;
            }

            int damage = weapon.Damage;

            Console.WriteLine($"{Name} attacks {target.Name} with {weapon.Name}, dealing {damage} damage!");

            weapon.Durability -= 1;
            if (weapon.Durability <= 0)
            {
                Console.WriteLine($"{weapon.Name} has broken!");
                Inventory = Inventory.Where(item => item != weapon).ToList();
            }
        }
    }
}
