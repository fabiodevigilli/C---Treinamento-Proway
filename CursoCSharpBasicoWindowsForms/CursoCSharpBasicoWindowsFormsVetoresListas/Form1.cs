using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CursoCSharpBasicoWindowsFormsVetoresListas
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nome = "Teste1";

            // Vetor é estático
            string[] nomes = {"Teste2", "Teste3", "Teste4"};

            string[] nomes2 = new string[3];
            nomes2[0] = "Teste5";
            nomes2[1] = "Teste6";
            nomes2[2] = "Teste7";

            // Lista é dinâmica
            List<string> nomes3 = new List<string>();
            nomes3.Add("Teste8");
            nomes3.Add("Teste9");
            nomes3.Add("Teste10");
            //nomes3.Add("Teste11");
            //nomes3.Add("Teste12");
            //nomes3.Remove("Teste11");
            //nomes3.Remove("Teste12");

            comboBox1.DataSource = nomes3;
        }
    }
}
