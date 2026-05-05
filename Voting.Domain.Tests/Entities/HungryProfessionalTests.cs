using NUnit.Framework;
using Voting.Domain.Entities;
using Voting.Domain.Entities.ValueObjects;

namespace Voting.Domain.Tests.Entities
{
    [TestFixture]
    public class HungryProfessionalTests
    {
        [Test]
        [Category("Entities")]
        public void DadoUmProfissionalFamintoValidoDeveSerCriadoComSucesso()
        {
            // Arrange
            var code = new Code("PROF001");
            var name = "João Silva";
            var password = "senha123";

            // Act
            var professional = new HungryProfessional(code, name, password);

            // Assert
            Assert.That(professional, Is.Not.Null);
            Assert.That(professional.Code, Is.EqualTo(code));
            Assert.That(professional.Name, Is.EqualTo(name));
            Assert.That(professional.Password, Is.EqualTo(password));
            Assert.That(professional.Id, Is.Not.Null);
        }

        [Test]
        [Category("Entities")]
        public void DadoUmProfissionalFamintoDeveRetornarToStringCorreto()
        {
            // Arrange
            var code = new Code("PROF001");
            var name = "João Silva";
            var password = "senha123";
            var professional = new HungryProfessional(code, name, password);

            // Act
            var result = professional.ToString();

            // Assert
            Assert.That(result.Contains(name), Is.True);
            Assert.That(result.Contains(code.Number), Is.True);
        }

        [Test]
        [Category("Entities")]
        public void DoisProfissionaisComMesmoIdDevemSerIguais()
        {
            // Arrange
            var code = new Code("PROF001");
            var professional1 = new HungryProfessional(code, "João", "senha");
            var professional2 = professional1;

            // Act & Assert
            Assert.That(professional1.Equals(professional2), Is.True);
        }

        [Test]
        [Category("Entities")]
        public void DoisProfissionaisComIdsDiferentesNaoDevemSerIguais()
        {
            // Arrange
            var code1 = new Code("PROF001");
            var code2 = new Code("PROF002");
            var professional1 = new HungryProfessional(code1, "João", "senha1");
            var professional2 = new HungryProfessional(code2, "Maria", "senha2");

            // Act & Assert
            Assert.That(professional1.Equals(professional2), Is.False);
        }
    }
}
