using System.Text.RegularExpressions;


namespace NikEp.Auth.Domain.ValueObjects
{

    public record PhoneNumber
    { 
        public string Number { get; }
        public PhoneNumber(string number)
        {
            Number = number;
        }
        private const string phoneRegex = @"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$";
        public static PhoneNumber Create(string number)
        {
            if (number != null & Regex.IsMatch(number, phoneRegex)) return new PhoneNumber(number);

            else throw new ArgumentException();
        }
    }
}
