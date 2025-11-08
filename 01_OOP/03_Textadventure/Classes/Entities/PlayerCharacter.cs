using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using _03_Textadventure;
using Entities;



namespace PlayerCharacter
{
    public class PlayerCharacter : BaseEntity
    {
        string PlayerClass { get; set; }
        ushort Range { get; set; }
        string[] WearAbleItemCategories { get; set; }
        ushort StartMoney { get; set; }
        ushort CurrentMoney { get; set; }
        float HitRate { get; set; }
        public PlayerCharacter(ushort maxLives, ushort currentLives, string[] inventory, ushort damage, string name, string damageType, string defenseType, string playerClass, ushort range, string[] wearAbleItemCategories, ushort startMoney, ushort currentMoney, float hitRate)
        : base(maxLives, currentLives, inventory, damage, name, damageType, defenseType)
        {
            PlayerClass = playerClass;
            Range = range;
            WearAbleItemCategories = wearAbleItemCategories;
            StartMoney = startMoney;
            HitRate = hitRate;
            CurrentMoney = currentMoney;

        }
        public void Interact()
        {

        }
        public void Test()
        {

        }
    }
    public class Mage : PlayerCharacter
    {
        public Mage(ushort maxLives, ushort currentLives, string[] inventory, ushort damage, string name, string damageType, string defenseType, string playerClass, ushort range, string[] wearAbleItemCategories, ushort startMoney, ushort currentMoney, float hitRate)
        : base(maxLives, currentLives, inventory, damage, name, damageType, defenseType, playerClass, range, wearAbleItemCategories, startMoney,currentMoney, hitRate)
        {

        }
    }
    public class Warrior : PlayerCharacter
    {
        public Warrior(ushort maxLives, ushort currentLives, string[] inventory, ushort damage, string name, string damageType, string defenseType, string playerClass, ushort range, string[] wearAbleItemCategories, ushort startMoney, ushort currentMoney,float hitRate)
        : base(maxLives, currentLives, inventory, damage, name, damageType, defenseType, playerClass, range, wearAbleItemCategories, startMoney,currentMoney, hitRate)
        {

        }
    }
        public class Archer : PlayerCharacter
    {
        public Archer(ushort maxLives, ushort currentLives, string[] inventory, ushort damage, string name, string damageType, string defenseType, string playerClass, ushort range, string[] wearAbleItemCategories, ushort startMoney, ushort currentMoney, float hitRate) 
        : base(maxLives, currentLives, inventory, damage, name, damageType, defenseType,playerClass,range,wearAbleItemCategories,startMoney,currentMoney,hitRate)
        {
            
        }
    }
}