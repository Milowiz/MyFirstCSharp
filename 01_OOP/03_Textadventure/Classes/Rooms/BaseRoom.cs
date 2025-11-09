using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rooms
{
    public class BaseRoom
    {
        string[] RoomName { get; set; }
        string[] LootInRoom { get; set; }
        bool AlreadyVisited { get; set; }
        bool HasNPC { get; set; }

        public BaseRoom(string[] roomName, string[] lootInRoom, bool alreadyVisited, bool hasNPC)
        {
            RoomName = roomName;
            LootInRoom = lootInRoom;
            AlreadyVisited = alreadyVisited;
            HasNPC = hasNPC;
        }

    }

    public class CursedCastleCourtyard : BaseRoom
    {
        public CursedCastleCourtyard(string[] roomName, string[] lootInRoom, bool alreadyVisited, bool hasNPC)
        : base(roomName, lootInRoom, alreadyVisited, hasNPC)
        {

        }
    }
    public class MainHall : BaseRoom
    {
        public MainHall(string[] roomName, string[] lootInRoom, bool alreadyVisited, bool hasNPC)
        : base(roomName, lootInRoom, alreadyVisited, hasNPC)
        {

        }
    }
    public class DiningRoom : BaseRoom
    {
        public DiningRoom(string[] roomName, string[] lootInRoom, bool alreadyVisited, bool hasNPC)
        : base(roomName, lootInRoom, alreadyVisited, hasNPC)
        {

        }
    }
    public class Library : BaseRoom
    {
        public Library(string[] roomName, string[] lootInRoom, bool alreadyVisited, bool hasNPC)
        : base(roomName, lootInRoom, alreadyVisited, hasNPC)
        {

        }
    }
    public class TowerOfStorms : BaseRoom
    {
        public TowerOfStorms(string[] roomName, string[] lootInRoom, bool alreadyVisited, bool hasNPC)
        : base(roomName, lootInRoom, alreadyVisited, hasNPC)
        {

        }
    }
    public class RitualRoom : BaseRoom
    {
        public RitualRoom(string[] roomName, string[] lootInRoom, bool alreadyVisited, bool hasNPC)
        : base(roomName, lootInRoom, alreadyVisited, hasNPC)
        {

        }
    }
    public class GardenOfShadows : BaseRoom
    {
        public GardenOfShadows(string[] roomName, string[] lootInRoom, bool alreadyVisited, bool hasNPC)
        : base(roomName, lootInRoom, alreadyVisited, hasNPC)
        {

        }
    }
    public class Catacombs : BaseRoom
    {
        public Catacombs(string[] roomName, string[] lootInRoom, bool alreadyVisited, bool hasNPC)
        : base(roomName, lootInRoom, alreadyVisited, hasNPC)
        {

        }
    }
        public class DragonCave : BaseRoom
    {
        public DragonCave(string[] roomName, string[] lootInRoom, bool alreadyVisited, bool hasNPC)
        : base(roomName, lootInRoom, alreadyVisited, hasNPC)
        {
            
        } 
    }
    
}