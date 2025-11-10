using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace Rooms
{
    public class BaseRoom
    {
        public virtual string RoomName => "Unkown Room";
        public virtual string[] From => ["None"];
        public virtual string[] To => ["None"];
        string[] LootInRoom { get; set; }
        bool AlreadyVisited { get; set; }
        bool HasNPC { get; set; }

        public BaseRoom(string[] lootInRoom, bool alreadyVisited, bool hasNPC)
        {
            LootInRoom = lootInRoom;
            AlreadyVisited = alreadyVisited;
            HasNPC = hasNPC;
        }
        public string CheckForRoom()
        {
            BaseRoom ccc = new BaseRoom(new[] { "Coin" }, false, false);
            Console.WriteLine($"Du befindest dich in Raum: {ccc.RoomName}");
            return ccc.RoomName;
        }
        public string[] AskForRoom()
        {
            int playerInput;
            for (int i = 0; i < To.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {To[i]}");
            }
            Console.WriteLine("In welchen Raum möchtest du gehen?");
            playerInput = int.Parse(Console.ReadLine() ?? "");
            return To;
        }
    }

    public class CursedCastleCourtyard : BaseRoom
    {
        public override string RoomName => "Cursed Castle Courtyard";
        public override string[] From => ["Entrance", "Garden of Shadows", "Main Hall"];
        public override string[] To => ["Main Hall", "Garden of Shadows"];

        public CursedCastleCourtyard(string[] lootInRoom, bool alreadyVisited, bool hasNPC)
        : base(lootInRoom, alreadyVisited, hasNPC)
        {
            
        }
    }
    public class MainHall : BaseRoom
    {
        public override string RoomName => "Main Hall";
        public override string[] From => ["Cursed Castle Courtyard", "Dining Room", "Library", "Garden Of Shadows"];
        public override string[] To => ["Cursed Castle Courtyard", "Dining Room", "Library", "Garden Of Shadows"];
        public MainHall(string[] lootInRoom, bool alreadyVisited, bool hasNPC)
        : base(lootInRoom, alreadyVisited, hasNPC)
        {
            
        }
    }
    public class DiningRoom : BaseRoom
    {
        public override string RoomName => "Dining Room";
        public override string[] From => ["Main Hall"];
        public override string[] To => ["Main Hall"];
        public DiningRoom(string[] lootInRoom, bool alreadyVisited, bool hasNPC)
        : base(lootInRoom, alreadyVisited, hasNPC)
        {
            
        }
    }
    public class Library : BaseRoom
    {
        public override string RoomName => "Library";
        public override string[] From => ["Main Hall", "Ritual Room"];
        public override string[] To => ["Main Hall", "Ritual Room", "Tower of Storms"];
        public Library(string[] lootInRoom, bool alreadyVisited, bool hasNPC)
        : base(lootInRoom, alreadyVisited, hasNPC)
        {
            
        }
    }
    public class TowerOfStorms : BaseRoom
    {
        public override string RoomName => "Tower Of Storms";
        public override string[] From => ["Library"];
        public override string[] To => ["Not possible"];

        public TowerOfStorms(string[] lootInRoom, bool alreadyVisited, bool hasNPC)
        : base(lootInRoom, alreadyVisited, hasNPC)
        {
            
        }
    }
    public class RitualRoom : BaseRoom
    {
        public override string RoomName => "RitualRoom";
        public override string[] From => ["Library", "Garden of Shadows", "Catacombs"];
        public override string[] To => ["Library", "Garden of Shadows", "Catacombs"];

        public RitualRoom(string[] lootInRoom, bool alreadyVisited, bool hasNPC)
        : base(lootInRoom, alreadyVisited, hasNPC)
        {
            
        }
    }
    public class GardenOfShadows : BaseRoom
    {
        public override string RoomName => "Garden of Shadows";
        public override string[] From => ["Cursed Castle Courtyard", "Main Hall", "Ritual Room"];
        public override string[] To => ["Cursed Castle Courtyard", "Main Hall", "Ritual Room"];
        public GardenOfShadows(string[] lootInRoom, bool alreadyVisited, bool hasNPC)
        : base(lootInRoom, alreadyVisited, hasNPC)
        {
            
        }
    }
    public class Catacombs : BaseRoom
    {
        public override string RoomName => "Catacombs";
        public override string[] From => ["Ritual Room"];
        public override string[] To => ["Ritual Room", "Dragon Cave"];
        public Catacombs(string[] lootInRoom, bool alreadyVisited, bool hasNPC)
        : base(lootInRoom, alreadyVisited, hasNPC)
        {
            
        }
    }
    public class DragonCave : BaseRoom
    {
        public override string RoomName => "Dragon Cave";
        public DragonCave(string[] lootInRoom, bool alreadyVisited, bool hasNPC)
        : base(lootInRoom, alreadyVisited, hasNPC)
        {

        }
    }
    

    
}