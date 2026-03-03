using System.Reflection;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using _05_ToDoManager.Data;
using _05_ToDoManager.Models;
using _05_ToDoManager.Services;
using _05_ToDoManager.UI;

internal class Program
{
    static async Task Main(string[] args)
    {
        TodoDbContext db = new TodoDbContext();
        TodoService service = new TodoService(db);
        ConsoleUI ui = new ConsoleUI(service);

        
        await ui.RunAsync();
    }
}