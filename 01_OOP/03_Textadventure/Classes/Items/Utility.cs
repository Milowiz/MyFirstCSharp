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
        public Utility(string[] category, ushort charges, ushort cooldown)
        : base(category)
        {
            Charges = charges;
            Cooldown = cooldown;
        }

    }

    public class HealPotion : Utility
    {
        public override string ItemName => new string("Health Potion");
        public override ushort Price => 5;
        public HealPotion(string[] category, ushort charges, ushort cooldown)
        : base(category, charges, cooldown)
        {

        }
    }
    public class InvisiblePotion : Utility
    {
        public override string ItemName => new string("Invisible Potion");
        public override ushort Price => 6;
        public InvisiblePotion(string[] category, ushort charges, ushort cooldown)
        : base(category, charges, cooldown)
        {

        }
    }
        public class StrengthPotion : Utility
    {
        public override string ItemName => new string("Strength Potion");
        public override ushort Price => 7;
        public StrengthPotion(string[] category, ushort charges, ushort cooldown)
        : base(category, charges, cooldown)
        {

        }
    }
    public class Key : Utility
    {
        public override string ItemName => new string("Key");
        public override ushort Price => 4;
        public Key(string[] category, ushort charges, ushort cooldown)
        : base(category, charges, cooldown)
        {

        }
    }

    public class Lighter : Utility
    {
        public override string ItemName => new string("Lighter");
        public override ushort Price => 3;
        public Lighter(string[] category, ushort charges, ushort cooldown)
        : base(category, charges, cooldown)
        {

        }
    }
    public class Stone : Utility
    {
        public override string ItemName => new string("Stone");
        public override ushort Price => 2;
        public Stone(string[] category, ushort charges, ushort cooldown)
        : base(category, charges, cooldown)
        {

        }
    }
}