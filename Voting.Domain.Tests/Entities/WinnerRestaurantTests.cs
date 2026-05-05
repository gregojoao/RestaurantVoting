using System;
using NUnit.Framework;
using Voting.Domain.Entities;
using Voting.Domain.Entities.ValueObjects;

namespace Voting.Domain.Tests.Entities
{
    [TestFixture]
    public class WinnerRestaurantTests
    {
        [Test]
        [Category("Entities")]
        public void DadoUmRestauranteVencedorValidoDeveSerCriadoComSucesso()
        {
            // Arrange
            var code = new Code("REST001");
            var favoriteRestaurant = new FavoriteRestaurant(code, "Restaurante Italiano");
            var votingId = Guid.NewGuid();

            // Act
            var winner = new WinnerRestaurant(favoriteRestaurant, votingId);

            // Assert
            Assert.That(winner, Is.Not.Null);
            Assert.That(winner.FavoriteRestaurant, Is.EqualTo(favoriteRestaurant));
            Assert.That(winner.IdRestaurantVoting, Is.EqualTo(votingId));
            Assert.That(winner.Id, Is.Not.Null);
            Assert.That(winner.VictoryDate, Is.Not.Null);
        }

        [Test]
        [Category("Entities")]
        public void DadoUmRestauranteVencedorDeveRetornarToStringCorreto()
        {
            // Arrange
            var code = new Code("REST001");
            var favoriteRestaurant = new FavoriteRestaurant(code, "Restaurante Italiano");
            var votingId = Guid.NewGuid();
            var winner = new WinnerRestaurant(favoriteRestaurant, votingId);

            // Act
            var result = winner.ToString();

            // Assert
            Assert.That(result.Contains(votingId.ToString()), Is.True);
            Assert.That(result.Contains("Restaurante Italiano"), Is.True);
        }

        [Test]
        [Category("Entities")]
        public void DoisRestaurantesVencedoresComMesmoIdDevemSerIguais()
        {
            // Arrange
            var code = new Code("REST001");
            var favoriteRestaurant = new FavoriteRestaurant(code, "Restaurante");
            var votingId = Guid.NewGuid();
            var winner1 = new WinnerRestaurant(favoriteRestaurant, votingId);
            var winner2 = winner1;

            // Act & Assert
            Assert.That(winner1.Equals(winner2), Is.True);
        }

        [Test]
        [Category("Entities")]
        public void DoisRestaurantesVencedoresComIdsDiferentesNaoDevemSerIguais()
        {
            // Arrange
            var code = new Code("REST001");
            var favoriteRestaurant = new FavoriteRestaurant(code, "Restaurante");
            var votingId = Guid.NewGuid();
            var winner1 = new WinnerRestaurant(favoriteRestaurant, votingId);
            var winner2 = new WinnerRestaurant(favoriteRestaurant, votingId);

            // Act & Assert
            Assert.That(winner1.Equals(winner2), Is.False);
        }
    }
}
