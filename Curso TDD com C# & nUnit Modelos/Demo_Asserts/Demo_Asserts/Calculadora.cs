using System;

namespace Demo_Asserts
{
    public class Calculadora
    {
        /*Método para somar inteiros*/
        public int SomarNumerosInteiros(int num1, int num2)
        {
            return num1 + num2;
        }

        /*Método para somar decimais*/
        public double SomarNumerosDecimais(double num1, double num2)
        {
            return num1 + num2;
        }

        /*Método para dividir*/
        public int Dividir(int num, int por)
        {
            if (num > 100)
            {
                throw new ArgumentOutOfRangeException("por"); // propósitos para  a demo
            }

            return num / por;
        }
    }
}
