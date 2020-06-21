namespace Calculadora
{
    public class CalculadoraSimples
    {
        /* Método para adicionar dois números*/
        public int Adicionar(int num1, int num2)
        {
            return num1 + num2;
        }

        /* Método para subtrair dois números*/
        public int Subtrair(int num1, int num2)
        {
            return num1 - num2;
        }

        /* Método para multiplicar dois números*/
        public int Multiplicar(int num1, int num2)
        {
            // Para fins de demo (bug) => deveria ser return num1 * num2;
            return num1 + num2;
        }

        /* Método para subtrair dois números*/
        public int Dividir(int num1, int num2)
        {
            return num1 / num2;
        }
    }
}
