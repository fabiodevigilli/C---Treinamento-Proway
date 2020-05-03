using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoCSharpBasicoWindowsFormsExercicioOrientacaoObjetos
{
    // Sacar
    // Depositar
    // Transferir
    // Extrato (histórico)

        // Uma classe internal só é vista dentro do próprio projeto e não por toda a solução
        // Uma classe public pode ser acessada por todos os projetos da mesma solução
        // O "this" é utilizado para acessar propriedades e metodos da instância da classe
    public class ContaBancaria
    {
        private List<RegistroBancario> historico = new List<RegistroBancario>();

        public string Proprietario { get; set; }
        public string NConta { get; set; }
        public double Saldo { get; private set; }

        public void Depositar(double quantia)
        {
            // this.Saldo = this.Saldo + quantia;
            this.Saldo += quantia;
            AuditarOperacao(quantia, TipoOperacao.Deposito);
        }

        public void Sacar(double quantia)
        {
            if (quantia > this.Saldo)
            {
                // neste caso, o throw new exception, vai dar um roll back, para o método (que precisa ter um tratamento de erro) que chamou o método Sacar, 
                // chegamos a um ponto do método atual, que não podemos seguir
                throw new Exception("Saldo Insuficiente");
            }
            this.Saldo -= quantia;
            AuditarOperacao(quantia, TipoOperacao.Saque);
        }

        private void AuditarOperacao(double quantia, TipoOperacao tipoOperacao)
        {
            RegistroBancario registro = new RegistroBancario();
            registro.TipoOperacao = tipoOperacao;
            registro.QuantiaTransacao = quantia;
            registro.SaldoPosOperacao = this.Saldo;
            historico.Add(registro);
        }

        public List<RegistroBancario> LerOperacoesUltimos3Meses()
        {
            List<RegistroBancario> registrosUltimos3Meses = new List<RegistroBancario>();
            for (int i = 0; i < historico.Count; i++)
            {
                if (historico[i].Data > DateTime.Now.AddMonths(-3))
                {
                    registrosUltimos3Meses.Add(historico[i]);
                }
            }
            return registrosUltimos3Meses;            
        }
    }
}
