using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Items
{
 public class Utility : BaseItem
    {
        ushort Charges { get; set; }
        ushort Cooldown { get; set; }
        public Utility(string[] category, ushort price, ushort charges, ushort cooldown)
        : base(category, price)
        {
            Charges = charges;
            Cooldown = cooldown;
        }

    }

    public class HealPotion : Utility
    {
        public HealPotion(string[] category, ushort price, ushort charges, ushort cooldown)
        : base(category, price, charges, cooldown)
        {

        }
    }
    public class InvisiblePotion : Utility
    {
        public InvisiblePotion(string[] category, ushort price, ushort charges, ushort cooldown)
        : base(category, price, charges, cooldown)
        {

        }
    }
        public class StrengthPotion : Utility
    {
        public StrengthPotion(string[] category, ushort price, ushort charges, ushort cooldown)
        : base(category, price, charges, cooldown)
        {

        }
    }
    public class Key : Utility
    {
        public Key(string[] category, ushort price, ushort charges, ushort cooldown)
        : base(category, price, charges, cooldown)
        {

        }
    }

    public class Lighter : Utility
    {
        public Lighter(string[] category, ushort price, ushort charges, ushort cooldown)
        : base(category, price, charges, cooldown)
        {

        }
    }
    public class Stone : Utility
    {
        public Stone(string[] category, ushort price, ushort charges, ushort cooldown)
        : base(category, price, charges, cooldown)
        {

        }
    }
}