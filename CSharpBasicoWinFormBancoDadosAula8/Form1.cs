using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpBasicoWinFormBancoDadosAula8
{
    public partial class Form1 : Form
    {
        // Para criar a conexão com banco de dados, devemos aprender(ADO.Net):

        // DbConnection
        // Acessamos View, Server Explorer, DataConnections (botão direito), Add Connection, Neste caso usamos Microsoft Sql Server Database File, 
        // Database file name usamos TesteADO, OK, Sim.
        // Botão direito na base criada, new query, fizemos um create table CLIENTES. Após escrita a query,
        // Selecione a query, botão direto e Execute.

        // DbCommand
        // Dentro do DbCommand, temos:
        // - CommandText = possui a query propriamente dita que desejamos executar, ex: "INSERT INTO CLIENTES (NOME, CPF) VALUES(@NOME, @CPF)"
        // - Parameters = possui os dados propriamente ditos que quero jogar para base de dados

        // Os Métodos do DbCommand, são:
        // - ExecuteNonQuery (Update e Delete), ExecuteScalar (Create), ExecuteReader (Get);
        // - Execute NonQuery, é usado para Create, Update e Delete
        // - ExecuteScalar, é usado para Create
        // - ExecuteReader, é utilizado para consulta no banco de dados "Get"

        // Para cada banco de dados(MySql, Oracle, etc), verificar o tipo de Connection pertinente
        public Form1()
        {
            InitializeComponent();

            // Para obtermos a connection string abaixo, clique com o botão direito na base de dados TesteAdo,
            // Propriedades, Connection String, copiamos o campo do lado direito e colamos abaixo no sqlconnection
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            Cliente c = new Cliente();
            c.Nome = txtNome.Text;
            c.CPF = txtCPF.Text;
            c.Email = txtEmail.Text;
            c.Telefone = txtTelefone.Text;
            ClienteADO ado = new ClienteADO();
            string mensagem = ado.Cadastrar(c);
            MessageBox.Show(mensagem);
            AtualizarGrid();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            Cliente c = new Cliente();
            try
            {
                c.ID = Convert.ToInt32(txtID.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Favor informe um ID válido");
                return;
            }
            c.Nome = txtNome.Text;
            c.CPF = txtCPF.Text;
            c.Email = txtEmail.Text;
            c.Telefone = txtTelefone.Text;
            ClienteADO ado = new ClienteADO();
            string mensagem = ado.Editar(c);
            MessageBox.Show(mensagem);
            AtualizarGrid();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            ClienteADO ado = new ClienteADO();
            ado.Excluir(Convert.ToInt32(txtID.Text));
            AtualizarGrid();
        }

        private void AtualizarGrid()
        {
            this.dataGridView1.DataSource = new ClienteADO().LerClientes();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AtualizarGrid();
        }
    }
}
