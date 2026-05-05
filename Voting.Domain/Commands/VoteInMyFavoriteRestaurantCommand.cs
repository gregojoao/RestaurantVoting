using Voting.Domain.Commands.Contracts;
using Flunt.Notifications;
using Flunt.Validations;

namespace Voting.Domain.Commands
{
    public class VoteInMyFavoriteRestaurantCommand : Notifiable<Notification>, ICommand
    {
        public VoteInMyFavoriteRestaurantCommand()
        {
            HungryProfessionalCode = string.Empty;
            FavoriteRestaurantCode = string.Empty;
        }

        public VoteInMyFavoriteRestaurantCommand(string hungryProfessionalCode, string favoriteRestaurantCode)
        {
            HungryProfessionalCode = hungryProfessionalCode;
            FavoriteRestaurantCode = favoriteRestaurantCode;
        }

        public string HungryProfessionalCode { get; set; }
        public string FavoriteRestaurantCode { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract<Notification>()
                    .Requires()
                    .IsNotNullOrEmpty(HungryProfessionalCode, "HungryProfessionalCode",
                        "Código do profissional não pode ser vazio.")
                    .IsGreaterOrEqualsThan(HungryProfessionalCode, 6, "HungryProfessionalCode",
                        "Código deve conter pelo menos 6 caracteres.")
                    .IsNotNullOrEmpty(FavoriteRestaurantCode, "FavoriteRestaurantCode",
                        "Código do restaurante não pode ser vazio.")
                    .IsGreaterOrEqualsThan(FavoriteRestaurantCode, 4, "FavoriteRestaurantCode",
                        "Código deve conter pelo menos 4 caracteres."));
        }
    }
}