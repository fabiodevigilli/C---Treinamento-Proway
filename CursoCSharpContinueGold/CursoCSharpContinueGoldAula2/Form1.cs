using CursoCSharpContinueGoldAula2.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CursoCSharpContinueGoldAula2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // AULA 2.01 - TRATAMENTO DE EXCEÇÕES
            //try
            //{
            //    int i = int.Parse(textBox1.Text);
            //    MessageBox.Show((i + 100).ToString());
            //}
            //catch (ArgumentNullException ex)
            //{
            //    MessageBox.Show("Favor, informe um valor");
            //}
            //catch (FormatException ex)
            //{
            //    MessageBox.Show("Favor, informe um número");
            //}
            //catch (OverflowException ex)
            //{
            //    MessageBox.Show(string.Format("Favor, digite um número entre {0} e {1}", int.MinValue, int.MaxValue));
            //}

            // AULA 2.02 - MÉTODOS DE EXTENSÃO
            Produto p = new Produto();
            p.Preco = textBox1.Text.ToDouble();

            // AULA 2.03 - CULTURA
            string s = "10.4";
            // double d = double.Parse(s, new CultureInfo("pt-br")); // conversão parametrizada.
            double d = double.Parse(textBox2.Text.Replace(".",",")); // utilizando a configuração realizada em "Program.cs"
            MessageBox.Show(d.ToString("C2")); // currency, para a cultura atual, com 2 casas decimais, utilizando a configuração realizada em "Program.cs"

            // AULA 2.04 - ENUMERADORES E ATRIBUTO FLAGS,
            Produto2 p2 = new Produto2();
            p2.UnidadeMedida = UnidadeMedida.Cx;
            p2.UnidadeMedida = (UnidadeMedida)3; // utilizando a propriedade selected index de uma combo box, pegando a posição, ex:3
            int a = (int)p2.UnidadeMedida;

            Veiculo v = new Veiculo();
            v.Acessorios = (AcessoriosVeiculo)3;
            v.Acessorios = AcessoriosVeiculo.Airbag | AcessoriosVeiculo.ComputadorBordo; // aqui utilizamos o operador "|" (ou) com 1 pipe, para adicionar os dois acessorios.

            if (v.Acessorios.HasFlag(AcessoriosVeiculo.Airbag))
            {
                // faz alguma coisa
            }
        }
    }

    // AULA 2.02 - MÉTODOS DE EXTENSÃO
    public class Produto
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public double Preco { get; set; }
    }

    public class ProdutoBLL
    {
        public void Validar(Produto p)
        {
            if (p.Preco == 0)
            {
                // faz alguma coisa
            }
        }
    }

    // AULA 2.04 - ENUMERADORES E ATRIBUTO FLAGS

    class Produto2
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public double Preco { get; set; }
        public int Quantidade { get; set; }
        public UnidadeMedida UnidadeMedida { get; set; }
    }

    // enum sem flags
    enum UnidadeMedida // : int // o int é implicitaemte configurado, não é necessário declarar, podendo usar short também
    {
        L, Kg, M, Cx, Un
    }

    class Veiculo
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int CV { get; set; }
        public int Km { get; set; }
        public AcessoriosVeiculo Acessorios { get; set; }
    }

    //para marcar mais de um enumerador em um objeto, é preciso marcar o atributo Flags (DataAnotation)
    // necessitamos que seja separado o valor das constantes com valores ao quadrado.
    [Flags]
    enum AcessoriosVeiculo
    {
        Airbag = 1,
        ComputadorBordo = 2,
        ABS = 4,
        Tracao4Rodas = 8
    }
}
