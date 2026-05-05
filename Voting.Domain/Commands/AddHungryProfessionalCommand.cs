using Flunt.Notifications;
using Flunt.Validations;
using Voting.Domain.Commands.Contracts;

namespace Voting.Domain.Commands
{
    public class AddHungryProfessionalCommand : Notifiable<Notification>, ICommand
    {
        public AddHungryProfessionalCommand()
        {
            HungryProfessionalName = string.Empty;
            HungryProfessionalPassword = string.Empty;
        }
        
        public AddHungryProfessionalCommand(string hungryProfessionalName, string hungryProfessionalPassword)
        {
            HungryProfessionalName = hungryProfessionalName;
            HungryProfessionalPassword = hungryProfessionalPassword;
        }

        public string HungryProfessionalName { get; set; }
        public string HungryProfessionalPassword { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract<Notification>()
                    .Requires()
                    .IsNotNullOrEmpty(HungryProfessionalName, "HungryProfessionalName",
                        "Nome do profissional não pode ser vazio.")
                    .IsGreaterOrEqualsThan(HungryProfessionalName, 2, "HungryProfessionalName",
                        "Nome do profissional deve conter pelo menos 2 caracteres.")
                    .IsNotNullOrEmpty(HungryProfessionalPassword, "HungryProfessionalPassword",
                        "Senha do profissional não pode ser vazia.")
                    .IsGreaterOrEqualsThan(HungryProfessionalPassword, 6, "HungryProfessionalPassword",
                        "Senha do profissional deve conter pelo menos 6 caracteres."));
        }
    }
}