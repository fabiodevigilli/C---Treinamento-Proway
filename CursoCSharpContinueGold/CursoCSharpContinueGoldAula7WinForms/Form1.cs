using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CursoCSharpContinueGoldAula7WinForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // AULA 07.01 - REFLECTION
        private void button1_Click(object sender, EventArgs e)
        {
            // AULA 07.01 - REFLECTION
            // a gridview, do winForms, usa reflection, para gerar as colunas.
            // este system.type é responsável por ler os metadados da sua classe
            // os metadados, são as descrições do que temos em uma classe, ex: Propriedades(privada, publica, double, string, etc.), variaveis, eventos, métodos, construtores.
            // 1º exemplo
            Cliente c = new Cliente();
            Type type = c.GetType(); // GetType, vai retornar um object type, que é o responsável por trabalhar com reflection no C#
            //2º exemplo - usando atalho typeof, para não precisar de instância
            Type type1 = typeof(Cliente);
            foreach (PropertyInfo property in type.GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                MessageBox.Show(($"{property.Name}, { property.PropertyType}").ToString());
            }
        }
        // AULA 07.02 - REFLECTION 2
        // AULA 07.03 - REFLECTION 3
        // AULA 07.04 - REFLECTION 4
        // interface gerada dinamicamente sem arrastar componente
        private void button2_Click(object sender, EventArgs e)
        {
            // TODO ESTE CÓDIGO, DEVERIA ESTAR EM UMA CLASSE FORMBUILDER
            TableLayoutPanel panel = new TableLayoutPanel();
            this.Controls.Add(panel);
            panel.Dock = DockStyle.Fill;
            int count = 0;
            int width = 200;
            foreach (PropertyInfo property in typeof(Produto).GetProperties())
            {
                if (property.Name != "Id")
                {
                    string displayName = property.Name;
                    Titulo titulo = property.GetCustomAttribute<Titulo>();
                    if (titulo != null)
                    {
                        displayName = titulo.Label;
                    }
                    Label lbl = new Label();
                    lbl.Text = displayName;
                    lbl.Name = "lbl" + property.Name;
                    lbl.Size = TextRenderer.MeasureText(lbl.Text, lbl.Font); // renderização automática do tamanho da label automática
                    //checagem do tipo primitivo da propriedade, para usar datepicker, NumericUpDown, etc.
                    if (property.PropertyType == typeof(string))
                    {
                        TextBox txt = new TextBox();
                        txt.Width = width;
                        // aqui vamos adicionar estes dois componentes na árvore de controles do painel
                        panel.Controls.Add(lbl, 0, count); // primeiro vai o control que queremos adicionar, a coluna e a linha
                        panel.Controls.Add(txt, 1, count);
                    }
                    else if (property.PropertyType == typeof(double))
                    {
                        NumericUpDown numeric = new NumericUpDown();
                        numeric.Width = width;
                        panel.Controls.Add(lbl, 0, count);
                        panel.Controls.Add(numeric, 1, count);
                    }
                    else if (property.PropertyType == typeof(DateTime))
                    {
                        DateTimePicker date = new DateTimePicker();
                        date.Format = DateTimePickerFormat.Custom;
                        date.CustomFormat = "dd/MM/yyyy";
                        panel.Controls.Add(lbl, 0, count);
                        panel.Controls.Add(date, 1, count);
                    }
                    count++;
                }                
            }
            Button btn = new Button();
            btn.Text = "Cadastrar";
            btn.Click += Btn_Click;
            panel.Controls.Add(btn, 1, count);
        }

        private void Btn_Click(object sender, EventArgs e)
        {
           
        }
    }
    // AULA 07.01 - REFLECTION
    class Cliente : Object // esta herança é implícita de system.object
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string RG { get; set; }
        public string Telefone { get; set; }
        [Titulo("Data de Nascimento")]
        public string DataNascimento { get; set; }
    }

    // setando a DataAnnotation
    [AttributeUsage(AttributeTargets.Property)]
    class Titulo : Attribute
    {
        public string Label { get; private set; }
        public Titulo(string lbl)
        {
            this.Label = lbl;
        }
    }

    class Produto
    {
        public int Id { get; set; }
        [Titulo("Descrição")]
        public string Descricao { get; set; }
        [Titulo("Preço")]
        public double Preco { get; set; }
        [Titulo("Validade")]
        public DateTime DataValidade { get; set; }
    }
}
