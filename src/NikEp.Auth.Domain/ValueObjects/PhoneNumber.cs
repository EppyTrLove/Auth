using System.Text.RegularExpressions;


namespace NikEp.Auth.Domain.ValueObjects
{

    public record PhoneNumber
    {
        public string Value { get; private set; }
        public PhoneNumber(string value)
        {
            var regex = new Regex(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$");
            if (value == null || !regex.IsMatch(value.Trim()))
                throw new ArgumentException();

            Value = value;
        }
    }
}
