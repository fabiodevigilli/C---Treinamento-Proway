using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Teste;

namespace CursoCSharpContinueGoldAula3
{
    class Program
    {
        static void Main(string[] args)
        {
            // AULA 3.01 - CONVERSORES IMPLÍCITOS E EXPLÍCITOS
            // implicit
            //Dolar d = 100.40;
            //double valor = d;

            // explicit
            //Dolar d = (Dolar)100.40;
            //double valor = (double)d;

            // AULA 3.02 - SOBRECARGA DE OPERADOR
            DateTime agora = DateTime.Now;
            DateTime nascimento = new DateTime(1988, 4, 19);
            TimeSpan ts = agora - nascimento;

            DolarSobrecarga ds1 = 100.40;
            DolarSobrecarga ds2 = 150.50;
            DolarSobrecarga ds3 = ds1 + ds2;
            DolarSobrecarga ds4 = ds3 - 100;

            // AULA 3.03 - DLL's e NameSpaces - vide novo namespace ao final deste namespace CursoCSharpContinueGoldAula3
            ABC abc = new ABC();
            abc.Nome = "Teste";

            // quando há uma chamada ambígua, ou seja, com dois namesspaces iguais devemos fazer o seguinte, para chamar o desejado
            // supondo que tivessemos:
            // using System.Windows.Forms,
            // using System.Threading,
            // em ambos temos o objeto Timer.
            // para acessar a instância desejada no código, fazemos:
            // System.Windows.Forms.Timer t = new System.Windows.Forms.Timer()
            // System.Threading.Timer t = new System.Threading.Timer()
            // ou ainda
            // using thr = System.Threading
            // thr.Timer tmr = new thr.Timer()

            // para acessarmos uma dll de outro projeto, da mesma solução
            // entre na references do projetos, onde deseja chamar uma classe de outro projeto,
            // clique com o botão direito, Add Reference, solution, escolha o namespace desejado, ok.
            // pesquisar ConfigurationManager msdn

            // AULA 3.04 - Interoperabilidade
            // este código seria para um windows forms
            // colocar esta chamada, dentro do código de um button
            FormInterop.MessageBoxTimeout(IntPtr.Zero, "a", "b", 1, 0, 4000);

        }

        // AULA 3.01 - CONVERSORES IMPLÍCITOS E EXPLÍCITOS
        public void Conversores()
        {
            // Tipos inteiros, possuem conversor implícito do int(valor padrão), para os demais.
            int i = 10;
            short s = 10;
            long l = 10;
            byte b = 10;
            // Pontos flutuantes não possuem conversores implícitos.
            double d = 10.4;
            //float f = 10.4;
            //decimal dd = 10.4;
            // pontos flutuantes precisam de conversores explícitos que necessitam de cast
            double d1 = 10.4;
            float f1 = (float)10.4; // ou
            float f2 = 10.4f;
            decimal dd1 = (decimal)10.4; // ou
            decimal dd2 = 10.4m;
        }

        // AULA 3.04 - Interoperabilidade
        // Para chamar um código que está em outra DLL, que pode estar em outra linguagem
        // Este código seria para um windows forms
        // Seria uma messagebox customizada
        public static class FormInterop
        {
            // ver pinvoke.net - site sobre plataform invoke (listagem de várias funções do windows que podemos invocar)
            [DllImport("user32.dll", SetLastError = true)]
            [return: MarshalAs(UnmanagedType.U4)]
            public static extern uint MessageBoxTimeout(IntPtr hwnd,
            [MarshalAs(UnmanagedType.LPTStr)]string text,
            [MarshalAs(UnmanagedType.LPTStr)]string title,
            [MarshalAs(UnmanagedType.U4)]uint type,
            Int16 wLanguageID,
            Int32 miliseconds);
        }
        
    }

    // AULA 3.01 - CONVERSORES IMPLÍCITOS E EXPLÍCITOS
    class Dolar
    {
        public double Valor { get; set; }

        //public static implicit operator double(Dolar dolar)
        //{
        //    return dolar.Valor;
        //}

        //public static implicit operator Dolar(double valor)
        //{
        //    return new Dolar() { Valor = valor };
        //}

        public static explicit operator double(Dolar dolar)
        {
            return dolar.Valor;
        }

        public static explicit operator Dolar(double valor)
        {
            return new Dolar() { Valor = valor };
        }
    }

    // AULA 3.02 - SOBRECARGA DE OPERADOR
    class DolarSobrecarga
    {
        public double Valor { get; set; }

        public static DolarSobrecarga operator+(DolarSobrecarga ds1, DolarSobrecarga ds2)
        {
            return new DolarSobrecarga()
            {
                Valor = ds1.Valor + ds2.Valor
            };
        }

        public static DolarSobrecarga operator-(DolarSobrecarga ds3, double valor)
        {
            return new DolarSobrecarga()
            {
                Valor = ds3.Valor - valor
            };
        }

        public static implicit operator double(DolarSobrecarga dolar)
        {
            return dolar.Valor;
        }

        public static implicit operator DolarSobrecarga(double valor)
        {
            return new DolarSobrecarga() { Valor = valor };
        }
    }
}

// AULA 3.03 - DLL's e NameSpaces
// Explicações sobre a diferença entre solução e projetos
// Class Library, é uma DLL e não pode ser executada, existe para ter classes, componentes, eventos, propriedades, construtores, código em geral,
// que será chamado pelos executáveis ou pela aplicação web
// É possível ter dois namespaces em um mesma Class, porém, as classes de uma só poderão ser acessadas pela outra, caso seja feita a importação.
namespace Teste
{
    public class ABC
    {
        public string Nome { get; set; }
    }
}
