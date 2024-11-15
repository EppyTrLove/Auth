using FluentValidation;
using System.Text.RegularExpressions;


namespace NikEp.Auth.Domain.ValueObjects
{

        public class PhoneNumberValidator : Validator<PhoneNumber>
        {
            public const int MinimumLength = 5;
            public const int MaximumLength = 40;
            private static Regex regex = new(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$");

            public PhoneNumberValidator()
            {
                RulesFor(phoneNumber => phoneNumber._phoneNumber, PhoneNumberRules);
            }

        public static IRuleBuilderOptions<T, string> PhoneNumberRules<T>(IRuleBuilder<T, string> ruleBuilder) =>
        ruleBuilder
            .NotEmpty()
            .MinimumLength(MinimumLength)
            .MaximumLength(MaximumLength)
            .Matches(regex);
        }

        public record PhoneNumber : ValueObject<PhoneNumber, PhoneNumberValidator>
        {

            public PhoneNumber(string phoneNumber)
            {
                _phoneNumber = phoneNumber;
                Validator.ValidateAndThrow(this);
            }

            public string _phoneNumber { get; private set; }
        }
 }
