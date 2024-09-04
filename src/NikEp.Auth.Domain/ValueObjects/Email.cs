using System.Text.RegularExpressions;

namespace NikEp.Auth.Domain.ValueObjects
{
    public record Email
    {
        public string Value { get; private set; }
        public Email(string value)
        {
            var regex = new Regex(@"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*" + "@"
                + @"((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$");

            if (String.IsNullOrEmpty(value))
                throw new ArgumentException("Emty Email");
            if (!regex.IsMatch(value.Trim()))
                throw new ArgumentException("Not a valid email");

            Value = value;
        }
    }
}

        
