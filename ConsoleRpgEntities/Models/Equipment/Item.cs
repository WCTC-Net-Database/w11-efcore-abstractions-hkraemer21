using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleRpgEntities.Models.Characters;
using ConsoleRpgEntities.Models.Characters.Monsters;

namespace ConsoleRpgEntities.Models.Equipment
{
    public abstract class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ItemType { get; set; }
        public int Value { get; set; }
        public int Durability { get; set; }
        public virtual IEnumerable<Player> Players { get; set; }
        public virtual IEnumerable<Monster> Monsters { get; set; }
        public abstract void Use(IPlayer player);
    }
}
