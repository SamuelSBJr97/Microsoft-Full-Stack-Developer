// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

string book1 = "";
string book2 = "";
string book3 = "";
string book4 = "";
string book5 = "";

while (true)
{
    Console.WriteLine("\nEscolha uma ação: add, remove, list, exit");
    string action = (Console.ReadLine() ?? "").Trim().ToLower();

    if (action == "add")
    {
        if (book1 != "" && book2 != "" && book3 != "" && book4 != "" && book5 != "")
        {
            Console.WriteLine("A biblioteca está cheia. Não é possível adicionar mais livros.");
            continue;
        }
        Console.WriteLine("Digite o título do livro para adicionar:");
        string newBook = Console.ReadLine() ?? "";
        if (string.IsNullOrWhiteSpace(newBook))
        {
            Console.WriteLine("Título inválido.");
            continue;
        }
        if (book1 == "") book1 = newBook;
        else if (book2 == "") book2 = newBook;
        else if (book3 == "") book3 = newBook;
        else if (book4 == "") book4 = newBook;
        else if (book5 == "") book5 = newBook;
        Console.WriteLine($"Livro '{newBook}' adicionado.");
    }
    else if (action == "remove")
    {
        if (book1 == "" && book2 == "" && book3 == "" && book4 == "" && book5 == "")
        {
            Console.WriteLine("A biblioteca está vazia. Não há livros para remover.");
            continue;
        }
        Console.WriteLine("Digite o título do livro para remover:");
        string removeBook = Console.ReadLine() ?? "";
        bool removed = false;
        if (book1.Equals(removeBook, StringComparison.OrdinalIgnoreCase)) { book1 = ""; removed = true; }
        else if (book2.Equals(removeBook, StringComparison.OrdinalIgnoreCase)) { book2 = ""; removed = true; }
        else if (book3.Equals(removeBook, StringComparison.OrdinalIgnoreCase)) { book3 = ""; removed = true; }
        else if (book4.Equals(removeBook, StringComparison.OrdinalIgnoreCase)) { book4 = ""; removed = true; }
        else if (book5.Equals(removeBook, StringComparison.OrdinalIgnoreCase)) { book5 = ""; removed = true; }
        if (removed)
            Console.WriteLine($"Livro '{removeBook}' removido.");
        else
            Console.WriteLine("Livro não encontrado.");
    }
    else if (action == "list")
    {
        Console.WriteLine("\nLivros na biblioteca:");
        if (book1 != "") Console.WriteLine(book1);
        if (book2 != "") Console.WriteLine(book2);
        if (book3 != "") Console.WriteLine(book3);
        if (book4 != "") Console.WriteLine(book4);
        if (book5 != "") Console.WriteLine(book5);
        if (book1 == "" && book2 == "" && book3 == "" && book4 == "" && book5 == "")
            Console.WriteLine("Nenhum livro cadastrado.");
    }
    else if (action == "exit")
    {
        Console.WriteLine("Saindo do programa...");
        break;
    }
    else
    {
        Console.WriteLine("Ação inválida. Tente novamente.");
    }
}
