using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Items
{
    public class Weapon
    {
        ushort Damage { get; set; }
        string DamageType { get; set; }

        public Weapon(ushort damage, string damageType)
        {
            Damage = damage;
            DamageType = damageType;
        }

    }

    public class Sword : Weapon
    {
        public Sword(ushort damage, string damageType)
        : base(damage, damageType)
        {

        }
    }
    public class Staff : Weapon
    {
        public Staff(ushort damage, string damageType)
        : base(damage, damageType)
        {

        }
    }
    public class Bow : Weapon
    {
        public Bow(ushort damage, string damageType)
        : base(damage, damageType)
        {
            
        }
    }
}