using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CursoCSharpBasicoWindowsFormsOrientacaoObjeto
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            double soma = Somar(10.4, 99);
            Imprimir(soma.ToString("N2"));

           
        }

        // Protetor de acesso
        // Retorno
        // Nome do método, sempre no infinitivo, iniciando com letra maiúscula
        // Parâmetros
        public double Somar(double numero1, double numero2)
        {
            return numero1 + numero2;
        }

        public void Imprimir(string mensagem)
        {
            MessageBox.Show(mensagem, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public void AulaEncapsulamento()
        {
            ContaBancaria cc = new ContaBancaria();

            // cc.proprietario = "Jonas";  // Para a situação 01 na Classe ContaBancaria

            // cc.SetProprietario("Jonas");  // Para a situação 02 na Classe ContaBancaria
            // MessageBox.Show(cc.GetProprietario()); // Para a situação 02 na Classe ContaBancaria

            // cc.Proprietario = "Pedro"; // Para a situação 03 na Classe ContaBancaria
            // MessageBox.Show(cc.Proprietario); // Para a situação 03 na Classe ContaBancaria

            cc.Proprietario = "Fulano";  // Para a situação 04 na Classe ContaBancaria
            MessageBox.Show(cc.Proprietario); // Para a situação 04 na Classe ContaBancaria
        }
    }
}
