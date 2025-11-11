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
            BaseGame game = new BaseGame("", new string[] { });
            game.CreateMap();
            string nextRoomName;
            // Alien alien = new Alien(0, 0, [], 0, "Timmy", "", "", "Vulkan", [], []);
            // Vendor vendor = new Vendor(0, 0, [], 0, "Timmy", "", "", "Vulkan", [], [], 0, []);
            // Princess princess = new Princess(0, 0, [], 0, "Timmy", "", "", "Vulkan", [], []);
            // BaseRoom baseRoom = new BaseRoom("", [""], false, false);
            // CursedCastleCourtyard ccc = new CursedCastleCourtyard([""], false, false);
            // MainHall mh = new MainHall([""], false, false);
            BaseRoom currentRoom = game.Map["Entrance"];
            Console.WriteLine("Du bist im Raum: " + currentRoom.GetType().Name);
            while (true)
            {
                nextRoomName = currentRoom.AskForRoom();
                if (nextRoomName != null && game.Map.ContainsKey(nextRoomName))
                {
                    currentRoom = game.Map[nextRoomName];
                    Console.WriteLine("Du bist jetzt im Raum: " + currentRoom.RoomName);

                }
                else

                {
                    Console.WriteLine("Raum nicht gefunden oder ungültige Eingabe");

                }

            }

            // entrance.AskForRoom();
            // string options = mh.AskForRoom();

            // string options2 = ccc.AskForRoom();
            
            
            //Console.WriteLine($"{string.Join(", ", options)}{string.Join(", ",options2)}");

            // alien.Talk();
            // vendor.Talk();
            // princess.Talk();

            //Alien alien = new Alien();
            
            

        }
    }
}