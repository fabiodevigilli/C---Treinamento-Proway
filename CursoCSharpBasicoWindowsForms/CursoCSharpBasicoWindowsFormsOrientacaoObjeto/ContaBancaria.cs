using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoCSharpBasicoWindowsFormsOrientacaoObjeto
{
    class ContaBancaria
    {
        // AULA DE ENCAPSULAMENTO

        // em c# chamamos de variável, em java chama-se de atributo
        // em C# chamamos de propriedade, validações na variável



        // SITUAÇÃO 01
        // public string proprietario;



        // SITUAÇÃO 02
        // A maneira mais antiga é:
        //private string proprietario;
        //public void SetProprietario(string p_proprietario)
        //{
        //    if (p_proprietario == "")
        //    {
        //        throw new Exception("Proprietário não foi informado");
        //    }
        //    proprietario = p_proprietario;
        //}
        //public string GetProprietario()
        //{
        //    return proprietario;
        //}



        // SITUAÇÃO 03
        // Neste caso, o proprietario com letra minuscula é a variável        
        //private string proprietario;
        // Selecionar proprietário, vá em Edit, Refactor, Encapsulate Field => Irá criar a propriedade abaixo.
        // Já o Proprietario com letra maiúscula é a propriedade acessor da variável
        //public string Proprietario { get => proprietario; set => proprietario = value; }


        // SITUAÇÃO 04 - MAIS USADA ATUALMENTE
        // Ignoramos a criação da variável e criamos diretamente a PROPRIEDADE
        public string Proprietario { get; set; }
        public string NConta { get; set; }
        public double Saldo { get; private set; }

        public void Depositar()
        { }
        public void Sacar()
        { }
    }
}
