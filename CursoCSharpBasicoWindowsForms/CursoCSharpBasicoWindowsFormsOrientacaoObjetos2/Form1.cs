using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CursoCSharpBasicoWindowsFormsOrientacaoObjetos2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            Triangulo t = new Triangulo(10, 20, 40); // instanciando via construtor ciado na classe Triangulo
            Pessoa p = new Pessoa();
            PessoaFisica pf = new PessoaFisica(1, "Fulano", DateTime.Parse("2020-01-01"), "001.001.001-01", "123");
            PessoaJuridica pj = new PessoaJuridica();

            Avatar a = new Avatar();
            a.Nome = "Pedro";
            a.Level = 99;
            a.AddArma(new AK47());
            a.AddArma(new Katana());
            // neste exemplo o objeto ARMA que é passado como dado de entrada, é encapsulado como um dos objetos da classe filho
            double dano = a.LerArma()[0].CalcularDano(); // o método calcular dano chamado, é aquele da AK47 ou da Katana, e não da classe Arma, ou seja, ele morfa conforme o tipo de arma apresentada no LerArma
        }
    }

    class Pessoa
    {
        // AULA DE HERANÇA

        public Pessoa()
        {

        }

        public Pessoa(int id, string nome)
        {
            ID = id;
            Nome = nome;
        }

        public int ID { get; set; }
        public string Nome { get; set; }
    }

    class PessoaFisica : Pessoa
    {
        // AULA DE HERANÇA

        public PessoaFisica(int id, string nome, DateTime nascimento, string cpf, string rg) : base(id, nome)
        {
            DataNascimento = nascimento;
            CPF = cpf;
            RG = rg;
        }

        public DateTime DataNascimento { get; set; }
        public string CPF { get; set; }
        public string RG { get; set; }
    }

    class PessoaJuridica : Pessoa
    {
        // AULA DE HERANÇA

        public string NomeFantasia { get; set; }
        public string CNPJ { get; set; }
        public string InscricaoEstadual { get; set; }
    }

    // virtual, abstract, override
    // EntityFramework, WEB MVC == bibliotecas da microsoft


    // uma classe abstrata, não pode ser instanciada diretamente
    abstract class Poligono
    {
        public int[] Lados { get; set; }
        public int CalcularPerimetro()
        {
            int perimetro = 0;
            for (int i = 0; i < Lados.Length; i++)
            {
                perimetro = perimetro + Lados[i];
            }
            return perimetro;

            // ou
            // return Lados.Sum();
        }

        // abstract, utilizada, quando temos uma função que conseguimos determinar um corpo para ela
        // para criarmos um método abstrato, a classe neste caso, também deverá ser abstrata
        public abstract double CalcularArea();
    }

    class TrianguloNovo : Poligono
    {
        public int Altura { get; private set; }

        // uma classe que herda de uma outra classe abstrata, DEVE sobrescrever o método abstrato da classe pai
        public override double CalcularArea()
        {
            return (Lados[0] * Altura) / 2;
        }
    }

    class Brasileiro
    {
        // VIRTUAL - possui implementação, porém, pode ser sobrescrito pela classe filho

        public string Nome { get; set; }
        public virtual double Trabalhar() // Para criarmos uma nova implamentação de uma classe pai, devemos utilizar o virtual no método da classe pai
        {
            return 2000;
        }
    }

    class Politico : Brasileiro
    {
        public override double Trabalhar()
        {
            return base.Trabalhar() * 20; // Estamos vinculando a implementação da classe pai, com a implementação do método filho
        }
    }

    // AULA DE POLIMORFISMO

    abstract class Arma
    {
        public string Nome { get; set; }
        public double Peso { get; set; }
        public QtdMaos QtdMaos { get; set; }

        public abstract double CalcularDano();
        public abstract double CalcularVelocidade();
    }

    class AK47 : Arma
    {
        public override double CalcularDano()
        {
            return 40;
        }
        public override double CalcularVelocidade()
        {
            return 0.33;
        }
    }

    class Katana : Arma
    {
        public override double CalcularDano()
        {
            return 80;
        }
        public override double CalcularVelocidade()
        {
            return 0.7;
        }
    }

    class Avatar
    {
        public string Nome { get; set; }
        public int Level { get; set; }
        private List<Arma> armas = new List<Arma>();

        public void AddArma(Arma arma)
        {
            if (armas.Count > 2)
            {
                throw new Exception("Não é possível adicionar nova arma");
            }
            armas.Add(arma);
            // exemplo de polimorfismo 
        }

        public List<Arma> LerArma()
        {
            return armas;
        }
    }

    enum QtdMaos
    { 
        Uma, Duas
    }
}
