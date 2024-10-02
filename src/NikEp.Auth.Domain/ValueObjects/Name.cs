using System.Text.RegularExpressions;

namespace NikEp.Auth.Domain.ValueObjects
{
    public record Name
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public Name(string firstName, string lastName) 
        {
            var regex = new Regex(@"/^([а-яё\s]+|[a-z\s]+)$/iu");
            if (String.IsNullOrEmpty(firstName) || String.IsNullOrEmpty(lastName))
                throw new ArgumentException("You entered an empty name");
            if(!regex.IsMatch(firstName.Trim()) || !regex.IsMatch(lastName.Trim()))
                throw new ArgumentException("It is allowed to specify letters of English or Russian " +
                                             "languages and numbers");
            
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
