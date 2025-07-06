class LibraryManager
{
    static void Main()
    {
        string book1 = "", book2 = "", book3 = "", book4 = "", book5 = "";
        string borrowed1 = "", borrowed2 = "", borrowed3 = "";

        while (true)
        {
            Console.WriteLine("\nChoose an action: add, remove, search, borrow, checkin, exit");
            string action = Console.ReadLine().ToLower();

            if (action == "add")
            {
                if (!string.IsNullOrEmpty(book1) && !string.IsNullOrEmpty(book2) && !string.IsNullOrEmpty(book3) && !string.IsNullOrEmpty(book4) && !string.IsNullOrEmpty(book5))
                {
                    Console.WriteLine("The library is full. No more books can be added.");
                }
                else
                {
                    Console.WriteLine("Enter the title of the book to add:");
                    string newBook = Console.ReadLine();
                    if (string.IsNullOrEmpty(book1)) book1 = newBook;
                    else if (string.IsNullOrEmpty(book2)) book2 = newBook;
                    else if (string.IsNullOrEmpty(book3)) book3 = newBook;
                    else if (string.IsNullOrEmpty(book4)) book4 = newBook;
                    else if (string.IsNullOrEmpty(book5)) book5 = newBook;
                }
            }
            else if (action == "remove")
            {
                if (string.IsNullOrEmpty(book1) && string.IsNullOrEmpty(book2) && string.IsNullOrEmpty(book3) && string.IsNullOrEmpty(book4) && string.IsNullOrEmpty(book5))
                {
                    Console.WriteLine("The library is empty. No books to remove.");
                }
                else
                {
                    Console.WriteLine("Enter the title of the book to remove:");
                    string removeBook = Console.ReadLine();
                    bool removed = false;
                    if (removeBook == book1) { book1 = ""; removed = true; }
                    else if (removeBook == book2) { book2 = ""; removed = true; }
                    else if (removeBook == book3) { book3 = ""; removed = true; }
                    else if (removeBook == book4) { book4 = ""; removed = true; }
                    else if (removeBook == book5) { book5 = ""; removed = true; }

                    // Se o livro removido estava emprestado, remove também dos emprestados
                    if (removeBook == borrowed1) borrowed1 = "";
                    if (removeBook == borrowed2) borrowed2 = "";
                    if (removeBook == borrowed3) borrowed3 = "";

                    if (removed)
                        Console.WriteLine($"Book '{removeBook}' removed.");
                    else
                        Console.WriteLine("Book not found.");
                }
            }
            else if (action == "search")
            {
                Console.WriteLine("Enter the title of the book to search:");
                string searchBook = Console.ReadLine();
                if ((searchBook == book1 && !string.IsNullOrEmpty(book1)) ||
                    (searchBook == book2 && !string.IsNullOrEmpty(book2)) ||
                    (searchBook == book3 && !string.IsNullOrEmpty(book3)) ||
                    (searchBook == book4 && !string.IsNullOrEmpty(book4)) ||
                    (searchBook == book5 && !string.IsNullOrEmpty(book5)))
                {
                    Console.WriteLine($"Book '{searchBook}' is available in the collection.");
                }
                else
                {
                    Console.WriteLine("Book not found in the collection.");
                }
            }
            else if (action == "borrow")
            {
                int borrowedCount = 0;
                if (!string.IsNullOrEmpty(borrowed1)) borrowedCount++;
                if (!string.IsNullOrEmpty(borrowed2)) borrowedCount++;
                if (!string.IsNullOrEmpty(borrowed3)) borrowedCount++;

                if (borrowedCount >= 3)
                {
                    Console.WriteLine("You have reached the borrowing limit of 3 books.");
                }
                else
                {
                    Console.WriteLine("Enter the title of the book to borrow:");
                    string borrowBook = Console.ReadLine();
                    bool exists = (borrowBook == book1 && !string.IsNullOrEmpty(book1)) ||
                                  (borrowBook == book2 && !string.IsNullOrEmpty(book2)) ||
                                  (borrowBook == book3 && !string.IsNullOrEmpty(book3)) ||
                                  (borrowBook == book4 && !string.IsNullOrEmpty(book4)) ||
                                  (borrowBook == book5 && !string.IsNullOrEmpty(book5));
                    bool alreadyBorrowed = (borrowBook == borrowed1) || (borrowBook == borrowed2) || (borrowBook == borrowed3);

                    if (!exists)
                    {
                        Console.WriteLine("Book not found in the collection.");
                    }
                    else if (alreadyBorrowed)
                    {
                        Console.WriteLine("This book is already borrowed.");
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(borrowed1)) borrowed1 = borrowBook;
                        else if (string.IsNullOrEmpty(borrowed2)) borrowed2 = borrowBook;
                        else if (string.IsNullOrEmpty(borrowed3)) borrowed3 = borrowBook;
                        Console.WriteLine($"Book '{borrowBook}' borrowed.");
                    }
                }
            }
            else if (action == "checkin")
            {
                Console.WriteLine("Enter the title of the book to check in:");
                string checkinBook = Console.ReadLine();
                bool checkedIn = false;
                if (checkinBook == borrowed1) { borrowed1 = ""; checkedIn = true; }
                else if (checkinBook == borrowed2) { borrowed2 = ""; checkedIn = true; }
                else if (checkinBook == borrowed3) { borrowed3 = ""; checkedIn = true; }

                if (checkedIn)
                    Console.WriteLine($"Book '{checkinBook}' checked in.");
                else
                    Console.WriteLine("This book is not currently checked out.");
            }
            else if (action == "exit")
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid action. Please type add, remove, search, borrow, checkin, or exit.");
            }

            // Display the list of books
            Console.WriteLine("\nAvailable books:");
            if (!string.IsNullOrEmpty(book1)) Console.WriteLine(book1);
            if (!string.IsNullOrEmpty(book2)) Console.WriteLine(book2);
            if (!string.IsNullOrEmpty(book3)) Console.WriteLine(book3);
            if (!string.IsNullOrEmpty(book4)) Console.WriteLine(book4);
            if (!string.IsNullOrEmpty(book5)) Console.WriteLine(book5);

            Console.WriteLine("\nBorrowed books:");
            if (!string.IsNullOrEmpty(borrowed1)) Console.WriteLine(borrowed1);
            if (!string.IsNullOrEmpty(borrowed2)) Console.WriteLine(borrowed2);
            if (!string.IsNullOrEmpty(borrowed3)) Console.WriteLine(borrowed3);
        }
    }
}