using NUnit.Framework;
using System;

namespace Demo_Asserts.Tests.Igualdade
{
    [TestFixture]
    public class DatasEspeciaisStoreTests
    {
        [Test]
        public void DeveRotornarCorretamenteAnoNovo()
        {
            var sut = new DatasEspeciaisStore();

            var resultado = sut.Data(DatasEspeciais.AnoNovo);

            Assert.That(resultado, Is.EqualTo(new DateTime(2017, 1, 1, 0, 0, 0, 0)));
        }

        [Test]
        public void DeveRotornarCorretamenteAnoNovo_Within()
        {
            var sut = new DatasEspeciaisStore();

            var resultado = sut.Data(DatasEspeciais.AnoNovo);

           // Assert.That(resultado, Is.EqualTo(new DateTime(2017, 1, 1, 0, 0, 0, 1)).Within(1).Milliseconds);
            // Outra forma de Fazer:
            Assert.That(resultado, Is.EqualTo(new DateTime(2017, 1, 1, 0, 0, 0, 1)).Within(TimeSpan.FromMilliseconds(1)));
        }
    }
}
