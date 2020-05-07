using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CursoCSharpContinueGoldAula4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // AULA 4.04 - HERANÇA EM COMPONENTES GRÁFICOS - CONTINUAÇÃO
            // estudar: DevExpress, Telerik
            // KeyPreview é um evento, diz que para cada vez que digitamos uma tecla, será procurado na árvore de controle filhos
            // se há um algum componente com evento keypress registrado, então executa este evento key press
            // neste exemplo, no form, selecione f4 na CustomTextBox, altere o TipoTexto para numero e rode o programa
            this.KeyPreview = true;
        }

        // AULA 4.05 - HERANÇA EM MERCADO DE TRABALHO

        private void button1_Click(object sender, EventArgs e)
        {
            // AULA 4.04 - HERANÇA EM COMPONENTES GRÁFICOS - CONTINUAÇÃO
            double d = customTextBox1;
        }
    }
    // AULA 4.01 - HERANÇA
    public class ContaBancaria
    {
        // private, só pode ser acessado por esta classe
        // protected, pode ser acessado por esta classe e seus filhos
        public double Saldo { get; protected set; }

        // método virtual possui implementação e essa implementação PODE ser sobrescrita, pelas classes filhas  
        // a diferença entre virtual e abstract é que o virtual possui implementação e o abstract não, pois o abstract possui apenas a descrição do método,
        // sendo as classes que herdam são obrigadas a implementar o método.
        public virtual void Sacar(double quantia)
        {
            if (quantia < 0)
            {
                throw new Exception("Quantia insuficiente");
            }
            Saldo -= quantia;
        }
    }
    public class ContaGold : ContaBancaria
    {
        public double Limite { get; private set; }

        public override void Sacar(double quantia)
        {
            if (quantia > Saldo)
            {
                Limite = quantia - Saldo;
            }
            base.Sacar(quantia);
        }
    }
    public class ContaUniversitaria : ContaBancaria
    {
        public override void Sacar(double quantia)
        {
            if (quantia > Saldo)
            {
                throw new Exception("Quantia insuficiente.");
            }
            base.Sacar(quantia);
        }
    }

    // AULA 4.02 - CLASSES ABSTRATAS E INTERFACES
    // A interface serve para firmar um possível e futuro contrato com alguma classe,
    // a classe implementa a interface a classe passsa a ser um objeto da interface, 
    // a classe deverá implementar todos os metodos e propriedades descritos na interface,
    // A interface, aceita apenas a marcação das classes, ou seja, sem o código interno das classes.
    // a interface não pode ser instanciada, apenas herdada, não possui protetor de acesso.
    public interface IObjetoVoador
    {
        void Voar(int x, int y, int z, int speed);
    }

    public class Aviao : IObjetoVoador
    {
        public void Voar(int x, int y, int z, int speed)
        {
            throw new NotImplementedException();
        }
    }
    public class Falcao : IObjetoVoador
    {
        public void Voar(int x, int y, int z, int speed)
        {
            throw new NotImplementedException();
        }
    }

    // toda a classe abstrata, não pode ser instanciada,
    // e não é obrigatorio ter um método abstrato nela, mas se o método for abstrato,
    // aí sim, a classe deverá ser obrigatoriomente abstrata.
    // o método abstrato necessita que alguém o herde, para implementação.
    public abstract class ObjetoVoadorAbstrato
    {
        public abstract void Voar(int x, int y, int z, int speed);
        public void AlterarAceleracao()
        { 
        }
        public int ID { get; set; }
        public string Peso { get; set; }
    }

    public class DiscoVoador : ObjetoVoadorAbstrato
    {
        public override void Voar(int x, int y, int z, int speed)
        {
            throw new NotImplementedException();
        }
    }

    // AULA 4.03 - HERANÇA EM COMPONENTES GRÁFICOS
    // AULA 4.04 - HERANÇA EM COMPONENTES GRÁFICOS - CONTINUAÇÃO
    public class CustomTextBox : TextBox
    {
        public TipoTexto TipoTexto { get; set; }
        public CustomTextBox()
        {
            this.Leave += CustomTextBox_Leave;
            this.KeyPress += CustomTextBox_KeyPress;
        }

        void CustomTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            //e.Handled = true; - não quero que registre o evento que acabou de aconteceu, ignora o que for digitado
            if (TipoTexto == TipoTexto.Numero)
            {
                e.Handled = !char.IsNumber(e.KeyChar) && e.KeyChar != ',' && e.KeyChar != '.' && e.KeyChar != '\b'; // \b corresponde ao backspace
            }
        }

        public static implicit operator double(CustomTextBox txt)
        {
            return ConvertDouble(txt.Text);
        }

        void CustomTextBox_Leave(object sender, EventArgs e)
        {
            if (TipoTexto == TipoTexto.Dinheiro)
            {
                this.Text = ConvertDouble(this.Text).ToString("C2");
                this.TextAlign = HorizontalAlignment.Right;
            }
            else if (TipoTexto == TipoTexto.Numero)
            {
                this.Text = ConvertDouble(this.Text).ToString("N2");
                this.TextAlign = HorizontalAlignment.Right;
            }
        }

        private static double ConvertDouble(string dado)
        {
            double temp = 0;
            double.TryParse(dado, out temp);
            return temp;
        }
    }

    public enum TipoTexto
    {
        Dinheiro, Numero, Texto
    }


    // AULA 4.05 - HERANÇA EM MERCADO DE TRABALHO
    // Design Patterns
    // Arquitetura em 3 camadas
    public class Entity
    {
        public int Id { get; set; }
        public int IdUsuarioLastAccess { get; set; }
        public int IdUsuarioCreated { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime LastAccessTime { get; set; }
    }

    public class Pessoa : Entity
    {
        public string Nome { get; set; }
        public string Estado { get; set; }
        public string Rua { get; set; }
        public string CEP { get; set; }
    }

    public class PessoaFisica : Pessoa
    {
        public string CPF { get; set; }
        public string RG { get; set; }
    }

    public class PessoaJuridica : Pessoa
    {
        public string NomeFantasia { get; set; }
        public string CNPJ { get; set; }
    }

    public class Representante : PessoaFisica
    {
        public int ContatoId { get; set; }
    }

    interface IRepresentanteService
    {
        void Inserir(Representante representante);
        void Atualizar(Representante representante);
        void Excluir(Representante representante);
        Representante LerPorId(int id);
        List<Representante> LerTodos();
    }

    interface IEntityCRUD<T> where T:Entity
    {
        void Inserir(T item);
        void Atualizar(T item);
        void Excluir(T item);
        T LerPorId(int id);
        List<T> LerTodos();
    }

    class RepresentanteDAL : IRepresentanteService
    {
        public void Atualizar(Representante representante)
        {
            throw new NotImplementedException();
        }

        public void Excluir(Representante representante)
        {
            throw new NotImplementedException();
        }

        public void Inserir(Representante representante)
        {
            throw new NotImplementedException();
        }

        public Representante LerPorId(int id)
        {
            throw new NotImplementedException();
        }

        public List<Representante> LerTodos()
        {
            throw new NotImplementedException();
        }
    }

    class Fornecedor : PessoaJuridica { }

    class FornecedorDAL : IEntityCRUD<Fornecedor>
    {
        public void Atualizar(Fornecedor item)
        {
            throw new NotImplementedException();
        }

        public void Excluir(Fornecedor item)
        {
            throw new NotImplementedException();
        }

        public void Inserir(Fornecedor item)
        {
            throw new NotImplementedException();
        }

        public Fornecedor LerPorId(int id)
        {
            throw new NotImplementedException();
        }

        public List<Fornecedor> LerTodos()
        {
            throw new NotImplementedException();
        }
    }
}

