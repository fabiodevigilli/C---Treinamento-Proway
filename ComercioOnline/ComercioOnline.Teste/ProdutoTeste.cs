using ComercioOnline.Model;
using dn32.infraestrutura;
using dn32.infraestrutura.Fabrica;
using dn32.infraestrutura.Model;
using System;
using Xunit;

namespace ComercioOnline.Teste
{
    public class ProdutoTeste
    {
        private void InicializeInfraestrutura()
        {
            var parametrosDeInicializacao = new ParametrosDeInicializacao
            {
                EnderecoDeBackupDoBancoDeDados = "c:/ravendb-backup",
                EnderecoDoBancoDeDados = "http://localhost:8080",
                NomeDoAssemblyDaValidacao = "ComercioOnline.Validacao",
                NomeDoAssemblyDoRepositorio = "ComercioOnline.Teste",
                NomeDoAssemblyDoServico = "ComercioOnline.Teste",
                NomeDoBancoDeDados = "ComercioOnline"
            };

            Inicializar.Inicialize(parametrosDeInicializacao);
        }

        [Fact]
        public void CadastroTeste()
        {
            InicializeInfraestrutura();

            var produto = new Produto
            {
                Nome = "Computador com impressora",
                Valor = 1285.58m,
                CodigoDeBarras = "484622648488"
            };

            var servico = FabricaDeServico.Crie<Produto>();

            servico.Cadastre(produto);

            Assert.NotEqual(produto.Codigo, 0);
        }

        [Fact]
        public void CadastroSemValorErroTeste()
        {
            InicializeInfraestrutura();

            var produto = new Produto
            {
                Nome = "Computador com impressora",
                CodigoDeBarras = "484622648488"
            };

            var servico = FabricaDeServico.Crie<Produto>();

            var ex = Assert.Throws<Exception>(() => {
                servico.Cadastre(produto);
            });           

            Assert.Equal(ex.Message, "O valor do produto é obrigatório");
        }
    }
}
