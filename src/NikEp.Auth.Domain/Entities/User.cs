using NikEp.Auth.Domain.ValueObjects;
using System.Xml.Linq;

namespace NikEp.Auth.Domain.Entities
{
    public class User
    {
        public Guid Id { get; }

        public Name Name { get; }
        public Email Email { get; }
        public PhoneNumber PhoneNumber { get; }
        public string Password { get; }
        
        public DateTime BirthDate { get; }
        public DateTime CreatedAt { get; }
        public DateTime? LoggedinAt { get; }

        protected User(Guid id, string firstName, string lastName, string email, string phoneNumber, DateTime birthDate,
            DateTime createdAt, string password)
        {
            Id = id;
            Name = new Name(firstName, lastName);
            Email = new Email(email);
            PhoneNumber = new PhoneNumber(phoneNumber);
            BirthDate = birthDate;
            CreatedAt = createdAt;
            Password = password;
        }
            public User(Name name, Email email, PhoneNumber phoneNumber, DateTime birthDate, string password)
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
            
            // Return
            //...
        }
    }
}

