using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using Rooms;

namespace GameEngine
{
    public class BaseGame
    {
        string CurrentRoom { get; set; }
        string[] DialogOptions { get; set; }
        public Dictionary<string, BaseRoom> Map{ get; set; }

        public BaseGame(string currentRoom, string[] dialogOptions)
        {
            CurrentRoom = currentRoom;
            DialogOptions = dialogOptions;
        }

        public void CreateMap()
        {
            Map = new Dictionary<string, BaseRoom>();
            

            Map["Entrance"] = new Entrance(new string[] { }, false, false);
            Map["Catacombs"] = new Catacombs(new string[] { }, false, false);
            Map["Cursed Castle Courtyard"] = new CursedCastleCourtyard(new string[] { }, false, false);
            Map["Dining Room"] = new DiningRoom(new string[] { }, false, false);
            Map["Dragon Cave"] = new DragonCave(new string[] { }, false, false);
            Map["Garden of Shadows"] = new GardenOfShadows(new string[] { }, false, false);
            Map["Library"] = new Library(new string[] { }, false, false);
            Map["Main Hall"] = new MainHall(new string[] { }, false, false);
            Map["Ritual Room"] = new RitualRoom(new string[] { }, false, false);
            Map["Tower of Storms"] = new TowerOfStorms(new string[] { }, false, false);


        }

        

        
    }
}