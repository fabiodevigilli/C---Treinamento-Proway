using NUnit.Framework;

namespace Demo_Asserts.Tests.Colecoes
{
    [TestFixture]
    public class CaracteristicaJogadorTests
    {
        // Método responsável por testar se a lista de uma determinada coleção está vazia:
        [Test]
        public void NaoDevoTerListaDeArmasVazia()
        {
            var sut = new CaracteristicasJogador();
            Assert.That(sut.Armas, Is.All.Not.Empty);
        }

        // Método responsável por testar se contem um determinado item na coleção
        [Test]
        public void DeveTerArmaTeiaDeAranha()
        {
            var sut = new CaracteristicasJogador();

            Assert.That(sut.Armas, Contains.Item("Teia de Aranha"));
        }

        // Método responsável por testar se contem um determinada palavra na coleção
        [Test]
        public void DeveConterPeloMenosUmTipoDeArmaFroça()
        {
            var sut = new CaracteristicasJogador();

            Assert.That(sut.Armas, Has.Some.Contain("Força"));
        }

        // Método responsável por testar se tem um número específico de determinados itens
        [Test]
        public void DeveConterDuasArmasForca()
        {
            var sut = new CaracteristicasJogador();
            Assert.That(sut.Armas, Has.Exactly(2).EndsWith("Força"));
        }

        // Metodo responsável para verificar se há duplicidade de item na lista
        [Test]
        public void NaoDeveContermaisTiposDeArmasNoJogo()
        {
            var sut = new CaracteristicasJogador();

            Assert.That(sut.Armas, Is.Unique);
        }

        // Método responsável por testar se determinado item não está listado na coleção
        [Test]
        public void NaoDeveConterArmaVoar()
        {
            var sut = new CaracteristicasJogador();

            Assert.That(sut.Armas, Has.None.EqualTo("Voar"));
        }

        // Método responsável por testar se há equivalência de itens na coleção
        [Test]
        public void DeveConterExatamenteTodasAsArmas()
        {
            var sut = new CaracteristicasJogador();

            var listaArmasEsperadas = new[]
            {
                "Agilidade",
                "Agilidade Força",
                "Força",                
                "Teia de Aranha",
                "Inteligência Artificial"
            };

            Assert.That(sut.Armas, Is.EquivalentTo(listaArmasEsperadas));
        }

        // Método responsável por testar se coleção está em ordem alfabética
        [Test]
        public void ArmasDevemEstarEmOrdemAlfabetica()
        {
            var sut = new CaracteristicasJogador();

            Assert.That(sut.Armas, Is.Ordered);
        }
    }
}
