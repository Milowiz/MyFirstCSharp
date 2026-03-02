using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _05_ToDoManager.Services;
using _05_ToDoManager.Models;

namespace _05_ToDoManager.UI
{
    public class ConsoleUI
    {
        private readonly TodoService _service;

        public ConsoleUI(TodoService service)
        {
            _service = service;
        }

        public async Task RunAsync()
        {
            bool running = true;

            while (running)
            {
                Console.WriteLine();
                Console.WriteLine("===== TO-DO MANAGER =====");
                Console.WriteLine("1) Offene Todos anzeigen");
                Console.WriteLine("2) Neues Todo anlegen");
                Console.WriteLine("3) Todo abschließen");
                Console.WriteLine("4) Todo löschen");
                Console.WriteLine("0) Beenden");
                Console.Write("Auswahl: ");

                string? input = Console.ReadLine();


                switch (input)
                {
                    case "1":
                        await ShowOpenTodosAsync();
                        break;

                    case "2":
                        await CreateTodoAsync();
                        break;

                    case "3":
                        await CompleteTodoAsync();
                        break;

                    case "4":
                        await DeleteTodoAsync();
                        break;

                    case "0":
                        running = false;
                        break;

                    default:
                        Console.WriteLine("Ungültige Eingabe.");
                        break;

                }

            }
        }


        // Methoden füllen wir in den nächsten Schritten
        private async Task ShowOpenTodosAsync()
        {
            List<TodoItem> offeneTodos = await _service.GetOpenTodosAsync();

            if (offeneTodos.Count == 0)
            {
                System.Console.WriteLine("Keine offene Todos!");
                return;
            }
            Console.WriteLine();
            Console.WriteLine("Offene Todos: ");
            foreach (TodoItem t in offeneTodos)
            {
                System.Console.WriteLine($"{t.Id} - {t.Title} (erstellt: {t.CreatedAt:yyyy-MM-dd HH:mm}UTC)");
            }
        }
        private async Task CreateTodoAsync()
        {
            Console.Write("Titel: ");
            string? title = Console.ReadLine();

            try
            {
                TodoItem created = await _service.AddTodoAsync(title ?? string.Empty);
                Console.WriteLine($"Angelegt: Id={created.Id}, Title={created.Title}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Fehler: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unerwarteter Fehler beim Anlegen: " + ex.Message);
            }
        }
        private async Task CompleteTodoAsync()

        {
            await ShowOpenTodosAsync();
            Console.Write("ID zum Abschließen: ");
            string? text = Console.ReadLine();

            int id;
            if (!int.TryParse(text, out id))
            {
                Console.WriteLine("Ungültige ID (bitte eine ganze Zahl eingeben).");
                return;
            }

            try
            {
                bool ok = await _service.CompleteTodoAsync(id);
                Console.WriteLine(ok ? "Erfolgreich abgeschlossen." : "ID nicht gefunden.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unerwarteter Fehler beim Abschließen: " + ex.Message);
            }
        }
        private async Task DeleteTodoAsync() 
        
        {
            await ShowOpenTodosAsync();
             Console.Write("ID zum Löschen: ");
             string? text = Console.ReadLine();

             int id;
             if(!int.TryParse(text, out id))
            {
                Console.WriteLine("Ungültige ID (bitte eine ganze Zahl eingeben).");
                return;
            }

            try
            {
                bool ok = await _service.DeleteTodoAsync(id);
                Console.WriteLine(ok ? "Gelösch." : "ID nicht gefunden.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unerwarteter Fehler beim Löschen: " + ex.Message);
            }
        }

    }
}