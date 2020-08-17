using ComercioOnline.Model;
using ComercioOnline.Model.UtilitariosDoModel;
using dn32.infraestrutura.Atributos;
using dn32.infraestrutura.Generico;
using System;

namespace ComercioOnline.Validacao
{
    [ValidacaoDe(typeof(Venda))]
    public class ValidacaoDeVenda : ValidacaoGenerica<Venda>
    {
        public void FinalizeAVenda(Venda venda)
        {
            if (venda == null)
            {
                throw new Exception(ConstantesDeValidacaoDoModel.A_VENDA_INFORMADA_NAO_FOI_ENCONTRADA);
            }
        }
    }
}
