// See https://aka.ms/new-console-template for more information
using System.Collections.Generic;
Console.WriteLine("Hello, World!");

List<string> books = new List<string>();
const int maxBooks = 5;

while (true)
{
    Console.WriteLine("\nChoose an action:");
    Console.WriteLine("Add a book    - add");
    Console.WriteLine("Remove a book - remove");
    Console.WriteLine("List books    - list");
    Console.WriteLine("Exit          - exit");
    Console.Write("Enter the number of your choice: ");
    string actionInput = (Console.ReadLine() ?? "").Trim();

    switch (actionInput)
    {
        case "add":
            if (books.Count >= maxBooks)
            {
                Console.WriteLine("The library is full. No more books can be added.");
                continue;
            }
            Console.WriteLine("Enter the title of the book to add:");
            string newBook = Console.ReadLine() ?? "";
            if (string.IsNullOrWhiteSpace(newBook))
            {
                Console.WriteLine("Invalid title.");
                continue;
            }
            books.Add(newBook);
            Console.WriteLine($"Book '{newBook}' added.");
            break;
        case "remove":
            if (books.Count == 0)
            {
                Console.WriteLine("The library is empty. There are no books to remove.");
                continue;
            }
            Console.WriteLine("Enter the title of the book to remove:");
            string removeBook = Console.ReadLine() ?? "";
            int index = books.FindIndex(b => b.Equals(removeBook, StringComparison.OrdinalIgnoreCase));
            if (index >= 0)
            {
                books.RemoveAt(index);
                Console.WriteLine($"Book '{removeBook}' removed.");
            }
            else
            {
                Console.WriteLine("Book not found.");
            }
            break;
        case "list":
            Console.WriteLine("\nBooks in the library:");
            if (books.Count == 0)
                Console.WriteLine("No books registered.");
            else
                foreach (var book in books)
                    Console.WriteLine(book);
            break;
        case "exit":
            Console.WriteLine("Exiting the program...");
            return;
        default:
            Console.WriteLine("Invalid action. Please try again.");
            break;
    }
}
