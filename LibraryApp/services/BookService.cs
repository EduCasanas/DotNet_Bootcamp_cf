using LibraryApp.entities;
using LibraryApp.utils;
using System.Text;
using System.Text.Json;

namespace LibraryApp.services
{
    public static class BookService
    {
        // Lista de libros
        private static List<Book> books = new List<Book>();

        // Metodo para cargar los libros de un archivo books.json
        public static List<Book> LoadFromFile()
        {
            // Si el archivo no existe, retorna una lista vacia
            if (!File.Exists(Constants.BOOKS_FILE))
            {
                return new List<Book>();
            }
            // Lee el archivo y lo guarda en la variable json
            string json = File.ReadAllText(Constants.BOOKS_FILE);
            // Si el archivo esta vacio, retorna una lista vacia
            if (string.IsNullOrWhiteSpace(json))
            {
                return new List<Book>();
            }
            // Deserializa el archivo json y devuelve una lista de libros
            return JsonSerializer.Deserialize<List<Book>>(json);
        }

        // Metodo para guardar los libros en un archivo books.json
        public static void SaveToFile(List<Book> books)
        {
            // Serializa la lista de libros y lo guarda en la variable json
            string json = JsonSerializer.Serialize(books);
            // Guarda la lista de libros en el archivo books.json
            File.WriteAllText(Constants.BOOKS_FILE, json);
        }
        // Metodo para actualizar un libro en el archivo books.json
        public static void UpdateBookToFile(int id, string newTitle, string newAuthor, string newCategory)
        {
            // Carga los libros del archivo books.json
            List<Book> books = LoadFromFile();
            // Busca el libro con el id ingresado para actualizarlo
            Book book = books.FirstOrDefault(book => book.Id == id);

            book.Title = newTitle;
            book.Autor = newAuthor;
            book.Category = newCategory;

            SaveToFile(books);
        }
        // Metodo para eliminar un libro del archivo books.json
        public static void DeleteBookFromFile(int id)
        {
            List<Book> books = LoadFromFile();
            var book = books.FirstOrDefault(book => book.Id == id);

            books.Remove(book);
            SaveToFile(books);
        }

        // Metodo para agregar un libro
        public static string AddBook()
        {
            Console.Write("Ingrese el titulo del libro: ");
            string title = Console.ReadLine();
            Console.Write("Ingrese el autor del libro: ");
            string autor = Console.ReadLine();
            Console.Write("Ingrese la categoria del libro: ");
            string category = Console.ReadLine();

            List<Book> books = LoadFromFile();

            Book book = new Book()
            {
                Id = books.Count + 1,
                Title = title,
                Autor = autor,
                Category = category,
                IsAvailable = true
            };
            // Agrega el libro a la lista de libros
            books.Add(book);
            SaveToFile(books);
            Console.WriteLine("---------------------------------------------");
            return "Libro agregado correctamente!";
        }
        // Metodo para editar un libro
        public static string Update()
        {
            Console.Write("Ingrese el id del libro a actualizar: ");
            // Validamos que el id sea un numero, porque si se ingresa un texto, el programa se cae.
            if (int.TryParse(Console.ReadLine(), out int idBook))
            {
                // Carga los libros del archivo books.json
                List<Book> books = LoadFromFile();
                // Busca el libro con el id ingresado porque si no existe, no se puede editar.
                var book = books.FirstOrDefault(book => book.Id == idBook);
                // Si es diferente de null, significa que el libro existe y se puede editar.
                if (book != null)
                {
                    Console.Write("Ingrese el titulo del libro: ");
                    string newTitle = Console.ReadLine();
                    Console.Write("Ingrese el autor del libro: ");
                    string newAutor = Console.ReadLine();
                    Console.Write("Ingrese la categoria del libro: ");
                    string newCategory = Console.ReadLine();
                    // Llama al metodo UpdateBook para actualizar el libro
                    UpdateBookToFile(idBook, newTitle, newAutor, newCategory);

                    return "Libro se ha editado correctamente!";
                }
                else
                {
                    return $"El libro con id {idBook} no existe!";
                }
            }
            else
            {
                return "El id debe ser un numero!";
            }
        }

        // Metodo para eliminar un libro
        public static string Delete()
        {
            Console.Write("Ingrese el id del libro a eliminar: ");

            if (int.TryParse(Console.ReadLine(), out int idBookToDelete))
            {

                List<Book> books = LoadFromFile();
                var book = books.FirstOrDefault(book => book.Id == idBookToDelete);

                if (book != null)
                {
                    // Llama al metodo DeleteBook para eliminar el libro
                    DeleteBookFromFile(idBookToDelete);
                    return "Libro eliminado correctamente!";
                }
                else
                {
                    return $"El libro con id {idBookToDelete} no existe!";
                }
            }
            else
            {
                return "El id debe ser un numero!";
            }
        }

        // Metodo para listar todos los libros  
        public static string GetAll()
        {
            // Cargar los libros del archivo books.json
            List<Book> books = LoadFromFile();
            // Si no hay libros, retorna un mensaje
            if (!books.Any())
                return "No hay libros registrados";

            //Armar la lista de libros en formato string
            var builder = new StringBuilder();
            builder.AppendLine("|ID".PadRight(10) + "|Título".PadRight(20) + "|Autor".PadRight(20) + "|Categoría".PadRight(20) + "|Disponible".PadRight(10));
            // Recorre la lista de libros y los agrega al string builder
            foreach (var book in books)
            {
                builder.AppendLine($"|{book.Id.ToString().PadRight(9)}|{book.Title.PadRight(19)}|{book.Autor.PadRight(19)}|{book.Category.PadRight(19)}|{(book.IsAvailable ? "Sí" : "No").PadRight(9)}");
            }
            return builder.ToString();
        }
    }
}