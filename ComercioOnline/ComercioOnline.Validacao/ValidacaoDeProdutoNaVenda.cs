using ComercioOnline.Model;
using ComercioOnline.Model.UtilitariosDoModel;
using dn32.infraestrutura.Atributos;
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
        }
    }
}
