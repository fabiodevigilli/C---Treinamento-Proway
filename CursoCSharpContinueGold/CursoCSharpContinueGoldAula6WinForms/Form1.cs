using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CursoCSharpContinueGoldAula6WinForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();            
        }

        // AULA 06.01 - THREADING
        // Threads são linhas de execução do nosso processo
        // Cada processo possui varias threads
        // Thread não traz performance ao nosso processo
        // o que traz melhoria de performance é o multiparalelismo
        // a thread nos dá responsividade
        private void button1_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(Executar);
            thread.Start();
        }
        public void Executar()
        {
            Thread.Sleep(5000);
            MessageBox.Show("Oi");
        }

        // AULA 06.04 - Threading - 4 -  thread pool
        private void button2_Click(object sender, EventArgs e)
        {
            // a ThreadPool, é uma thread de background, ou seja, quando a thread pai morre, as filhas morrem também
            // o que é o contrário de uma thread foreground, como vimos nas aulas anteriores
            ThreadPool.QueueUserWorkItem(WriteFile, new FileParams()
            {
                FilePath = "teste.txt", Content = FileParams.BuildContent()
            });
        }
        private void WriteFile(object state)
        {
            FileParams fileparams = (FileParams)state;
            FileStream fs = new FileStream(fileparams.Content, FileMode.Create);
            byte[] dados = Encoding.UTF8.GetBytes(fileparams.Content);
            fs.Write(dados, 0, dados.Length);
            fs.Dispose();
        }

        // AULA 06.05 - Async e await - exemplo de criação de arquivo novamente
        private async void button3_Click(object sender, EventArgs e)
        {
            await WriteFile("teste123", "teste.txt");            
        }
        // o await vai indicar que nosso programa, pode sair deste método e voltar a executar coisas do button3_click,
        // que quando terminar, vai retornar para cá.
        public async Task WriteFile(string conteudo, string pathname)
        {
            FileStream fs = new FileStream(pathname, FileMode.Create);
            byte[] dados = Encoding.UTF8.GetBytes(conteudo);
            await fs.WriteAsync(dados, 0, dados.Length);
        }
    }

    class FileParams
    {
        public static string BuildContent()
        {
            // para concatenar mais de 4, usar StringBuilder, pois é mais performático
            StringBuilder sb = new StringBuilder();
            Random rdm = new Random();
            for (int i = 0; i < 10000; i++)
            {
                char caracter =  (char)rdm.Next(64, 90);
                sb.Append(caracter);
            }
            return sb.ToString();
        }

        public string FilePath { get; set; }
        public string Content { get; set; }
    }
}
