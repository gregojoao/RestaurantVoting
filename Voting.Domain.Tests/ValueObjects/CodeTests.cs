using NUnit.Framework;
using Voting.Domain.Entities.ValueObjects;

namespace Voting.Domain.Tests.ValueObjects
{
    [TestFixture]
    public class CodeTests
    {
        [Test]
        [Category("ValueObjects")]
        public void DadoUmCodigoValidoDeveSerCriadoComSucesso()
        {
            // Arrange
            var number = "CODE001";

            // Act
            var code = new Code(number);

            // Assert
            Assert.That(code, Is.Not.Null);
            Assert.That(code.Number, Is.EqualTo(number));
        }

        [Test]
        [Category("ValueObjects")]
        public void DadoUmCodigoVazioDeveSerCriadoComStringVazia()
        {
            // Act
            var code = new Code();

            // Assert
            Assert.That(code, Is.Not.Null);
            Assert.That(code.Number, Is.EqualTo(string.Empty));
        }

        [Test]
        [Category("ValueObjects")]
        public void DadoUmCodigoNuloDeveSerCriadoComStringVazia()
        {
            // Act
            var code = new Code(null!);

            // Assert
            Assert.That(code, Is.Not.Null);
            Assert.That(code.Number, Is.EqualTo(string.Empty));
        }

        [Test]
        [Category("ValueObjects")]
        public void DadoUmCodigoComEspacosDeveManterOValor()
        {
            // Arrange
            var number = "  CODE 001  ";

            // Act
            var code = new Code(number);

            // Assert
            Assert.That(code.Number, Is.EqualTo(number));
        }
    }
}
