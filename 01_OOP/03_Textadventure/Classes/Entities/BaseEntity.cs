using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Entities
{
    public class BaseEntity
    {

        ushort MaxLives { get; set; }
        ushort CurrentLives { get; set; }
        string[] Inventory { get; set; }
        ushort Damage { get; set; }
        string Name { get; set; }
        string DamageType{ get; set; }
        string DefenseType { get; set; }
        public BaseEntity(ushort maxLives, ushort currentLives, string[] inventory, ushort damage, string name, string damageType, string defenseType)
        {
            MaxLives = maxLives;
            CurrentLives = currentLives;
            Inventory = inventory;
            Damage = damage;
            Name = name;
            DamageType = damageType;
            DefenseType = defenseType;
        }
        public static void DoIt()
        {
            System.Console.WriteLine("Player");
        }

    }
}