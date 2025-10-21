using BookList;

List<Book> books = new List<Book>();
int ISBN = 0;

string filePath = @"Livros.txt";
string directoryPath = @"C:\Livraria\";

try
{
    if (!Directory.Exists(directoryPath))
    {
        Directory.CreateDirectory(directoryPath);
    }
}
catch (Exception e)
{
    Console.WriteLine(e.StackTrace);
    Console.WriteLine(e.Message);
}

var fullPath = Path.Combine(directoryPath, filePath);

Book BookCreator()
{
    Console.WriteLine("Digite o nome do livro que deseja cadastrar:");
    string title = Console.ReadLine();
    Console.WriteLine("Digite o autor do livro desejado:");
    string author = Console.ReadLine();
    Console.WriteLine("Digite a categoria do livro:");
    string category = Console.ReadLine();
    Console.WriteLine("Digite o ISBN do livro:");
    ISBN = int.Parse(Console.ReadLine());
    Book newBook = new Book(ISBN, title, author, category);
    books.Add(newBook);
    Console.Clear();
    return newBook;
}
void Library()
{
    Console.WriteLine("Biblioteca");
    foreach (var newBook in books)
    {
        StreamWriter writer = new StreamWriter(fullPath, append: true);

        writer.WriteLine(newBook);
        writer.Close();

        StreamReader reader = new StreamReader(fullPath);
        using (reader)
        {
            string content = reader.ReadToEnd();
            Console.WriteLine(content);
            reader.Close();
        }
        //Console.WriteLine(newBook);
    }
}
Book FindBookByISBN(int ISBN)
{
    return books.Find(book => book.ISBN == ISBN);
}
Book? UpdateBook()
{
    Console.WriteLine("Atualizar Livros");
    Console.WriteLine("Digite o ISBN do livro que deseja editar");
    int ISBN = int.Parse(Console.ReadLine() ?? "");
    Book bookToUpdate = FindBookByISBN(ISBN); 
    if (bookToUpdate != null)
    {
        Console.WriteLine("Digite o novo nome do livro:");
        bookToUpdate.Title = Console.ReadLine();
        Console.WriteLine("Digite o novo autor do livro:");
        bookToUpdate.Author = Console.ReadLine();
        Console.WriteLine("Digite a nova categoria do livro:");
        bookToUpdate.Category = Console.ReadLine();
        return bookToUpdate;
    }
    return null;
}
void RemoveBookByISBN()
{
    Console.WriteLine("Deletar Livros");
    Console.WriteLine("Digite o ISBN do livro que deseja remvoer:");
    int ISBN = int.Parse(Console.ReadLine() ?? "");
    var book = FindBookByISBN(ISBN);
    if (book is not null)
    {
        books.Remove(book);
        Console.WriteLine("Livro removido");
        StreamReader reader = new StreamReader(fullPath);
        using (reader)
        {
            string content = reader.ReadToEnd();
            Console.WriteLine(content);
            reader.Close();
        }
    }
    else
    {
        Console.WriteLine("Livro não encontrado");
    }
}

int option = 0;

do
{
    Console.WriteLine("Digite a operação que deseja executar:" +
        "\n1 - Adicionar Livro" +
        "\n2 - Listar Livros" +
        "\n3 - Atualizar informações do Livro" +
        "\n4 - Deletar Livros" +
        "\n5 - Sair");
    option = int.Parse(Console.ReadLine()!);

    switch (option)
    {
        case 1:
            BookCreator();
            break;
        case 2:
            Library();
            break;
        case 3:
            UpdateBook();
            break;
        case 4:
            RemoveBookByISBN();
            break;
        case 5:
            Console.WriteLine("Saindo");
            break;
        default:
            Console.WriteLine("Opção Inválida");
            break;
    }
} while (option != 5);
