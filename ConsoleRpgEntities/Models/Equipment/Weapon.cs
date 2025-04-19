using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleRpgEntities.Models.Characters;

namespace ConsoleRpgEntities.Models.Equipment
{
    public class Weapon : Item
    {
        public int Damage { get; set; }
        public string WeaponType { get; set; }
        public override void Use(IPlayer player)
        {
            Console.WriteLine($"{player.Name} uses {Name} to deal {Damage} damage!");
        }
    }
    
    
}
