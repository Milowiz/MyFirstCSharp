using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _05_ToDoManager.Models;
using _05_ToDoManager.Data;
using Microsoft.EntityFrameworkCore;

namespace _05_ToDoManager.Services
{
    public class TodoService
    {
        private readonly TodoDbContext _db;

        public TodoService(TodoDbContext db)
        {
            _db = db;
        }
        public async Task<TodoItem> AddTodoAsync(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException("Title cannot be empty.");

            TodoItem todo = new TodoItem
            {
                Title = title.Trim(),
                CreatedAt = DateTime.UtcNow
            };

            _db.Todos.Add(todo);
            await _db.SaveChangesAsync();

            return todo;
        }
        public async Task<List<TodoItem>> GetOpenTodosAsync()
        {
            return await _db.Todos.Where(t => !t.IsDone)
                                  .OrderBy(t => t.CreatedAt)
                                  .ToListAsync();
        }

        public async Task<bool> CompleteTodoAsync(int id)
        {
            TodoItem? todo = await _db.Todos.FindAsync(id);
            if (todo == null)
            {
                return false;
            }

            todo.IsDone = true;
            await _db.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteTodoAsync(int id)
        {
            TodoItem? todo = await _db.Todos.FindAsync(id);

            if(todo == null)
            {
                return false;
            }

            _db.Todos.Remove(todo);
            await _db.SaveChangesAsync();

            return true;
        }
    }
}