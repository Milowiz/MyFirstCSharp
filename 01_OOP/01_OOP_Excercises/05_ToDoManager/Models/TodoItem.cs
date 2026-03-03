using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static _05_ToDoManager.Models.Subtasks;

namespace _05_ToDoManager.Models
{
    public class TodoItem
    {
        public int Id { get; set; } // Primary Key
        public string Title { get; set; } = string.Empty; //Pflichtfeld (Titel)
        public bool IsDone { get; set; } = false; // Status
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public string? Notes { get; set; }

        public DateTime? DueAt { get; set; }

       // public ICollection<Subtask> Subtasks {get; set; } = new List<Subtask>();
    }
}