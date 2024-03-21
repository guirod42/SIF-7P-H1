namespace Calculadora.Core
{
    public static class Calcular
    {
        public static int Somar(int x, int y) => x + y;
        public static int Subtrair(int x, int y) => x - y;
        public static int Multiplicar(int x, int y) => x * y;

        public static int Dividir(int x, int y)
        {
            if (y == 0) throw new Exception("Impossivel dividir por zero");
            return x / y;
        }
        /* Comentário para testar o Build & Test */
    }
}
