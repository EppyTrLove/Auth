using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

using NikEp.Auth.Domain.ValueObjects;

namespace NikEp.Auth.Domain.Entities
{
    internal class User
    {
        public User(string email, string password, Name name,
            PhoneNumber phoneNumber, Guid id, DateTime createdAt)
        {
            Email = email;
            Password = password;
            Name = name;
            PhoneNumber = phoneNumber;
            CreatedAt = createdAt;
            Id = id;
        }

        [Required(ErrorMessage = "Email required")]
        [RegularExpression(@"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*" + "@"
            + @"((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$", ErrorMessage = "Not a valid email")]
        [DisplayName("Login")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password required")]
        [StringLength(10, MinimumLength = 3, ErrorMessage = "Wrong password. Please, try again.")]
        [DisplayName("Password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Password required")]
        [Compare("Password", ErrorMessage = "Passwords don't match")]
        public string ConfirmPassword { get; set; }

        [Required]
        public Name Name { get; set; }

        [Required]
        public Age Age { get; set; }

        [Required]
        public PhoneNumber PhoneNumber { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LoggedinAt { get; set; }

        private Guid Id { get; set; }
    }
}

