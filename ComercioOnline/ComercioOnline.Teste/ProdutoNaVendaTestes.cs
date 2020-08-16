using ComercioOnline.Model;
using ComercioOnline.Model.UtilitariosDoModel;
using ComercioOnline.Servico;
using ComercioOnline.Teste.Utilitarios;
using dn32.infraestrutura.Generico;
using System;
using Xunit;

namespace ComercioOnline.Teste
{
    public class ProdutoNaVendaTestes : TesteGenerico<ProdutoNaVenda>
    {
        public override void InicializarInfraestrutura()
        {
            UtilitariosDeTeste.InicializarInfraestrutura();
        }

        [Fact(DisplayName = nameof(AdicionarProdutoNaVenda))]
        public void AdicionarProdutoNaVenda()
        {
            var servico = Servico as ServicoDeProdutoNaVenda;

            var venda = VendaTeste.CadastreUmaVenda();
            var produto = ProdutoTeste.CadastreUmProduto();
            int quantidade = 1;

            var produtoNaVenda = servico.Cadastre(venda.Codigo, produto.Codigo, quantidade);

            Assert.NotEqual(produtoNaVenda.Codigo, 0);

            servico.Remova(produtoNaVenda.Codigo);
            VendaTeste.RemovaUmaVenda(venda.Codigo);
            ProdutoTeste.RemovaUmProduto(produto.Codigo);
        }

        [Theory(DisplayName = nameof(AdicionarProdutoNaVendaECalculaODeconto))]
        [InlineData(3, 0)]
        [InlineData(9, 0)]
        [InlineData(10, 10)]
        [InlineData(17, 10)]
        [InlineData(50, 10)]
        public void AdicionarProdutoNaVendaECalculaODeconto(int quantidadeDeProdutos, decimal descontoEsperado)
        {
            var servico = Servico as ServicoDeProdutoNaVenda;

            var venda = VendaTeste.CadastreUmaVenda();
            var produto = ProdutoTeste.CadastreUmProduto();

            var produtoNaVenda = servico.Cadastre(venda.Codigo, produto.Codigo, quantidadeDeProdutos);

            var valorTotal = quantidadeDeProdutos * produto.Valor;
            var desconto = valorTotal * (descontoEsperado / 100);

            Assert.NotEqual(produtoNaVenda.Codigo, 0);
            Assert.Equal(produtoNaVenda.Desconto, desconto);

            servico.Remova(produtoNaVenda.Codigo);
            VendaTeste.RemovaUmaVenda(venda.Codigo);
            ProdutoTeste.RemovaUmProduto(produto.Codigo);
        }

        [Fact(DisplayName = nameof(AdicionarProdutoErradoNaVendaErro))]
        public void AdicionarProdutoErradoNaVendaErro()
        {
            var servico = Servico as ServicoDeProdutoNaVenda;

            var venda = VendaTeste.CadastreUmaVenda();
            var codigoDoProduto = ObtenhaUmCodigo();
            int quantidade = 1;

            var ex = Assert.Throws<Exception>(() => servico.Cadastre(venda.Codigo, codigoDoProduto, quantidade));
            Assert.Equal(ex.Message, ConstantesDeValidacaoDoModel.O_PRODUTO_INFORMADO_NAO_FOI_ENCONTRADO);

            VendaTeste.RemovaUmaVenda(venda.Codigo);
        }

        [Fact(DisplayName = nameof(AdicionarVendaNaoExisteNoProdutoNaVendaErro))]
        public void AdicionarVendaNaoExisteNoProdutoNaVendaErro()
        {
            var servico = Servico as ServicoDeProdutoNaVenda;

            var codigoDaVenda = ObtenhaUmCodigo();
            var produto = ProdutoTeste.CadastreUmProduto();
            int quantidade = 1;

            var ex = Assert.Throws<Exception>(() => servico.Cadastre(codigoDaVenda, produto.Codigo, quantidade));
            Assert.Equal(ex.Message, ConstantesDeValidacaoDoModel.A_VENDA_INFORMADA_NAO_FOI_ENCONTRADA);

            ProdutoTeste.RemovaUmProduto(produto.Codigo);
        }

        [Fact(DisplayName = nameof(AdicionarProdutoEVendaNaoExistemErro))]
        public void AdicionarProdutoEVendaNaoExistemErro()
        {
            var servico = Servico as ServicoDeProdutoNaVenda;

            var codigoDaVenda = ObtenhaUmCodigo();
            var codigoDoProduto = ObtenhaUmCodigo();
            int quantidade = 1;

            var ex = Assert.Throws<Exception>(() => servico.Cadastre(codigoDaVenda, codigoDoProduto, quantidade));
            Assert.Equal(ex.Message, ConstantesDeValidacaoDoModel.O_PRODUTO_INFORMADO_NAO_FOI_ENCONTRADO);


        }

        //[Fact(DisplayName = nameof(RemoverProdutoNaVenda))]
        //public void RemoverProdutoNaVenda()
        //{

        //}

        //[Fact(DisplayName = nameof(RemoverProdutoNaVendaFechadaErro))]
        //public void RemoverProdutoNaVendaFechadaErro()
        //{

        //}
    }
}
