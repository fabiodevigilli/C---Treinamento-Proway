using ComercioOnline.Model;
using ComercioOnline.Model.UtilitariosDoModel;
using dn32.infraestrutura;
using dn32.infraestrutura.Atributos;
using dn32.infraestrutura.Fabrica;
using dn32.infraestrutura.Generico;
using System;

namespace ComercioOnline.Validacao
{
    [ValidacaoDe(typeof(ProdutoNaVenda))]
    public class ValidacaoDeProdutoNaVenda : ValidacaoGenerica<ProdutoNaVenda>
    {
        public void Cadastre(Produto produto, Venda venda, int quantidade)
        {
            if (produto == null)
            {
                throw new Exception(ConstantesDeValidacaoDoModel.O_PRODUTO_INFORMADO_NAO_FOI_ENCONTRADO);
            }

            if (venda == null)
            {
                throw new Exception(ConstantesDeValidacaoDoModel.A_VENDA_INFORMADA_NAO_FOI_ENCONTRADA);
            }

            if (venda.Status == StatusDaVenda.FECHADA)
            {
                throw new Exception(ConstantesDeValidacaoDoModel.NAO_EH_POSSIVEL_ALTERAR_UMA_VENDA_FECHADA);
            }
        }

        //public override void Remova(int codigo)
        //{
        //    var produtoNaVenda = Repositorio.Consulte(codigo);
        //    var codigoVenda = Utilitarios.ObtenhaCodigoDoElemento(produtoNaVenda.IdVenda);

        //    var repositorio = FabricaDeRepositorio.Crie<Venda>();
        //    var venda = repositorio.Consulte(codigoVenda);

        //    if (venda == null)
        //    {
        //        throw new Exception(ConstantesDeValidacaoDoModel.A_VENDA_INFORMADA_NAO_FOI_ENCONTRADA);

        //    }
        //    if (venda.Status == StatusDaVenda.FECHADA)
        //    {
        //        throw new Exception(ConstantesDeValidacaoDoModel.NAO_EH_POSSIVEL_ALTERAR_UMA_VENDA_FECHADA);
        //    }

        //    base.Remova(codigo);
        //}
    }
}
