using NikEp.Auth.Domain.ValueObjects;

namespace NikEp.Auth.Domain.Entities
{
    public class User
    {
        public Email Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public Name Name { get; set; }
        public DateTime BirthDate { get; set; }
        public PhoneNumber PhoneNumber { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? LoggedinAt { get; set; }
        private Id Id { get; set; }
        

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

