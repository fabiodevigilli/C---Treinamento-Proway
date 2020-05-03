using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoCSharpBasicoWindowsFormsExercicioOrientacaoObjetos
{
    public class RegistroBancario
    {
        public RegistroBancario()
        {
            Data = DateTime.Now;
        }
        public DateTime Data { get; set; }
        public double SaldoPosOperacao { get; set; }
        public double QuantiaTransacao { get; set; }
        public TipoOperacao TipoOperacao { get; set; }
    }

    public enum TipoOperacao 
    {
        Saque,
        Deposito
    }
}
