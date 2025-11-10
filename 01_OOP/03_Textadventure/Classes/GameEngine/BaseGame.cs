using System;
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

        public BaseGame(string currentRoom, string[] dialogOptions)
        {
            CurrentRoom = currentRoom;
            DialogOptions = dialogOptions;
        }
        
    }
}