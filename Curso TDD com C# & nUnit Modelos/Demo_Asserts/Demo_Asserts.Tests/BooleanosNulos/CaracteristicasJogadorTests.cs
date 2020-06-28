using NUnit.Framework;

namespace Demo_Asserts.Tests.BooleanosNulos
{
    [TestFixture]
    public class CaracteristicasJogadorTests
    {
        /* Método que testa a geração dos nomes de maneira randômica */
        [Test]
        public void DevoGerarNomeRandomicoPorDefault()
        {
            var sut = new CaracteristicasJogador();

            Assert.That(sut.Nome, Is.Not.Empty);
        }

        /* Método responsável por testar o valor booleano de se é novo jogador*/
        [Test]
        public void DevoVerificarNovoJogador ()
        {
            var sut = new CaracteristicasJogador();

            Assert.That(sut.NovoJogador, Is.True);
        }

        /* Método que testa se o apelido do jogador é nulo */
        [Test]
        public void DevoVerificarApelidoJogador()
        {
            var sut = new CaracteristicasJogador();

            Assert.That(sut.Apelido, Is.Null);

            // Assert.That(sut.Apelido, Is.Not.Null);
        }

    }
}
