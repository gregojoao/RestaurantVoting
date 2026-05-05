namespace Voting.Domain.Entities.ValueObjects
{
    public class Code
    {
        public Code()
        {
            Number = string.Empty;
        }

        public Code(string number)
        {
            Number = number ?? string.Empty;
        }

        public string Number { get; private set; }
    }
}