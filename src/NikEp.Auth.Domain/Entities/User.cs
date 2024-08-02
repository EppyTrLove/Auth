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
            // Checks
            if (password.Length < 3 || password.Length > 10)
                throw new ArgumentException("Wrong password. Please, try again.");

            Email = email;
            Password = password;
            Name = name;
            BirthDate = birthDate;
            PhoneNumber = phoneNumber;
            CreatedAt = DateTime.UtcNow;
            Id = id;
            
            // Return
            //...
        }
    }
}

