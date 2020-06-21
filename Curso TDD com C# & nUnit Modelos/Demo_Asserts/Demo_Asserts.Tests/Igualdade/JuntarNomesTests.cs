using NUnit.Framework;

namespace Demo_Asserts.Tests.Igualdade
{
    [TestFixture]
    public class JuntarNomesTests
    {
        /* Método de teste finalidade: Comparar duas strings iguais */
        [Test]
        public void DevoJuntarNomeCompleto()
        {
            var sut = new JuntarNomes();

            var nomeCompleto = sut.Juntar("João", "Silva");

            Assert.That(nomeCompleto, Is.EqualTo("João Silva"));
        }

        /* Método de teste finalidade: Comparar duas strings em case sensitive */
        [Test]
        public void DevoJuntarNome_Completo_CaseSensitive()
        {
            var sut = new JuntarNomes();

            var nomeCompleto = sut.Juntar("joão", "silva");

            Assert.That(nomeCompleto, Is.EqualTo("JOÃO SILVA").IgnoreCase);
        }

        /* Método de teste finalidade: Comparar duas strings diferentes */
        [Test]
        public void DevoJuntarNomeCompleto_NaoIgual()
        {
            var sut = new JuntarNomes();

            var nomeCompleto = sut.Juntar("João", "Silva");

            Assert.That(nomeCompleto, Is.Not.EqualTo("José Silva"));
        }
    }
}
