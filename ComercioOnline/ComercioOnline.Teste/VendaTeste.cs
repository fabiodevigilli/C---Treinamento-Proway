using ComercioOnline.Model;
using ComercioOnline.Model.UtilitariosDoModel;
using ComercioOnline.Servico;
using ComercioOnline.Teste.Utilitarios;
using dn32.infraestrutura.Fabrica;
using dn32.infraestrutura.Generico;
using System;
using Xunit;

namespace ComercioOnline.Teste
{
    public class VendaTeste : TesteGenerico<Venda>
    {
        public override void InicializarInfraestrutura()
        {
            UtilitariosDeTeste.InicializarInfraestrutura();
        }

        [Fact(DisplayName = nameof(VendaCadastroTeste))]
        public void VendaCadastroTeste()
        {
            var venda = CadastreUmaVenda();
            Assert.NotEqual(venda.Codigo, 0);
            Servico.Remova(venda.Codigo);
        }

        [Fact(DisplayName = nameof(VendaConsulteTeste))]
        public void VendaConsulteTeste()
        {
            var venda = CadastreUmaVenda();
            var vendaBancoDeDados = Servico.Consulte(venda.Codigo);

            var ehIgual = Compare(venda, vendaBancoDeDados, nameof(Venda.DataDeAtualizacao), nameof(Venda.DataDeCadastro));
            Assert.Equal(ehIgual, true);
            Servico.Remova(venda.Codigo);
        }

        [Fact(DisplayName = nameof(FinalizeAVendaTeste))]
        public void FinalizeAVendaTeste()
        {
            var venda = CadastreUmaVenda();
            var produto1 = ProdutoTeste.CadastreUmProduto();
            var produto2 = ProdutoTeste.CadastreUmProduto();
            var produtoNaVenda1 = ProdutoNaVendaTestes.CadastreUmProdutoNaVenda(venda, produto1, 1);
            var produtoNaVenda2 = ProdutoNaVendaTestes.CadastreUmProdutoNaVenda(venda, produto2, 1);

            var servico = Servico as ServicoDeVenda;
            servico.FinalizeAVenda(venda);            

            var vendaBancoDeDados = servico.Consulte(venda.Codigo);
            Assert.Equal(vendaBancoDeDados.Status, StatusDaVenda.FECHADA);

            Servico.Remova(venda.Codigo);
            ProdutoTeste.RemovaUmProduto(produto1.Codigo);
            ProdutoTeste.RemovaUmProduto(produto2.Codigo);
            ProdutoNaVendaTestes.RemovaUmProdutoNaVenda(produtoNaVenda1.Codigo);
            ProdutoNaVendaTestes.RemovaUmProdutoNaVenda(produtoNaVenda2.Codigo);
        }

        [Fact(DisplayName = nameof(FinalizeAVendaCalculandoDescontoTeste))]
        public void FinalizeAVendaCalculandoDescontoTeste()
        {
            var venda = CadastreUmaVenda();
            var produto1 = ProdutoTeste.CadastreUmProduto();
            var produto2 = ProdutoTeste.CadastreUmProduto();
            var produtoNaVenda1 = ProdutoNaVendaTestes.CadastreUmProdutoNaVenda(venda, produto1, 11);
            var produtoNaVenda2 = ProdutoNaVendaTestes.CadastreUmProdutoNaVenda(venda, produto2, 2);

            var servico = Servico as ServicoDeVenda;
            servico.FinalizeAVenda(venda);

            var produtosSalvos = servico.ObtenhaProdutosDaVenda(venda);
            var descontoTotal = 0m;
            foreach (var produto in produtosSalvos)
            {
                descontoTotal += produto.Desconto;
            }

            Assert.Equal(venda.DescontoTotal, descontoTotal);            

            Servico.Remova(venda.Codigo);
            ProdutoTeste.RemovaUmProduto(produto1.Codigo);
            ProdutoTeste.RemovaUmProduto(produto2.Codigo);
            ProdutoNaVendaTestes.RemovaUmProdutoNaVenda(produtoNaVenda1.Codigo);
            ProdutoNaVendaTestes.RemovaUmProdutoNaVenda(produtoNaVenda2.Codigo);
        }

        [Fact(DisplayName = nameof(FinalizeAVendaCalculandoValorTotalTeste))]
        public void FinalizeAVendaCalculandoValorTotalTeste()
        {
            var venda = CadastreUmaVenda();
            var produto1 = ProdutoTeste.CadastreUmProduto();
            var produto2 = ProdutoTeste.CadastreUmProduto();
            var produtoNaVenda1 = ProdutoNaVendaTestes.CadastreUmProdutoNaVenda(venda, produto1, 11);
            var produtoNaVenda2 = ProdutoNaVendaTestes.CadastreUmProdutoNaVenda(venda, produto2, 2);

            var servico = Servico as ServicoDeVenda;
            servico.FinalizeAVenda(venda);

            var produtosSalvos = servico.ObtenhaProdutosDaVenda(venda);
            var valorTotal = 0m;
            foreach (var produto in produtosSalvos)
            {
                valorTotal += produto.Desconto;
            }

            Assert.Equal(venda.ValorTotal, valorTotal);

            Servico.Remova(venda.Codigo);
            ProdutoTeste.RemovaUmProduto(produto1.Codigo);
            ProdutoTeste.RemovaUmProduto(produto2.Codigo);
            ProdutoNaVendaTestes.RemovaUmProdutoNaVenda(produtoNaVenda1.Codigo);
            ProdutoNaVendaTestes.RemovaUmProdutoNaVenda(produtoNaVenda2.Codigo);
        }

        [Fact(DisplayName = nameof(FinalizeAVendaOndeVendaNaoExisteTeste))]
        public void FinalizeAVendaOndeVendaNaoExisteTeste()
        {
            Venda venda = null;
            var servico = Servico as ServicoDeVenda;      

            var ex = Assert.Throws<Exception>(() => servico.FinalizeAVenda(venda));
            Assert.Equal(ex.Message, ConstantesDeValidacaoDoModel.A_VENDA_INFORMADA_NAO_FOI_ENCONTRADA);
        }


        [Fact(DisplayName = nameof(VendaRemovaTeste))]
        public void VendaRemovaTeste() // Este método não foi criado na aula, fiz por iniciativa própria.
        {
            var venda = CadastreUmaVenda();

            Servico.Remova(venda.Codigo);

            var vendaBancoDeDados = Servico.Consulte(venda.Codigo);

            Assert.Equal(vendaBancoDeDados, null);            
        }

        public static Venda CadastreUmaVenda()
        {
            var servico = FabricaDeServico.Crie<Venda>();
            var venda = ObtenhaUmaVenda();
            servico.Cadastre(venda);
            return venda;
        }

        public static Venda ObtenhaUmaVenda()
        {
            return new Venda
            {
                Status = StatusDaVenda.NOVA,
                ValorTotal = 0m,
                DescontoTotal = 0m
            };
        }

        public static void RemovaUmaVenda(int codigo)
        {
            var servico = FabricaDeServico.Crie<Venda>();
            servico.Remova(codigo);
        }        
    }
}
