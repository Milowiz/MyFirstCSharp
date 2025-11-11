using System.Security.Cryptography;
using Entities;
using GameEngine;
using Items;
using Rooms;
namespace _03_Textadventure
{
    public class Textadventure
    {
        public static void Run()
        {
            BaseGame game = new BaseGame("", new string[] { });
            BaseItem items = new BaseItem([]);
            Stone stone = new Stone([""], 0, 0);
            Sword sword = new Sword([""], "");
            Lever lever = new Lever([""], [""], [""]);
            HealPotion healPotion = new HealPotion([""], 2, 10);
            game.CreateMap();

            // Alien alien = new Alien(0, 0, [], 0, "Timmy", "", "", "Vulkan", [], []);
            // Vendor vendor = new Vendor(0, 0, [], 0, "Timmy", "", "", "Vulkan", [], [], 0, []);
            // Princess princess = new Princess(0, 0, [], 0, "Timmy", "", "", "Vulkan", [], []);
            // BaseRoom baseRoom = new BaseRoom("", [""], false, false);
            // CursedCastleCourtyard ccc = new CursedCastleCourtyard([""], false, false);
            // MainHall mh = new MainHall([""], false, false);
            string itemName = lever.ItemName;
            int price = lever.Price;
            //int damage = lever.Damage;
            lever.IsUsed = true;
            int healAmount = healPotion.HealAmount;
            System.Console.WriteLine($"{itemName}; {price};{healAmount}");




            // Move through World put in PlayerCharacter
            //string nextRoomName;
            // BaseRoom currentRoom = game.Map["Entrance"];
            // Console.WriteLine("Du bist im Raum: " + currentRoom.GetType().Name);
            // while (true)
            // {
            //     nextRoomName = currentRoom.AskForRoom();
            //     if (nextRoomName != null && game.Map.ContainsKey(nextRoomName))
            //     {
            //         currentRoom = game.Map[nextRoomName];
            //         Console.WriteLine("Du bist jetzt im Raum: " + currentRoom.RoomName);

            //     }
            //     else

            //     {
            //         Console.WriteLine("Raum nicht gefunden oder ungültige Eingabe");

            //     }

            // }

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