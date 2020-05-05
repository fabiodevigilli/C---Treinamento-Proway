using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CursoCSharpContinueGoldAula2
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // AULA 2.03 - CULTURA
            Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-br"); // cultura utilizada pela thread atual
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-br"); // cultura da user interface
            // final da aula 2.03

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
