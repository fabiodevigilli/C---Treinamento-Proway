using NUnit.Framework;

namespace Demo_Asserts.Tests.Referencias
{
    [TestFixture]
    public class CaracteristicasJogadorTests
    {
        // var carro = new Carro() vamos testar esse tipo de situação
        [Test]
        public void CompararReferenciaDeObjetoComSameAs()
        {
            var jogador1 = new CaracteristicasJogador();
            var jogador2 = new CaracteristicasJogador();

            // Assert.That(jogador1, Is.SameAs(jogador2)); - teste para falhar
            Assert.That(jogador1, Is.SameAs(jogador1));            
        }

        [Test]
        public void CompararReferenciaDeObjetoComVariavelSameAs()
        {
            var jogador1 = new CaracteristicasJogador();
            var jogador2 = new CaracteristicasJogador();

            var jogador = jogador1;
            Assert.That(jogador, Is.SameAs(jogador1));
        }

        [Test]
        public void CompararReferenciaDeObjetoComIsNotSameAs()
        {
            var jogador1 = new CaracteristicasJogador();
            var jogador2 = new CaracteristicasJogador();

            Assert.That(jogador1, Is.Not.SameAs(jogador2));
        }
    }
}
