using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NikEp.Auth.Domain.Entities;
using NikEp.Auth.Domain.ValueObjects;

namespace NikEp.Auth.Persistence.Configurations;


public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasIndex(x => x.Email).IsUnique();

        builder.Property(x => x.Name)
            .HasMaxLength(NameValidator.MaximumStoreLength)
            .HasConversion(x => (string)x, x => x);
        builder.Property(x => x.Email)
            .HasMaxLength(EmailValidator.MaximumLength)
            .HasConversion(x => x._email, x => new Email(x));
        builder.Property(x => x.PhoneNumber)
            .HasMaxLength(PhoneNumberValidator.MaximumLength)
            .HasConversion(x => x._phoneNumber, x => new PhoneNumber(x));
    }
}