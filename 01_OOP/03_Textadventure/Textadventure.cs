using System.Security.Cryptography;
using Entities;
using GameEngine;
using Items;
using NPC;
using Rooms;
namespace _03_Textadventure
{
    public class Textadventure
    {
        public static void Run()
        {
            string room;
            Alien alien = new Alien(0, 0, [], 0, "Timmy", "", "", "Vulkan", [], []);
            Vendor vendor = new Vendor(0, 0, [], 0, "Timmy", "", "", "Vulkan", [], [], 0, []);
            Princess princess = new Princess(0, 0, [], 0, "Timmy", "", "", "Vulkan", [], []);
            // BaseRoom baseRoom = new BaseRoom("", [""], false, false);
            CursedCastleCourtyard ccc = new CursedCastleCourtyard([""], false, false);
            MainHall mh = new MainHall([""], false, false);
            string options = mh.AskForRoom();

            string options2 = ccc.AskForRoom();
            Console.WriteLine($"{string.Join(", ", options)}{string.Join(", ",options2)}");

            // alien.Talk();
            // vendor.Talk();
            // princess.Talk();

            //Alien alien = new Alien();
            
            

        }
    }
}