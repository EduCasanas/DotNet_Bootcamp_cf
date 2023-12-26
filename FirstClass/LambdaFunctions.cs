namespace FirstClass
{
    public static class LambdaFunctions
    {
        // Funciones Lambda son funciones anonimas que pueden ser usadas para crear expresiones mas compactas. Simplifican la escritura del codigo en operaciones de colecciones, eventos y funciones de orden superior.
        public static int Suma(int a, int b)
        {
            return a + b;
        }
        // Funcion Lambda que realiza la misma operacion que la funcion Suma anterior.
        public static Func<int, int, int> SumaLambda = (a, b) => a + b;

        // Parametros por defecto
        public static int SumaConParametrosPorDefecto(int a, int b = 2)
        {
            return a + b;
        }
    }
}
