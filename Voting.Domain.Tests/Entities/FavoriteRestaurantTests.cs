using NUnit.Framework;
using Voting.Domain.Entities;
using Voting.Domain.Entities.ValueObjects;

namespace Voting.Domain.Tests.Entities
{
    [TestFixture]
    public class FavoriteRestaurantTests
    {
        [Test]
        [Category("Entities")]
        public void DadoUmRestauranteFavoritoValidoDeveSerCriadoComSucesso()
        {
            // Arrange
            var code = new Code("REST001");
            var name = "Restaurante Italiano";

            // Act
            var restaurant = new FavoriteRestaurant(code, name);

            // Assert
            Assert.That(restaurant, Is.Not.Null);
            Assert.That(restaurant.Code, Is.EqualTo(code));
            Assert.That(restaurant.Name, Is.EqualTo(name));
            Assert.That(restaurant.Id, Is.Not.Null);
        }

        [Test]
        [Category("Entities")]
        public void DadoUmRestauranteFavoritoDeveRetornarToStringCorreto()
        {
            // Arrange
            var code = new Code("REST001");
            var name = "Restaurante Italiano";
            var restaurant = new FavoriteRestaurant(code, name);

            // Act
            var result = restaurant.ToString();

            // Assert
            Assert.That(result.Contains(name), Is.True);
            Assert.That(result.Contains(code.Number), Is.True);
        }

        [Test]
        [Category("Entities")]
        public void DoisRestaurantesComMesmoIdDevemSerIguais()
        {
            // Arrange
            var code = new Code("REST001");
            var restaurant1 = new FavoriteRestaurant(code, "Restaurante 1");
            var restaurant2 = restaurant1;

            // Act & Assert
            Assert.That(restaurant1.Equals(restaurant2), Is.True);
        }

        [Test]
        [Category("Entities")]
        public void DoisRestaurantesComIdsFerentesNaoDevemSerIguais()
        {
            // Arrange
            var code1 = new Code("REST001");
            var code2 = new Code("REST002");
            var restaurant1 = new FavoriteRestaurant(code1, "Restaurante 1");
            var restaurant2 = new FavoriteRestaurant(code2, "Restaurante 2");

            // Act & Assert
            Assert.That(restaurant1.Equals(restaurant2), Is.False);
        }
    }
}
