using ComercioOnline.Model;
using ComercioOnline.Repositorio;
using ComercioOnline.Validacao;
using dn32.infraestrutura.Atributos;
using dn32.infraestrutura.Fabrica;
using dn32.infraestrutura.Generico;
using System.Collections.Generic;

namespace ComercioOnline.Servico
{
    [ServicoDe(typeof(Venda))]
    public class ServicoDeVenda : ServicoGenerico<Venda>
    {
        public void FinalizeAVenda(Venda venda)
        {
            ((ValidacaoDeVenda)Validacao).FinalizeAVenda(venda);
            venda.Status = StatusDaVenda.FECHADA;

            CalculeDescontoTotalDaVenda(venda);
            CalculeValorTotalDaVenda(venda);

            Repositorio.Atualizar(venda);
        }

        private void CalculeDescontoTotalDaVenda(Venda venda)
        {
            var produtosNaVenda = ObtenhaProdutosDaVenda(venda);
            venda.DescontoTotal = 0m;
            foreach (var produto in produtosNaVenda)
            {
                venda.DescontoTotal += produto.Desconto;
            }
        }       

        private void CalculeValorTotalDaVenda(Venda venda)
        {
            var produtosNaVenda = ObtenhaProdutosDaVenda(venda);
            venda.ValorTotal = 0m;
            foreach (var produto in produtosNaVenda)
            {
                venda.ValorTotal += produto.ValorTotal;
            }
        }

        public List<ProdutoNaVenda> ObtenhaProdutosDaVenda(Venda venda)
        {
            var repositorioDeProdutoNaVenda = FabricaDeRepositorio.Crie<ProdutoNaVenda>() as RepositorioDeProdutoNaVenda;
            return repositorioDeProdutoNaVenda.ConsulteProdutosPorVenda(venda.Codigo);
        }

        //public void ReabreAVenda(Venda venda)
        //{
        //    venda.Status = StatusDaVenda.NOVA;
        //    Repositorio.Atualizar(venda);
        //}
    }
}
