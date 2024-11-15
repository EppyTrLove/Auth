using FluentValidation;
using System.Text.RegularExpressions;

namespace NikEp.Auth.Domain.ValueObjects
{
    public class EmailValidator : Validator<Email>
    {
        public const int MinimumLength = 2;
        public const int MaximumLength = 30;
        private static Regex regex = new(@"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*" + "@"
                + @"((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$");

        public EmailValidator()
        {
            RulesFor(email => email._email, EmailRules);
        }

        public static IRuleBuilderOptions<T, string> EmailRules<T>(IRuleBuilder<T, string> ruleBuilder) => ruleBuilder
            .NotEmpty()
            .MinimumLength(MinimumLength)
            .MaximumLength(MaximumLength);
           // .Matches(regex);
    }

    public record Email : ValueObject<Email, EmailValidator>
    {
        public Email(string email)
        {
            _email = email;
           Validator.ValidateAndThrow(this);
        }

        public string _email { get; private set; }
    }
}

 