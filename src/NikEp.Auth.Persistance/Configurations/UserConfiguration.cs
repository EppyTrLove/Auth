using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NikEp.Auth.Domain.Entities;
using NikEp.Auth.Domain.ValueObjects;

namespace NikEp.Auth.Persistence.Configurations;


public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name)
            .HasMaxLength(NameValidator.MaximumStoreLength)
            .HasConversion(x => (string)x, x => x);
    }
}