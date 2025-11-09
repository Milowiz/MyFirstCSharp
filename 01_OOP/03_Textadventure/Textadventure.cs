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
            Alien alien = new Alien(0, 0, [], 0, "Timmy", "", "", "Vulkan", [], []);
            Vendor vendor = new Vendor(0, 0, [], 0, "Timmy", "", "", "Vulkan", [], [],0,[]);
            Princess princess = new Princess(0, 0, [], 0, "Timmy", "", "", "Vulkan", [], []);

            alien.Talk();
            vendor.Talk();
            princess.Talk();

            //Alien alien = new Alien();
            
            

        }
    }
}