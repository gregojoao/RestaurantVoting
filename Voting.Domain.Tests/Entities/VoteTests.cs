using System;
using NUnit.Framework;
using Voting.Domain.Entities;
using Voting.Domain.Entities.ValueObjects;

namespace Voting.Domain.Tests.Entities
{
    [TestFixture]
    public class VoteTests
    {
        [Test]
        [Category("Entities")]
        public void DadoUmVotoValidoDeveSerCriadoComSucesso()
        {
            // Arrange
            var professionalCode = new Code("PROF001");
            var restaurantCode = new Code("REST001");
            var votingId = Guid.NewGuid();

            // Act
            var vote = new Vote(professionalCode, restaurantCode, votingId);

            // Assert
            Assert.That(vote, Is.Not.Null);
            Assert.That(vote.HungryProfessionalCode, Is.EqualTo(professionalCode));
            Assert.That(vote.FavoriteRestaurantCode, Is.EqualTo(restaurantCode));
            Assert.That(vote.IdRestaurantVoting, Is.EqualTo(votingId));
            Assert.That(vote.Id, Is.Not.Null);
            Assert.That(vote.Date, Is.Not.Null);
        }

        [Test]
        [Category("Entities")]
        public void DadoUmVotoDeveRetornarToStringCorreto()
        {
            // Arrange
            var professionalCode = new Code("PROF001");
            var restaurantCode = new Code("REST001");
            var votingId = Guid.NewGuid();
            var vote = new Vote(professionalCode, restaurantCode, votingId);

            // Act
            var result = vote.ToString();

            // Assert
            Assert.That(result.Contains(votingId.ToString()), Is.True);
            Assert.That(result.Contains(professionalCode.Number), Is.True);
            Assert.That(result.Contains(restaurantCode.Number), Is.True);
        }

        [Test]
        [Category("Entities")]
        public void DoisVotosComMesmoIdDevemSerIguais()
        {
            // Arrange
            var professionalCode = new Code("PROF001");
            var restaurantCode = new Code("REST001");
            var votingId = Guid.NewGuid();
            var vote1 = new Vote(professionalCode, restaurantCode, votingId);
            var vote2 = vote1;

            // Act & Assert
            Assert.That(vote1.Equals(vote2), Is.True);
        }

        [Test]
        [Category("Entities")]
        public void DoisVotosComIdsDiferentesNaoDevemSerIguais()
        {
            // Arrange
            var professionalCode = new Code("PROF001");
            var restaurantCode = new Code("REST001");
            var votingId = Guid.NewGuid();
            var vote1 = new Vote(professionalCode, restaurantCode, votingId);
            var vote2 = new Vote(professionalCode, restaurantCode, votingId);

            // Act & Assert
            Assert.That(vote1.Equals(vote2), Is.False);
        }
    }
}
