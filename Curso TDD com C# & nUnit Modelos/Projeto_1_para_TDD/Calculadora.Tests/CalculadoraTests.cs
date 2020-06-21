using NUnit.Framework;

namespace Calculadora.Tests
{
    public class CalculadoraTests
    {
        [TestFixture]
        public class CalculadoraSimplesTests
        {
            /*Teste Classe Adicionar dois números*/
            [Test]
            public void DeveAdicionarDoisNumeros()
            {
                var sut = new CalculadoraSimples();

                var resultado = sut.Adicionar(5,5);

                Assert.That(resultado, Is.EqualTo(10));
            }

            /*Teste Classe Subtrair dois números*/
            [Test]
            public void DeveSubtrairDoisNumeros()
            {
                var sut = new CalculadoraSimples();

                var resultado = sut.Subtrair(10, 5);

                Assert.That(resultado, Is.EqualTo(5));
            }

            /*Teste Classe Multiplicar dois números - neste caso, irá falhar*/
            [Test]
            public void DeveMultiplicarDoisNumeros()
            {
                var sut = new CalculadoraSimples();

                var resultado = sut.Multiplicar(5, 3);

                Assert.That(resultado, Is.EqualTo(15));
            }

            /*Teste Classe Dividir dois números*/
            [Test]
            public void DeveDividirDoisNumeros()
            {
                var sut = new CalculadoraSimples();

                var resultado = sut.Dividir(10, 5);

                Assert.That(resultado, Is.EqualTo(2));
            }

        }
    }
}
