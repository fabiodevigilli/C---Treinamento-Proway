using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CursoCSharpContinueGoldAula9WinForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // AULA 9.01 - MISCELANEA - ADO.NET AVANÇADO
        private void button1_Click(object sender, EventArgs e)
        {
            // ExecuteNonQuery - insert, *update e *delete
            // ExecuteScalar - insert, dá para retornar o ID
            // ExecuteReader - select(GET)

            //Conexão com banco de dados, usando Fábricas, para objeto abstratos
            // Classe ConfigurationManager
            DbProviderFactory factory = 
            DbProviderFactories.GetFactory("System.Data.SqlClient");
            DbCommand command = factory.CreateCommand();
            DbConnection connection = factory.CreateConnection();
        }        
    }

    // AULA 9.01 - MISCELANEA - ADO.NET AVANÇADO
    public static class ParameterExtensions
    {
        public static void AddWithValue(this DbParameterCollection collection, string parameterName, object parameterVal)
        {
            DbProviderFactory factory =
            DbProviderFactories.GetFactory("System.Data.SqlClient");
            DbParameter parameter = factory.CreateParameter();
            parameter.Value = parameterVal;
            parameter.ParameterName = parameterName;
            collection.Add(parameter);
        }
    }
}
