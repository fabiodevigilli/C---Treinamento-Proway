using ComercioOnline.Model;
using ComercioOnline.Repositorio;
using ComercioOnline.Validacao;
using dn32.infraestrutura.Atributos;
using dn32.infraestrutura.Fabrica;
using dn32.infraestrutura.Generico;

namespace ComercioOnline.Servico
{
    [ServicoDe(typeof(ProdutoNaVenda))]
    public class ServicoDeProdutoNaVenda : ServicoGenerico<ProdutoNaVenda>
    {
        public ProdutoNaVenda Cadastre(int codigoDaVenda, int codigoDoProduto, int quantidade)
        {
            var servicoDeVenda = FabricaDeServico.Crie<Venda>();
            var servicoDeProduto = FabricaDeServico.Crie<Produto>();
            var validacaoDeProdutoNaVenda = FabricaDeValidacao.Crie<ProdutoNaVenda>() as ValidacaoDeProdutoNaVenda;

            var venda = servicoDeVenda.Consulte(codigoDaVenda);
            var produto = servicoDeProduto.Consulte(codigoDoProduto);
            
            validacaoDeProdutoNaVenda.Cadastre(produto,venda,quantidade);

            var produtoNaVenda = new ProdutoNaVenda
            {
                IdVenda = venda.Id,
                IdProduto = produto.Id,
                Quantidade = quantidade
            };
            produtoNaVenda.ValorTotal = produto.Valor * quantidade;

            var desconto = 0m;
            if (quantidade >= 10)
            {
                desconto = (produtoNaVenda.ValorTotal * 10) / 100;
            }
            produtoNaVenda.Desconto = desconto;
            produtoNaVenda.ValorTotal -= desconto;            

            Cadastre(produtoNaVenda);
            
            return produtoNaVenda;
        }      
    }
}
