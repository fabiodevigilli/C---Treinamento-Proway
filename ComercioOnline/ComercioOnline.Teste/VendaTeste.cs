using ComercioOnline.Model;
using ComercioOnline.Teste.Utilitarios;
using dn32.infraestrutura.Fabrica;
using dn32.infraestrutura.Generico;
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
