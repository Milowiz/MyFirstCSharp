using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Items
{
    public class Interactable : BaseItem
    {
        public override string ItemName => new string("NoneInteractable");
        string[] UseOption { get; set; }
        string[] DialogOption { get; set; }
        public Interactable(string[] category, string[] useOption, string[] dialogOption)
        : base(category)
        {
            UseOption = useOption;
            DialogOption = dialogOption;
        }

    }
    public class Lever : Interactable
    {
        public override string ItemName => new string("Lever");
        public Lever(string[] category, string[] useOption, string[] dialogOption)
        : base(category, useOption, dialogOption)
        {

        }
        public override void Use()
        {

            if (!IsUsed)
            {
                IsUsed = true;
                System.Console.WriteLine("You activated the lever and something happened!");
            }
            else
            {
                System.Console.WriteLine($"You used {ItemName} already!");
            }
        }
    }
    public class KeyHole : Interactable
    {
        public override string ItemName => new string("Key Hole");

        public KeyHole(string[] category, string[] useOption, string[] dialogOption)
        : base(category, useOption, dialogOption)
        {

        }
        public override void Use()
        {
            if (!IsUsed)
            {
                IsUsed = true;
                System.Console.WriteLine("You put the key in the keyhole and something happened!");
            }
            else
            {
                System.Console.WriteLine($"You used {ItemName} already!");
            }
        }
    }
    public class Barrel : Interactable
    {
        public override string ItemName => new string("Barrel");
        public Barrel(string[] category, string[] useOption, string[] dialogOption)
        : base(category, useOption, dialogOption)
        {

        }
        public override void Use()
        {
            if (!IsUsed)
            {
                IsUsed = true;
                System.Console.WriteLine("You put the key in the keyhole and something happened!");
            }
            else
            {
                System.Console.WriteLine($"You used {ItemName} already!");
            }
        }
    }
    public class WallTorch : Interactable
    {
        public override string ItemName => new string("Wall Torch");
        public WallTorch(string[] category, string[] useOption, string[] dialogOption)
        : base(category, useOption, dialogOption)
        {

        }
        public override void Use()
        {
            if (!IsUsed)
            {
                IsUsed = true;
                System.Console.WriteLine("You lit the torch and something happened!");
            }
            else
            {
                System.Console.WriteLine($"You used {ItemName} already!");
            }
        }
    }
    public class GoldenCup : Interactable
    {
        public override string ItemName => new string("Golden Cup");
        public GoldenCup(string[] category, string[] useOption, string[] dialogOption)
        : base(category, useOption, dialogOption)
        {

        }
        public override void Use()
        {
            if (!IsUsed)
            {
                IsUsed = true;
                System.Console.WriteLine("You hit the Golden Cup and you see how something happened!");
            }
            else
            {
                System.Console.WriteLine($"You used {ItemName} already!");
            }
        }
    }
    public class FinalChest : Interactable
    {
        public override string ItemName => new string("Final Chest");
        public FinalChest(string[] category, string[] useOption, string[] dialogOption)
        : base(category, useOption, dialogOption)
        {

        }
        public override void Use()
        {
            if (!IsUsed)
            {
                IsUsed = true;
                System.Console.WriteLine("You won the game !");
            }
            else
            {
                System.Console.WriteLine($"You used {ItemName} already!");
            }
        }
    }
}