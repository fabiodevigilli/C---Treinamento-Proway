using NUnit.Framework;

namespace Demo_Asserts.Tests.Igualdade
{
    [TestFixture]
    public class CalculadoraTests
    {
        /*Método de testes, finalidade: somar numeros inteiros*/
        [Test]
        public void DevoSomarNumerosInteiros()
        {
            var sut = new Calculadora();

            var resultado = sut.SomarNumerosInteiros(4, 2);

            Assert.That(resultado, Is.EqualTo(6));
        }

        /*Método de testes, finalidade: somar numeros decimais*/
        [Test]
        public void DevoSomarNumerosDecimais()
        {
            var sut = new Calculadora();

            var resultado = sut.SomarNumerosDecimais(4.2, 2.3);

            Assert.That(resultado, Is.EqualTo(6.5));
        }

        [Test]
        public void DevoSomarNumerosDecimais_UsandoWithin()
        {
            var sut = new Calculadora();

            var resultado = sut.SomarNumerosDecimais(1.1, 2.2);

            Assert.That(resultado, Is.EqualTo(3.3).Within(0.01)); // Within adiciona uma tolerância ao resultado
        }

        [Test]
        public void DevoSomarNumerosDecimais_UsandoWithinPorcentagem()
        {
            var sut = new Calculadora();

            var resultado = sut.SomarNumerosDecimais(50, 50); // 100%

            Assert.That(resultado, Is.EqualTo(101).Within(1).Percent); // Within adiciona uma tolerância ao resultado. Percent, modifica para interpretar como percentual.
        }

        [Test]
        public void DevoSomarNumerosDecimais_NaoBomExemploWithin()
        {
            var sut = new Calculadora();

            var resultado = sut.SomarNumerosDecimais(1.1, 2.2); // resultado 3.3

            Assert.That(resultado, Is.EqualTo(30).Within(100));
            // Teste passa, pois a tolerância é de 100 para o resultado. Não é indicado, pois o valor de tolerância é muito alto e não identifica possíveis erros no nosso método;
        }

        /*Método de testes, finalidade: dividir numeros inteiros*/
        [Test]
        public void DevoDividirNumerosInteiros()
        {
            var sut = new Calculadora();

            //var resultado = sut.Dividir(120, 10); // Teste deverá falhar, caindo em ArgumentOutOfRangeException
            var resultado = sut.Dividir(40, 10);

            Assert.That(resultado, Is.EqualTo(4));
        }

        /* Outros métodos utilizados além do IsEqualTo:
         - Is.Positive;
         - Is.Negative;
         - Is.NaN;
         */
    }
}
