using NUnit.Framework;
using Voting.Domain.Entities.ValueObjects;

namespace Voting.Domain.Tests.ValueObjects
{
    [TestFixture]
    public class TimeTests
    {
        [Test]
        [Category("ValueObjects")]
        public void DadoUmHorarioValidoDeveSerCriadoComSucesso()
        {
            // Arrange
            var hour = 10;
            var minute = 30;

            // Act
            var time = new Time(hour, minute);

            // Assert
            Assert.That(time, Is.Not.Null);
            Assert.That(time.Hour, Is.EqualTo(hour));
            Assert.That(time.Minute, Is.EqualTo(minute));
        }

        [Test]
        [Category("ValueObjects")]
        public void DadoUmHorarioInicialDoDiaDeveSerCriadoCorretamente()
        {
            // Arrange
            var hour = 0;
            var minute = 0;

            // Act
            var time = new Time(hour, minute);

            // Assert
            Assert.That(time.Hour, Is.EqualTo(0));
            Assert.That(time.Minute, Is.EqualTo(0));
        }

        [Test]
        [Category("ValueObjects")]
        public void DadoUmHorarioFinalDoDiaDeveSerCriadoCorretamente()
        {
            // Arrange
            var hour = 23;
            var minute = 59;

            // Act
            var time = new Time(hour, minute);

            // Assert
            Assert.That(time.Hour, Is.EqualTo(23));
            Assert.That(time.Minute, Is.EqualTo(59));
        }

        [Test]
        [Category("ValueObjects")]
        public void DadoHorariosDiferentesDevemTerValoresDiferentes()
        {
            // Arrange
            var time1 = new Time(10, 30);
            var time2 = new Time(14, 45);

            // Act & Assert
            Assert.That(time2.Hour, Is.Not.EqualTo(time1.Hour));
            Assert.That(time2.Minute, Is.Not.EqualTo(time1.Minute));
        }
    }
}
