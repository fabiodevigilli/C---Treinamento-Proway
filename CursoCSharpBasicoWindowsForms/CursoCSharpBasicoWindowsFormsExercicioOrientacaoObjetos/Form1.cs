using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CursoCSharpBasicoWindowsFormsExercicioOrientacaoObjetos
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ContaBancaria contaJoao = new ContaBancaria();
            contaJoao.NConta = "123456";
            contaJoao.Proprietario = "Joao";
            // usamos um bloco try catch, onde todas as operações que podem dar algum tipo de problema, ficam no try
            // se algo der errado, cairá no catch imediatamente, ignorando as demais operações.
            try
            {
                contaJoao.Depositar(1000);
                contaJoao.Sacar(500);
                contaJoao.Sacar(500);
                contaJoao.Sacar(1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            

        }
    }
}
