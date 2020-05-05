using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoCSharpContinueGoldAula2.Extensions
{
    public static class StringExtensions
    {
        // AULA 2.02 - MÉTODOS DE EXTENSÃO
        // este this, é uma palavra chave, para indicar que este é um método de extensão
        public static double ToDouble(this string valor)
        {
            double temp;
            double.TryParse(valor, out temp);
            return temp;
        }

        public static int ToInt(this string valor)
        {
            int temp;
            int.TryParse(valor, out temp);
            return temp;
        }
    }
}
