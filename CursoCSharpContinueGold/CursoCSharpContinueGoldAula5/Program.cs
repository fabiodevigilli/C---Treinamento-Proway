using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoCSharpContinueGoldAula5
{
    class Program
    {
        static void Main(string[] args)
        {
            //AULA 05.01 - DELEGATES E EVENTOS
            // Aqui instanciamos o objeto delegate
            // dentro do construtor do delegate vai pedir um ponteiro para um método que neste caso é static
            // Saudar s = new Saudar(DizerTchau);
            // s("Pedro");
            // Podemos criar também os multicasts delegates que possuem diversas referencias a metodos diferentes
            //Saudar a, b, c, d;
            //a = DizerOi;
            //b = DizerTchau;
            //c = a + b;
            //d = c - a;
            //a("A");
            //b("B");
            //c("C");
            //d("D");


            //AULA 05.02 - LÂMBDA EXPRESSIONS, MÉTODOS ANÔNINOS E DELEGATES
            // 1º exemplo com delegate
            CriarMensagem c = Saudar;
            c("C");
            //2º exemplo com métodos anônimos
            CriarMensagem d = delegate (string nome)
            {
                Console.WriteLine("Olá" + nome);
            };
            // no 2º exemplo, só é executado, qdo invocado, conforme abaixo:
            d("D");
            //3º exemplo com expressão lâmbda
            CriarMensagem e = (nome)=>
            {
                Console.WriteLine("Olá" + nome);
            };
            e("E");

            List<Produto> produtos = Produto.GetProdutos();
            // produtosCaros com delegate
            List<Produto> produtosCaros = produtos.Where(FiltrarProdutosCaros).ToList();
            // produtosCaros com lambda
            List<Produto> produtosCarosLambda = produtos.Where(x => x.Preco > 25).ToList();

        }
        //AULA 05.01 - DELEGATES E EVENTOS
        static void DizerOi(string nome)
        {
            Console.WriteLine("Oi" + nome);
        }

        static void DizerTchau(string nome)
        {
            Console.WriteLine("Tchau" + nome);
        }

        //AULA 05.02 - LÂMBDA EXPRESSIONS, MÉTODOS ANÔNINOS E DELEGATES
        static void Saudar(string nome)
        {
            Console.WriteLine("Olá" + nome);
        }

        static bool FiltrarProdutosCaros(Produto p)
        {
            return p.Preco > 25;
        }

    }
    //AULA 05.01 - DELEGATES E EVENTOS
    // delegate aceita um ponteiro para uma função
    public delegate void Saudar(string nome);

    //AULA 05.02 - LÂMBDA EXPRESSIONS, MÉTODOS ANÔNINOS E DELEGATES
    public delegate void CriarMensagem(string nome);


    public class Produto
    {
        public static List<Produto> GetProdutos()
        {
            return new List<Produto>()
            { // AQUI CRIAMOS UMA LISTAGEM
                new Produto()
                {
                    Id = 1, Descricao = "A",
                    Preco = 20, QtdeEstoque = 40
                },
                new Produto()
                {
                    Id = 2, Descricao = "B",
                    Preco = 30, QtdeEstoque = 40
                },
                new Produto()
                {
                    Id = 3, Descricao = "C",
                    Preco = 40, QtdeEstoque = 40
                }
            };
        }

        public int Id { get; set; }
        public string Descricao { get; set; }
        public double Preco { get; set; }
        public double QtdeEstoque { get; set; }
    }
}
