using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities;
using System.Buffers.Binary;

namespace NPC
{
    /// <summary>
    /// Entities BaseClass
    /// </summary>
    public class NPC : BaseEntity
    {
        string Race { get; set; }
        string[] InteractiveOptions { get; set; }

        string[] Dialog { get; set; }
        public NPC(ushort maxLives, ushort currentLives, string[] inventory, ushort damage, string name, string damageType, string defenseType, string race, string[] interactiveOptions, string[] dialog)
        : base(maxLives, currentLives, inventory, damage, name, damageType, defenseType)
        {
            Race = race;
            InteractiveOptions = interactiveOptions;
            Dialog = dialog;
        }
    }

    public class Stats
    {
        
    }

    /// <summary>
    /// Friendly NPCs parent class
    /// </summary>
    public class Friendly : NPC
    {

        public Friendly(ushort maxLives, ushort currentLives, string[] inventory, ushort damage, string name, string damageType, string defenseType, string race, string[] interactiveOptions, string[] dialog)
        : base(maxLives, currentLives, inventory, damage, name, damageType, defenseType, race, interactiveOptions, dialog)
        {

        }
    }
    /// <summary>
    /// Hostile NPCs parent class
    /// </summary>
    public class Hostile : NPC
    {
        string Weakness { get; set; }
        float HitRate { get; set; }
        float DodgeRate { get; set; }
        ushort DropsGoldAmount { get; set; }
        public Hostile(ushort maxLives, ushort currentLives, string[] inventory, ushort damage, string name, string damageType, string defenseType, string race, string[] interactiveOptions, string[] dialog, string weakness, float hitRate, float dodgeRate, ushort dropsGoldAmount)
        : base(maxLives, currentLives, inventory, damage, name, damageType, defenseType, race, interactiveOptions, dialog)
        {
            Weakness = weakness;
            HitRate = hitRate;
            DodgeRate = dodgeRate;
            DropsGoldAmount = dropsGoldAmount;

        }

    }

    public class Troll : Hostile
    {
        public Troll(ushort maxLives, ushort currentLives, string[] inventory, ushort damage, string name, string damageType, string defenseType, string race, string[] interactiveOptions, string[] dialog, string weakness, float hitRate, float dodgeRate, ushort dropsGoldAmount)
        : base(maxLives, currentLives, inventory, damage, name, damageType, defenseType, race, interactiveOptions, dialog, weakness, hitRate, dodgeRate, dropsGoldAmount)
        {

        }
    }

    public class Goblin : Hostile
    {
        public Goblin(ushort maxLives, ushort currentLives, string[] inventory, ushort damage, string name, string damageType, string defenseType, string race, string[] interactiveOptions, string[] dialog, string weakness, float hitRate, float dodgeRate, ushort dropsGoldAmount)
        : base(maxLives, currentLives, inventory, damage, name, damageType, defenseType, race, interactiveOptions, dialog, weakness, hitRate, dodgeRate, dropsGoldAmount)
        {

        }
    }

    public class Guardian : Hostile
    {
        public Guardian(ushort maxLives, ushort currentLives, string[] inventory, ushort damage, string name, string damageType, string defenseType, string race, string[] interactiveOptions, string[] dialog, string weakness, float hitRate, float dodgeRate, ushort dropsGoldAmount)
        : base(maxLives, currentLives, inventory, damage, name, damageType, defenseType, race, interactiveOptions, dialog, weakness, hitRate, dodgeRate, dropsGoldAmount)
        {

        }
    }
        public class DragonBoss : Hostile
    {
        string[] BodyPart;
        public DragonBoss(ushort maxLives, ushort currentLives, string[] inventory, ushort damage, string name, string damageType, string defenseType, string race, string[] interactiveOptions, string[] dialog, string weakness, float hitRate, float dodgeRate, ushort dropsGoldAmount, string[] bodyPart)
        : base(maxLives, currentLives, inventory, damage, name, damageType, defenseType, race, interactiveOptions, dialog, weakness, hitRate, dodgeRate, dropsGoldAmount)
        {
            BodyPart = bodyPart;
        }
    }

    public class Vendor : Friendly
    {
        ushort Price { get; set; }
        string[] Room { get; set; }
        public Vendor(ushort maxLives, ushort currentLives, string[] inventory, ushort damage, string name, string damageType, string defenseType, string race, string[] interactiveOptions, string[] dialog, ushort price, string[] room)
        : base(maxLives, currentLives, inventory, damage, name, damageType, defenseType, race, interactiveOptions, dialog)
        {
            Price = price;
            Room = room;
        }

    }
    public class Princess : Friendly
    {
        public Princess(ushort maxLives, ushort currentLives, string[] inventory, ushort damage, string name, string damageType, string defenseType, string race, string[] interactiveOptions, string[] dialog)
        : base(maxLives, currentLives, inventory, damage, name, damageType, defenseType, race, interactiveOptions, dialog)
        {

        }

    }
    public class Alien : Friendly
    {
        public Alien(ushort maxLives, ushort currentLives, string[] inventory, ushort damage, string name, string damageType, string defenseType, string race, string[] interactiveOptions, string[] dialog)
        : base(maxLives, currentLives, inventory, damage, name, damageType, defenseType, race, interactiveOptions, dialog)
        {
           dialog[] = [""] 
        } 
        public static void Talk()
        {
            string[] dialog = ["Das", "ist", "super"];
            int playerInput;
            for(int i = 0; i < dialog.Length; i++)
            {
                Console.WriteLine($"{i}. {dialog[i]}");
                Console.WriteLine("Wie möchtest du weiter vorgehen?");
                playerInput = int.Parse(Console.ReadLine() ?? "");
            }
        }
    }


    

}
