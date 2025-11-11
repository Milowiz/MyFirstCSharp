using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace Items
{
    public class Weapon : BaseItem
    {
        public override string ItemName => new string("NoneWeapon");
        public virtual ushort Damage => 0;
        string DamageType { get; set; }

        public Weapon(string[] category, string damageType)
        :base(category)
        {
            
            DamageType = damageType;
        }

    }

    public class Sword : Weapon
    {
        public override string ItemName => new string("Sword");
        public override ushort Damage => 10;
        public Sword(string[] category, string damageType)
        : base(category, damageType)
        {
            
        }
    }
    public class Staff : Weapon
    {
        public override string ItemName => new string("Staff");
        public override ushort Damage => 5;
        public Staff(string[] category, string damageType)
        : base(category, damageType)
        {

        }
    }
    public class Bow : Weapon
    {
        public override string ItemName => new string("Bow");
        public override ushort Damage => 6;
        public Bow(string[] category, string damageType)
        : base(category, damageType)
        {
            
        }
    }
}