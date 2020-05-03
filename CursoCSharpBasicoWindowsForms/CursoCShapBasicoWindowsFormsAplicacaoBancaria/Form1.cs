using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CursoCShapBasicoWindowsFormsAplicacaoBancaria
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        double saldo = 0;

        private void btnSacar_Click(object sender, EventArgs e)
        {
            double saldoDigitado = Convert.ToDouble(txtQuantia.Text);
            saldo = saldo - saldoDigitado;
            lblSaldo.Text = saldo.ToString("C2");
        }

        private void btnDepositar_Click(object sender, EventArgs e)
        {
            double saldoDigitado = Convert.ToDouble(txtQuantia.Text);
            saldo = saldo + saldoDigitado;
            lblSaldo.Text = saldo.ToString("C2");
        }
    }
}
