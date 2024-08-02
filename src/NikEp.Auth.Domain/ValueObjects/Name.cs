using System.Text.RegularExpressions;

namespace NikEp.Auth.Domain.ValueObjects
{
    public record Name
    {
        public string Value { get; private set; }
        private Name(string value) 
        {
            Value = value;
        }

        public static (bool IsSucsess, string Message, Name Value) Create(string value)
        {
            Regex regex = new Regex(@"^[А-ЯЁ][а-яё]+ [А-ЯЁ][а-яё]+$");
            if (String.IsNullOrEmpty(value)) 
                return (false, "You entered an empty name", null);
            if(!regex.IsMatch(value.Trim())) 
                return (false, "It is allowed to specify letters of English or Russian " +
                    "languages and numbers", null);

            return (true, "Successfully", new Name(value));
        }
    }
}
