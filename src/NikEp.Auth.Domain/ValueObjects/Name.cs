using FluentValidation;
using System.Text.RegularExpressions;

namespace NikEp.Auth.Domain.ValueObjects;

public class NameValidator : Validator<Name>
{
    public const int MinimumLength = 2;
    public const int MaximumLength = 80;
    public static int MaximumStoreLength => MaximumLength + Name.StringSeparator.Length + MaximumLength;
    private static Regex regex = new(@"^[A-Za-z]+$");

    public NameValidator()
    {
        RulesFor(name => name.FirstName, FirstNameRules);
        RulesFor(name => name.LastName, LastNameRules);
    }

    public static IRuleBuilderOptions<T, string> FirstNameRules<T>(IRuleBuilder<T, string> ruleBuilder) => ruleBuilder
        .NotEmpty()
        .MinimumLength(MinimumLength)
        .MaximumLength(MaximumLength)
        .Matches(regex);
    public static IRuleBuilderOptions<T, string> LastNameRules<T>(IRuleBuilder<T, string> ruleBuilder) => ruleBuilder
        .NotEmpty()
        .MinimumLength(MinimumLength)
        .MaximumLength(MaximumLength)
        .Matches(regex);
}

public record Name : ValueObject<Name, NameValidator>
{
    public const string StringSeparator = "|";

    public Name(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
        
        Validator.ValidateAndThrow(this);
    }
    
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string FullName => $"{FirstName} {LastName}";

    public static implicit operator Name(string value)
    {
        var data = value.Split(StringSeparator, StringSplitOptions.RemoveEmptyEntries);
        if (data.Length != 2)
            throw new FormatException($"Invalid name format: {value}");
        
        return new Name(data[0], data[1]);
    }
    
    public static implicit operator string(Name value)
    {
        return $"{value.FirstName}{StringSeparator}{value.LastName}";
    }
}