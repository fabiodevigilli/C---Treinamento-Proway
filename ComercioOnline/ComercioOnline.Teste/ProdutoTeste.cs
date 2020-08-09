using ComercioOnline.Model;
using ComercioOnline.Model.UtilitariosDoModel;
using dn32.infraestrutura;
using dn32.infraestrutura.Constantes;
using dn32.infraestrutura.Fabrica;
using dn32.infraestrutura.Generico;
using dn32.infraestrutura.Model;
using System;
using Xunit;

namespace ComercioOnline.Teste
{
    public class ProdutoTeste : TesteGenerico<Produto>
    {
        public override void InicializarInfraestrutura()
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

        #region CADASTRO
        [Fact(DisplayName = nameof(CadastroTeste))]
        public void CadastroTeste()
        {
            var servico = FabricaDeServico.Crie<Produto>();
            var produto = CadastreUmProduto();
            Assert.NotEqual(produto.Codigo, 0);
            servico.Remova(produto.Codigo);
        }

        [Fact(DisplayName = nameof(CadastroSemValorErroTeste))]
        public void CadastroSemValorErroTeste()
        {
            var produto = ObtenhaUmProduto();
            produto.Valor = 0m;

            var servico = FabricaDeServico.Crie<Produto>();

            var ex = Assert.Throws<Exception>(() =>
            {
                servico.Cadastre(produto);
            });

            Assert.Equal(ex.Message, ConstantesDeValidacaoDoModel.O_VALOR_DO_PRODUTO_EH_OBRIGATORIO);
        }

        [Fact(DisplayName = nameof(CadastroSemNomeErroTeste))]
        public void CadastroSemNomeErroTeste()
        {
            var produto = ObtenhaUmProduto();
            produto.Nome = string.Empty;

            var servico = FabricaDeServico.Crie<Produto>();

            var ex = Assert.Throws<Exception>(() =>
            {
                servico.Cadastre(produto);
            });

            Assert.Equal(ex.Message, ConstantesDeValidacao.O_NOME_DO_ELEMENTO_DEVE_SER_INFORMADO);
        }
        #endregion

        #region CONSULTA
        [Fact(DisplayName = nameof(ConsultaTeste))]
        public void ConsultaTeste()
        {
            var servico = FabricaDeServico.Crie<Produto>();
            var produto = CadastreUmProduto();       

            var produtoDoBanco = servico.Consulte(produto.Codigo);

            var json1 = Serialize(produto); // utilizado apenas para consultar visualmente o objeto, formato json
            var json2 = Serialize(produtoDoBanco); // utilizado apenas para consultar visualmente o objeto, formato json

            var ehIgual = Compare(produto, produtoDoBanco, nameof(Produto.DataDeAtualizacao), nameof(Produto.DataDeCadastro));

            Assert.Equal(ehIgual, true);

            servico.Remova(produto.Codigo);
        }
        #endregion

        #region ATUALIZAÇÃO

        [Fact(DisplayName = nameof(AtualizacaoSemValorErroTeste))]
        public void AtualizacaoSemValorErroTeste()
        {
            var produto = CadastreUmProduto();
            produto.Valor = 0m;

            var servico = FabricaDeServico.Crie<Produto>();

            var ex = Assert.Throws<Exception>(() =>
            {
                servico.Atualize(produto);
            });

            Assert.Equal(ex.Message, ConstantesDeValidacaoDoModel.O_VALOR_DO_PRODUTO_EH_OBRIGATORIO);
            servico.Remova(produto.Codigo);
        }

        [Fact(DisplayName = nameof(AtualizacaoSemNomeErroTeste))]
        public void AtualizacaoSemNomeErroTeste()
        {
            var produto = CadastreUmProduto();
            produto.Nome = string.Empty;

            var servico = FabricaDeServico.Crie<Produto>();

            var ex = Assert.Throws<Exception>(() =>
            {
                servico.Atualize(produto);
            });

            Assert.Equal(ex.Message, ConstantesDeValidacao.O_NOME_DO_ELEMENTO_DEVE_SER_INFORMADO);
            servico.Remova(produto.Codigo);
        }

        #endregion

        #region MÉTODOS PRIVADOS

        private Produto CadastreUmProduto()
        {
            var servico = FabricaDeServico.Crie<Produto>();
            var produto = ObtenhaUmProduto();
            servico.Cadastre(produto);
            return produto;
        }

        private static Produto ObtenhaUmProduto()
        {
            return new Produto
            {
                Nome = "Computador com impressora",
                Valor = 1285.58m,
                CodigoDeBarras = "484622648488"
            };
        }

        #endregion
    }
}
