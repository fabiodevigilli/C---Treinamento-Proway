using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoCSharpBasicoWindowsFormsOrientacaoObjetos2
{
    class Triangulo
    {
        // Aprendendo sobre construtor
        // setando como private o set nas PROPRIEDADES, poderemos apenas adicionar valores, via construtor criado abaixo
        public int Lado1 { get; private set; }
        public int Lado2 { get; private set; }
        public int Lado3 { get; private set; }


        // O construtor é criado, para ser utilizado, sempre que a classe é instanciada
        public Triangulo(int l1, int l2, int l3)
        {
            Lado1 = l1;
            Lado2 = l2;
            Lado3 = l3;
            VerificarIntegridadeTriangulo();
        }


        public bool VerificarIntegridadeTriangulo()
        {
            return !(Lado1 > Lado2 + Lado3 || Lado2 > Lado1 + Lado3 || Lado3 > Lado1 + Lado2);            
        }
    }
}
