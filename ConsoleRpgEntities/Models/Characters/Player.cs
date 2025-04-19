using ConsoleRpgEntities.Models.Abilities.PlayerAbilities;
using ConsoleRpgEntities.Models.Attributes;
using ConsoleRpgEntities.Models.Equipment;

namespace ConsoleRpgEntities.Models.Characters
{
    public class Player : ITargetable, IPlayer
    {
        public int Experience { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Health { get; set; }
        public virtual IEnumerable<Ability> Abilities { get; set; }
        public virtual IEnumerable<Item> Inventory { get; set; }

        public void Attack(ITargetable target)
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

        

        public void UseAbility(IAbility ability, ITargetable target)
        {
            if (Abilities.Contains(ability))
            {
                ability.Activate(this, target);
            }
            else
            {
                Console.WriteLine($"{Name} does not have the ability {ability.Name}!");
            }
        }
    }
}
