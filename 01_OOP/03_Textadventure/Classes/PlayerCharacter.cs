using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Classes;

namespace _03_Textadventure.Classes
{
    public class PlayerCharacter : Character
    {
        public PlayerCharacter(ushort maxLives, ushort currentLives, string[] inventory, ushort damage, string name, string damageType, string defenseType)
        : base(maxLives, currentLives, inventory, damage, name, damageType, defenseType)
        {

        }
       
       public void Test()
        {
            
       }
    }
}