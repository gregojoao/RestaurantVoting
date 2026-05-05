using Voting.Domain.Commands;
using NUnit.Framework;

namespace Voting.Domain.Tests.Commands
{
    public class AddHungryProfessionalCommandTests
    {
        private AddHungryProfessionalCommand _addHungryProfessionalCommandInvalid;
        private AddHungryProfessionalCommand _addHungryProfessionalCommandValid;

        [SetUp]
        public void Setup()
        {
            _addHungryProfessionalCommandInvalid = new AddHungryProfessionalCommand();

            const string hungryProfessionalName = "João";
            const string hungryProfessionalPassword = "123!@#";
            _addHungryProfessionalCommandValid =
                new AddHungryProfessionalCommand(hungryProfessionalName, hungryProfessionalPassword);
        }

        [Test]
        [Category("Commands")]
        public void DadoUmComandoInvalidoORetornoDeveSerInvalido()
        {
            _addHungryProfessionalCommandInvalid.Validate();
            Assert.That(_addHungryProfessionalCommandInvalid.IsValid, Is.False);
        }

        [Test]
        [Category("Commands")]
        public void DadoUmComandoValidoORetornoDeveSerValido()
        {
            _addHungryProfessionalCommandValid.Validate();
            Assert.That(_addHungryProfessionalCommandValid.IsValid, Is.True);
        }
    }
}