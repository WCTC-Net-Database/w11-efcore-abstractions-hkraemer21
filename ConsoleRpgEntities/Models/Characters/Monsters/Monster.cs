using ConsoleRpgEntities.Models.Attributes;
using ConsoleRpgEntities.Models.Equipment;

namespace ConsoleRpgEntities.Models.Characters.Monsters
{
    public abstract class Monster : IMonster, ITargetable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Health { get; set; }
        public int AggressionLevel { get; set; }
        public string MonsterType { get; set; }
        public virtual IEnumerable<Item> Inventory { get; set; }

        protected Monster()
        {

        }

        public abstract void Attack(ITargetable target);

    }
}
