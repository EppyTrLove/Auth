using NikEp.Auth.Domain.ValueObjects;

namespace NikEp.Auth.Domain.Entities
{
    public class User
    {
        private Id Id { get; }
        
        public Name Name { get; }
        public Email Email { get; }
        public PhoneNumber PhoneNumber { get; }
        public string Password { get; }
        
        public DateTime BirthDate { get; }
        public DateTime CreatedAt { get; }
        public DateTime? LoggedinAt { get; }
        

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

