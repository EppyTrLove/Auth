using FluentValidation;
using NikEp.Auth.Domain.ValueObjects;

namespace NikEp.Auth.Domain.Entities;

public class UserValidator : Validator<User>
{
    public UserValidator()
    {
        RulesFor(name => name.Name, new NameValidator());
    }
}

public class User : Entity<User, UserValidator>
{
    public User(Name name, Email email, PhoneNumber phoneNumber)
    {   
        Name = name;
        Email = email;
        PhoneNumber = phoneNumber;

        Validator.ValidateAndThrow(this);
    }
    
    protected User(Guid id, Name name, Email email, PhoneNumber phoneNumber) : base(id)
    {
        Name = name;
        Email = email;
        PhoneNumber = phoneNumber;
    }

    public Name Name { get; set; }
    public Email Email { get; set; }
    public PhoneNumber PhoneNumber { get; set; }
}