using FirstClass;

// ****Lambda Functions****

//Suma normal
int resultado = LambdaFunctions.Suma(1, 2);
Console.WriteLine($"La suma es: {resultado}");

//Suma con funcion Lambda
int resultado2 = LambdaFunctions.SumaLambda(1, 2);
Console.WriteLine($"La suma es: {resultado2}");

//Suma con parametros por defecto
int resultado3 = LambdaFunctions.SumaConParametrosPorDefecto(5);
Console.WriteLine($"La suma es: {resultado3}");

// Suma con parametros por defecto en la funcion Lambda
var SumaConParametrosPorDefectoLambda = (int a, int b = 7) => a + b;
int resultado4 = SumaConParametrosPorDefectoLambda(5);
Console.WriteLine($"La suma es: {resultado4}");

//Parametros en funciones Lambda, "params" permite pasar varios parametros de un mismo tipo a una funcion Lambda
var sum = (params int[] values) =>
{
    int result = 0;
    foreach (var value in values)
    {
        result += value;
    }
    return result;
};
int resultado5 = sum(1, 2, 3, 4, 5);
Console.WriteLine($"La suma de todos los parametros es: {resultado5}");


// ****Primary Constructor****

PrimaryConstructor primaryconstructor = new PrimaryConstructor(1, "constructorPrimario", "Constructor Primario");
Console.WriteLine($"El id es: {primaryconstructor.Id}, el nombre es: {primaryconstructor.Name}, y la descripcion es: {primaryconstructor.Description}");

// ****Funcion local****

int resultado6 = LocalFunction.CalcularSuma(4, 26);
Console.WriteLine($"La suma es: {resultado6}");

