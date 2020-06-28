using NUnit.Framework;

namespace Demo_Asserts.Tests.Intervalos
{
    [TestFixture]
    public class CaracteristicasJogadorTests
    {
        /* Método de teste responsável por testar se jogador está ganhando vida depois de dormir. */
        [Test]
        public void DevoAumentarVidaJogadorDepoisDormir()
        {
            // vida inicial do jogador é igual a 100%
            var sut = new CaracteristicasJogador { Vida = 100 };

            sut.Dormir();

            Assert.That(sut.Vida, Is.GreaterThan(100));            
        }

        /* O correto seria fazer o método abaixo: */
        /* Método de teste responsável por testar se jogador está ganhando vida depois de dormir, porém, utilizando intervalo/faixas de valores */
        [Test]
        public void DevoAumentarVidaJogadorDepoisDormir_Intervalo()
        {
            var sut = new CaracteristicasJogador { Vida = 100 };

            sut.Dormir();

            Assert.That(sut.Vida, Is.InRange(101, 200)); // Utilizado para trabalhar com intervalos de valores
        }

        /*
         - Podemos utilizar para casos de intervalos:
         1) Is.GreaterThanOrEqualTo();
         2) Is.LessThan();
         3) Is.LessThanOrEqualTo();
         4) Is.GreaterThan();
         */
    }
}
