using NUnit.Framework;
using System;

namespace Demo_Asserts.Tests.Excecoes
{
    [TestFixture]
    public class CalculadoraTests
    {
        [Test]
        public void DeveRetornarErroQuandoDividirPorZero()
        {
            var sut = new Calculadora();
            Assert.That(() => sut.Dividir(200, 0), Throws.Exception);
        }

        [Test]
        public void DeveRetornarErroQuandoDividirPorZero_Ex2()
        {
            var sut = new Calculadora();
            Assert.That(() => sut.Dividir(99, 0), Throws.TypeOf<DivideByZeroException>());
        }

        [Test]
        public void DeveRetornarErroQuandoNumeroMaiorDoQue100()
        {
            var sut = new Calculadora();
            Assert.That(() => sut.Dividir(200, 2), Throws.TypeOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void DeveRetornarErroQdoNumeroMaior100_MelhorCaso()
        {
            var sut = new Calculadora();
            Assert.That(() => sut.Dividir(200, 2),
                Throws.TypeOf<ArgumentOutOfRangeException>()
                .With.Matches<ArgumentOutOfRangeException>(v => v.ParamName == "por"));
        }
    }
}
