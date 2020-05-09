using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CursoCSharpContinueGoldAula5WinForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // AULA 5.03 - EVENTOS
            // exemplo 01
            TextBox txt = new TextBox();
            txt.Location = new Point(100, 100);
            txt.Width = 200;
            this.Controls.Add(txt);
            // usando expressões lambdas
            txt.Leave += (obj, e) =>
            {
                txt.TextAlign = HorizontalAlignment.Center;
            };

            //exemplo 02 - usando delegate
            ForeCast f = new ForeCast();
            f.InvernoChegou += F_InvernoChegou;
            f.VeraoChegou += F_VeraoChegou;
            f.TrocarTemperatura(20);
            f.TrocarTemperatura(5);
            f.TrocarTemperatura(35);        
        }

        // AULA 5.03 - EVENTOS
        private void F_VeraoChegou(int temperatura)
        {
            MessageBox.Show("Verão chegou e está" + temperatura + "º");
        }

        private void F_InvernoChegou(int temperatura)
        {
            MessageBox.Show("Inverno chegou e está" + temperatura + "º");
        }

        // AULA 5.04 - DELEGATE ASSÍNCRONO
        private void button1_Click(object sender, EventArgs e)
        {
            FileManager manager = new FileManager(new FileStream("teste10.txt", FileMode.Create));
            WriteFile write = new WriteFile(manager.WriteContent);
            write.BeginInvoke("Olá, tudo bem?", manager.EndWrite, null);
            MessageBox.Show("Test");
        }
    }
    // AULA 5.03 - EVENTOS
    public class ForeCast
    {
        public int Temperatura { get; private set; }

        public event TrocarEstacao VeraoChegou;
        public event TrocarEstacao InvernoChegou;

        public void TrocarTemperatura(int temperatura)
        {
            this.Temperatura = temperatura;
            if (temperatura > 32 && VeraoChegou != null)
            {
                VeraoChegou(temperatura);
            }
            else if (temperatura < 14 && InvernoChegou != null)
            {
                InvernoChegou(temperatura);
            }
        }
    }
    public delegate void TrocarEstacao(int temperatura);


    // AULA 5.04 - DELEGATE ASSÍNCRONO
    public delegate void WriteFile(string file);

    public class FileManager
    {
        private FileStream fs = null;
        public FileManager(FileStream file)
        {
            this.fs = file;
        }

        public void WriteContent(string content)
        {
            if (fs != null)
            {
                byte[] dados = Encoding.UTF8.GetBytes(content);
                fs.Write(dados, 0, dados.Length);
            }
        }

        public void EndWrite(IAsyncResult result)
        {
            try
            {
                if (fs.Length == 0)
                {
                    throw new Exception("Erro na escrita");
                }
            }
            finally
            {
                fs.Dispose();
            }            
        }
    }
}
