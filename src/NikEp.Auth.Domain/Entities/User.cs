using NikEp.Auth.Domain.ValueObjects;

namespace NikEp.Auth.Domain.Entities
{
    public class User
    {
        public Email Email { get; }
        public string Password { get; }
        public string ConfirmPassword { get; }
        public Name Name { get; }
        public DateTime BirthDate { get; }
        public PhoneNumber PhoneNumber { get; }
        public DateTime CreatedAt { get; }
        public DateTime? LoggedinAt { get; }
        private Id Id { get; }
        

        public User(Email email, string password, Name name, DateTime birthDate,
            PhoneNumber phoneNumber, Id id)
        {
            Email = email;
            if (Enumerable.Range(3, 10).Contains(password.Length))
            {
                Password = password;
            }
            else throw new ArgumentException("Wrong password. Please, try again.");
            Name = name;
            BirthDate = birthDate;
            PhoneNumber = phoneNumber;
            CreatedAt = DateTime.UtcNow;
            Id = id;
        }
    }
}

