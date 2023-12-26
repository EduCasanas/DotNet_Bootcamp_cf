namespace FirstClass
{
    public static class LocalFunction
    {
        // Funcion local es una funcion que se declara dentro de otra funcion y solo se puede acceder a ella desde la funcion que la contiene.
        public static int CalcularSuma(int a, int b)
        {
            return Suma(a, b);

            // Funcion local
            int Suma(int a, int b)
            {
                return a + b;
            }
        }
    }
}
