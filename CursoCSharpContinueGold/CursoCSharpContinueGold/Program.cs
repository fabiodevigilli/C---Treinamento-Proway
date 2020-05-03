using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoCSharpContinueGold
{
    class Program
    {
        static void Main(string[] args)
        {
            // ALULA 1.3
            X x = new X();
            x.Valor = 1;
            Y y = new Y();
            y.Valor = 1;
            Testar1(x);
            Testar2(y);

            // AULA 1.4
            
            if (CommonValidations.IsCPF("12345678901"))
            { }

            // cada vez que vc instancia um novo objeto, zeramos as propriedades
            Jogo j = new Jogo();
            j.Teste = "Teste123";
            // entretanto, as que são estáticas, se mantém para sempre em nosso programa
            Jogo.Vidas = 10;
            // cada vez que alteramos uma propriedade estática, ela se aplica ao programa inteiro.

        }
        
        public void TiposPrimitivos()
        {
            // LEITURA DE MATERIAL:
            // pinvoke.net



            // AULA 1.01 - TIPOS PRIMITIVOS
            // ** TIPOS NUMÉRICOS: byte(1), short(2), int(4), long(8 bytes) - essa maneira de escrever que usamos é um alias.
            // o Struct destes alias, são: Byte, Int16, Int32, Int64
            // esses tipos vão de negativo a positivo, exceto byte, que é só positivo.
            // não há checagem de estouro para numeros inteiros no CSharp
            // para fazer uma checagem, é necessário utilizar o checked
            int numero = int.MaxValue;
            checked
            {
                numero = numero + 100;
            }
            // para que o programa inteiro faça a checagem de estouro para numeros inteiros,
            // abrir o solution explorer, com o botão direito na solução, propriedades,
            // build, advanced, selecionar "check for arithmetic overflow/underflow", ok.

            // temos ainda como ponto flutuante, o float(4), double(8), decimal(16 bytes) - essa maneira de escrever que usamos é um alias.
            // o Struct destes alias, são: Single, Double, Decimal

            // AULA 1.02 - TIPOS PRIMITIVOS
            // temos também o sbyte, ushort, uint, ulong - essa maneira de escrever que usamos é um alias.
            // o Struct destes alias, são: SByte, UInt16, UInt32, UInt64
            // este "u" no inicio de uint, por ex, significa unsigned, ou seja, sem sinal.
            // Portanto, vai o dobro de numeros para positivo, porém, não vai para o negativo.
            // O "s" na frente do sbyte, significa signed, ou seja, vai de negativo para positivo.

            // o float requer que declaremos f após o número, que significa float
            float f = 10.4f;

            // o decimal requer que declaremos m após o número, que significa monetary
            decimal d = 10.4m;

            // se declaramos uma variável normal, sem a letra após o numero, ela será implicitamente um double.
            double dd = 10.4;

            // temos também char, bool e string           
        }

        public void StructClass()
        {
            // AULA 1.03 - STRUCT E CLASS

            // Struct - passagem por cópia (até 16 bytes)
            // ideal até 16 bytes
            // no struct, se temos uma inicialização externa de uma propriedade com valor 1 e dentro de um método tentarmos alterar para 99, 
            // o valor de memória não será alterado, ou seja, irá permanecer 1.
            // exemplo de struct é o DateTime, bem como o char também, embora o vetor de char é uma string, que é uma class.

            // Class - passagem por referência
            // na class, temos a situação oposta do struct, o valor em memória seria alterado para 99. 
            // string é uma class
        }

        public static void Testar1(X x)
        {
            x.Valor = 99;
        }

        public static void Testar2(Y y)
        {
            y.Valor = 99;
        }
    }

    class X
    {
        public int Valor { get; set; }
    }

    struct Y
    {
        public int Valor { get; set; }
    }


    // AULA 1.4
    // propriedades, metodos e construtores estáticos
    // em um método estático, não conseguimos acessar o "this", vc só tem acesso ao que é estático, ex: Vidas.
    // se o método NÃO for estatico, também conseguimos acessar aquilo que é estático , ex: Vidas.
    class CommonValidations
    {
        // como só temos um método que trabalha com CPF, podemos utilizar este como estático
        public static bool IsCPF(string cpf)
        {
            // aqui utilizamos uma propriedade estática, porque não precisamos acessar uma instância de string,
            // para acessar o método IsNullorWhiteSpace
            if (string.IsNullOrWhiteSpace(cpf))
            {
                return false;
            }
            // o método replace não é estático, ou seja, só temos acesso pela instância válida não nula do cpf
            cpf = cpf.Replace(".", "").Replace("-", "");
            return cpf.Length == 11;
        }
    }

    class Jogo
    {
        // construtor estático
        public Jogo()
        {
                
        }
        static Jogo() // é executado uma única vez no programa, antes de qual quer construtor e serve para inicialização de variável estática
        {
            Vidas = 10;
        }

        // a propriedade normal, temos acesso pela instância
        public string Teste { get; set; }
        public static int Vidas { get; set; }
    }
}
