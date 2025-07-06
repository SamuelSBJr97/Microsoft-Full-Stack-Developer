List<string> books = new List<string>();
List<string> borrowedBooks = new List<string>(); // Track borrowed books
const int maxBooks = 5;
const int maxBorrowedBooks = 3;

while (true)
{
    Console.WriteLine("\nChoose an action:");
    Console.WriteLine("Add a book    - add");
    Console.WriteLine("Remove a book - remove");
    Console.WriteLine("List books    - list");
    Console.WriteLine("Search book   - search");
    Console.WriteLine("Borrow book   - borrow");
    Console.WriteLine("Checkin book  - checkin");
    Console.WriteLine("Exit          - exit");
    Console.Write("Enter the action of your choice: ");
    string actionInput = (Console.ReadLine() ?? "").Trim();

    switch (actionInput)
    {
        case "add":
            AddBook(books, maxBooks);
            break;
        case "remove":
            RemoveBook(books, borrowedBooks);
            break;
        case "list":
            ListBooks(books, borrowedBooks);
            break;
        case "search":
            SearchBook(books, borrowedBooks);
            break;
        case "borrow":
            BorrowBook(books, borrowedBooks, maxBorrowedBooks);
            break;
        case "checkin":
            CheckinBook(borrowedBooks);
            break;
        case "exit":
            Console.WriteLine("Exiting the program...");
            return;
        default:
            Console.WriteLine("Invalid action. Please try again.");
            break;
    }
}

void AddBook(List<string> books, int maxBooks)
{
    if (books.Count >= maxBooks)
    {
        Console.WriteLine("The library is full. No more books can be added.");
        return;
    }
    Console.WriteLine("Enter the title of the book to add:");
    string newBook = Console.ReadLine() ?? "";
    if (string.IsNullOrWhiteSpace(newBook))
    {
        Console.WriteLine("Invalid title.");
        return;
    }
    books.Add(newBook);
    Console.WriteLine($"Book '{newBook}' added.");
}

void RemoveBook(List<string> books, List<string> borrowedBooks)
{
    if (books.Count == 0)
    {
        Console.WriteLine("The library is empty. There are no books to remove.");
        return;
    }
    Console.WriteLine("Enter the title of the book to remove:");
    string removeBook = Console.ReadLine() ?? "";
    int index = books.FindIndex(b => b.Equals(removeBook, StringComparison.OrdinalIgnoreCase));
    if (index >= 0)
    {
        books.RemoveAt(index);
        borrowedBooks.RemoveAll(b => b.Equals(removeBook, StringComparison.OrdinalIgnoreCase));
        Console.WriteLine($"Book '{removeBook}' removed.");
    }
    else
    {
        Console.WriteLine("Book not found.");
    }
}

void ListBooks(List<string> books, List<string> borrowedBooks)
{
    Console.WriteLine("\nBooks in the library:");
    if (books.Count == 0)
        Console.WriteLine("No books registered.");
    else
        foreach (var book in books)
        {
            string status = borrowedBooks.Contains(book) ? "(Borrowed)" : "(Available)";
            Console.WriteLine($"{book} {status}");
        }
    Console.WriteLine("\nBooks you have borrowed:");
    if (borrowedBooks.Count == 0)
        Console.WriteLine("No books borrowed.");
    else
        foreach (var book in borrowedBooks)
            Console.WriteLine(book);
}

void SearchBook(List<string> books, List<string> borrowedBooks)
{
    Console.WriteLine("Enter the title of the book to search:");
    string searchBook = Console.ReadLine() ?? "";
    int searchIndex = books.FindIndex(b => b.Equals(searchBook, StringComparison.OrdinalIgnoreCase));
    if (searchIndex >= 0)
    {
        string status = borrowedBooks.Contains(books[searchIndex]) ? "(Borrowed)" : "(Available)";
        Console.WriteLine($"Book '{books[searchIndex]}' is in the collection {status}.");
    }
    else
    {
        Console.WriteLine("Book not found in the collection.");
    }
}

void BorrowBook(List<string> books, List<string> borrowedBooks, int maxBorrowedBooks)
{
    if (borrowedBooks.Count >= maxBorrowedBooks)
    {
        Console.WriteLine($"You have reached the borrowing limit of {maxBorrowedBooks} books.");
        return;
    }
    Console.WriteLine("Enter the title of the book to borrow:");
    string borrowBook = Console.ReadLine() ?? "";
    int borrowIndex = books.FindIndex(b => b.Equals(borrowBook, StringComparison.OrdinalIgnoreCase));
    if (borrowIndex >= 0)
    {
        if (borrowedBooks.Contains(books[borrowIndex]))
        {
            Console.WriteLine("This book is already borrowed.");
        }
        else
        {
            borrowedBooks.Add(books[borrowIndex]);
            Console.WriteLine($"Book '{books[borrowIndex]}' borrowed.");
        }
    }
    else
    {
        Console.WriteLine("Book not found in the collection.");
    }
}

void CheckinBook(List<string> borrowedBooks)
{
    Console.WriteLine("Enter the title of the book to check in:");
    string checkinBook = Console.ReadLine() ?? "";
    int checkinIndex = borrowedBooks.FindIndex(b => b.Equals(checkinBook, StringComparison.OrdinalIgnoreCase));
    if (checkinIndex >= 0)
    {
        borrowedBooks.RemoveAt(checkinIndex);
        Console.WriteLine($"Book '{checkinBook}' checked in.");
    }
    else
    {
        Console.WriteLine("This book is not currently checked out.");
    }
}