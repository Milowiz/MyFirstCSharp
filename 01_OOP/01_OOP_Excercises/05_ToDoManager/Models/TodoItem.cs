using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _05_ToDoManager.Models
{
    public class TodoItem
    {
        public int Id {get; set;} // Primary Key
        public string Title {get; set;} = string.Empty; //Pflichtfeld (Titel)
        public bool IsDone {get; set;} = false; // Status
        public DateTime CreatedAt {get; set;} = DateTime.UtcNow;
    }
}