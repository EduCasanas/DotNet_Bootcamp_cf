using LibraryApp.services;
using LibraryApp.utils;

// se envuelve en un while para que el usuario pueda ejecutar las opciones del menu principal hasta que el usuario ingrese la opcion 5 que es salir.
while (true)
{
    // Limpia la consola
    Console.Clear();
    // LLama al metodo Options() y guarda el valor en la variable opcion
    int opcion = Options();
    // Convierte el valor de opcion a OptionEnum
    OptionEnum optionEnum = (OptionEnum)opcion;
    // Si el valor de optionEnum es igual a OptionEnum.Exit se rompe el ciclo
    if (optionEnum == OptionEnum.Exit)
        break;

    // Dependiendo del valor de optionEnum se ejecuta un metodo
    string message = optionEnum switch
    {
        OptionEnum.Add => BookService.AddBook(),
        OptionEnum.Update => BookService.Update(),
        OptionEnum.Delete => BookService.Delete(),
        OptionEnum.List => BookService.GetAll(),
        OptionEnum.Exit => "Salir",
        _ => "Opcion NO válida, por favor ingrese entre 1 y 5."
    };
    Console.WriteLine(message);
    Console.WriteLine("---------------------------------------------");
    Console.Write("Presione enter para volver al menu principal...");
    Console.ReadLine();
}
// Encabezado de la aplicación
static void Header()
{
    Console.WriteLine(",-----.                  ,--.                                         ,--.  ,--.,------.,--------. \r\n|  |) /_  ,---.  ,---. ,-'  '-. ,---. ,--,--.,--,--,--. ,---.         |  ,'.|  ||  .---''--.  .--' \r\n|  .-.  \\| .-. || .-. |'-.  .-'| .--'' ,-.  ||        || .-. |        |  |' '  ||  `--,    |  |    \r\n|  '--' /' '-' '' '-' '  |  |  \\ `--.\\ '-'  ||  |  |  || '-' '    .--.|  | `   ||  `---.   |  |    \r\n`------'  `---'  `---'   `--'   `---' `--`--'`--`--`--'|  |-'     '--'`--'  `--'`------'   `--'");
}
// Menu principal de la aplicación
static int Options()
{
    while (true)
    {
        Console.Clear();
        Header();
        Console.WriteLine("*************************");
        Console.WriteLine("Bienvenido a la Libreria");
        Console.WriteLine("*************************");
        Console.WriteLine("1.- Crear Libro");
        Console.WriteLine("2.- Editar Libro");
        Console.WriteLine("3.- Eliminar Libro");
        Console.WriteLine("4.- Listar Libros");
        Console.WriteLine("5.- Salir");

        Console.WriteLine("-------------------------");
        Console.Write("Escriba una opcion: ");

        //Validación de la opción ingresada, porque si se ingresa un string, el programa se rompe, por eso se usa el TryParse para validar que el valor ingresado sea un número, y se lo envuelve en un while para que se vuelva a presentar el menu de la aplicacion hasta que se ingrese un string convertible a entero.  
        string input = Console.ReadLine();
        if (int.TryParse(input, out int option))
            return option;

        Console.WriteLine("Opción no válida. Por favor, ingrese un número.");
        Console.Write("Presione enter para volver al menu principal...");
        Console.ReadLine();
    }
}
