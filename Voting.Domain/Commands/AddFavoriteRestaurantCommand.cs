using Voting.Domain.Commands.Contracts;
using Flunt.Notifications;
using Flunt.Validations;

namespace Voting.Domain.Commands
{
    public class AddFavoriteRestaurantCommand : Notifiable<Notification>, ICommand
    {
        public AddFavoriteRestaurantCommand()
        {
            FavoriteRestaurantName = string.Empty;
        }

        public AddFavoriteRestaurantCommand(string favoriteRestaurantName)
        {
            FavoriteRestaurantName = favoriteRestaurantName;
        }

        public string FavoriteRestaurantName { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract<Notification>()
                    .Requires()
                    .IsNotNullOrEmpty(FavoriteRestaurantName, "FavoriteRestaurantName",
                        "Nome do restaurante não pode ser vazio.")
                    .IsGreaterOrEqualsThan(FavoriteRestaurantName, 2, "FavoriteRestaurantName",
                        "Nome do restaurante deve conter pelo menos 2 caracteres."));
        }
    }
}