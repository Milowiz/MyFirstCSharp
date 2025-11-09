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
        string[] UseOption { get; set; }
        string[] DialogOption { get; set; }
        public Interactable(string[] category, ushort price, string[] useOption, string[] dialogOption)
        : base(category, price)
        {
            UseOption = useOption;
            DialogOption = dialogOption;
        }

    }
    public class Lever : Interactable
    {
        public Lever(string[] category, ushort price, string[] useOption, string[] dialogOption)
        : base(category, price, useOption, dialogOption)
        {

        }
    }
    public class KeyHole : Interactable
    {
        public KeyHole(string[] category, ushort price, string[] useOption, string[] dialogOption)
        : base(category, price, useOption, dialogOption)
        {

        }
    }
    public class Barrel : Interactable
    {
        public Barrel(string[] category, ushort price, string[] useOption, string[] dialogOption)
        : base(category, price, useOption, dialogOption)
        {

        }
    }
    public class WallTorch : Interactable
    {
        public WallTorch(string[] category, ushort price, string[] useOption, string[] dialogOption)
        : base(category, price, useOption, dialogOption)
        {

        }
    }
    public class GoldenCup : Interactable
    {
        public GoldenCup(string[] category, ushort price, string[] useOption, string[] dialogOption)
        : base(category, price, useOption, dialogOption)
        {

        }
    }
    public class FinalChest : Interactable
    {
        public FinalChest(string[] category, ushort price, string[] useOption, string[] dialogOption)
        : base(category, price, useOption, dialogOption)
        {

        }
    }
}