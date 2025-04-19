using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleRpgEntities.Models.Characters;

namespace ConsoleRpgEntities.Models.Equipment
{
    public class Armor : Item
    {
        public int Defense { get; set; }
        public string ArmorType { get; set; }
        public override void Use(IPlayer player)
        {
            Console.WriteLine($"{player.Name} equips {Name} for +{Defense} defense!");
            
        }
    }
}
